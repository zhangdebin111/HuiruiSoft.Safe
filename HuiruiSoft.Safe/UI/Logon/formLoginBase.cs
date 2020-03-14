using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;
using HuiruiSoft.Data.Configuration;
using HuiruiSoft.Security.Cryptography;

namespace HuiruiSoft.Safe
{
     internal class formLoginBase : System.Windows.Forms.Form
     {
          protected System.Windows.Forms.Button buttonOK;
          protected System.Windows.Forms.Label labelPassword;
          protected System.Windows.Forms.Label labelLoginName;
          protected System.Windows.Forms.GroupBox groupOptions;
          protected System.Windows.Forms.TextBox textPassword;
          protected System.Windows.Forms.TextBox textLoginName;
          protected System.Windows.Forms.Button buttonCancel;
          private System.ComponentModel.IContainer components = null;

          internal formLoginBase()
          {
               this.InitializeComponent();

               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!this.DesignMode)
               {
                    this.MinimizeBox = false;
                    this.MaximizeBox = false;
                    this.AcceptButton = this.buttonOK;
                    this.CancelButton = this.buttonCancel;
                    this.Icon = WindowsUtils.DefaultAppIcon;

                    this.textLoginName.Text = Account.CurrentAccount.UserName;
                    this.textPassword.PasswordChar = '*';
                    this.textPassword.Focus();
               }
          }

          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows 窗体设计器生成的代码

          private void InitializeComponent()
          {
               this.buttonOK = new System.Windows.Forms.Button();
               this.textPassword = new System.Windows.Forms.TextBox();
               this.labelPassword = new System.Windows.Forms.Label();
               this.textLoginName = new System.Windows.Forms.TextBox();
               this.labelLoginName = new System.Windows.Forms.Label();
               this.groupOptions = new System.Windows.Forms.GroupBox();
               this.buttonCancel = new System.Windows.Forms.Button();
               this.groupOptions.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(393, 324);
               this.buttonOK.Margin = new System.Windows.Forms.Padding(6);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(195, 69);
               this.buttonOK.TabIndex = 1;
               this.buttonOK.Text = "&OK";
               this.buttonOK.UseVisualStyleBackColor = true;
               this.buttonOK.Click += new System.EventHandler(this.OnLoginButtonClick);
               // 
               // textPassword
               // 
               this.textPassword.Font = new System.Drawing.Font("宋体", 10F);
               this.textPassword.Location = new System.Drawing.Point(177, 141);
               this.textPassword.Margin = new System.Windows.Forms.Padding(6);
               this.textPassword.Name = "textPassword";
               this.textPassword.PasswordChar = '*';
               this.textPassword.Size = new System.Drawing.Size(490, 30);
               this.textPassword.TabIndex = 3;
               // 
               // labelPassword
               // 
               this.labelPassword.AutoSize = true;
               this.labelPassword.Location = new System.Drawing.Point(44, 148);
               this.labelPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
               this.labelPassword.Name = "labelPassword";
               this.labelPassword.Size = new System.Drawing.Size(89, 18);
               this.labelPassword.TabIndex = 2;
               this.labelPassword.Text = "Password:";
               // 
               // textLoginName
               // 
               this.textLoginName.Font = new System.Drawing.Font("宋体", 10F);
               this.textLoginName.Location = new System.Drawing.Point(177, 51);
               this.textLoginName.Margin = new System.Windows.Forms.Padding(6);
               this.textLoginName.Name = "textLoginName";
               this.textLoginName.Size = new System.Drawing.Size(490, 30);
               this.textLoginName.TabIndex = 1;
               // 
               // labelLoginName
               // 
               this.labelLoginName.AutoSize = true;
               this.labelLoginName.Location = new System.Drawing.Point(44, 58);
               this.labelLoginName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
               this.labelLoginName.Name = "labelLoginName";
               this.labelLoginName.Size = new System.Drawing.Size(107, 18);
               this.labelLoginName.TabIndex = 0;
               this.labelLoginName.Text = "Login Name:";
               // 
               // groupOptions
               // 
               this.groupOptions.Controls.Add(this.textPassword);
               this.groupOptions.Controls.Add(this.labelPassword);
               this.groupOptions.Controls.Add(this.textLoginName);
               this.groupOptions.Controls.Add(this.labelLoginName);
               this.groupOptions.Location = new System.Drawing.Point(63, 44);
               this.groupOptions.Margin = new System.Windows.Forms.Padding(6);
               this.groupOptions.Name = "groupOptions";
               this.groupOptions.Padding = new System.Windows.Forms.Padding(6);
               this.groupOptions.Size = new System.Drawing.Size(762, 242);
               this.groupOptions.TabIndex = 0;
               this.groupOptions.TabStop = false;
               this.groupOptions.Text = "Login options";
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(630, 324);
               this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(195, 69);
               this.buttonCancel.TabIndex = 2;
               this.buttonCancel.Text = "&Cancel";
               this.buttonCancel.UseVisualStyleBackColor = true;
               this.buttonCancel.Click += new System.EventHandler(this.OnCloseButtonClick);
               // 
               // formLoginBase
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(902, 438);
               this.Controls.Add(this.buttonCancel);
               this.Controls.Add(this.groupOptions);
               this.Controls.Add(this.buttonOK);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formLoginBase";
               this.Text = "Login";
               this.groupOptions.ResumeLayout(false);
               this.groupOptions.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion

          protected virtual void OnLoginButtonClick(object sender, System.EventArgs args)
          {
               string tmpPassword = this.textPassword.Text.Trim();
               if (string.IsNullOrEmpty(tmpPassword))
               {
                    this.textPassword.Focus();
               }
               else
               {
                    bool tmpCheckResult = this.CheckValidity();
                    if (tmpCheckResult)
                    {
                         this.DialogResult = DialogResult.OK;
                    }
               }
          }

          protected virtual void OnCloseButtonClick(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          protected virtual bool CheckValidity()
          {
               var tmpUserName = this.textLoginName.Text.Trim();
               var tmpPassword = this.textPassword.Text.Trim();

               var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;

               if (string.IsNullOrEmpty(tmpUserName))
               {
                    this.textLoginName.Focus();
                    MessageBox.Show(SafePassResource.LoginWindowPromptUserNameIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }
               else if (string.IsNullOrEmpty(tmpPassword))
               {
                    this.textPassword.Focus();
                    MessageBox.Show(SafePassResource.LoginWindowPromptPasswordIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }

               if (tmpUserName != Account.CurrentAccount.UserName)
               {
                    this.textLoginName.Focus();
                    MessageBox.Show(SafePassResource.LoginWindowPromptUserNameNonExistent, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }

               var tmpPasswordMd5 = Md5DigestHelper.Md5Salt(tmpPassword, tmpUserName);
               var tmpPwdEncrypted = EncryptorHelper.DESEncrypt(Account.CurrentAccount.SecretKey, tmpPasswordMd5);
               if (tmpPwdEncrypted == Account.CurrentAccount.PasswordStored)
               {
                    Account.CurrentAccount.Password = tmpPassword;
                    DataBaseConfig.Password = tmpPasswordMd5;
                    DataBaseConfig.DataSource = System.IO.Path.Combine(Program.Config.WorkingDirectory, ApplicationDefines.SafePassDbFile);
               }
               else
               {
                    this.textPassword.Focus();
                    MessageBox.Show(SafePassResource.LoginWindowPromptPasswordIncorrect, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }

               return true;
          }
     }
}