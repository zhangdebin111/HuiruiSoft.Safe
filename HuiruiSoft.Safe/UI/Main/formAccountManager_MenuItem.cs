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
          private List<KeyValuePair<ToolStripItem, ToolStripItem>> linkedToolStripItems = null;

          private void InitializeToolBar()
          {
               for (int index = 0; index < this.toolBarStrip.Items.Count; index++)
               {
                    if (this.toolBarStrip.Items[index] is ToolStripButton)
                    {
                         var tmpToolButtonItem = (ToolStripButton)this.toolBarStrip.Items[index];
                         tmpToolButtonItem.Click += new System.EventHandler(this.OnToolButtonItemClicked);
                    }
               }

               this.toolStripSeparator6.Visible = false;
               this.menuItemReArrangePopup.Visible = false; // 功能未实现，暂时隐藏

               this.linkedToolStripItems = new List<KeyValuePair<ToolStripItem, ToolStripItem>>();
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemRefresh, this.OnRefreshMenuItemClick, true);

               this.menuItemEdit.DropDownItems.Insert(0, new ToolStripSeparator());
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemCopyEmail, this.OnCopyEmailMenuItemClick, true);
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemCopyMobile, this.OnCopyMobileMenuItemClick, true);
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemCopyPassword, this.OnCopyPasswordMenuItemClick, true);
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemCopyUserName, this.OnCopyUserNameMenuItemClick, true);

               this.menuItemEdit.DropDownItems.Insert(0, new ToolStripSeparator());
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemSelectAll, this.OnSelectAllMenuItemClick, true);
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemEntryDelete, this.OnDeleteAccountMenuItemClick, true);
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemEntryEdit, this.OnUpdateAccountMenuItemClick, true);
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemEntryCreate, this.OnCreateAccountMenuItemClick, true);

               this.menuItemEdit.DropDownItems.Insert(0, new ToolStripSeparator());
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemCatalogDelete, this.OnDeleteCatalogMenuItemClick, true);
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemCatalogEdit, this.OnUpdateCatalogMenuItemClick, true);
               this.InsertToolStripItem(this.menuItemEdit, this.menuItemCatalogCreate, this.OnCreateCatalogMenuItemClick, true);

               this.SetLocalizedStrings();
               this.AssignMenuItemShortcuts();
          }

          private void AssignMenuItemShortcuts()
          {
               WindowsUtils.AssignShortcut(this.menuItemEntryCreate, Keys.Control | Keys.I);
               WindowsUtils.AssignShortcut(this.menuItemRefresh, Keys.F5);
               WindowsUtils.AssignShortcut(this.menuItemSelectAll, Keys.Control | Keys.A);
               WindowsUtils.AssignShortcut(this.menuItemLockWindow, Keys.Control | Keys.L);
               WindowsUtils.AssignShortcut(this.menuItemLockScreen, Keys.Control | Keys.W);
               WindowsUtils.AssignShortcut(this.menuItemExitWorkspace, Keys.Control | Keys.Q);

               WindowsUtils.AssignShortcut(this.menuItemEntryCreate, Keys.Control | Keys.N);
               WindowsUtils.AssignShortcut(this.menuItemEntryDelete, Keys.Delete);
               WindowsUtils.AssignShortcut(this.menuItemAccountMoveToTop, Keys.Alt | Keys.Home);
               WindowsUtils.AssignShortcut(this.menuItemAccountMoveOneUp, Keys.Alt | Keys.Up);
               WindowsUtils.AssignShortcut(this.menuItemAccountMoveOneDown, Keys.Alt | Keys.Down);
               WindowsUtils.AssignShortcut(this.menuItemAccountMoveToBottom, Keys.Alt | Keys.End);

               WindowsUtils.AssignShortcut(this.menuItemCopyUserName, Keys.Control | Keys.B);
               WindowsUtils.AssignShortcut(this.menuItemCopyPassword, Keys.Control | Keys.P);
          }

          private void SetLocalizedStrings()
          {
               this.menuItemFile.Text = SafePassResource.MenuItemFile;
               this.menuItemEdit.Text = SafePassResource.MenuItemEdit;
               this.menuItemView.Text = SafePassResource.MenuItemView;
               this.menuItemTools.Text = SafePassResource.MenuItemTools;
               this.menuItemHelp.Text = SafePassResource.MenuItemHelp;

               this.menuItemChangePassword.Text = SafePassResource.MenuItemChangePassword;
               this.menuItemFileImport.Text = SafePassResource.MenuItemFileImport;
               this.menuItemFileExport.Text = SafePassResource.MenuItemFileExport;
               this.menuItemLockWindow.Text = SafePassResource.MenuItemLockWindow;
               this.menuItemLockScreen.Text = SafePassResource.MenuItemLockScreen;
               this.menuItemExitWorkspace.Text = SafePassResource.MenuItemExitWorkspace;

               this.menuItemCatalogCreate.Text = SafePassResource.MenuItemCatalogCreate;
               this.menuItemCatalogEdit.Text = SafePassResource.MenuItemCatalogEdit;
               this.menuItemCatalogDelete.Text = SafePassResource.MenuItemCatalogDelete;

               this.menuItemEntryCreate.Text = SafePassResource.MenuItemEntryCreate;
               this.menuItemEntryEdit.Text = SafePassResource.MenuItemEntryEdit;
               this.menuItemEntryDelete.Text = SafePassResource.MenuItemEntryDelete;
               this.menuItemEntryMoveTo.Text = SafePassResource.MenuItemEntryMoveTo;

               this.menuItemRefresh.Text = SafePassResource.ToolButtonDataRefresh;

               this.menuItemCopyUserName.Text = SafePassResource.MenuItemCopyUserName;
               this.menuItemCopyPassword.Text = SafePassResource.MenuItemCopyPassword;
               this.menuItemCopyMobile.Text = SafePassResource.MenuItemCopyMobile;
               this.menuItemCopyEmail.Text = SafePassResource.MenuItemCopyEmail;

               this.menuItemReArrangePopup.Text = SafePassResource.MenuItemReArrangePopup;
               this.menuItemAccountMoveToTop.Text = SafePassResource.MenuItemEntryMoveToTop;
               this.menuItemAccountMoveOneUp.Text = SafePassResource.MenuItemEntryMoveOneUp;
               this.menuItemAccountMoveOneDown.Text = SafePassResource.MenuItemEntryMoveOneDown;
               this.menuItemAccountMoveToBottom.Text = SafePassResource.MenuItemEntryMoveToBottom;

               this.menuItemChangeLanguage.Text = SafePassResource.MenuItemChangeLanguage;
               this.menuItemSelectAll.Text = SafePassResource.MenuItemSelectAll;
               this.menuItemRestoreRecycleBin.Text = SafePassResource.MenuItemRestoreRecycleBin;
               this.menuItemEmptyRecycleBin.Text = SafePassResource.MenuItemEmptyRecycleBin;

               this.menuItemToolsOptions.Text = SafePassResource.MenuItemToolsOptions;
               this.menuItemHelpAbout.Text = SafePassResource.MenuItemHelpAbout;

               this.toolButtonCatalogCreate.Text = SafePassResource.ToolButtonCatalogCreate;
               this.toolButtonCatalogCreate.ToolTipText = SafePassResource.ToolButtonCatalogCreateTips;

               this.toolButtonCatalogEdit.Text = SafePassResource.ToolButtonCatalogEdit;
               this.toolButtonCatalogEdit.ToolTipText = SafePassResource.ToolButtonCatalogEditTips;

               this.toolButtonCatalogDelete.Text = SafePassResource.ToolButtonCatalogDelete;
               this.toolButtonCatalogDelete.ToolTipText = SafePassResource.ToolButtonCatalogDeleteTips;

               this.toolButtonEntryCreate.Text = SafePassResource.ToolButtonEntryCreate;
               this.toolButtonEntryCreate.ToolTipText = SafePassResource.ToolButtonEntryCreateTips;

               this.toolButtonEntryEdit.Text = SafePassResource.ToolButtonEntryEdit;
               this.toolButtonEntryEdit.ToolTipText = SafePassResource.ToolButtonEntryEditTips;

               this.toolButtonEntryDelete.Text = SafePassResource.ToolButtonEntryDelete;
               this.toolButtonEntryDelete.ToolTipText = SafePassResource.ToolButtonEntryDeleteTips;

               this.toolButtonDataRefresh.Text = SafePassResource.ToolButtonDataRefresh;
               this.toolButtonDataRefresh.ToolTipText = SafePassResource.ToolButtonDataRefreshTips;

               this.toolButtonLockWindow.Text = SafePassResource.ToolButtonLockWindow;
               this.toolButtonLockWindow.ToolTipText = SafePassResource.ToolButtonLockWindowTips;

               this.toolButtonLockScreen.Text = SafePassResource.ToolButtonLockScreen;
               this.toolButtonLockScreen.ToolTipText = SafePassResource.ToolButtonLockScreenTips;

               this.toolButtonToolsOptions.Text = SafePassResource.ToolButtonToolsOptions;
               this.toolButtonToolsOptions.ToolTipText = SafePassResource.ToolButtonToolsOptionsTips;

               if (this.recycleBinTreeNode != null)
               {
                    this.recycleBinTreeNode.Text = SafePassResource.RecycleBin;
               }

               if (this.searchResultTreeNode != null)
               {
                    this.searchResultTreeNode.Text = SafePassResource.SearchResult;
               }

               foreach (var tmpLinkedToolItemPair in this.linkedToolStripItems)
               {
                    if (tmpLinkedToolItemPair.Value.Text != tmpLinkedToolItemPair.Key.Text)
                    {
                         tmpLinkedToolItemPair.Value.Text = tmpLinkedToolItemPair.Key.Text;
                    }
               }
               this.DataGridLocalization();
          }

          private ToolStripMenuItem InsertToolStripItem(ToolStripMenuItem toolStripContainer, ToolStripMenuItem toolStripTemplate, System.EventHandler eventHandler, bool permanentlyLinkToTemplate)
          {
               var tmpToolMenuItem = new ToolStripMenuItem(toolStripTemplate.Text, toolStripTemplate.Image);
               tmpToolMenuItem.Click += eventHandler;
               tmpToolMenuItem.ShowShortcutKeys = toolStripTemplate.ShowShortcutKeys;

               var tmpShortcutKeys = toolStripTemplate.ShortcutKeyDisplayString;
               if (!string.IsNullOrEmpty(tmpShortcutKeys))
               {
                    tmpToolMenuItem.ShortcutKeyDisplayString = tmpShortcutKeys;
               }

               if (permanentlyLinkToTemplate)
               {
                    this.linkedToolStripItems.Add(new KeyValuePair<ToolStripItem, ToolStripItem>(toolStripTemplate, tmpToolMenuItem));
               }

               toolStripContainer.DropDownItems.Insert(0, tmpToolMenuItem);

               return tmpToolMenuItem;
          }


          private void OnToolButtonItemClicked(object sender, System.EventArgs args)
          {
               if (sender == this.toolButtonCatalogCreate)
               {
                    this.OpenCatalogCreator();
               }
               else if (sender == this.toolButtonCatalogEdit)
               {
                    this.OpenCatalogEditor();
               }
               else if (sender == this.toolButtonCatalogDelete)
               {
                    this.DeleteCatalog();
               }
               else if (sender == this.toolButtonEntryCreate)
               {
                    this.OpenAccountCreator();
               }
               else if (sender == this.toolButtonEntryEdit)
               {
                    this.OpenAccountEditor();
               }
               else if (sender == this.toolButtonEntryDelete)
               {
                    this.DeleteToRecycleBin();
               }
               else if (sender == this.toolButtonDataRefresh)
               {
                    this.GetCatalogChildAccounts(true);
               }
               else if (sender == this.toolButtonLockWindow)
               {
                    this.OpenLockWindow();
               }
               else if (sender == this.toolButtonLockScreen)
               {
                    NativeMethods.LockWorkStation();
               }
               else if (sender == this.toolButtonToolsOptions)
               {
                    this.OpenSystemOptionDialog();
               }
          }

          private void OnShowToolBarMenuItemClick(object sender, System.EventArgs args)
          {
               this.toolBarStrip.Visible = !this.toolBarStrip.Visible;
               //this.menuItemViewToolBar.Checked = this.toolBarStrip.Visible;
               this.menuItemViewToolBar.Text = this.toolBarStrip.Visible ? SafePassResource.MenuItemViewHideToolBar : SafePassResource.MenuItemViewShowToolBar;
          }

          private void OnShowStatusBarMenuItemClick(object sender, System.EventArgs args)
          {
               this.stripStatusBar.Visible = !this.stripStatusBar.Visible;
               //this.menuItemViewStatusBar.Checked = this.stripStatusBar.Visible;
               this.menuItemViewStatusBar.Text = this.stripStatusBar.Visible ? SafePassResource.MenuItemViewHideStatusBar : SafePassResource.MenuItemViewShowStatusBar;
          }

          private void OnLockWindowMenuItemClick(object sender, System.EventArgs args)
          {
               this.OpenLockWindow();
          }

          private void OnLockScreenMenuItemClick(object sender, System.EventArgs args)
          {
               NativeMethods.LockWorkStation();
          }

          private void OnChangePasswordMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpChangePwdWindow = new formChangePassword();
               var tmpDialogResult = tmpChangePwdWindow.ShowDialog();
               if (tmpDialogResult == DialogResult.OK)
               {
                    //
               }
               tmpChangePwdWindow.Dispose();
          }

          private void OnImportEntryMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpImportWindow = new formImportAccount(this.allAccountEntries);
               var tmpDialogResult = tmpImportWindow.ShowDialog();
               if (tmpDialogResult == DialogResult.OK)
               {
                    this.InitializeTreeView();
                    this.LoadAccountEntries();
               }
               tmpImportWindow.Dispose();
          }

          private void OnExportEntryMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpExportWindow = new formExportAccount(this.treeViewCatalog.Nodes);
               var tmpDialogResult = tmpExportWindow.ShowDialog();
               if (tmpDialogResult == DialogResult.OK)
               {
                    //
               }

               tmpExportWindow.Dispose();
          }

          private void OnExitWorkspaceMenuItemClick(object sender, System.EventArgs args)
          {
               this.NotifyUserActivity();
               this.Close();
               //Application.Exit();
          }

          private void OnCreateCatalogMenuItemClick(object sender, System.EventArgs args)
          {
               this.OpenCatalogCreator();
          }

          private void OnUpdateCatalogMenuItemClick(object sender, System.EventArgs args)
          {
               this.OpenCatalogEditor();
          }

          private void OnDeleteCatalogMenuItemClick(object sender, System.EventArgs args)
          {
               this.DeleteCatalog();
          }

          private void DeleteToRecycleBin()
          {
               if (this.dataGridAccount.SelectedDataRows.Length > 0)
               {
                    var tmpSelectedCount = this.dataGridAccount.SelectedDataRows.Length;
                    if (tmpSelectedCount <= 0)
                    {
                         return;
                    }

                    var tmpMessageBoxTitle = tmpSelectedCount == 1 ? SafePassResource.MoveSelectedEntryToRecycleBinTitle : SafePassResource.MoveSelectedEntriesToRecycleBinTitle;
                    var tmpMessageBoxPrompt = tmpSelectedCount == 1 ? SafePassResource.MoveSelectedEntryToRecycleBinQuestion : SafePassResource.MoveSelectedEntriesToRecycleBinQuestion;

                    var tmpDeletePrompt = new System.Text.StringBuilder();
                    tmpDeletePrompt.AppendFormat("{0}{1}{2}{2}", tmpMessageBoxPrompt, new string((char)32, 50), System.Environment.NewLine);

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
                              var tmpExecuteResult = this.accountService.MoveToRecycleBin(tmpAccountIds);
                              if (tmpExecuteResult)
                              {
                                   this.GetCatalogChildAccounts(true);
                              }
                         }
                    }
               }
          }

          private void OnEmptyRecycleBinMenuItemClick(object sender, System.EventArgs args)
          {
               if (this.treeViewCatalog.SelectedNode == this.recycleBinTreeNode)
               {
                    var tmpDataRowCount = this.accountDataTable.Rows.Count;
                    if (tmpDataRowCount <= 0)
                    {
                         return;
                    }

                    var tmpMessageBoxTitle = tmpDataRowCount == 1 ? SafePassResource.DeletePermanentlySelectedEntryTitle : SafePassResource.DeletePermanentlySelectedEntriesTitle;
                    var tmpMessageBoxPrompt = tmpDataRowCount == 1 ? SafePassResource.DeletePermanentlySelectedEntryQuestion : SafePassResource.DeletePermanentlySelectedEntriesQuestion;

                    var tmpPromptBuilder = new System.Text.StringBuilder();
                    tmpPromptBuilder.AppendFormat("{0}{1}{2}{2}", tmpMessageBoxPrompt, new string((char)32, 50), System.Environment.NewLine);

                    int tmpPromptCount = 0;
                    const int MaxPromptCount = 10;
                    for (var index = 0; index < tmpDataRowCount; index++)
                    {
                         var tmpCurrentDataRow = this.accountDataTable.Rows[index];
                         if (tmpCurrentDataRow != null)
                         {
                              tmpPromptCount++;
                              if (tmpPromptCount == 1)
                              {
                                   tmpPromptBuilder.AppendFormat("{0}", tmpCurrentDataRow[Account_Column_Name]);
                              }
                              else
                              {
                                   tmpPromptBuilder.AppendFormat("{0}{1}", System.Environment.NewLine, tmpCurrentDataRow[Account_Column_Name]);
                              }

                              if (tmpPromptCount > MaxPromptCount)
                              {
                                   break;
                              }
                         }
                    }

                    if (tmpDataRowCount > MaxPromptCount)
                    {
                         tmpPromptBuilder.AppendFormat(SafePassResource.DeleteSelectedEntriesMorePrompt, System.Environment.NewLine, tmpDataRowCount - MaxPromptCount);
                    }

                    if (MessageBox.Show(tmpPromptBuilder.ToString(), tmpMessageBoxTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                         var tmpExecuteResult = this.accountService.EmptyRecycleBin();
                         if (tmpExecuteResult)
                         {
                              this.GetCatalogChildAccounts(true);
                         }
                    }
               }
          }

          private void OnRestoreRecycleBinMenuItemClick(object sender, System.EventArgs args)
          {
               this.RestoreFromRecycleBin();
          }

          private void OnCreateAccountMenuItemClick(object sender, System.EventArgs args)
          {
               this.OpenAccountCreator();
          }

          private void OnUpdateAccountMenuItemClick(object sender, System.EventArgs args)
          {
               this.OpenAccountEditor();
          }

          private void OnDeleteAccountMenuItemClick(object sender, System.EventArgs args)
          {
               if (this.treeViewCatalog.SelectedNode == this.recycleBinTreeNode)
               {
                    this.DeleteAccounts();
               }
               else
               {
                    bool tmpShiftPressed = ((Control.ModifierKeys & Keys.Shift) != Keys.None);
                    if (tmpShiftPressed)
                    {
                         this.DeleteAccounts();
                    }
                    else
                    {
                         this.DeleteToRecycleBin();
                    }
               }
          }

          private void OnMoveAccountMenuItemClick(object sender, System.EventArgs args)
          {
               this.MoveAccountTo();
          }

          private void OnAccountSetTopLevelMenuItemClick(object sender, System.EventArgs args)
          {
               this.SetAccountTopLevel();
          }

          private void OnAccountMoveToTopMenuItemClick(object sender, System.EventArgs args)
          {
               //
          }

          private void OnAccountMoveToBottomMenuItemClick(object sender, System.EventArgs args)
          {
               //
          }

          private void OnAccountMoveUpMenuItemClick(object sender, System.EventArgs args)
          {
               //
          }

          private void OnAccountMoveDownMenuItemClick(object sender, System.EventArgs args)
          {
               //
          }

          private void OnCopyUserNameMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpCurrentEntry = this.GetCurrentSelectedEntry();
               if (tmpCurrentEntry != null)
               {
                    if (tmpCurrentEntry.LoginName != null)
                    {
                         ClipboardHelper.Copy(tmpCurrentEntry.LoginName);
                         this.StartClipboardCountDown();
                    }
               }
          }

          private void OnCopyPasswordMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpCurrentEntry = this.GetCurrentSelectedEntry();
               if (tmpCurrentEntry != null)
               {
                    if (tmpCurrentEntry.Password != null)
                    {
                         ClipboardHelper.Copy(tmpCurrentEntry.Password);
                         this.StartClipboardCountDown();
                    }
               }
          }

          private void OnCopyMobileMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpCurrentEntry = this.GetCurrentSelectedEntry();
               if (tmpCurrentEntry != null)
               {
                    if (tmpCurrentEntry.Mobile != null)
                    {
                         ClipboardHelper.Copy(tmpCurrentEntry.Mobile);
                         this.StartClipboardCountDown();
                    }
               }
          }

          private void OnCopyEmailMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpCurrentEntry = this.GetCurrentSelectedEntry();
               if (tmpCurrentEntry != null)
               {
                    if (tmpCurrentEntry.Email != null)
                    {
                         ClipboardHelper.Copy(tmpCurrentEntry.Email);
                         this.StartClipboardCountDown();
                    }
               }
          }

          private void OnRefreshMenuItemClick(object sender, System.EventArgs args)
          {
               this.GetCatalogChildAccounts(true);
          }

          private void OnChangeLanguageMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpLanguageWindow = new formSelectLanguage();
               var tmpDialogResult = tmpLanguageWindow.ShowDialog();
               if (tmpDialogResult == DialogResult.OK)
               {
                    this.restartApplication = true;
                    this.OnExitWorkspaceMenuItemClick(sender, new System.EventArgs());
               }
               tmpLanguageWindow.Dispose();
          }

          private void OnSelectAllMenuItemClick(object sender, System.EventArgs args)
          {
               if (this.dataGridAccount.Rows.Count > 1)
               {
                    var tmpSelectRange = new SourceGrid.Range(1, 1, this.dataGridAccount.Rows.Count, this.dataGridAccount.Columns.Count);
                    this.dataGridAccount.Selection.SelectRange(tmpSelectRange, true);
                    this.dataGridAccount.Selection.Invalidate();
               }
          }

          private void OnSystemOptionMenuItemClick(object sender, System.EventArgs args)
          {
               this.OpenSystemOptionDialog();
          }

          private void OnHelpAboutMenuItemClick(object sender, System.EventArgs args)
          {
               var tmpAboutWindow = new formHelpAbout();
               tmpAboutWindow.ShowDialog();
               tmpAboutWindow.Dispose();
          }

          private bool   quickFindBlockFlags = false;
          private object quickFindSyncObject = new object();
          private int    lastQuickSearchTick = System.Environment.TickCount - 1500;
          private string lastQuickSearchText = string.Empty;

          private delegate void PerformQuickFindDelegate(string search, bool forceShowExpired, bool respectEntrySearchDisabled);


          private void PerformQuickFind(string search, bool forceShowExpired, bool respectEntrySearchDisabled)
          {
               Cursor.Current = Cursors.WaitCursor;

               var tmpAccountModels = this.allAccountEntries.FindAll(delegate (AccountModel item)
               {
                    return (!string.IsNullOrEmpty(item.Name) && item.Name.Contains(search)) ||
                           (!string.IsNullOrEmpty(item.URL) && item.URL.Contains(search)) ||
                           (!string.IsNullOrEmpty(item.LoginName) && item.LoginName.Contains(search)) ||
                           (!string.IsNullOrEmpty(item.Email) && item.Email.Contains(search)) ||
                           (!string.IsNullOrEmpty(item.Mobile) && item.Mobile.Contains(search)) ||
                           (!string.IsNullOrEmpty(item.Comment) && item.Comment.Contains(search));
               });

               if (tmpAccountModels != null)
               {
                    if (!this.treeViewCatalog.Nodes.Contains(this.searchResultTreeNode))
                    {
                         this.treeViewCatalog.Nodes.Add(this.searchResultTreeNode);
                    }

                    this.treeViewCatalog.SelectedNode = this.searchResultTreeNode;

                    this.accountDataTable.BeginLoadData();
                    this.accountDataTable.Rows.Clear();
                    this.FillAccountDataGrid(tmpAccountModels);
                    this.accountDataTable.EndLoadData();
               }

               Cursor.Current = Cursors.Default;
          }

          private void OnToolComboBoxQuickFindKeyDown(object sender, KeyEventArgs args)
          {
               if (this.HandleMainWindowKeyMessage(args, true))
               {
                    return;
               }

               bool tempHandled = false;

               if (args.KeyCode == Keys.Return)
               {
                    this.OnToolComboBoxQuickFindSelectedIndexChanged(sender, args);
                    tempHandled = true;
               }

               if (tempHandled)
               {
                    args.Handled = true;
                    args.SuppressKeyPress = true;
               }
          }

          private void OnToolComboBoxQuickFindKeyUp(object sender, KeyEventArgs args)
          {
               if (this.HandleMainWindowKeyMessage(args, false))
               {
                    return;
               }

               bool tempHandled = false;

               if (args.KeyCode == Keys.Return)
               {
                    tempHandled = true;
               }

               if (tempHandled)
               {
                    args.Handled = true;
                    args.SuppressKeyPress = true;
               }
          }


          private void OnToolComboBoxQuickFindSelectedIndexChanged(object sender, System.EventArgs args)
          {
               if (this.quickFindBlockFlags)
               {
                    return;
               }

               this.quickFindBlockFlags = true;

               string tmpSearchText = this.toolComboBoxQuickFind.Text;

               lock (this.quickFindSyncObject)
               {
                    int tmpNowTicks = System.Environment.TickCount;
                    if (tmpNowTicks - this.lastQuickSearchTick <= 1000 && tmpSearchText == this.lastQuickSearchText)
                    {
                         this.quickFindBlockFlags = false;
                         return;
                    }

                    this.lastQuickSearchTick = tmpNowTicks;
                    this.lastQuickSearchText = tmpSearchText;
               }

               int tmpExistsAlready = -1;
               for (int index = 0; index < this.toolComboBoxQuickFind.Items.Count; ++index)
               {
                    string tmpItemText = (string)this.toolComboBoxQuickFind.Items[index];
                    if (tmpItemText.Equals(tmpSearchText, System.StringComparison.OrdinalIgnoreCase))
                    {
                         tmpExistsAlready = index;
                         break;
                    }
               }

               if (tmpExistsAlready >= 0)
               {
                    this.toolComboBoxQuickFind.Items.RemoveAt(tmpExistsAlready);
               }
               else if (this.toolComboBoxQuickFind.Items.Count >= 8)
               {
                    this.toolComboBoxQuickFind.Items.RemoveAt(this.toolComboBoxQuickFind.Items.Count - 1);
               }

               this.toolComboBoxQuickFind.Items.Insert(0, tmpSearchText);
               this.toolComboBoxQuickFind.SelectedIndex = 0;
               this.toolComboBoxQuickFind.Select(0, tmpSearchText.Length);
               this.BeginInvoke(new PerformQuickFindDelegate(this.PerformQuickFind), tmpSearchText, false, true);

               this.quickFindBlockFlags = false;
          }
     }
}