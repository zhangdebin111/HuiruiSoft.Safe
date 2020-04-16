using System.Windows.Forms;
using HuiruiSoft.Win32;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formSystemOptions : System.Windows.Forms.Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private bool blockUpdateControls = false;

          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.TabPage tabPageGeneral;
          private System.Windows.Forms.TabPage tabPageSecurity;
          private System.Windows.Forms.TabControl tabControlMain;
          private System.Windows.Forms.Label labelSecretRank0;
          private System.Windows.Forms.Label labelSecretRank1;
          private System.Windows.Forms.Label labelSecretRank2;
          private System.Windows.Forms.Label labelSecretRank3;
          private System.Windows.Forms.Label labelWorkDirectory;
          private System.Windows.Forms.TextBox textWorkDirectory;
          private System.Windows.Forms.Button buttonChangeDirectory;
          private System.Windows.Forms.CheckBox checkAutoRun;
          private System.Windows.Forms.CheckBox checkLockAfterTime;
          private System.Windows.Forms.CheckBox checkLockGlobalTime;
          private HuiruiSoft.UI.Controls.ColorBoxCombo colorComboRank0;
          private HuiruiSoft.UI.Controls.ColorBoxCombo colorComboRank1;
          private HuiruiSoft.UI.Controls.ColorBoxCombo colorComboRank2;
          private HuiruiSoft.UI.Controls.ColorBoxCombo colorComboRank3;
          private System.Windows.Forms.NumericUpDown numericLockAfterTime;
          private System.Windows.Forms.NumericUpDown numericLockGlobalTime;
          private SecurityConfig originalConfig = null;

          internal formSystemOptions( )
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
                    this.textWorkDirectory.ReadOnly = true;
                    this.numericLockAfterTime.Minimum = 30;
                    this.numericLockAfterTime.Maximum = 12 * 60 * 60;
                    this.numericLockAfterTime.Increment = 5;

                    this.numericLockGlobalTime.Minimum = 30;
                    this.numericLockGlobalTime.Maximum = 12 * 60 * 60;
                    this.numericLockGlobalTime.Increment = 5;

                    this.LoadSystemOptions( );

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.OptionWindowCaption;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;
                    this.tabPageGeneral.Text = SafePassResource.OptionWindowTabPageGeneral;
                    this.tabPageSecurity.Text = SafePassResource.OptionWindowTabPageSecurity;
                    this.labelSecretRank0.Text = SafePassResource.OptionWindowSecretPublicColor;
                    this.labelSecretRank1.Text = SafePassResource.OptionWindowSecretSecretColor;
                    this.labelSecretRank2.Text = SafePassResource.OptionWindowSecretConfidentialColor;
                    this.labelSecretRank3.Text = SafePassResource.OptionWindowSecretTopSecretColor;
                    this.labelWorkDirectory.Text = SafePassResource.OptionWindowLabelWorkDirectory;
                    this.buttonChangeDirectory.Text = SafePassResource.OptionWindowButtonChangeDirectory;
                    this.checkLockAfterTime.Text = SafePassResource.OptionWindowCheckBoxLockAfterTime;
                    this.checkLockGlobalTime.Text = SafePassResource.OptionWindowCheckBoxLockGlobalTime;
                    this.checkAutoRun.Text = SafePassResource.OptionWindowCheckBoxAutoRunAtStartup;

                    this.colorComboRank0.ColorChanged += new HuiruiSoft.UI.Controls.ColorChangedEventHandler(this.OnColorSelectorColorChanged);
                    this.colorComboRank1.ColorChanged += new HuiruiSoft.UI.Controls.ColorChangedEventHandler(this.OnColorSelectorColorChanged);
                    this.colorComboRank2.ColorChanged += new HuiruiSoft.UI.Controls.ColorChangedEventHandler(this.OnColorSelectorColorChanged);
                    this.colorComboRank3.ColorChanged += new HuiruiSoft.UI.Controls.ColorChangedEventHandler(this.OnColorSelectorColorChanged);
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          private void LoadSystemOptions( )
          {
               this.originalConfig = Program.Config.Application.Security;

               var tmpLockSettings = this.originalConfig.LockWorkspace;
               var tmpLockAfterTime = tmpLockSettings.LockAfterTime;
               var tmpLockWorkspace = tmpLockAfterTime > 0;
               this.numericLockAfterTime.Value = (tmpLockWorkspace ? tmpLockAfterTime : 100);
               this.checkLockAfterTime.Checked = tmpLockWorkspace;
               this.numericLockAfterTime.Enabled = (this.checkLockAfterTime.Checked && this.checkLockAfterTime.Enabled);

               var tmpLockAfterGlobal = tmpLockSettings.LockGlobalTime;
               var tmpLockWorkStation = tmpLockAfterGlobal > 0;
               this.numericLockGlobalTime.Value = (tmpLockWorkStation ? tmpLockAfterGlobal : 200);
               this.checkLockGlobalTime.Checked = tmpLockWorkStation;
               this.numericLockGlobalTime.Enabled = (this.checkLockGlobalTime.Checked && this.checkLockGlobalTime.Enabled);

               this.colorComboRank0.Color = this.originalConfig.SecretRank.Rank0BackColor;
               this.colorComboRank1.Color = this.originalConfig.SecretRank.Rank1BackColor;
               this.colorComboRank2.Color = this.originalConfig.SecretRank.Rank2BackColor;
               this.colorComboRank3.Color = this.originalConfig.SecretRank.Rank3BackColor;

               this.textWorkDirectory.Text = Program.Config.WorkingDirectory;

               this.checkAutoRun.Checked = NativeShellHelper.GetStartWithWindows(ApplicationDefines.AutoRunName);
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
               this.buttonCancel = new System.Windows.Forms.Button();
               this.buttonOK = new System.Windows.Forms.Button();
               this.numericLockGlobalTime = new System.Windows.Forms.NumericUpDown();
               this.checkLockGlobalTime = new System.Windows.Forms.CheckBox();
               this.checkLockAfterTime = new System.Windows.Forms.CheckBox();
               this.numericLockAfterTime = new System.Windows.Forms.NumericUpDown();
               this.checkAutoRun = new System.Windows.Forms.CheckBox();
               this.tabControlMain = new System.Windows.Forms.TabControl();
               this.tabPageGeneral = new System.Windows.Forms.TabPage();
               this.labelWorkDirectory = new System.Windows.Forms.Label();
               this.buttonChangeDirectory = new System.Windows.Forms.Button();
               this.textWorkDirectory = new System.Windows.Forms.TextBox();
               this.tabPageSecurity = new System.Windows.Forms.TabPage();
               this.labelSecretRank0 = new System.Windows.Forms.Label();
               this.labelSecretRank1 = new System.Windows.Forms.Label();
               this.labelSecretRank2 = new System.Windows.Forms.Label();
               this.labelSecretRank3 = new System.Windows.Forms.Label();
               this.colorComboRank0 = new HuiruiSoft.UI.Controls.ColorBoxCombo();
               this.colorComboRank3 = new HuiruiSoft.UI.Controls.ColorBoxCombo();
               this.colorComboRank1 = new HuiruiSoft.UI.Controls.ColorBoxCombo();
               this.colorComboRank2 = new HuiruiSoft.UI.Controls.ColorBoxCombo();
               ((System.ComponentModel.ISupportInitialize)(this.numericLockGlobalTime)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericLockAfterTime)).BeginInit();
               this.tabControlMain.SuspendLayout();
               this.tabPageGeneral.SuspendLayout();
               this.tabPageSecurity.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(875, 579);
               this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 55);
               this.buttonCancel.TabIndex = 2;
               this.buttonCancel.Text = "&Cancel";
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(663, 579);
               this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 55);
               this.buttonOK.TabIndex = 1;
               this.buttonOK.Text = "&OK";
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // numericLockGlobalTime
               // 
               this.numericLockGlobalTime.Location = new System.Drawing.Point(523, 78);
               this.numericLockGlobalTime.Margin = new System.Windows.Forms.Padding(4);
               this.numericLockGlobalTime.Maximum = new decimal(new int[] {
            1209600,
            0,
            0,
            0});
               this.numericLockGlobalTime.Name = "numericLockGlobalTime";
               this.numericLockGlobalTime.Size = new System.Drawing.Size(99, 28);
               this.numericLockGlobalTime.TabIndex = 3;
               this.numericLockGlobalTime.ValueChanged += new System.EventHandler(this.numericLockGlobalTime_ValueChanged);
               // 
               // checkLockGlobalTime
               // 
               this.checkLockGlobalTime.AutoSize = true;
               this.checkLockGlobalTime.Location = new System.Drawing.Point(30, 81);
               this.checkLockGlobalTime.Margin = new System.Windows.Forms.Padding(4);
               this.checkLockGlobalTime.Name = "checkLockGlobalTime";
               this.checkLockGlobalTime.Size = new System.Drawing.Size(358, 22);
               this.checkLockGlobalTime.TabIndex = 2;
               this.checkLockGlobalTime.Text = "操作系统处于非活动状态锁定时间 (秒):";
               this.checkLockGlobalTime.UseVisualStyleBackColor = true;
               this.checkLockGlobalTime.CheckedChanged += new System.EventHandler(this.OnLockAfterGlobalCheckedChanged);
               // 
               // checkLockAfterTime
               // 
               this.checkLockAfterTime.AutoSize = true;
               this.checkLockAfterTime.Location = new System.Drawing.Point(30, 34);
               this.checkLockAfterTime.Margin = new System.Windows.Forms.Padding(4);
               this.checkLockAfterTime.Name = "checkLockAfterTime";
               this.checkLockAfterTime.Size = new System.Drawing.Size(358, 22);
               this.checkLockAfterTime.TabIndex = 0;
               this.checkLockAfterTime.Text = "主窗口处于非活动状态锁定的时间 (秒):";
               this.checkLockAfterTime.UseVisualStyleBackColor = true;
               this.checkLockAfterTime.CheckedChanged += new System.EventHandler(this.OnLockAfterTimeCheckedChanged);
               // 
               // numericLockAfterTime
               // 
               this.numericLockAfterTime.Location = new System.Drawing.Point(523, 31);
               this.numericLockAfterTime.Margin = new System.Windows.Forms.Padding(4);
               this.numericLockAfterTime.Maximum = new decimal(new int[] {
            1209600,
            0,
            0,
            0});
               this.numericLockAfterTime.Name = "numericLockAfterTime";
               this.numericLockAfterTime.Size = new System.Drawing.Size(99, 28);
               this.numericLockAfterTime.TabIndex = 1;
               this.numericLockAfterTime.ValueChanged += new System.EventHandler(this.numericLockAfterTime_ValueChanged);
               // 
               // checkAutoRun
               // 
               this.checkAutoRun.AutoSize = true;
               this.checkAutoRun.Location = new System.Drawing.Point(30, 132);
               this.checkAutoRun.Name = "checkAutoRun";
               this.checkAutoRun.Size = new System.Drawing.Size(340, 22);
               this.checkAutoRun.TabIndex = 4;
               this.checkAutoRun.Text = "开机时自动打开 SafePass (当前用户)";
               this.checkAutoRun.UseVisualStyleBackColor = true;
               this.checkAutoRun.CheckedChanged += new System.EventHandler(this.checkAutoRun_CheckedChanged);
               // 
               // tabControlMain
               // 
               this.tabControlMain.Controls.Add(this.tabPageGeneral);
               this.tabControlMain.Controls.Add(this.tabPageSecurity);
               this.tabControlMain.Location = new System.Drawing.Point(19, 29);
               this.tabControlMain.Name = "tabControlMain";
               this.tabControlMain.SelectedIndex = 0;
               this.tabControlMain.Size = new System.Drawing.Size(1040, 520);
               this.tabControlMain.TabIndex = 0;
               // 
               // tabPageGeneral
               // 
               this.tabPageGeneral.Controls.Add(this.labelWorkDirectory);
               this.tabPageGeneral.Controls.Add(this.buttonChangeDirectory);
               this.tabPageGeneral.Controls.Add(this.textWorkDirectory);
               this.tabPageGeneral.Controls.Add(this.checkLockGlobalTime);
               this.tabPageGeneral.Controls.Add(this.checkAutoRun);
               this.tabPageGeneral.Controls.Add(this.numericLockAfterTime);
               this.tabPageGeneral.Controls.Add(this.numericLockGlobalTime);
               this.tabPageGeneral.Controls.Add(this.checkLockAfterTime);
               this.tabPageGeneral.Location = new System.Drawing.Point(4, 28);
               this.tabPageGeneral.Name = "tabPageGeneral";
               this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
               this.tabPageGeneral.Size = new System.Drawing.Size(1032, 488);
               this.tabPageGeneral.TabIndex = 0;
               this.tabPageGeneral.Text = "General";
               this.tabPageGeneral.UseVisualStyleBackColor = true;
               // 
               // labelWorkDirectory
               // 
               this.labelWorkDirectory.Location = new System.Drawing.Point(13, 209);
               this.labelWorkDirectory.Name = "labelWorkDirectory";
               this.labelWorkDirectory.Size = new System.Drawing.Size(165, 20);
               this.labelWorkDirectory.TabIndex = 5;
               this.labelWorkDirectory.Text = "工作目录:";
               this.labelWorkDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // buttonChangeDirectory
               // 
               this.buttonChangeDirectory.Location = new System.Drawing.Point(832, 189);
               this.buttonChangeDirectory.Name = "buttonChangeDirectory";
               this.buttonChangeDirectory.Size = new System.Drawing.Size(180, 60);
               this.buttonChangeDirectory.TabIndex = 7;
               this.buttonChangeDirectory.Text = "更改目录";
               this.buttonChangeDirectory.UseVisualStyleBackColor = true;
               this.buttonChangeDirectory.Click += new System.EventHandler(this.buttonChangeDirectory_Click);
               // 
               // textWorkDirectory
               // 
               this.textWorkDirectory.Location = new System.Drawing.Point(183, 205);
               this.textWorkDirectory.Name = "textWorkDirectory";
               this.textWorkDirectory.Size = new System.Drawing.Size(645, 28);
               this.textWorkDirectory.TabIndex = 6;
               // 
               // tabPageSecurity
               // 
               this.tabPageSecurity.Controls.Add(this.labelSecretRank0);
               this.tabPageSecurity.Controls.Add(this.labelSecretRank1);
               this.tabPageSecurity.Controls.Add(this.labelSecretRank2);
               this.tabPageSecurity.Controls.Add(this.labelSecretRank3);
               this.tabPageSecurity.Controls.Add(this.colorComboRank0);
               this.tabPageSecurity.Controls.Add(this.colorComboRank3);
               this.tabPageSecurity.Controls.Add(this.colorComboRank1);
               this.tabPageSecurity.Controls.Add(this.colorComboRank2);
               this.tabPageSecurity.Location = new System.Drawing.Point(4, 28);
               this.tabPageSecurity.Name = "tabPageSecurity";
               this.tabPageSecurity.Padding = new System.Windows.Forms.Padding(3);
               this.tabPageSecurity.Size = new System.Drawing.Size(1032, 488);
               this.tabPageSecurity.TabIndex = 1;
               this.tabPageSecurity.Text = "Security";
               this.tabPageSecurity.UseVisualStyleBackColor = true;
               // 
               // labelSecretRank0
               // 
               this.labelSecretRank0.Location = new System.Drawing.Point(20, 37);
               this.labelSecretRank0.Name = "labelSecretRank0";
               this.labelSecretRank0.Size = new System.Drawing.Size(170, 30);
               this.labelSecretRank0.TabIndex = 0;
               this.labelSecretRank0.Text = "public color:";
               this.labelSecretRank0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // labelSecretRank1
               // 
               this.labelSecretRank1.Location = new System.Drawing.Point(20, 94);
               this.labelSecretRank1.Name = "labelSecretRank1";
               this.labelSecretRank1.Size = new System.Drawing.Size(170, 30);
               this.labelSecretRank1.TabIndex = 2;
               this.labelSecretRank1.Text = "secret color:";
               this.labelSecretRank1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // labelSecretRank2
               // 
               this.labelSecretRank2.Location = new System.Drawing.Point(20, 151);
               this.labelSecretRank2.Name = "labelSecretRank2";
               this.labelSecretRank2.Size = new System.Drawing.Size(170, 30);
               this.labelSecretRank2.TabIndex = 4;
               this.labelSecretRank2.Text = "confidential color:";
               this.labelSecretRank2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // labelSecretRank3
               // 
               this.labelSecretRank3.Location = new System.Drawing.Point(20, 208);
               this.labelSecretRank3.Name = "labelSecretRank3";
               this.labelSecretRank3.Size = new System.Drawing.Size(170, 30);
               this.labelSecretRank3.TabIndex = 6;
               this.labelSecretRank3.Text = "Top secret color:";
               this.labelSecretRank3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // colorComboRank0
               // 
               this.colorComboRank0.Color = System.Drawing.Color.Empty;
               this.colorComboRank0.Location = new System.Drawing.Point(192, 29);
               this.colorComboRank0.MinimumSize = new System.Drawing.Size(160, 34);
               this.colorComboRank0.Name = "colorComboRank0";
               this.colorComboRank0.Size = new System.Drawing.Size(300, 47);
               this.colorComboRank0.TabIndex = 1;
               // 
               // colorComboRank3
               // 
               this.colorComboRank3.Color = System.Drawing.Color.Empty;
               this.colorComboRank3.Location = new System.Drawing.Point(192, 200);
               this.colorComboRank3.MinimumSize = new System.Drawing.Size(160, 34);
               this.colorComboRank3.Name = "colorComboRank3";
               this.colorComboRank3.Size = new System.Drawing.Size(300, 47);
               this.colorComboRank3.TabIndex = 7;
               // 
               // colorComboRank1
               // 
               this.colorComboRank1.Color = System.Drawing.Color.Empty;
               this.colorComboRank1.Location = new System.Drawing.Point(192, 86);
               this.colorComboRank1.MinimumSize = new System.Drawing.Size(160, 34);
               this.colorComboRank1.Name = "colorComboRank1";
               this.colorComboRank1.Size = new System.Drawing.Size(300, 47);
               this.colorComboRank1.TabIndex = 3;
               // 
               // colorComboRank2
               // 
               this.colorComboRank2.Color = System.Drawing.Color.Empty;
               this.colorComboRank2.Location = new System.Drawing.Point(192, 143);
               this.colorComboRank2.MinimumSize = new System.Drawing.Size(160, 34);
               this.colorComboRank2.Name = "colorComboRank2";
               this.colorComboRank2.Size = new System.Drawing.Size(300, 47);
               this.colorComboRank2.TabIndex = 5;
               // 
               // formSystemOptions
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1078, 674);
               this.Controls.Add(this.tabControlMain);
               this.Controls.Add(this.buttonCancel);
               this.Controls.Add(this.buttonOK);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formSystemOptions";
               this.Text = "Options";
               ((System.ComponentModel.ISupportInitialize)(this.numericLockGlobalTime)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericLockAfterTime)).EndInit();
               this.tabControlMain.ResumeLayout(false);
               this.tabPageGeneral.ResumeLayout(false);
               this.tabPageGeneral.PerformLayout();
               this.tabPageSecurity.ResumeLayout(false);
               this.ResumeLayout(false);

          }

          #endregion

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               if(!this.checkLockAfterTime.Checked)
               {
                    this.originalConfig.LockWorkspace.LockAfterTime = 0;
               }
               else
               {
                    this.originalConfig.LockWorkspace.LockAfterTime = (uint)this.numericLockAfterTime.Value;
               }

               if(!this.checkLockGlobalTime.Checked)
               {
                    this.originalConfig.LockWorkspace.LockGlobalTime = 0;
               }
               else
               {
                    this.originalConfig.LockWorkspace.LockGlobalTime = (uint)this.numericLockGlobalTime.Value;
               }

               var tmpRequested = this.checkAutoRun.Checked;
               var currentValue = NativeShellHelper.GetStartWithWindows(ApplicationDefines.AutoRunName);
               if (tmpRequested != currentValue)
               {
                    var tmpExecutablePath = WindowsUtils.GetExecutablePath().Trim();
                    if (tmpExecutablePath.StartsWith("\"") == false)
                    {
                         tmpExecutablePath = "\"" + tmpExecutablePath + "\"";
                    }

                    NativeShellHelper.SetStartWithWindows(ApplicationDefines.AutoRunName, tmpExecutablePath, tmpRequested);
               }

               this.originalConfig.SecretRank.Rank0BackColor = this.colorComboRank0.Color;
               this.originalConfig.SecretRank.Rank1BackColor = this.colorComboRank1.Color;
               this.originalConfig.SecretRank.Rank2BackColor = this.colorComboRank2.Color;
               this.originalConfig.SecretRank.Rank3BackColor = this.colorComboRank3.Color;

               ApplicationConfigSerializer.SaveApplicationConfig(Program.Config);

               var tmpNewWorkDirectory = this.textWorkDirectory.Text;
               var tmpOldWorkDirectory = NativeShellHelper.GetWorkingDirectory();
               if (System.IO.Directory.Exists(tmpNewWorkDirectory))
               {
                    if (tmpNewWorkDirectory != tmpOldWorkDirectory)
                    {
                         MoveDirectoryTo(System.IO.Path.Combine(tmpOldWorkDirectory, "data"), tmpNewWorkDirectory);
                         MoveDirectoryTo(System.IO.Path.Combine(tmpOldWorkDirectory, "config"), tmpNewWorkDirectory);

                         Program.Config.WorkingDirectory = tmpNewWorkDirectory;
                         NativeShellHelper.SetWorkingDirectory(tmpNewWorkDirectory);
                         HuiruiSoft.Data.Configuration.DataBaseConfig.DataSource = System.IO.Path.Combine(Program.Config.WorkingDirectory, ApplicationDefines.SafePassDbFile);
                    }
               }

               this.DialogResult = DialogResult.OK;
          }

          private void checkAutoRun_CheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState( );
          }

          private void OnLockAfterTimeCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState( );
          }

          private void OnLockAfterGlobalCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState( );
          }

          private void numericLockAfterTime_ValueChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState( );
          }

          private void numericLockGlobalTime_ValueChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnColorSelectorColorChanged(object sender, HuiruiSoft.UI.Controls.ColorChangedEventArgs args)
          {
               this.UpdateControlState();
          }

          private void UpdateControlState( )
          {
               if (!this.blockUpdateControls)
               {
                    this.blockUpdateControls = true;
                    this.numericLockAfterTime.Enabled = (this.checkLockAfterTime.Checked && this.checkLockAfterTime.Enabled);

                    if (WindowsUtils.IsWindows9x || NativeMethods.IsUnix())
                    {
                         this.checkLockGlobalTime.Checked = false;
                         this.checkLockGlobalTime.Enabled = false;
                         this.numericLockGlobalTime.Enabled = false;
                    }
                    else
                    {
                         this.numericLockGlobalTime.Enabled = (this.checkLockGlobalTime.Checked && this.checkLockGlobalTime.Enabled);
                    }

                    this.blockUpdateControls = false;

                    if (this.originalConfig != null)
                    {
                         var tmpNotModified = true;

                         if (tmpNotModified)
                         {
                              tmpNotModified = (this.originalConfig.LockWorkspace.LockAfterTime == (uint)this.numericLockAfterTime.Value);
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.originalConfig.LockWorkspace.LockGlobalTime == (uint)this.numericLockGlobalTime.Value;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.checkAutoRun.Checked == NativeShellHelper.GetStartWithWindows(ApplicationDefines.AutoRunName);
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.originalConfig.SecretRank.Rank0BackColor == this.colorComboRank0.Color;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.originalConfig.SecretRank.Rank1BackColor == this.colorComboRank1.Color;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.originalConfig.SecretRank.Rank2BackColor == this.colorComboRank2.Color;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.originalConfig.SecretRank.Rank3BackColor == this.colorComboRank3.Color;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = string.Equals(this.textWorkDirectory.Text, Program.Config.WorkingDirectory, System.StringComparison.CurrentCultureIgnoreCase);
                         }

                         this.buttonOK.Enabled = !tmpNotModified;
                    }
               }
          }

          private void buttonChangeDirectory_Click(object sender, System.EventArgs args)
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
                    this.UpdateControlState();
               }
          }

          public static void MoveDirectoryTo(string sourceDirectory, string targetDirectory)
          {
               var tmpSourceDirectory = new System.IO.DirectoryInfo(sourceDirectory);
               if (tmpSourceDirectory.Exists)
               {
                    var tmpFolderName = tmpSourceDirectory.Name;
                    var tmpTargetPath = System.IO.Path.Combine(targetDirectory, tmpFolderName);
                    if (!System.IO.Directory.Exists(tmpTargetPath))
                    {
                         try
                         {
                              System.IO.Directory.CreateDirectory(tmpTargetPath);
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              System.Diagnostics.Debug.WriteLine(exception.Message);
                         }
                    }

                    var tmpFileInfos = tmpSourceDirectory.GetFiles();
                    foreach (var tmpFileInfo in tmpFileInfos)
                    {
                         try
                         {
                              tmpFileInfo.CopyTo(System.IO.Path.Combine(tmpTargetPath, tmpFileInfo.Name), true);
                              tmpFileInfo.Delete();
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              System.Diagnostics.Debug.WriteLine(exception.Message);
                         }
                    }

                    var tmpSubDirectories = tmpSourceDirectory.GetDirectories();
                    foreach (var tmpDirectoryInfo in tmpSubDirectories)
                    {
                         MoveDirectoryTo(System.IO.Path.Combine(sourceDirectory, tmpDirectoryInfo.Name), tmpTargetPath);
                    }

                    if (tmpSourceDirectory.GetFiles().Length == 0 && tmpSourceDirectory.GetDirectories().Length == 0)
                    {
                         try
                         {
                              tmpSourceDirectory.Delete();
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              System.Diagnostics.Debug.WriteLine(exception.Message);
                         }
                    }
               }
          }
     }
}
