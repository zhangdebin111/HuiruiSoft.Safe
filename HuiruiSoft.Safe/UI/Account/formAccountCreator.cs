
using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formAccountCreator : formAccountBase
     {
          private AccountCatalog currentCatalog;
          
          public formAccountCreator(AccountCatalog catalog) : base( )
          {
               this.currentCatalog = catalog;

               this.buttonOK.Visible = true;
               this.CancelButton = this.buttonCancel;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Text = SafePassResource.AccountCreatorCaption;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;
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

          protected override bool CheckInputValidity()
          {
               bool tmpCheckResult = base.CheckInputValidity();
               if (!tmpCheckResult)
               {
                    var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;

                    var tmpAccountName = this.textName.Text.Trim();
                    if (string.IsNullOrEmpty(tmpAccountName))
                    {
                         this.textName.Focus();
                         MessageBox.Show(SafePassResource.AccountEditorPromptNameIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return false;
                    }
                    else if (tmpAccountName.Length > 30)
                    {
                         this.textName.Focus();
                         MessageBox.Show(SafePassResource.AccountEditorPromptNameTooLong, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return false;
                    }

                    if (!string.Equals(this.textPassword.Text, this.textPwdRepeat.Text))
                    {
                         this.textPwdRepeat.Focus();
                         MessageBox.Show(SafePassResource.PasswordRepeatFailed, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return false;
                    }
               }

               return tmpCheckResult;
          }

          protected override void buttonOK_Click(object sender, System.EventArgs args)
          {
               if(this.CheckInputValidity( ))
               {
                    var tmpComment = this.textComment.Text.Trim( );
                    var tmpEmail = this.textEmail.Text.Trim( );
                    var tmpMobile = this.textMobile.Text.Trim( );
                    var tmpHttpUrl = this.textURL.Text.Trim();

                    var tmpAccountInfo = new AccountModel( );
                    tmpAccountInfo.AccountGuid = System.Guid.NewGuid( ).ToString("N");
                    tmpAccountInfo.Name = this.textName.Text.Trim();
                    tmpAccountInfo.LoginName = this.textLoginName.Text.Trim();
                    tmpAccountInfo.Password = this.textPassword.Text.Trim();
                    tmpAccountInfo.Email = string.IsNullOrEmpty(tmpEmail) ? null : tmpEmail;
                    tmpAccountInfo.URL = string.IsNullOrEmpty(tmpHttpUrl) ? null : tmpHttpUrl;
                    tmpAccountInfo.Mobile = string.IsNullOrEmpty(tmpMobile) ? null : tmpMobile;
                    tmpAccountInfo.Comment = string.IsNullOrEmpty(tmpComment) ? null : tmpComment;
                    tmpAccountInfo.CreateTime = System.DateTime.Now;
                    tmpAccountInfo.UpdateTime = System.DateTime.Now;

                    if(this.radioSecretRank0.Checked)
                    {
                         tmpAccountInfo.SecretRank = SecretRank.公开;
                    }
                    else if(this.radioSecretRank1.Checked)
                    {
                         tmpAccountInfo.SecretRank = SecretRank.秘密;
                    }
                    else if(this.radioSecretRank2.Checked)
                    {
                         tmpAccountInfo.SecretRank = SecretRank.机密;
                    }
                    else if(this.radioSecretRank3.Checked)
                    {
                         tmpAccountInfo.SecretRank = SecretRank.绝密;
                    }
                    else
                    {
                         tmpAccountInfo.SecretRank = SecretRank.绝密;
                    }

                    if(this.currentCatalog != null)
                    {
                         tmpAccountInfo.CatalogId = this.currentCatalog.CatalogId;
                    }

                    short order = 0;
                    foreach(System.Data.DataRow tmpCurrentRow in this.accountDataTable.Rows)
                    {
                         var attributeName = string.Format("{0}", tmpCurrentRow[Account_Column_Name]);
                         var attributeValue = string.Format("{0}", tmpCurrentRow[Account_Column_Value]);

                         if(!string.IsNullOrEmpty(attributeName) && !string.IsNullOrEmpty(attributeValue))
                         {
                              var tmpAttribute = new AccountAttribute( );
                              tmpAttribute.AccountId = tmpAccountInfo.AccountId;
                              tmpAttribute.Order = ++order;
                              tmpAttribute.Name = attributeName;
                              tmpAttribute.Value = attributeValue;

                              if(tmpCurrentRow[Account_Column_Encrypt] != System.DBNull.Value)
                              {
                                   tmpAttribute.Encrypted = System.Convert.ToBoolean(tmpCurrentRow[Account_Column_Encrypt]);
                              }

                              tmpAccountInfo.Attributes.Add(tmpAttribute);
                         }
                    }

                    try
                    {
                         Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                         var tmpAccountService = new HuiruiSoft.Safe.Service.AccountService( );
                         bool tmpCreateResult = tmpAccountService.CreateAccount(tmpAccountInfo);
                         tmpAccountService = null;

                         if(tmpCreateResult)
                         {
                              this.textName.Text = "";
                              this.textLoginName.Text = "";
                              this.textMobile.Text = "";
                              this.textURL.Text = "";
                              this.textPassword.Text = "";
                              this.textEmail.Text = "";
                              this.textComment.Text = "";
                              this.accountDataTable.Rows.Clear( );
                         }

                         Cursor.Current = System.Windows.Forms.Cursors.Default;
                         this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    catch(System.Exception exception)
                    {
                         loger.Error(exception);
                         Cursor.Current = System.Windows.Forms.Cursors.Default;
                         MessageBox.Show(string.Format(SafePassResource.AccountEditorDialogMessageCreateFailed, System.Environment.NewLine, exception.Message), SafePassResource.AccountEditorDialogTitleCreateFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }
               }
          }
     }
}