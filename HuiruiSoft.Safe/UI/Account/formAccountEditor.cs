
using System.Windows.Forms;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formAccountEditor : formAccountBase
     {
          private AccountModel currentAccount;

          internal formAccountEditor(AccountModel account) : base()
          {
               this.currentAccount = account;

               this.buttonOK.Visible = true;
               this.CancelButton = this.buttonCancel;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Text = SafePassResource.AccountEditorCaption;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonClose;
               }

               if (this.currentAccount != null)
               {
                    this.textName.Text = this.currentAccount.Name;
                    this.textLoginName.Text = this.currentAccount.LoginName;
                    this.textPassword.Text = this.currentAccount.Password;
                    this.textURL.Text = this.currentAccount.URL;
                    this.textEmail.Text = this.currentAccount.Email;
                    this.textMobile.Text = this.currentAccount.Mobile;
                    this.textComment.Text = this.currentAccount.Comment;

                    switch (this.currentAccount.SecretRank)
                    {
                         case SecretRank.公开:
                              this.radioSecretRank0.Checked = true;
                              break;

                         case SecretRank.秘密:
                              this.radioSecretRank1.Checked = true;
                              break;

                         case SecretRank.机密:
                              this.radioSecretRank2.Checked = true;
                              break;

                         case SecretRank.绝密:
                              this.radioSecretRank3.Checked = true;
                              break;
                    }

                    foreach (var item in this.currentAccount.Attributes)
                    {
                         var tmpNewAttributeRow = this.accountDataTable.NewRow();
                         tmpNewAttributeRow[Account_Column_AccountId] = item.AccountId;
                         tmpNewAttributeRow[Account_Column_Id] = item.AttributeId;
                         tmpNewAttributeRow[Account_Column_Order] = item.Order;
                         tmpNewAttributeRow[Account_Column_Name] = item.Name;
                         tmpNewAttributeRow[Account_Column_Value] = item.Value;
                         tmpNewAttributeRow[Account_Column_Encrypt] = item.Encrypted;

                         this.accountDataTable.Rows.Add(tmpNewAttributeRow);
                    }

                    for (int index = 0; index < this.dataGridAccount.Columns.Count; index++)
                    {
                         var tmpCurrentColumn = this.dataGridAccount.Columns[index];
                         switch (tmpCurrentColumn.Name)
                         {
                              case Account_Column_AccountId:
                              case Account_Column_Id:
                                   tmpCurrentColumn.Visible = false;
                                   break;

                              case Account_Column_Encrypt:
                              case Account_Column_Order:
                              case Account_Column_Name:
                              case Account_Column_Value:
                                   break;
                         }
                    }
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          protected override void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          }

          protected override void buttonOK_Click(object sender, System.EventArgs args)
          {
               if (base.CheckInputValidity())
               {
                    var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;

                    string tmpAccountName = this.textName.Text.Trim();
                    if (string.IsNullOrEmpty(tmpAccountName))
                    {
                         this.textName.Focus();
                         MessageBox.Show(SafePassResource.AccountEditorPromptNameIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }
                    else if (tmpAccountName.Length > 30)  // if(HuiruiSoft.Shared.StringHelper.GetStringByteCount(tmpAccountName) > 30) 
                    {
                         this.textName.Focus();
                         MessageBox.Show(SafePassResource.AccountEditorPromptNameTooLong, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }

                    string tmpComment = this.textComment.Text.Trim();
                    string tmpEmailAddress = this.textEmail.Text.Trim();
                    string tmpMobileNumber = this.textMobile.Text.Trim();

                    this.currentAccount.Name = tmpAccountName;
                    this.currentAccount.URL = this.textURL.Text.Trim();
                    this.currentAccount.LoginName = this.textLoginName.Text.Trim();
                    this.currentAccount.Password = this.textPassword.Text.Trim();
                    this.currentAccount.Email = string.IsNullOrEmpty(tmpEmailAddress) ? null : tmpEmailAddress;
                    this.currentAccount.Mobile = string.IsNullOrEmpty(tmpMobileNumber) ? null : tmpMobileNumber;
                    this.currentAccount.UpdateTime = System.DateTime.Now;
                    this.currentAccount.Comment = string.IsNullOrEmpty(tmpComment) ? null : tmpComment;

                    if (this.radioSecretRank0.Checked)
                    {
                         currentAccount.SecretRank = SecretRank.公开;
                    }
                    else if (this.radioSecretRank1.Checked)
                    {
                         currentAccount.SecretRank = SecretRank.秘密;
                    }
                    else if (this.radioSecretRank2.Checked)
                    {
                         currentAccount.SecretRank = SecretRank.机密;
                    }
                    else if (this.radioSecretRank3.Checked)
                    {
                         currentAccount.SecretRank = SecretRank.绝密;
                    }
                    else
                    {
                         currentAccount.SecretRank = SecretRank.绝密;
                    }

                    this.currentAccount.Attributes.Clear();

                    short order = 0;
                    foreach (System.Data.DataRow tmpCurrentRow in accountDataTable.Rows)
                    {
                         string attributeName = string.Format("{0}", tmpCurrentRow[Account_Column_Name]);
                         string attributeValue = string.Format("{0}", tmpCurrentRow[Account_Column_Value]);

                         if (!string.IsNullOrEmpty(attributeName) && !string.IsNullOrEmpty(attributeValue))
                         {
                              order++;

                              var tmpAttribute = new AccountAttribute();
                              tmpAttribute.AccountId = this.currentAccount.AccountId;

                              int tmpAttributeId = -1;
                              if (tmpCurrentRow[Account_Column_Id] != System.DBNull.Value)
                              {
                                   int.TryParse(string.Format("{0}", tmpCurrentRow[Account_Column_Id]), out tmpAttributeId);
                              }
                              tmpAttribute.AttributeId = tmpAttributeId;

                              tmpAttribute.Order = order;
                              tmpAttribute.Name = attributeName;
                              tmpAttribute.Value = attributeValue;

                              if (tmpCurrentRow[Account_Column_Encrypt] != System.DBNull.Value)
                              {
                                   tmpAttribute.Encrypted = System.Convert.ToBoolean(tmpCurrentRow[Account_Column_Encrypt]);
                              }

                              this.currentAccount.Attributes.Add(tmpAttribute);
                         }
                    }

                    try
                    {
                         Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                         var tmpAccountService = new HuiruiSoft.Safe.Service.AccountService();
                         bool tmpCreateResult = tmpAccountService.UpdateAccount(this.currentAccount);
                         tmpAccountService = null;

                         Cursor.Current = System.Windows.Forms.Cursors.Default;
                         this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    catch (System.Exception exception)
                    {
                         Cursor.Current = System.Windows.Forms.Cursors.Default;
                         MessageBox.Show(string.Format(SafePassResource.AccountEditorDialogMessageUpdateFailed, System.Environment.NewLine, exception.Message), SafePassResource.AccountEditorDialogTitleUpdateFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }
               }
          }
     }
}