using System.Windows.Forms;
using System.Collections.Generic;
using HuiruiSoft.Win32;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     public partial class formAccountManager : Form
     {
          private int lockTimerMaximum = 0;
          private int lockGlobalMaximum = 0;
          private int lastInputTime = int.MaxValue;
          private long lockAtInputTicks = long.MaxValue;
          private long lockAtGlobalTicks = long.MaxValue;

          public void NotifyUserActivity( )
          {
               if(this.lockTimerMaximum < 30)
               {
                    this.lockAtInputTicks = long.MaxValue;
               }
               else
               {
                    var tmpUtcLockAt = System.DateTime.UtcNow;
                    tmpUtcLockAt = tmpUtcLockAt.AddSeconds(this.lockTimerMaximum);
                    this.lockAtInputTicks = tmpUtcLockAt.Ticks;
               }

               if (this.lockGlobalMaximum < 30)
               {
                    this.lockAtGlobalTicks = long.MaxValue;
               }
               else
               {
                    var tmpGlobalLockAt = System.DateTime.UtcNow;
                    tmpGlobalLockAt = tmpGlobalLockAt.AddSeconds(this.lockGlobalMaximum);
                    this.lockAtGlobalTicks = tmpGlobalLockAt.Ticks;
               }
          }

          internal void SetStatusText(string statusText)
          {
               this.statusPartMessage.Text = statusText != null ? statusText : statusReady;
          }

          private void UpdateGlobalLockTimeout(System.DateTime currentTime)
          {
               var tmpLockGlobal = Program.Config.Application.Security.LockWorkspace.LockGlobalTime;
               if(tmpLockGlobal <= 0)
               {
                    this.lockAtGlobalTicks = long.MaxValue;
               }
               else
               {
                    var tmpLastInputTime = NativeMethods.GetLastInputTime( );
                    if(tmpLastInputTime.HasValue && tmpLastInputTime.Value != this.lastInputTime)
                    {
                         var tmpUtcLockAt = currentTime.AddSeconds(tmpLockGlobal);
                         this.lockAtGlobalTicks = tmpUtcLockAt.Ticks;
                         this.lastInputTime = tmpLastInputTime.Value;
                    }
               }
          }

          private AccountModel GetCurrentSelectedEntry( )
          {
               AccountModel tmpAccountInfo = null;

               var tmpActivePosition = this.dataGridAccount.Selection.ActivePosition;
               if (tmpActivePosition.Row > 0 && this.dataGridAccount.SelectedDataRows.Length > 0)
               {
                    var tmpCurrentDataRow = this.dataGridAccount.SelectedDataRows[0] as System.Data.DataRowView;
                    if (tmpCurrentDataRow != null)
                    {
                         int tmpAccountId;
                         if (int.TryParse(string.Format("{0}", tmpCurrentDataRow[Account_Column_AccountId]), out tmpAccountId))
                         {
                              tmpAccountInfo = this.allAccountEntries.Find(delegate (AccountModel item)
                              {
                                   return item.AccountId == tmpAccountId;
                              });
                         }
                    }
               }

               return tmpAccountInfo;
          }

          private void LoadAccountEntries()
          {
               this.allAccountEntries = this.accountService.GetAccountInfosWithAttributes();
          }

          private void GetCatalogChildAccounts(bool forceRefresh)
          {
               this.accountDataTable.BeginLoadData();
               this.accountDataTable.Rows.Clear();

               if (forceRefresh || this.allAccountEntries == null)
               {
                    this.LoadAccountEntries();
               }

               var tmpSelectedNode = this.treeViewCatalog.SelectedNode;
               if (tmpSelectedNode != null && this.allAccountEntries != null)
               {
                    Cursor.Current = Cursors.WaitCursor;

                    IList<AccountModel> tmpAccountModels = null;

                    if (tmpSelectedNode == this.recycleBinTreeNode)
                    {
                         tmpAccountModels = this.accountService.GetDeletedAccounts();
                    }
                    else if (tmpSelectedNode.Tag is AccountCatalog)
                    {
                         var tmpAccountCatalog = (AccountCatalog)(tmpSelectedNode.Tag);
                         tmpAccountModels = this.allAccountEntries.FindAll(delegate (AccountModel item)
                         {
                              return !item.Deleted && item.CatalogId == tmpAccountCatalog.CatalogId;
                         });
                    }

                    if (tmpAccountModels != null)
                    {
                         this.FillAccountDataGrid(tmpAccountModels);
                    }

                    Cursor.Current = Cursors.Default;
               }

               this.accountDataTable.EndLoadData();
          }

          private void GetCatalogChildAccounts(AccountCatalog catalog)
          {
               this.accountDataTable.BeginLoadData( );
               this.accountDataTable.Rows.Clear( );

               if(catalog != null)
               {
                    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                    var tmpAccountModels = this.allAccountEntries.FindAll(delegate (AccountModel item)
                    {
                         return item.CatalogId == catalog.CatalogId;
                    });

                    if(tmpAccountModels != null)
                    {
                         this.FillAccountDataGrid(tmpAccountModels);
                    }

                    Cursor.Current = System.Windows.Forms.Cursors.Default;
               }

               this.accountDataTable.EndLoadData( );
          }

          private void OpenPasswordBuilder( )
          {
               var tmpPasswordBuilder = new formPasswordBuilder( );
               var tmpDialogResult = tmpPasswordBuilder.ShowDialog( );
               if (tmpDialogResult == DialogResult.OK)
               {
                    //
               }
               tmpPasswordBuilder.Dispose( );
          }


          private formLockWindow lockMaskWindow;

          private void OpenLockWindow( )
          {
               if(this.lockMaskWindow == null)
               {
                    this.lockMaskWindow = new formLockWindow( );
               }
               else if(!this.lockMaskWindow.Visible)
               {
                    if (this.lockMaskWindow.IsDisposed)
                    {
                         this.lockMaskWindow.Dispose();
                         this.lockMaskWindow = null;
                    }

                    this.lockMaskWindow = new formLockWindow();
               }

               if(this.lockMaskWindow != null && !this.lockMaskWindow.Visible)
               {
                    this.Hide( );
                    this.lockMaskWindow.ClearPassword();
                    if(this.lockMaskWindow.ShowDialog(this) == DialogResult.OK)
                    {
                         this.Show();
                         this.Activate( );
                         GlobalWindowManager.ShowAllWindows();
                    }
                    else
                    {
                         //this.idleTickTimer.Stop( );
                         //this.idleTickTimer.Enabled = false;
                         System.Windows.Forms.Application.Exit( );
                    }
               }
          }

          private DialogResult OpenCatalogCreator( )
          {
               var tmpSelectTreeNode = this.treeViewCatalog.SelectedNode;

               AccountCatalog tmpParentCatalog = null;
               if(tmpSelectTreeNode != null && (tmpSelectTreeNode.Tag is AccountCatalog))
               {
                    tmpParentCatalog = (AccountCatalog)(tmpSelectTreeNode.Tag);
               }

               var tmpCatalogCreator = new formCatalogCreator(tmpParentCatalog);
               var tmpDialogResult = tmpCatalogCreator.ShowDialog( );
               if(tmpDialogResult == DialogResult.OK)
               {
                    if(tmpCatalogCreator.NewCatalog != null)
                    {
                         var tmpNewCatalog = (AccountCatalog)tmpCatalogCreator.NewCatalog.Clone( );

                         var tmpNewCatalogTreeNode = new TreeNode( );
                         tmpNewCatalogTreeNode.Text = tmpNewCatalog.Name;
                         tmpNewCatalogTreeNode.ImageIndex = tmpNewCatalogTreeNode.SelectedImageIndex = 0;
                         tmpNewCatalogTreeNode.Tag = tmpNewCatalog;

                         if(tmpSelectTreeNode == null)
                         {
                              this.treeViewCatalog.Nodes.Add(tmpNewCatalogTreeNode);
                         }
                         else
                         {
                              tmpSelectTreeNode.Nodes.Add(tmpNewCatalogTreeNode);
                              tmpSelectTreeNode.ExpandAll( );
                         }
                    }
               }

               tmpCatalogCreator.Dispose( );

               return tmpDialogResult;
          }

          private void OpenCatalogViewer(AccountCatalog catalogItem)
          {
               if(catalogItem != null)
               {
                    var tmpCatalogViewer = new formCatalogViewer(catalogItem);
                    tmpCatalogViewer.ShowDialog( );
                    tmpCatalogViewer.Dispose( );
               }
          }

          private DialogResult OpenCatalogEditor( )
          {
               var tmpDialogResult = DialogResult.None;

               var tmpSelectTreeNode = this.treeViewCatalog.SelectedNode;
               if(tmpSelectTreeNode != null && (tmpSelectTreeNode.Tag is AccountCatalog))
               {
                    var tmpCurrentCatalog = (AccountCatalog)(tmpSelectTreeNode.Tag);

                    var tmpCatalogEditor = new formCatalogEditor(tmpCurrentCatalog);
                    tmpDialogResult = tmpCatalogEditor.ShowDialog( );
                    tmpCatalogEditor.Dispose( );
               }

               return tmpDialogResult;
          }

          private void DeleteCatalog( )
          {
               var tmpSelectedNode = this.treeViewCatalog.SelectedNode;
               if(tmpSelectedNode != null)
               {
                    if(tmpSelectedNode.Nodes.Count > 0)
                    {
                         MessageBox.Show(string.Format(SafePassResource.DeleteSelectedCatalogErrorForNotEmpty, tmpSelectedNode.Text), SafePassResource.DeletePermanentlySelectedCatalogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }
                    else if(tmpSelectedNode.Tag is AccountCatalog)
                    {
                         if(this.DeleteCatalog((AccountCatalog)(tmpSelectedNode.Tag)))
                         {
                              tmpSelectedNode.Remove( );
                         }
                    }
               }
          }

          private bool DeleteCatalog(AccountCatalog catalogItem)
          {
               if (catalogItem != null)
               {
                    var tmpMessageBoxTitle = SafePassResource.DeletePermanentlySelectedCatalogTitle;

                    var tmpCatalogService = new HuiruiSoft.Safe.Service.CatalogService();
                    if (tmpCatalogService.GetChildCatalogCount(catalogItem.CatalogId) > 0)
                    {
                         MessageBox.Show(string.Format(SafePassResource.DeleteSelectedCatalogErrorForNotEmpty, catalogItem.Name), tmpMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return false;
                    }

                    var tmpAccountService = new HuiruiSoft.Safe.Service.AccountService();
                    if (tmpAccountService.GetBelongAccountCount(catalogItem.CatalogId) > 0)
                    {
                         MessageBox.Show(string.Format(SafePassResource.DeleteSelectedCatalogErrorForNotEmpty, catalogItem.Name), tmpMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return false;
                    }
                    else
                    {
                         var tmpMessageBoxPrompt = SafePassResource.DeletePermanentlySelectedCatalogQuestion;
                         if (MessageBox.Show(string.Format(tmpMessageBoxPrompt, catalogItem.Name), tmpMessageBoxTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                         {
                              return tmpCatalogService.Delete(catalogItem);
                         }
                    }
               }

               return false;
          }

          private void OpenAccountCreator( )
          {
               var tmpSelectedNode = this.treeViewCatalog.SelectedNode;
               if(tmpSelectedNode != null && (tmpSelectedNode.Tag is AccountCatalog))
               {
                    var tmpCurrentCatalog = (AccountCatalog)(tmpSelectedNode.Tag);

                    var tmpAccountCreator = new formAccountCreator(tmpCurrentCatalog);
                    var tmpDialogResult = tmpAccountCreator.ShowDialog( );
                    if(tmpDialogResult == DialogResult.OK)
                    {
                         this.LoadAccountEntries();
                         this.GetCatalogChildAccounts(tmpCurrentCatalog);
                    }
                    tmpAccountCreator.Dispose( );
               }
          }

          private void OpenAccountViewer( )
          {
               var tmpCurrentEntry = this.GetCurrentSelectedEntry();
               if (tmpCurrentEntry != null)
               {
                    var tmpAccountViewer = new formAccountViewer(tmpCurrentEntry);
                    var tmpDialogResult = tmpAccountViewer.ShowDialog();
                    tmpAccountViewer.Dispose();
               }
          }

          private void OpenAccountEditor()
          {
               var tmpCurrentEntry = this.GetCurrentSelectedEntry();
               if (tmpCurrentEntry != null)
               {
                    var tmpAccountEditor = new formAccountEditor(tmpCurrentEntry);
                    var tmpDialogResult = tmpAccountEditor.ShowDialog();
                    if (tmpDialogResult == DialogResult.OK)
                    {
                         var tmpSelectedNode = this.treeViewCatalog.SelectedNode;
                         if (tmpSelectedNode != null && (tmpSelectedNode.Tag is AccountCatalog))
                         {
                              this.LoadAccountEntries();
                              this.GetCatalogChildAccounts((AccountCatalog)(tmpSelectedNode.Tag));
                         }
                    }
                    tmpAccountEditor.Dispose();
               }
          }

          private void MoveAccountTo( )
          {
               var tmpCatalogSelector = new formCatalogSelector(this.treeViewCatalog.Nodes);
               tmpCatalogSelector.SelectedNode = this.treeViewCatalog.SelectedNode;
               var tmpDialogResult = tmpCatalogSelector.ShowDialog( );
               if(tmpDialogResult == DialogResult.OK)
               {
                    var tmpSelectedCount = this.dataGridAccount.SelectedDataRows.Length;
                    if(tmpSelectedCount > 0)
                    {
                         var tmpAccountIds = new List<int>(tmpSelectedCount);

                         for(var index = 0; index < tmpSelectedCount; index++)
                         {
                              var tmpCurrentDataRow = this.dataGridAccount.SelectedDataRows[index] as System.Data.DataRowView;
                              if(tmpCurrentDataRow != null)
                              {
                                   if(tmpCurrentDataRow[Account_Column_AccountId] != System.DBNull.Value)
                                   {
                                        tmpAccountIds.Add((int)tmpCurrentDataRow[Account_Column_AccountId]);
                                   }
                              }
                         }

                         if(tmpAccountIds.Count > 0)
                         {
                              bool tmpUpdateResult;
                              if (tmpCatalogSelector.CatalogId == null)
                              {
                                   tmpUpdateResult = this.accountService.MoveToRecycleBin(tmpAccountIds);
                              }
                              else
                              {
                                   tmpUpdateResult = this.accountService.MoveToCatalog(tmpAccountIds, tmpCatalogSelector.CatalogId.Value);
                              }

                              if(tmpUpdateResult)
                              {
                                   this.GetCatalogChildAccounts(true);
                              }
                         }
                    }
               }
          }

          private void SetAccountTopLevel( )
          {
               var tmpSelectedCount = this.dataGridAccount.SelectedDataRows.Length;
               if(tmpSelectedCount > 0)
               {
                    var tmpAccountIds = new List<int>(tmpSelectedCount);

                    int tmpToplevel = int.MinValue;
                    for(var index = 0; index < tmpSelectedCount; index++)
                    {
                         var tmpCurrentDataRow = this.dataGridAccount.SelectedDataRows[index] as System.Data.DataRowView;
                         if(tmpCurrentDataRow != null)
                         {
                              if(tmpCurrentDataRow[Account_Column_AccountId] != System.DBNull.Value)
                              {
                                   tmpAccountIds.Add((int)tmpCurrentDataRow[Account_Column_AccountId]);
                              }

                              if(tmpToplevel == int.MinValue)
                              {
                                   if(tmpCurrentDataRow[Account_Column_TopMost] != System.DBNull.Value)
                                   {
                                        tmpToplevel = (short)tmpCurrentDataRow[Account_Column_TopMost];
                                   }
                              }
                         }
                    }

                    if(tmpAccountIds.Count > 0)
                    {
                         bool tmpUpdateResult;
                         if (tmpToplevel <= 0)
                         {
                              tmpUpdateResult = this.accountService.SetTopMost(tmpAccountIds);
                         }
                         else
                         {
                              tmpUpdateResult = this.accountService.CancelTopMost(tmpAccountIds);
                         }

                         if(tmpUpdateResult)
                         {
                              this.GetCatalogChildAccounts(true);
                         }
                    }
               }
          }

          private void DeleteAccounts( )
          {
               if (this.dataGridAccount.SelectedDataRows.Length > 0)
               {
                    var tmpSelectedCount = this.dataGridAccount.SelectedDataRows.Length;
                    if (tmpSelectedCount <= 0)
                    {
                         return;
                    }

                    var tmpMessageBoxTitle = tmpSelectedCount == 1 ? SafePassResource.DeletePermanentlySelectedEntryTitle : SafePassResource.DeletePermanentlySelectedEntriesTitle;
                    var tmpMessageBoxPrompt = tmpSelectedCount == 1 ? SafePassResource.DeletePermanentlySelectedEntryQuestion : SafePassResource.DeletePermanentlySelectedEntriesQuestion;

                    var tmpDeletePrompt = new System.Text.StringBuilder();
                    tmpDeletePrompt.AppendFormat("{0}{1}{2}{2}", tmpMessageBoxPrompt, new string((char)32, 30), System.Environment.NewLine);

                    const int MaxPromptCount = 10;
                    int tmpPromptCount = 0;
                    var tmpAccountIds = new List<int>(tmpSelectedCount);
                    for (var index = 0; index < tmpSelectedCount; index++)
                    {
                         var tmpCurrentDataRow = this.dataGridAccount.SelectedDataRows[index] as System.Data.DataRowView;
                         if (tmpCurrentDataRow != null)
                         {
                              if (tmpCurrentDataRow[Account_Column_AccountId] != System.DBNull.Value)
                              {
                                   tmpAccountIds.Add((int)tmpCurrentDataRow[Account_Column_AccountId]);
                              }

                              tmpPromptCount++;
                              if (tmpPromptCount <= MaxPromptCount)
                              {
                                   if (tmpPromptCount == 1)
                                   {
                                        tmpDeletePrompt.AppendFormat("{0}", tmpCurrentDataRow[Account_Column_Name]);
                                   }
                                   else
                                   {
                                        tmpDeletePrompt.AppendFormat("{0}{1}", System.Environment.NewLine, tmpCurrentDataRow[Account_Column_Name]);
                                   }
                              }
                         }
                    }

                    if (tmpAccountIds.Count > 0)
                    {
                         if (tmpAccountIds.Count > MaxPromptCount)
                         {
                              tmpDeletePrompt.AppendFormat(SafePassResource.DeleteSelectedEntriesMorePrompt, System.Environment.NewLine, tmpAccountIds.Count - MaxPromptCount);
                         }

                         if (MessageBox.Show(tmpDeletePrompt.ToString(), tmpMessageBoxTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                         {
                              var tmpDeleteResult = this.accountService.DeleteOutrightAccounts(tmpAccountIds);
                              if (tmpDeleteResult)
                              {
                                   this.GetCatalogChildAccounts(true);
                              }
                         }
                    }
               }
          }

          private void RestoreFromRecycleBin( )
          {
               if(this.recycleBinTreeNode == this.treeViewCatalog.SelectedNode)
               {
                    var tmpSelectedCount = this.dataGridAccount.SelectedDataRows.Length;
                    if(tmpSelectedCount > 0)
                    {
                         var tmpAccountIds = new List<int>(tmpSelectedCount);
                         for(var index = 0; index < tmpSelectedCount; index++)
                         {
                              var tmpCurrentDataRow = this.dataGridAccount.SelectedDataRows[index] as System.Data.DataRowView;
                              if(tmpCurrentDataRow != null)
                              {
                                   if(tmpCurrentDataRow[Account_Column_AccountId] != System.DBNull.Value)
                                   {
                                        tmpAccountIds.Add((int)tmpCurrentDataRow[Account_Column_AccountId]);
                                   }
                              }
                         }

                         if(tmpAccountIds.Count > 0)
                         {
                              var tmpExecuteResult = this.accountService.RestoreFromRecycleBin(tmpAccountIds);
                              if(tmpExecuteResult)
                              {
                                   this.GetCatalogChildAccounts(true);
                              }
                         }
                    }
               }
          }

          private void OpenSystemOptionDialog( )
          {
               var tmpOptionsWindow = new formSystemOptions( );
               if (tmpOptionsWindow.ShowDialog(this) == DialogResult.OK)
               {
                    var tmpSecurityConfig = Program.Config.Application.Security;
                    this.lockTimerMaximum = (int)tmpSecurityConfig.LockWorkspace.LockAfterTime;
                    this.lockGlobalMaximum = (int)tmpSecurityConfig.LockWorkspace.LockGlobalTime;
                    this.NotifyUserActivity( );

                    this.SecretCellRank0.BackColor = tmpSecurityConfig.SecretRank.Rank0BackColor;
                    this.SecretCellRank1.BackColor = tmpSecurityConfig.SecretRank.Rank1BackColor;
                    this.SecretCellRank2.BackColor = tmpSecurityConfig.SecretRank.Rank2BackColor;
                    this.SecretCellRank3.BackColor = tmpSecurityConfig.SecretRank.Rank3BackColor;

                    this.dataGridAccount.Refresh( );
               }
          }

          /// <summary>
          /// 
          /// </summary>
          /// <param name="setModified"></param>
          private void UpdateControlState(bool setModified = false)
          {
               var tmpSelectedNode = this.treeViewCatalog.SelectedNode;

               var tmpCatalogSelected = (tmpSelectedNode != null && tmpSelectedNode.Tag is AccountCatalog);
               var tmpRecycleBinSelected = (tmpSelectedNode == this.recycleBinTreeNode);

               this.menuItemCatalogCreate.Enabled = tmpCatalogSelected;
               this.menuItemEntryCreate.Enabled = tmpCatalogSelected;
               this.toolButtonEntryCreate.Enabled = tmpCatalogSelected;

               this.menuItemCatalogEdit.Enabled = tmpCatalogSelected;
               this.menuItemCatalogDelete.Enabled = tmpCatalogSelected;
               this.toolButtonCatalogEdit.Enabled = tmpCatalogSelected;
               this.toolButtonCatalogDelete.Enabled = tmpCatalogSelected;
               this.menuItemAccountTopLevel.Enabled = tmpCatalogSelected;
               this.menuItemSelectAll.Enabled = this.dataGridAccount.Rows.Count > 1;

               var tmpCurrentEntry = this.GetCurrentSelectedEntry();
               var tmpAccountSelected = tmpCurrentEntry != null;
               this.menuItemEntryEdit.Enabled = (tmpCatalogSelected && tmpAccountSelected);
               this.menuItemEntryMoveTo.Enabled = tmpAccountSelected;
               this.menuItemEntryDelete.Enabled = tmpAccountSelected;
               this.toolButtonEntryEdit.Enabled = tmpAccountSelected;
               this.toolButtonEntryDelete.Enabled = tmpAccountSelected;
               this.toolButtonCatalogCreate.Enabled = this.menuItemCatalogCreate.Enabled;

               this.menuItemFileExport.Enabled = this.allAccountEntries != null && this.allAccountEntries.Count > 0;
               this.menuItemCopyMobile.Enabled = tmpCurrentEntry != null && !string.IsNullOrEmpty(tmpCurrentEntry.Mobile);
               this.menuItemCopyEmail.Enabled = tmpCurrentEntry != null && !string.IsNullOrEmpty(tmpCurrentEntry.Email);
               this.menuItemCopyUserName.Enabled = tmpCurrentEntry != null && !string.IsNullOrEmpty(tmpCurrentEntry.LoginName);
               this.menuItemCopyPassword.Enabled = tmpCurrentEntry != null && !string.IsNullOrEmpty(tmpCurrentEntry.Password);

               this.menuItemEmptyRecycleBin.Enabled = tmpRecycleBinSelected;
               this.menuItemRestoreRecycleBin.Visible = tmpRecycleBinSelected;
               this.toolSeparatorRestore.Visible = this.menuItemRestoreRecycleBin.Visible;
               if(tmpRecycleBinSelected)
               {
                    this.menuItemRestoreRecycleBin.Enabled = tmpAccountSelected;
               }

               // this.menuItemViewToolBar.Checked = this.toolBarStrip.Visible;
               // this.menuItemViewStatusBar.Checked = this.stripStatusBar.Visible;

               this.menuItemViewToolBar.Text = this.toolBarStrip.Visible ? SafePassResource.MenuItemViewHideToolBar : SafePassResource.MenuItemViewShowToolBar;
               this.menuItemViewStatusBar.Text = this.stripStatusBar.Visible ? SafePassResource.MenuItemViewHideStatusBar : SafePassResource.MenuItemViewShowStatusBar;

               this.SetStatusText(null);

               if (!tmpAccountSelected)
               {
                    this.menuItemAccountTopLevel.Enabled = false;
               }
               else
               {
                    this.menuItemAccountTopLevel.Enabled = true;

                    var tmpCurrentDataRow = this.dataGridAccount.SelectedDataRows[0] as System.Data.DataRowView;
                    if(tmpCurrentDataRow[Account_Column_TopMost] != System.DBNull.Value)
                    {
                         var tmpToplevel = (short)tmpCurrentDataRow[Account_Column_TopMost];
                         this.menuItemAccountTopLevel.Text = tmpToplevel <= 0 ? SafePassResource.MenuItemEntryTopmost : SafePassResource.MenuItemEntryTopmostCancel;
                    }
               }

               foreach(var tmpLinkedToolItemPair in this.linkedToolStripItems)
               {
                    tmpLinkedToolItemPair.Value.Enabled = tmpLinkedToolItemPair.Key.Enabled;
               }
          }
     }
}