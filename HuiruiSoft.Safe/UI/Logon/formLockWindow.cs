using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     public partial class formLockWindow : System.Windows.Forms.Form
     {
          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.GroupBox groupOptions;
          private System.Windows.Forms.Label labelPassword;
          private System.Windows.Forms.Label labelLoginName;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonExit;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.TextBox textPassword;
          private System.Windows.Forms.TextBox textLoginName;

          internal formLockWindow( )
          {
               this.InitializeComponent( );

               this.WindowState = FormWindowState.Normal;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.MinimizeBox = true;
                    this.MaximizeBox = false;
                    this.ShowInTaskbar = true;
                    GlobalWindowManager.HideAllWindows();

                    this.AcceptButton = this.buttonOK;
                    this.CancelButton = this.buttonCancel;
                    this.buttonCancel.Location = new System.Drawing.Point(-200, -100);

                    this.textLoginName.ReadOnly = true;
                    this.textLoginName.Text = Account.CurrentAccount.UserName;
                    this.textPassword.PasswordChar = '*';
                    this.textPassword.Focus( );

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.LockedWindowCaption;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonExit.Text = SafePassResource.ButtonExitApp;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;
                    this.groupOptions.Text = SafePassResource.LoginWindowOptions;
                    this.labelLoginName.Text = SafePassResource.LoginWindowUserName;
                    this.labelPassword.Text = SafePassResource.LoginWindowPassword;

                    HuiruiSoft.Win32.NativeMethods.SetForegroundWindow(this.Handle);
                    HuiruiSoft.Win32.NativeMethods.SetActiveWindow(this.Handle);
                    HuiruiSoft.Win32.NativeMethods.SetFocus(this.textPassword.Handle);
               }
          }

          protected override void OnFormClosing(FormClosingEventArgs args)
          {
               base.OnFormClosing(args);

               if (args.CloseReason == CloseReason.UserClosing)
               {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
               }
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
               this.buttonExit = new System.Windows.Forms.Button();
               this.groupOptions = new System.Windows.Forms.GroupBox();
               this.textPassword = new System.Windows.Forms.TextBox();
               this.labelPassword = new System.Windows.Forms.Label();
               this.textLoginName = new System.Windows.Forms.TextBox();
               this.labelLoginName = new System.Windows.Forms.Label();
               this.buttonOK = new System.Windows.Forms.Button();
               this.buttonCancel = new System.Windows.Forms.Button();
               this.groupOptions.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonExit
               // 
               this.buttonExit.Location = new System.Drawing.Point(630, 330);
               this.buttonExit.Margin = new System.Windows.Forms.Padding(6);
               this.buttonExit.Name = "buttonExit";
               this.buttonExit.Size = new System.Drawing.Size(195, 69);
               this.buttonExit.TabIndex = 2;
               this.buttonExit.Text = "E&xit";
               this.buttonExit.UseVisualStyleBackColor = true;
               this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
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
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(393, 330);
               this.buttonOK.Margin = new System.Windows.Forms.Padding(6);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(195, 69);
               this.buttonOK.TabIndex = 1;
               this.buttonOK.Text = "&OK";
               this.buttonOK.UseVisualStyleBackColor = true;
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(867, 330);
               this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(195, 69);
               this.buttonCancel.TabIndex = 3;
               this.buttonCancel.Text = "&Cancel";
               this.buttonCancel.UseVisualStyleBackColor = true;
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // formLockWindow
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(898, 444);
               this.Controls.Add(this.buttonExit);
               this.Controls.Add(this.groupOptions);
               this.Controls.Add(this.buttonOK);
               this.Controls.Add(this.buttonCancel);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formLockWindow";
               this.Text = "Locked";
               this.groupOptions.ResumeLayout(false);
               this.groupOptions.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion

          public void ClearPassword()
          {
               this.textPassword.Clear();
               this.textPassword.Focus();
          }

          private void buttonExit_Click(object sender, System.EventArgs args)
          {
               System.Windows.Forms.Application.Exit( );
          }

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.Close();
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               var tmpPassword = this.textPassword.Text.Trim( );
               if(string.IsNullOrEmpty(tmpPassword))
               {
                    this.textPassword.Focus( );
               }
               else
               {
                    bool tmpCheckResult = this.CheckValidity( );
                    if(tmpCheckResult)
                    {
                         this.DialogResult = DialogResult.OK;
                    }
               }
          }

          protected virtual bool CheckValidity( )
          {
               var tmpUserName = this.textLoginName.Text.Trim( );
               var tmpPassword = this.textPassword.Text.Trim( );

               var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;
               if (string.IsNullOrEmpty(tmpUserName))
               {
                    this.textLoginName.Focus( );
                    MessageBox.Show(SafePassResource.LoginWindowPromptUserNameIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }
               else if(string.IsNullOrEmpty(tmpPassword))
               {
                    this.textPassword.Focus( );
                    MessageBox.Show(SafePassResource.LoginWindowPromptPasswordIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }

               if(tmpUserName != Account.CurrentAccount.UserName)
               {
                    this.textLoginName.Focus( );
                    MessageBox.Show(SafePassResource.LoginWindowPromptUserNameNonExistent, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }

               string tmpPasswordMd5 = HuiruiSoft.Security.Cryptography.Md5DigestHelper.Md5Salt(tmpPassword, tmpUserName);
               if (tmpPasswordMd5 == Account.CurrentAccount.PasswordMd5)
               {
                    //
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
