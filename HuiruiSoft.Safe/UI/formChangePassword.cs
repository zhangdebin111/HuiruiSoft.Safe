using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;
using HuiruiSoft.Data.Configuration;
using HuiruiSoft.Security.Cryptography;

namespace HuiruiSoft.Safe
{
     public partial class formChangePassword : System.Windows.Forms.Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.Button buttonBuildPassword;
          private System.Windows.Forms.Button buttonShowPassword;
          private System.Windows.Forms.Label labelOldPassword;
          private System.Windows.Forms.Label labelNewPassword;
          private System.Windows.Forms.Label labelRepeatPassword;
          private System.Windows.Forms.Label labelPasswordQuality;
          private System.Windows.Forms.TextBox textOldPassword;
          private System.Windows.Forms.TextBox textNewPassword;
          private System.Windows.Forms.TextBox textRepeatPassword;
          private HuiruiSoft.UI.Controls.QualityProgressBar qualityProgressBar;

          internal formChangePassword( )
          {
               this.InitializeComponent( );

               this.MinimizeBox = false;
               this.MaximizeBox = false;
               this.ShowInTaskbar = false;
               this.WindowState = FormWindowState.Normal;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.CancelButton = this.buttonCancel;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.ChangePasswordWindowCaption;
                    this.labelOldPassword.Text = SafePassResource.ChangePasswordWindowLabelOldPassword;
                    this.labelNewPassword.Text = SafePassResource.ChangePasswordWindowLabelNewPassword;
                    this.labelRepeatPassword.Text = SafePassResource.ChangePasswordWindowLabelRepeatPassword;
                    this.labelPasswordQuality.Text = SafePassResource.ChangePasswordWindowLabelPasswordQuality;

                    this.textNewPassword.MaxLength = 50;
                    this.textOldPassword.PasswordChar = '*';
                    this.textNewPassword.PasswordChar = '*';
                    this.textRepeatPassword.PasswordChar = '*';
                    this.textOldPassword.ImeMode = ImeMode.Disable;
                    this.textNewPassword.ImeMode = ImeMode.Disable;

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, true);
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          protected override void Dispose(bool disposing)
          {
               if(disposing && (components != null))
               {
                    components.Dispose( );
               }
               base.Dispose(disposing);
          }

          #region Windows 窗体设计器生成的代码

