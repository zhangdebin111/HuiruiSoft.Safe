using System.Windows.Forms;
using System.Collections.Generic;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formAccountManager : Form
     {
          private SourceGrid.Cells.Cell GridCellTopMost = null;
          private SourceGrid.Cells.Cell GridCellTopNone = null;
          private SourceGrid.Cells.Views.Cell SecretCellRank0 = null;
          private SourceGrid.Cells.Views.Cell SecretCellRank1 = null;
          private SourceGrid.Cells.Views.Cell SecretCellRank2 = null;
          private SourceGrid.Cells.Views.Cell SecretCellRank3 = null;

          private System.Data.DataTable accountDataTable;

          private const string
               Account_Column_Order = "Order",
               Account_Column_AccountId = "AccountId",
               Account_Column_Name = "Name",
               Account_Column_URL = "URL",
               Account_Column_Secret = "Secret",
               Account_Column_TopMost = "TopMost",
               Account_Column_LoginName = "LoginName",
               Account_Column_Email = "Email",
               Account_Column_Mobile = "Mobile",
               Account_Column_CreateTime = "CreateTime",
               Account_Column_UpdateTime = "UpdateTime";

          private void InitializeAccountDataGrid()
          {
               #region InitializeAccountDataGrid

               this.accountDataTable = new System.Data.DataTable();
               this.accountDataTable.Columns.Add(Account_Column_Order, typeof(int));
               this.accountDataTable.Columns.Add(Account_Column_AccountId, typeof(int));
               this.accountDataTable.Columns.Add(Account_Column_TopMost, typeof(short));
               this.accountDataTable.Columns.Add(Account_Column_Name, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_LoginName, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_Secret, typeof(SecretRank));
               this.accountDataTable.Columns.Add(Account_Column_Email, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_Mobile, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_URL, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_CreateTime, typeof(System.DateTime));
               this.accountDataTable.Columns.Add(Account_Column_UpdateTime, typeof(System.DateTime));

               this.dataGridAccount.BorderStyle = BorderStyle.Fixed3D;
               this.dataGridAccount.BackColor = System.Drawing.SystemColors.AppWorkspace;
               this.dataGridAccount.Font = ApplicationDefines.DefaultDataGridCellFont;
               this.dataGridAccount.Rows.RowHeight = 30;
               this.dataGridAccount.Rows.SetHeight(0, 30);
               this.dataGridAccount.SelectionMode = SourceGrid.GridSelectionMode.Cell;
               this.dataGridAccount.Selection.EnableMultiSelection = true;
               this.dataGridAccount.ClipboardMode = SourceGrid.ClipboardMode.All;

               var tmpGridSelection = this.dataGridAccount.Selection as SourceGrid.Selection.SelectionBase;
               if (tmpGridSelection != null)
               {
                    tmpGridSelection.Border = tmpGridSelection.Border.SetColor(System.Drawing.Color.Blue);
                    tmpGridSelection.BackColor = System.Drawing.Color.FromArgb(60, tmpGridSelection.BackColor);
               }

               SourceGrid.DataGridColumn tmpGridColumn;
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Order, SafePassResource.DataGridAccountColumnOrderNo, typeof(int));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_AccountId, SafePassResource.DataGridAccountColumnAccountGuid, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_TopMost, SafePassResource.DataGridAccountColumnTopMost, typeof(short));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Name, SafePassResource.DataGridAccountColumnName, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Secret, SafePassResource.DataGridAccountColumnSecret, typeof(SecretRank));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_LoginName, SafePassResource.DataGridAccountColumnLoginName, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Mobile, SafePassResource.DataGridAccountColumnMobile, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Email, SafePassResource.DataGridAccountColumnEmail, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_CreateTime, SafePassResource.DataGridAccountColumnCreateTime, typeof(System.DateTime));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_UpdateTime, SafePassResource.DataGridAccountColumnUpdateTime, typeof(System.DateTime));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_URL, SafePassResource.DataGridAccountColumnURL, typeof(string));

               var tmpDateTimeFormat = ApplicationDefines.DateTimeFormat;
               var dateTimeParseFormats = new string[] { tmpDateTimeFormat };
               var tmpDateTimeStyles = System.Globalization.DateTimeStyles.AllowInnerWhite | System.Globalization.DateTimeStyles.AllowLeadingWhite | System.Globalization.DateTimeStyles.AllowTrailingWhite | System.Globalization.DateTimeStyles.AllowWhiteSpaces;
               var tmpDateTimeEditor = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(System.DateTime));
               tmpDateTimeEditor.TypeConverter = new DevAge.ComponentModel.Converter.DateTimeTypeConverter(tmpDateTimeFormat, dateTimeParseFormats, tmpDateTimeStyles);

               var tmpDataSource = new DevAge.ComponentModel.BoundDataView(this.accountDataTable.DefaultView);
               tmpDataSource.AllowNew = false;
               tmpDataSource.AllowSort = true;
               this.dataGridAccount.DataSource = tmpDataSource;

               var tmpGridColor = System.Drawing.SystemColors.ActiveBorder;
               var tmpGridBorder = new DevAge.Drawing.RectangleBorder(new DevAge.Drawing.BorderLine(tmpGridColor, 0), new DevAge.Drawing.BorderLine(tmpGridColor));

               var tmpGridLinkCellView = new SourceGrid.Cells.Views.Link();
               tmpGridLinkCellView.Font = ApplicationDefines.DefaultDataGridCellFont;

               var tmpAlignCenterCellView = new SourceGrid.Cells.Views.Cell();
               tmpAlignCenterCellView.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               tmpAlignCenterCellView.Font = ApplicationDefines.DefaultDataGridCellFont;

               var tmpLoginNameCellView = new SourceGrid.Cells.Views.Cell();
               tmpLoginNameCellView.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Regular);

               this.SecretCellRank0 = new SourceGrid.Cells.Views.Cell();
               this.SecretCellRank0.ForeColor = System.Drawing.Color.White;
               this.SecretCellRank0.BackColor = Program.Config.Application.Security.SecretRank.Rank0BackColor;
               this.SecretCellRank0.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               this.SecretCellRank0.Font = ApplicationDefines.DefaultDataGridCellFont;

               this.SecretCellRank1 = new SourceGrid.Cells.Views.Cell();
               this.SecretCellRank1.ForeColor = System.Drawing.Color.White;
               this.SecretCellRank1.BackColor = System.Drawing.Color.Blue;
               this.SecretCellRank1.BackColor = Program.Config.Application.Security.SecretRank.Rank1BackColor;
               this.SecretCellRank1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               this.SecretCellRank1.Font = ApplicationDefines.DefaultDataGridCellFont;

               this.SecretCellRank2 = new SourceGrid.Cells.Views.Cell();
               this.SecretCellRank2.ForeColor = System.Drawing.Color.White;
               this.SecretCellRank2.BackColor = Program.Config.Application.Security.SecretRank.Rank2BackColor;
               this.SecretCellRank2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               this.SecretCellRank2.Font = ApplicationDefines.DefaultDataGridCellFont;

               this.SecretCellRank3 = new SourceGrid.Cells.Views.Cell();
               this.SecretCellRank3.ForeColor = System.Drawing.Color.White;
               this.SecretCellRank3.BackColor = Program.Config.Application.Security.SecretRank.Rank3BackColor;
               this.SecretCellRank3.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               this.SecretCellRank3.Font = ApplicationDefines.DefaultDataGridCellFont;

               var tmpTopMostModel = new SourceGrid.Cells.Views.Cell();
               tmpTopMostModel.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               this.GridCellTopMost = new SourceGrid.Cells.Cell();
               this.GridCellTopMost.View = new SourceGrid.Cells.Views.Cell(tmpTopMostModel);
               this.GridCellTopMost.Image = HuiruiSoft.Safe.Properties.Resources.TopMost;

               this.GridCellTopNone = new SourceGrid.Cells.Cell();
               this.GridCellTopNone.View = new SourceGrid.Cells.Views.Cell(tmpTopMostModel);
               this.GridCellTopNone.Image = HuiruiSoft.Safe.Properties.Resources.TopNone;

               var tmpConditionTopMost = new SourceGrid.Conditions.ConditionCell(this.GridCellTopMost);
               tmpConditionTopMost.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_TopMost] is short && (short)tmpDataRow[Account_Column_TopMost] > 0);
               };

               var tmpConditionTopNone = new SourceGrid.Conditions.ConditionCell(this.GridCellTopNone);
               tmpConditionTopNone.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_TopMost] is short && (short)tmpDataRow[Account_Column_TopMost] <= 0);
               };

               var tmpConditionRank0 = new SourceGrid.Conditions.ConditionView(this.SecretCellRank0);
               tmpConditionRank0.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_Secret] is ushort && (ushort)tmpDataRow[Account_Column_Secret] == (ushort)SecretRank.¹«¿ª);
               };

               var tmpConditionRank1 = new SourceGrid.Conditions.ConditionView(this.SecretCellRank1);
               tmpConditionRank1.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_Secret] is ushort && (ushort)tmpDataRow[Account_Column_Secret] == (ushort)SecretRank.ÃØÃÜ);
               };

               var tmpConditionRank2 = new SourceGrid.Conditions.ConditionView(this.SecretCellRank2);
               tmpConditionRank2.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_Secret] is ushort && (ushort)tmpDataRow[Account_Column_Secret] == (ushort)SecretRank.»úÃÜ);
               };

               var tmpConditionRank3 = new SourceGrid.Conditions.ConditionView(this.SecretCellRank3);
               tmpConditionRank3.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_Secret] is ushort && (ushort)tmpDataRow[Account_Column_Secret] == (ushort)SecretRank.¾øÃÜ);
               };

               for (int index = 0; index < this.dataGridAccount.Columns.Count; index++)
               {
                    var tmpCurrentColumn = this.dataGridAccount.Columns[index];
                    tmpCurrentColumn.HeaderCell.View.Border = tmpGridBorder;
                    tmpCurrentColumn.HeaderCell.View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

                    if (tmpCurrentColumn.DataCell.Editor != null)
                    {
                         tmpCurrentColumn.DataCell.Editor.EnableEdit = false;
                    }

                    switch (tmpCurrentColumn.PropertyName)
                    {
                         case Account_Column_AccountId:
                         case Account_Column_CreateTime:
                              tmpCurrentColumn.Width = 150;
                              tmpCurrentColumn.Visible = false;
                              break;

                         case Account_Column_TopMost:
                              tmpCurrentColumn.Width = 50;
                              tmpCurrentColumn.Conditions.Add(tmpConditionTopNone);
                              tmpCurrentColumn.Conditions.Add(tmpConditionTopMost);
                              break;

                         case Account_Column_Order:
                              tmpCurrentColumn.Width = 50;
                              tmpCurrentColumn.DataCell.View = tmpAlignCenterCellView;
                              break;

                         case Account_Column_Name:
                              tmpCurrentColumn.Width = 175;
                              break;

                         case Account_Column_Secret:
                              tmpCurrentColumn.Width = 80;
                              tmpCurrentColumn.Conditions.Add(tmpConditionRank0);
                              tmpCurrentColumn.Conditions.Add(tmpConditionRank1);
                              tmpCurrentColumn.Conditions.Add(tmpConditionRank2);
                              tmpCurrentColumn.Conditions.Add(tmpConditionRank3);
                              break;

                         case Account_Column_LoginName:
                              tmpCurrentColumn.Width = 200;
                              tmpCurrentColumn.DataCell.View = tmpLoginNameCellView;
                              break;

                         case Account_Column_Mobile:
                              tmpCurrentColumn.Width = 120;
                              tmpCurrentColumn.DataCell.View = tmpAlignCenterCellView;
                              break;

                         case Account_Column_Email:
                              tmpCurrentColumn.Width = 200;
                              break;

                         case Account_Column_URL:
                              tmpCurrentColumn.Width = 270;
                              tmpCurrentColumn.DataCell.View = tmpGridLinkCellView;
                              break;

                         case Account_Column_UpdateTime:
                              tmpCurrentColumn.Width = 156;
                              tmpCurrentColumn.DataCell.Editor = tmpDateTimeEditor;
                              tmpCurrentColumn.DataCell.Editor.EnableEdit = false;
                              tmpCurrentColumn.DataCell.View = tmpAlignCenterCellView;
                              break;
                    }
               }

               #endregion InitializeAccountDataGrid
          }

          private void DataGridLocalization()
          {
               const string FieldName = "m_Value";
               var tmpGridModelType = typeof(SourceGrid.Cells.Models.ValueModel);
               var tmpModelField = tmpGridModelType.GetField(FieldName);
               if (tmpModelField != null)
               {
                    for (int index = 0; index < this.dataGridAccount.Columns.Count; index++)
                    {
                         var tmpCurrentColumn = this.dataGridAccount.Columns[index];
                         switch (tmpCurrentColumn.PropertyName)
                         {
                              case Account_Column_AccountId:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnAccountGuid);
                                   break;

                              case Account_Column_TopMost:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnTopMost);
                                   break;

                              case Account_Column_Order:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnOrderNo);
                                   break;

                              case Account_Column_Name:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnName);
                                   break;

                              case Account_Column_Secret:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnSecret);
                                   break;

                              case Account_Column_LoginName:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnLoginName);
                                   break;

                              case Account_Column_Mobile:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnMobile);
                                   break;

                              case Account_Column_Email:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnEmail);
                                   break;

                              case Account_Column_URL:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnURL);
                                   break;

                              case Account_Column_CreateTime:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnCreateTime);
                                   break;

                              case Account_Column_UpdateTime:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnUpdateTime);
                                   break;
                         }
                    }
               }
          }

          private void FillAccountDataGrid(IList<AccountModel> accountModels)
          {
               if (accountModels != null)
               {
                    int dataRowIndex = 0;
                    foreach (var tmpAccountItem in accountModels)
                    {
                         var tmpNewAccountRow = this.accountDataTable.NewRow();
                         tmpNewAccountRow[Account_Column_Order] = ++dataRowIndex;
                         tmpNewAccountRow[Account_Column_AccountId] = tmpAccountItem.AccountId;
                         tmpNewAccountRow[Account_Column_Name] = tmpAccountItem.Name;
                         tmpNewAccountRow[Account_Column_TopMost] = tmpAccountItem.TopMost;
                         tmpNewAccountRow[Account_Column_Secret] = tmpAccountItem.SecretRank;

                         tmpNewAccountRow[Account_Column_URL] = tmpAccountItem.URL;
                         tmpNewAccountRow[Account_Column_LoginName] = CryptoObfuscateHelper.ObfuscateUserName(tmpAccountItem.LoginName);
                         tmpNewAccountRow[Account_Column_Email] = CryptoObfuscateHelper.ObfuscateMail(tmpAccountItem.Email);
                         tmpNewAccountRow[Account_Column_Mobile] = CryptoObfuscateHelper.ObfuscateMobile(tmpAccountItem.Mobile);
                         tmpNewAccountRow[Account_Column_CreateTime] = tmpAccountItem.CreateTime;
                         tmpNewAccountRow[Account_Column_UpdateTime] = tmpAccountItem.UpdateTime;

                         this.accountDataTable.Rows.Add(tmpNewAccountRow);
                    }
               }
          }

          private void dataGridAccount_MouseDown(object sender, MouseEventArgs args)
          {
               if (args.Button == MouseButtons.Right)
               {
                    var tmpActiveRow = this.dataGridAccount.PositionAtPoint(args.Location).Row;
                    if (!this.dataGridAccount.Selection.IsSelectedRow(tmpActiveRow))
                    {
                         var tmpSelectRange = new SourceGrid.Range(tmpActiveRow, 0, tmpActiveRow, this.dataGridAccount.Columns.Count);
                         this.dataGridAccount.Selection.FocusRow(tmpSelectRange.Start.Row);
                         this.dataGridAccount.Selection.SelectRange(tmpSelectRange, true);
                         this.dataGridAccount.Selection.Invalidate();
                    }
               }
          }

          private void dataGridAccount_MouseUp(object sender, MouseEventArgs args)
          {
               this.NotifyUserActivity();
               this.UpdateControlState(false);
          }

          private void dataGridAccount_DoubleClick(object sender, System.EventArgs args)
          {
               this.RaiseActivateOnEvent();
          }

          private void dataGridAccount_PreviewKeyDown(object sender, PreviewKeyDownEventArgs args)
          {
               if (args.KeyCode == Keys.Enter)
               {
                    this.RaiseActivateOnEvent();
               }
          }

          private void RaiseActivateOnEvent()
          {
               var tmpActivePosition = this.dataGridAccount.Selection.ActivePosition;
               if (tmpActivePosition.Row > 0 && tmpActivePosition.Column >= 0)
               {
                    var tmpCurrentColumn = this.dataGridAccount.Columns[tmpActivePosition.Column];
                    switch (tmpCurrentColumn.PropertyName)
                    {
                         case Account_Column_Name:
                         case Account_Column_Mobile:
                         case Account_Column_Email:
                         case Account_Column_AccountId:
                         case Account_Column_LoginName:
                              this.OpenAccountViewer();
                              break;

                         case Account_Column_URL:
                              var tempCellContext = new SourceGrid.CellContext(this.dataGridAccount, tmpActivePosition);
                              if (tempCellContext.Value != null)
                              {
                                   string url = string.Format("{0}", tempCellContext.Value);
                                   if (!string.IsNullOrEmpty(url))
                                   {
                                        var tmpBrowserProcess = System.Diagnostics.Process.Start(url);
                                   }
                              }
                              break;
                    }
               }
          }
     }
}