using System.IO;
using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;
using HuiruiSoft.Security.Cryptography;

namespace HuiruiSoft.Safe
{
     public partial class formNewSafeWizard : System.Windows.Forms.Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.Button buttonShowPassword;
          private System.Windows.Forms.Button buttonBuildPassword;
          private System.Windows.Forms.Button buttonSelectDirectory;
          private System.Windows.Forms.Label labelSafePassNameTips;
          private System.Windows.Forms.Label labelLoginName;
          private System.Windows.Forms.Label labelPwdQuality;
          private System.Windows.Forms.Label labelPassword;
          private System.Windows.Forms.Label labelPwdRepeat;
          private System.Windows.Forms.Label labelWorkDirectory;
          private System.Windows.Forms.Label labelSafePassName;
          private System.Windows.Forms.Label labelLoginNameTips;
          private System.Windows.Forms.Label labelPromptRemember;
          private System.Windows.Forms.TextBox textLoginName;
          private System.Windows.Forms.TextBox textPassword;
          private System.Windows.Forms.TextBox textPwdRepeat;
          private System.Windows.Forms.TextBox textSafePassName;
          private System.Windows.Forms.TextBox textWorkDirectory;
          private HuiruiSoft.UI.Controls.QualityProgressBar qualityProgressBar;

          internal formNewSafeWizard()
          {
               this.InitializeComponent();

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
                    this.textPassword.MaxLength = 50;
                    this.textLoginName.MaxLength = 30;
                    this.textSafePassName.MaxLength = 50;
                    this.textWorkDirectory.ReadOnly = true;
                    this.textPassword.PasswordChar = '*';
                    this.textPassword.ImeMode = ImeMode.Disable;
                    this.textPwdRepeat.ImeMode = ImeMode.Disable;
                    this.textLoginName.ImeMode = ImeMode.Disable;

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;
                    this.Text = SafePassResource.NewWizardWindowCaption;
                    this.labelLoginName.Text = SafePassResource.NewWizardWindowLabelLoginName;
                    this.labelPassword.Text = SafePassResource.NewWizardWindowLabelPassword;
                    this.labelPwdRepeat.Text = SafePassResource.NewWizardWindowLabelPwdRepeat;
                    this.labelPwdQuality.Text = SafePassResource.NewWizardWindowLabelPwdQuality;
                    this.labelSafePassName.Text = SafePassResource.NewWizardWindowLabelSafePassName;
                    this.labelWorkDirectory.Text = SafePassResource.NewWizardWindowLabelWorkDirectory;
                    this.buttonSelectDirectory.Text = SafePassResource.NewWizardWindowButtonSelectDirectory;
                    this.labelPromptRemember.Text = SafePassResource.NewWizardWindowPromptRememberPassword;

                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, true);
                    this.textWorkDirectory.Text = NativeShellHelper.GetWorkingDirectory();
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
               this.buttonCancel = new System.Windows.Forms.Button();
               this.labelWorkDirectory = new System.Windows.Forms.Label();
               this.buttonSelectDirectory = new System.Windows.Forms.Button();
               this.textWorkDirectory = new System.Windows.Forms.TextBox();
               this.buttonBuildPassword = new System.Windows.Forms.Button();
               this.labelPwdRepeat = new System.Windows.Forms.Label();
               this.textPwdRepeat = new System.Windows.Forms.TextBox();
               this.labelPwdQuality = new System.Windows.Forms.Label();
               this.buttonShowPassword = new System.Windows.Forms.Button();
               this.textPassword = new System.Windows.Forms.TextBox();
               this.labelPassword = new System.Windows.Forms.Label();
               this.textSafePassName = new System.Windows.Forms.TextBox();
               this.labelSafePassName = new System.Windows.Forms.Label();
               this.textLoginName = new System.Windows.Forms.TextBox();
               this.labelLoginName = new System.Windows.Forms.Label();
               this.qualityProgressBar = new HuiruiSoft.UI.Controls.QualityProgressBar();
               this.labelLoginNameTips = new System.Windows.Forms.Label();
               this.labelSafePassNameTips = new System.Windows.Forms.Label();
               this.labelPromptRemember = new System.Windows.Forms.Label();
               this.SuspendLayout();
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(479, 522);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 49);
               this.buttonOK.TabIndex = 18;
               this.buttonOK.Text = "&OK";
               this.buttonOK.UseVisualStyleBackColor = true;
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(703, 522);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 49);
               this.buttonCancel.TabIndex = 19;
               this.buttonCancel.Text = "&Close";
               this.buttonCancel.UseVisualStyleBackColor = true;
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // labelWorkDirectory
               // 
               this.labelWorkDirectory.Location = new System.Drawing.Point(30, 432);
               this.labelWorkDirectory.Name = "labelWorkDirectory";
               this.labelWorkDirectory.Size = new System.Drawing.Size(165, 26);
               this.labelWorkDirectory.TabIndex = 15;
               this.labelWorkDirectory.Text = "Work directory:";
               this.labelWorkDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // buttonSelectDirectory
               // 
               this.buttonSelectDirectory.Location = new System.Drawing.Point(708, 417);
               this.buttonSelectDirectory.Name = "buttonSelectDirectory";
               this.buttonSelectDirectory.Size = new System.Drawing.Size(175, 56);
               this.buttonSelectDirectory.TabIndex = 17;
               this.buttonSelectDirectory.Text = "Select directory";
               this.buttonSelectDirectory.UseVisualStyleBackColor = true;
               this.buttonSelectDirectory.Click += new System.EventHandler(this.buttonSelectDirectory_Click);
               // 
               // textWorkDirectory
               // 
               this.textWorkDirectory.Location = new System.Drawing.Point(203, 431);
               this.textWorkDirectory.Name = "textWorkDirectory";
               this.textWorkDirectory.Size = new System.Drawing.Size(499, 28);
               this.textWorkDirectory.TabIndex = 16;
               // 
               // buttonBuildPassword
               // 
               this.buttonBuildPassword.Location = new System.Drawing.Point(815, 231);
               this.buttonBuildPassword.Margin = new System.Windows.Forms.Padding(4);
               this.buttonBuildPassword.Name = "buttonBuildPassword";
               this.buttonBuildPassword.Size = new System.Drawing.Size(68, 39);
               this.buttonBuildPassword.TabIndex = 9;
               this.buttonBuildPassword.Text = "...";
               this.buttonBuildPassword.UseVisualStyleBackColor = true;
               this.buttonBuildPassword.Click += new System.EventHandler(this.buttonBuildPassword_Click);
               // 
               // labelPwdRepeat
               // 
               this.labelPwdRepeat.Location = new System.Drawing.Point(30, 237);
               this.labelPwdRepeat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPwdRepeat.Name = "labelPwdRepeat";
               this.labelPwdRepeat.Size = new System.Drawing.Size(165, 26);
               this.labelPwdRepeat.TabIndex = 7;
               this.labelPwdRepeat.Text = "&Confirm password:";
               this.labelPwdRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // textPwdRepeat
               // 
               this.textPwdRepeat.AllowDrop = true;
               this.textPwdRepeat.Location = new System.Drawing.Point(203, 236);
               this.textPwdRepeat.Margin = new System.Windows.Forms.Padding(4);
               this.textPwdRepeat.Name = "textPwdRepeat";
               this.textPwdRepeat.Size = new System.Drawing.Size(607, 28);
               this.textPwdRepeat.TabIndex = 8;
               this.textPwdRepeat.UseSystemPasswordChar = true;
               // 
               // labelPwdQuality
               // 
               this.labelPwdQuality.Location = new System.Drawing.Point(30, 302);
               this.labelPwdQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPwdQuality.Name = "labelPwdQuality";
               this.labelPwdQuality.Size = new System.Drawing.Size(165, 26);
               this.labelPwdQuality.TabIndex = 10;
               this.labelPwdQuality.Text = "Password &quality:";
               this.labelPwdQuality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // buttonShowPassword
               // 
               this.buttonShowPassword.Location = new System.Drawing.Point(815, 166);
               this.buttonShowPassword.Margin = new System.Windows.Forms.Padding(4);
               this.buttonShowPassword.Name = "buttonShowPassword";
               this.buttonShowPassword.Size = new System.Drawing.Size(68, 39);
               this.buttonShowPassword.TabIndex = 6;
               this.buttonShowPassword.UseVisualStyleBackColor = true;
               this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
               // 
               // textPassword
               // 
               this.textPassword.Location = new System.Drawing.Point(203, 171);
               this.textPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textPassword.Name = "textPassword";
               this.textPassword.Size = new System.Drawing.Size(607, 28);
               this.textPassword.TabIndex = 5;
               this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
               // 
               // labelPassword
               // 
               this.labelPassword.Location = new System.Drawing.Point(30, 172);
               this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPassword.Name = "labelPassword";
               this.labelPassword.Size = new System.Drawing.Size(165, 26);
               this.labelPassword.TabIndex = 4;
               this.labelPassword.Text = "&Password:";
               this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // textSafePassName
               // 
               this.textSafePassName.Location = new System.Drawing.Point(203, 366);
               this.textSafePassName.Name = "textSafePassName";
               this.textSafePassName.Size = new System.Drawing.Size(680, 28);
               this.textSafePassName.TabIndex = 13;
               // 
               // labelSafePassName
               // 
               this.labelSafePassName.Location = new System.Drawing.Point(30, 367);
               this.labelSafePassName.Name = "labelSafePassName";
               this.labelSafePassName.Size = new System.Drawing.Size(165, 26);
               this.labelSafePassName.TabIndex = 12;
               this.labelSafePassName.Text = "SafePass Name:";
               this.labelSafePassName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // textLoginName
               // 
               this.textLoginName.Location = new System.Drawing.Point(203, 106);
               this.textLoginName.Margin = new System.Windows.Forms.Padding(6);
               this.textLoginName.Name = "textLoginName";
               this.textLoginName.Size = new System.Drawing.Size(680, 28);
               this.textLoginName.TabIndex = 2;
               this.textLoginName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLoginName_KeyPress);
               // 
               // labelLoginName
               // 
               this.labelLoginName.Location = new System.Drawing.Point(30, 107);
               this.labelLoginName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
               this.labelLoginName.Name = "labelLoginName";
               this.labelLoginName.Size = new System.Drawing.Size(165, 26);
               this.labelLoginName.TabIndex = 1;
               this.labelLoginName.Text = "Login Name:";
               this.labelLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // qualityProgressBar
               // 
               this.qualityProgressBar.Location = new System.Drawing.Point(203, 301);
               this.qualityProgressBar.Margin = new System.Windows.Forms.Padding(4);
               this.qualityProgressBar.Name = "qualityProgressBar";
               this.qualityProgressBar.QualityHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
               this.qualityProgressBar.QualityLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
               this.qualityProgressBar.Size = new System.Drawing.Size(680, 28);
               this.qualityProgressBar.TabIndex = 11;
               this.qualityProgressBar.Text = "qualityProgressBar";
               // 
               // labelLoginNameTips
               // 
               this.labelLoginNameTips.ForeColor = System.Drawing.Color.Red;
               this.labelLoginNameTips.Location = new System.Drawing.Point(888, 107);
               this.labelLoginNameTips.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
               this.labelLoginNameTips.Name = "labelLoginNameTips";
               this.labelLoginNameTips.Size = new System.Drawing.Size(28, 26);
               this.labelLoginNameTips.TabIndex = 3;
               this.labelLoginNameTips.Text = "*";
               this.labelLoginNameTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // labelSafePassNameTips
               // 
               this.labelSafePassNameTips.ForeColor = System.Drawing.Color.Red;
               this.labelSafePassNameTips.Location = new System.Drawing.Point(888, 367);
               this.labelSafePassNameTips.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
               this.labelSafePassNameTips.Name = "labelSafePassNameTips";
               this.labelSafePassNameTips.Size = new System.Drawing.Size(28, 26);
               this.labelSafePassNameTips.TabIndex = 14;
               this.labelSafePassNameTips.Text = "*";
               this.labelSafePassNameTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // labelPromptRemember
               // 
               this.labelPromptRemember.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
               this.labelPromptRemember.ForeColor = System.Drawing.Color.Tomato;
               this.labelPromptRemember.Location = new System.Drawing.Point(66, 38);
               this.labelPromptRemember.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
               this.labelPromptRemember.Name = "labelPromptRemember";
               this.labelPromptRemember.Size = new System.Drawing.Size(817, 30);
               this.labelPromptRemember.TabIndex = 0;
               this.labelPromptRemember.Text = "Please remember your password. Once lost, it will not be retrieved";
               this.labelPromptRemember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // formNewSafeWizard
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(938, 624);
               this.Controls.Add(this.labelPromptRemember);
               this.Controls.Add(this.labelSafePassNameTips);
               this.Controls.Add(this.labelLoginNameTips);
               this.Controls.Add(this.textLoginName);
               this.Controls.Add(this.labelLoginName);
               this.Controls.Add(this.textSafePassName);
               this.Controls.Add(this.labelSafePassName);
               this.Controls.Add(this.buttonBuildPassword);
               this.Controls.Add(this.labelPwdRepeat);
               this.Controls.Add(this.qualityProgressBar);
               this.Controls.Add(this.textPwdRepeat);
               this.Controls.Add(this.labelPwdQuality);
               this.Controls.Add(this.buttonShowPassword);
               this.Controls.Add(this.textPassword);
               this.Controls.Add(this.labelPassword);
               this.Controls.Add(this.labelWorkDirectory);
               this.Controls.Add(this.buttonSelectDirectory);
               this.Controls.Add(this.textWorkDirectory);
               this.Controls.Add(this.buttonOK);
               this.Controls.Add(this.buttonCancel);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formNewSafeWizard";
               this.Text = "New Wizard";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void textLoginName_KeyPress(object sender, KeyPressEventArgs args)
          {
               if (!(char.IsNumber(args.KeyChar) || char.IsLetter(args.KeyChar) || args.KeyChar == (char)8 || args.KeyChar == (char)13 || args.KeyChar == '.' || args.KeyChar == '-' || args.KeyChar == '_'))
               {
                    args.Handled = true;
               }
          }

          private void buttonSelectDirectory_Click(object sender, System.EventArgs args)
          {
               var folderBrowserDialog = new FolderBrowserDialog();
               folderBrowserDialog.Description = SafePassResource.DialogDescriptionFolderBrowser;

               var tmpWorkDirectory = this.textWorkDirectory.Text;
               if (!string.IsNullOrEmpty(tmpWorkDirectory))
               {
                    if (System.IO.Directory.Exists(tmpWorkDirectory))
                    {
                         folderBrowserDialog.SelectedPath = tmpWorkDirectory;
                    }
               }

               var tmpDialogResult = folderBrowserDialog.ShowDialog();
               if (tmpDialogResult == DialogResult.OK || tmpDialogResult == DialogResult.Yes)
               {
                    this.textWorkDirectory.Text = folderBrowserDialog.SelectedPath;
               }
          }

          private void textPassword_TextChanged(object sender, System.EventArgs args)
          {
               this.qualityProgressBar.Value = (int)QualityEstimation.EstimatePasswordQuality(this.textPassword.Text);
          }

          private void buttonShowPassword_Click(object sender, System.EventArgs args)
          {
               if (this.textPassword.PasswordChar == '*')
               {
                    this.textPassword.PasswordChar = (char)0;
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, false);
               }
               else
               {
                    this.textPassword.PasswordChar = '*';
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, true);
               }
          }

          private void buttonBuildPassword_Click(object sender, System.EventArgs args)
          {
               var tmpPasswordBuilder = new formPasswordBuilder();
               var tmpDialogResult = tmpPasswordBuilder.ShowDialog();
               if (tmpDialogResult == DialogResult.OK)
               {
                    this.textPwdRepeat.Text = this.textPassword.Text = tmpPasswordBuilder.PasswordString;
               }
               tmpPasswordBuilder.Dispose();
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               var tmpCreateResult = false;
               var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;

               var tmpLoginName = this.textLoginName.Text.Trim();
               if (string.IsNullOrEmpty(tmpLoginName))
               {
                    this.textLoginName.Focus();
                    MessageBox.Show(SafePassResource.NewWizardWindowPromptLoginNameIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else if (tmpLoginName.Length > 30)
               {
                    this.textLoginName.Focus();
                    MessageBox.Show(SafePassResource.NewWizardWindowPromptLoginNameTooLong, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }

               var tmpPassword = this.textPassword.Text.Trim();
               var tmpMasterPassword = Program.Config.Application.Security.MasterPassword;
               if (string.IsNullOrEmpty(tmpPassword))
               {
                    this.textPassword.Focus();
                    MessageBox.Show(SafePassResource.NewWizardWindowPromptPasswordIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else if (tmpPassword.Length < tmpMasterPassword.MinimumLength)
               {
                    this.textPassword.Focus();
                    MessageBox.Show(string.Format(SafePassResource.MasterPasswordMinimumLengthFailed, tmpMasterPassword.MinimumLength), tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else if (QualityEstimation.EstimatePasswordQuality(tmpPassword) < tmpMasterPassword.MinimumQuality)
               {
                    this.textPassword.Focus();
                    MessageBox.Show(string.Format(SafePassResource.MasterPasswordMinimumQualityFailed, tmpMasterPassword.MinimumQuality), tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else if (!string.Equals(tmpPassword, this.textPwdRepeat.Text))
               {
                    this.textPwdRepeat.Focus();
                    MessageBox.Show(SafePassResource.PasswordRepeatFailed, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }

               var tmpSafePassName = this.textSafePassName.Text.Trim();
               if (string.IsNullOrEmpty(tmpSafePassName))
               {
                    this.textSafePassName.Focus();
                    MessageBox.Show(SafePassResource.NewWizardWindowPromptSafePassNameIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else if (StringHelper.GetStringBytesCount(tmpSafePassName) > 30)
               {
                    this.textSafePassName.Focus();
                    MessageBox.Show(SafePassResource.NewWizardWindowPromptSafePassNameTooLong, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }

               var tmpRootDirectory = new DirectoryInfo(this.textWorkDirectory.Text);
               if (!tmpRootDirectory.Exists)
               {
                    tmpRootDirectory = Directory.CreateDirectory(this.textWorkDirectory.Text);
               }

               DirectoryInfo tmpWorkDirectory;
               if (string.Equals(tmpRootDirectory.Name, tmpLoginName, System.StringComparison.OrdinalIgnoreCase))
               {
                    tmpWorkDirectory = new DirectoryInfo(tmpRootDirectory.FullName);
               }
               else
               {
                    tmpWorkDirectory = new DirectoryInfo(Path.Combine(tmpRootDirectory.FullName, tmpLoginName));
                    if (!tmpWorkDirectory.Exists)
                    {
                         tmpWorkDirectory = Directory.CreateDirectory(tmpWorkDirectory.FullName);
                    }
               }

               if (tmpWorkDirectory.Exists)
               {
                    NativeShellHelper.SetWorkingDirectory(tmpWorkDirectory.FullName);
                    var tmpDataDirectory = Path.Combine(tmpWorkDirectory.FullName, "data");
                    if (!Directory.Exists(tmpDataDirectory))
                    {
                         try
                         {
                              Directory.CreateDirectory(tmpDataDirectory);
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              System.Diagnostics.Debug.WriteLine(exception.Message);
                         }
                    }

                    var tmpConfigDirectory = Path.Combine(tmpWorkDirectory.FullName, "config");
                    if (!Directory.Exists(tmpConfigDirectory))
                    {
                         try
                         {
                              Directory.CreateDirectory(tmpConfigDirectory);
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              System.Diagnostics.Debug.WriteLine(exception.Message);
                         }
                    }

                    if (Directory.Exists(tmpConfigDirectory))
                    {
                         try
                         {
                              //this.CreateLog4NetConfig( );
                              this.CreateApplicationConfig(tmpConfigDirectory, tmpLoginName, tmpPassword);
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              System.Diagnostics.Debug.WriteLine(exception.Message);
                         }
                    }

                    if (Directory.Exists(tmpDataDirectory))
                    {
                         try
                         {
                              tmpCreateResult = this.InitializeDataBase(tmpDataDirectory, tmpLoginName, tmpPassword);
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              System.Diagnostics.Debug.WriteLine(exception.Message);
                         }
                    }
               }

               if (tmpCreateResult)
               {
                    MessageBox.Show(SafePassResource.NewWizardWindowDialogMessageCreateSuccess, SafePassResource.NewWizardWindowDialogTitleCreateSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
               }
          }

          private bool CreateLog4NetConfig( )
          {
               bool tmpCreateResult = false;
               var tmpConfigStream = ResourceStreamHelper.GetStream("resources.config.log4net.config", typeof(ResourceFinder));
               if (tmpConfigStream != null)
               {
                    var tmpConfigDirectory = Path.Combine(Application.StartupPath, "config");
                    if (!Directory.Exists(tmpConfigDirectory))
                    {
                         try
                         {
                              Directory.CreateDirectory(tmpConfigDirectory);
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              System.Diagnostics.Debug.WriteLine(exception.Message);
                         }
                    }

                    using (var tmpFileStream = new FileStream(Path.Combine(tmpConfigDirectory, "log4net.config"), FileMode.OpenOrCreate, FileAccess.Write))
                    {
                         byte[] buffer = new byte[tmpConfigStream.Length];
                         tmpConfigStream.Read(buffer, 0, buffer.Length);
                         tmpFileStream.Write(buffer, 0, buffer.Length);
                         tmpFileStream.Flush();
                         tmpFileStream.Close();
                         tmpCreateResult = true;
                    }
               }

               return tmpCreateResult;
          }

          private bool CreateApplicationConfig(string configDirectory, string userName, string password)
          {
               var tmpSafePassConfig = new SafePassConfiguration();
               if (System.Globalization.CultureInfo.CurrentCulture.Name == "zh-CN")
               {
                    tmpSafePassConfig.Application.LanguageFile = ApplicationDefines.ChineseSimpLanguageFile;
               }

               var tmpSecurityProfile = tmpSafePassConfig.Application.Security;
               tmpSecurityProfile.LockWorkspace = Program.Config.Application.Security.LockWorkspace;
               tmpSecurityProfile.MasterPassword = Program.Config.Application.Security.MasterPassword;
               tmpSecurityProfile.CurrentAccount.UserName = userName;
               tmpSecurityProfile.CurrentAccount.Password = password;
               tmpSecurityProfile.CurrentAccount.PasswordStored = EncryptorHelper.DESEncrypt(Account.CurrentAccount.SecretKey, tmpSecurityProfile.CurrentAccount.PasswordMd5);

               tmpSecurityProfile.Clipboard.ClipboardClearOnExit = Program.Config.Application.Security.Clipboard.ClipboardClearOnExit;
               tmpSecurityProfile.Clipboard.ClipboardClearAfterSeconds = Program.Config.Application.Security.Clipboard.ClipboardClearAfterSeconds;

               tmpSecurityProfile.SecretRank.SecretRank0Color = Program.Config.Application.Security.SecretRank.SecretRank0Color;
               tmpSecurityProfile.SecretRank.SecretRank1Color = Program.Config.Application.Security.SecretRank.SecretRank1Color;
               tmpSecurityProfile.SecretRank.SecretRank2Color = Program.Config.Application.Security.SecretRank.SecretRank2Color;
               tmpSecurityProfile.SecretRank.SecretRank3Color = Program.Config.Application.Security.SecretRank.SecretRank3Color;
               tmpSafePassConfig.MainWindow = Program.Config.MainWindow;

               var tmpCreateResult = ApplicationConfigSerializer.SaveApplicationConfig(Path.Combine(configDirectory, "SafePass.config.xml"), tmpSafePassConfig);

               return tmpCreateResult;
          }

          private bool InitializeDataBase(string dataDirectory, string userName, string password)
          {
               bool tmpCreateResult = false;

               var tmpSQLiteDataBase = new HuiruiSoft.Data.SQLite.GeneralSQLiteDataBase();
               tmpSQLiteDataBase.DataSource = string.Format(@"{0}\SafePassData.dat", dataDirectory);
               tmpSQLiteDataBase.Password = Md5DigestHelper.Md5Salt(password, userName);
               tmpSQLiteDataBase.CreateDataBase();

               var tmpResourceStream = ResourceStreamHelper.GetStream("resources.database.SafePass.sql", typeof(ResourceFinder));
               if (tmpResourceStream != null)
               {
                    byte[] bytes = new byte[tmpResourceStream.Length];
                    tmpResourceStream.Read(bytes, 0, bytes.Length);
                    string tmpCommandString = System.Text.Encoding.UTF8.GetString(bytes);

                    tmpSQLiteDataBase.ExecuteNonQuery(tmpCommandString);

                    var tmpRootCatalog = new AccountCatalog();
                    tmpRootCatalog.Depth = 1;
                    tmpRootCatalog.ParentId = -1;
                    tmpRootCatalog.Name = this.textSafePassName.Text;

                    tmpCreateResult = tmpSQLiteDataBase.CreateRootCatalog(tmpRootCatalog);
                    if (tmpCreateResult)
                    {
                         //
                    }
               }

               return tmpCreateResult;
          }
     }
}