          private void InitializeComponent( )
          {
               this.buttonOK = new System.Windows.Forms.Button();
               this.buttonCancel = new System.Windows.Forms.Button();
               this.buttonBuildPassword = new System.Windows.Forms.Button();
               this.labelRepeatPassword = new System.Windows.Forms.Label();
               this.textRepeatPassword = new System.Windows.Forms.TextBox();
               this.buttonShowPassword = new System.Windows.Forms.Button();
               this.textNewPassword = new System.Windows.Forms.TextBox();
               this.labelNewPassword = new System.Windows.Forms.Label();
               this.textOldPassword = new System.Windows.Forms.TextBox();
               this.labelOldPassword = new System.Windows.Forms.Label();
               this.qualityProgressBar = new HuiruiSoft.UI.Controls.QualityProgressBar();
               this.labelPasswordQuality = new System.Windows.Forms.Label();
               this.SuspendLayout();
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(374, 321);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 49);
               this.buttonOK.TabIndex = 10;
               this.buttonOK.Text = "&OK";
               this.buttonOK.UseVisualStyleBackColor = true;
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(598, 321);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 49);
               this.buttonCancel.TabIndex = 11;
               this.buttonCancel.Text = "&Close";
               this.buttonCancel.UseVisualStyleBackColor = true;
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // buttonBuildPassword
               // 
               this.buttonBuildPassword.Location = new System.Drawing.Point(710, 175);
               this.buttonBuildPassword.Margin = new System.Windows.Forms.Padding(4);
               this.buttonBuildPassword.Name = "buttonBuildPassword";
               this.buttonBuildPassword.Size = new System.Drawing.Size(68, 39);
               this.buttonBuildPassword.TabIndex = 7;
               this.buttonBuildPassword.Text = "...";
               this.buttonBuildPassword.UseVisualStyleBackColor = true;
               this.buttonBuildPassword.Click += new System.EventHandler(this.buttonBuildPassword_Click);
               // 
               // labelRepeatPassword
               // 
               this.labelRepeatPassword.Location = new System.Drawing.Point(27, 181);
               this.labelRepeatPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelRepeatPassword.Name = "labelRepeatPassword";
               this.labelRepeatPassword.Size = new System.Drawing.Size(200, 26);
               this.labelRepeatPassword.TabIndex = 5;
               this.labelRepeatPassword.Text = "Confirm new password:";
               this.labelRepeatPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // textRepeatPassword
               // 
               this.textRepeatPassword.AllowDrop = true;
               this.textRepeatPassword.Location = new System.Drawing.Point(236, 180);
               this.textRepeatPassword.Margin = new System.Windows.Forms.Padding(4);
               this.textRepeatPassword.Name = "textRepeatPassword";
               this.textRepeatPassword.Size = new System.Drawing.Size(466, 28);
               this.textRepeatPassword.TabIndex = 6;
               this.textRepeatPassword.UseSystemPasswordChar = true;
               // 
               // buttonShowPassword
               // 
               this.buttonShowPassword.Location = new System.Drawing.Point(710, 108);
               this.buttonShowPassword.Margin = new System.Windows.Forms.Padding(4);
               this.buttonShowPassword.Name = "buttonShowPassword";
               this.buttonShowPassword.Size = new System.Drawing.Size(68, 39);
               this.buttonShowPassword.TabIndex = 4;
               this.buttonShowPassword.UseVisualStyleBackColor = true;
               this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
               // 
               // textNewPassword
               // 
               this.textNewPassword.Location = new System.Drawing.Point(236, 113);
               this.textNewPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textNewPassword.Name = "textNewPassword";
               this.textNewPassword.Size = new System.Drawing.Size(466, 28);
               this.textNewPassword.TabIndex = 3;
               this.textNewPassword.TextChanged += new System.EventHandler(this.textNewPassword_TextChanged);
               // 
               // labelNewPassword
               // 
               this.labelNewPassword.Location = new System.Drawing.Point(27, 114);
               this.labelNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelNewPassword.Name = "labelNewPassword";
               this.labelNewPassword.Size = new System.Drawing.Size(200, 26);
               this.labelNewPassword.TabIndex = 2;
               this.labelNewPassword.Text = "New password:";
               this.labelNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // textOldPassword
               // 
               this.textOldPassword.Location = new System.Drawing.Point(236, 46);
               this.textOldPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textOldPassword.Name = "textOldPassword";
               this.textOldPassword.Size = new System.Drawing.Size(542, 28);
               this.textOldPassword.TabIndex = 1;
               // 
               // labelOldPassword
               // 
               this.labelOldPassword.Location = new System.Drawing.Point(27, 47);
               this.labelOldPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelOldPassword.Name = "labelOldPassword";
               this.labelOldPassword.Size = new System.Drawing.Size(200, 26);
               this.labelOldPassword.TabIndex = 0;
               this.labelOldPassword.Text = "Old password:";
               this.labelOldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // qualityProgressBar
               // 
               this.qualityProgressBar.Location = new System.Drawing.Point(236, 247);
               this.qualityProgressBar.Margin = new System.Windows.Forms.Padding(4);
               this.qualityProgressBar.Name = "qualityProgressBar";
               this.qualityProgressBar.QualityHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
               this.qualityProgressBar.QualityLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
               this.qualityProgressBar.Size = new System.Drawing.Size(542, 28);
               this.qualityProgressBar.TabIndex = 9;
               this.qualityProgressBar.Text = "qualityProgressBar";
               // 
               // labelPasswordQuality
               // 
               this.labelPasswordQuality.Location = new System.Drawing.Point(27, 248);
               this.labelPasswordQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPasswordQuality.Name = "labelPasswordQuality";
               this.labelPasswordQuality.Size = new System.Drawing.Size(200, 26);
               this.labelPasswordQuality.TabIndex = 8;
               this.labelPasswordQuality.Text = "Quality:";
               this.labelPasswordQuality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // formChangePassword
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(812, 411);
               this.Controls.Add(this.qualityProgressBar);
               this.Controls.Add(this.labelPasswordQuality);
               this.Controls.Add(this.textOldPassword);
               this.Controls.Add(this.labelOldPassword);
               this.Controls.Add(this.buttonBuildPassword);
               this.Controls.Add(this.labelRepeatPassword);
               this.Controls.Add(this.textRepeatPassword);
               this.Controls.Add(this.buttonShowPassword);
               this.Controls.Add(this.textNewPassword);
               this.Controls.Add(this.labelNewPassword);
               this.Controls.Add(this.buttonOK);
               this.Controls.Add(this.buttonCancel);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formChangePassword";
               this.Text = "Change password";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private void buttonBuildPassword_Click(object sender, System.EventArgs args)
          {
               var tmpPasswordBuilder = new formPasswordBuilder();
               var tmpDialogResult = tmpPasswordBuilder.ShowDialog();
               if (tmpDialogResult == DialogResult.OK)
               {
                    this.textRepeatPassword.Text = this.textNewPassword.Text = tmpPasswordBuilder.PasswordString;
               }
               tmpPasswordBuilder.Dispose();
          }

          private void buttonShowPassword_Click(object sender, System.EventArgs args)
          {
               if (this.textNewPassword.PasswordChar == '*')
               {
                    this.textNewPassword.PasswordChar = (char)0;
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, false);
               }
               else
               {
                    this.textNewPassword.PasswordChar = '*';
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, true);
               }
          }

          private void textNewPassword_TextChanged(object sender, System.EventArgs args)
          {
               this.qualityProgressBar.Value = (int)QualityEstimation.EstimatePasswordQuality(this.textNewPassword.Text);
          }

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;

               var tmpOldPassword = this.textOldPassword.Text.Trim();
               var tmpNewPassword = this.textNewPassword.Text.Trim();

               if (tmpOldPassword != Account.CurrentAccount.Password)
               {
                    this.textOldPassword.Focus();
                    MessageBox.Show(SafePassResource.ChangePasswordWindowPromptPasswordIncorrect, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }

               if (string.IsNullOrEmpty(tmpNewPassword))
               {
                    this.textNewPassword.Focus();
                    MessageBox.Show(SafePassResource.ChangePasswordWindowPromptPasswordIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else if (!string.Equals(tmpNewPassword, this.textRepeatPassword.Text))
               {
                    this.textRepeatPassword.Focus();
                    MessageBox.Show(SafePassResource.PasswordRepeatFailed, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }

               if (string.Equals(tmpOldPassword, tmpNewPassword, System.StringComparison.OrdinalIgnoreCase))
               {
                    this.textNewPassword.Focus();
                    MessageBox.Show(SafePassResource.ChangePasswordWindowPromptSameAsOldPassword, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }

               try
               {
                    var tmpPasswordMd5 = Md5DigestHelper.Md5Salt(tmpNewPassword, Account.CurrentAccount.UserName);

                    var tmpAccountService = new HuiruiSoft.Safe.Service.AccountService();
                    var tmpChangeResult = tmpAccountService.ChangePassword(tmpPasswordMd5);
                    if (tmpChangeResult)
                    {
                         DataBaseConfig.Password = tmpPasswordMd5;
                         Account.CurrentAccount.Password = tmpNewPassword;
                         Account.CurrentAccount.PasswordStored = EncryptorHelper.DESEncrypt(Account.CurrentAccount.SecretKey, tmpPasswordMd5);

                         ApplicationConfigSerializer.SaveApplicationConfig(Program.Config);
                         MessageBox.Show(SafePassResource.ChangePasswordWindowMessageChangeSuccess, SafePassResource.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         this.DialogResult = DialogResult.OK;
                    }
               }
               catch (System.SystemException exception)
               {
                    loger.Error(exception);
                    MessageBox.Show(SafePassResource.ChangePasswordWindowMessageChangeFailed, SafePassResource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
          }
     }
}
