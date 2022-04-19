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
          private SecurityConfig originalConfig = null;

          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.TabPage tabPageGeneral;
          private System.Windows.Forms.TabPage tabPageSecurity;
          private System.Windows.Forms.TabPage tabPageSecretLevel;
          private System.Windows.Forms.TabControl tabControlMain;
          private System.Windows.Forms.Label labelWorkDirectory;
          private System.Windows.Forms.TextBox textWorkDirectory;
          private System.Windows.Forms.Button buttonChangeDirectory;
          private System.Windows.Forms.CheckBox checkAutoRunAtStartup;
          private System.Windows.Forms.CheckBox checkTrayIconSingleClick;
          private System.Windows.Forms.CheckBox checkMinimizeWindowToTray;
          private System.Windows.Forms.CheckBox checkLockWindowAfterTime;
          private System.Windows.Forms.CheckBox checkLockScreenAfterTime;
          private System.Windows.Forms.CheckBox checkClearClipboardTime;
          private System.Windows.Forms.CheckBox checkMinimizeAtCloseButton;
          private System.Windows.Forms.CheckBox checkLockOnMinimizeToTray;
          private System.Windows.Forms.CheckBox checkLockOnMinimizeTaskbar;
          private System.Windows.Forms.CheckBox checkExitInsteadOfLockAfterTime;
          private System.Windows.Forms.NumericUpDown numericLockWindowAfterTime;
          private System.Windows.Forms.NumericUpDown numericLockScreenAfterTime;
          private System.Windows.Forms.NumericUpDown numericClearClipboardTime;
          private System.Windows.Forms.Label labelSecretRank0;
          private System.Windows.Forms.Label labelSecretRank1;
          private System.Windows.Forms.Label labelSecretRank2;
          private System.Windows.Forms.Label labelSecretRank3;
          private HuiruiSoft.UI.Controls.ColorBoxCombo colorComboRank0;
          private HuiruiSoft.UI.Controls.ColorBoxCombo colorComboRank3;
          private HuiruiSoft.UI.Controls.ColorBoxCombo colorComboRank1;
          private HuiruiSoft.UI.Controls.ColorBoxCombo colorComboRank2;

          internal formSystemOptions()
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
                    this.textWorkDirectory.ReadOnly = true;
                    this.numericLockWindowAfterTime.Minimum = 30;
                    this.numericLockWindowAfterTime.Maximum = 12 * 60 * 60;
                    this.numericLockWindowAfterTime.Increment = 5;

                    this.numericLockScreenAfterTime.Minimum = 60;
                    this.numericLockScreenAfterTime.Maximum = 24 * 60 * 60;
                    this.numericLockScreenAfterTime.Increment = 5;

                    this.numericClearClipboardTime.Minimum = 8;
                    this.numericClearClipboardTime.Maximum = 5 * 60;
                    this.numericClearClipboardTime.Increment = 1;

                    this.LoadSystemOptions();

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.OptionWindowCaption;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;
                    this.tabPageGeneral.Text = SafePassResource.OptionWindowTabPageGeneral;
                    this.tabPageSecurity.Text = SafePassResource.OptionWindowTabPageSecurity;
                    this.tabPageSecretLevel.Text = SafePassResource.OptionWindowTabPageSecretLevel;
                    this.labelSecretRank0.Text = SafePassResource.OptionWindowSecretPublicColor;
                    this.labelSecretRank1.Text = SafePassResource.OptionWindowSecretSecretColor;
                    this.labelSecretRank2.Text = SafePassResource.OptionWindowSecretConfidentialColor;
                    this.labelSecretRank3.Text = SafePassResource.OptionWindowSecretTopSecretColor;
                    this.labelWorkDirectory.Text = SafePassResource.OptionWindowLabelWorkDirectory;
                    this.buttonChangeDirectory.Text = SafePassResource.OptionWindowButtonChangeDirectory;
                    this.checkAutoRunAtStartup.Text = SafePassResource.OptionWindowCheckBoxAutoRunAtStartup;
                    this.checkLockWindowAfterTime.Text = SafePassResource.OptionWindowCheckBoxLockWindowAfterTime;
                    this.checkLockScreenAfterTime.Text = SafePassResource.OptionWindowCheckBoxLockScreenAfterTime;

                    this.checkTrayIconSingleClick.Text = SafePassResource.OptionWindowCheckBoxTrayIconSingleClick;
                    this.checkMinimizeWindowToTray.Text = SafePassResource.OptionWindowCheckBoxMinimizeWindowToTray;
                    this.checkClearClipboardTime.Text = SafePassResource.OptionWindowCheckBoxClearClipboardTime;
                    this.checkMinimizeAtCloseButton.Text = SafePassResource.OptionWindowCheckBoxMinimizeAtCloseButton;
                    this.checkLockOnMinimizeToTray.Text = SafePassResource.OptionWindowCheckBoxLockOnMinimizeToTray;
                    this.checkLockOnMinimizeTaskbar.Text = SafePassResource.OptionWindowCheckBoxLockOnMinimizeTaskbar;
                    this.checkExitInsteadOfLockAfterTime.Text = SafePassResource.OptionWindowCheckBoxExitInsteadOfLockAfterTime;

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

          private void LoadSystemOptions()
          {
               this.originalConfig = Program.Config.Application.Security;

               var tmpLockSettings = this.originalConfig.LockWorkspace;
               var tmpLockWindowTime = tmpLockSettings.LockWindowAfterTime;
               var tmpLockWorkspace = tmpLockWindowTime > 0;
               this.numericLockWindowAfterTime.Value = (tmpLockWorkspace ? tmpLockWindowTime : 100);
               this.checkLockWindowAfterTime.Checked = tmpLockWorkspace;
               this.numericLockWindowAfterTime.Enabled = (this.checkLockWindowAfterTime.Checked && this.checkLockWindowAfterTime.Enabled);

               var tmpLockScreenTime = tmpLockSettings.LockScreenAfterTime;
               var tmpLockWorkStation = tmpLockScreenTime > 0;
               this.numericLockScreenAfterTime.Value = (tmpLockWorkStation ? tmpLockScreenTime : 200);
               this.checkLockScreenAfterTime.Checked = tmpLockWorkStation;
               this.numericLockScreenAfterTime.Enabled = (this.checkLockScreenAfterTime.Checked && this.checkLockScreenAfterTime.Enabled);

               this.checkExitInsteadOfLockAfterTime.Checked = tmpLockSettings.ExitInsteadOfLockAfterTime;

               var tmpClipSettings = this.originalConfig.Clipboard;
               var tmpClearClipboard = tmpClipSettings.ClipboardClearAfterSeconds > 0;
               this.numericClearClipboardTime.Value = (tmpClearClipboard ? tmpClipSettings.ClipboardClearAfterSeconds : 10);
               this.checkClearClipboardTime.Checked = tmpLockWorkStation;
               this.numericClearClipboardTime.Enabled = (this.checkClearClipboardTime.Checked && this.checkClearClipboardTime.Enabled);

               this.checkTrayIconSingleClick.Checked = Program.Config.MainWindow.ActionTraySingleClick;
               this.checkMinimizeWindowToTray.Checked = Program.Config.MainWindow.MinimizeWindowToTray;
               this.checkMinimizeAtCloseButton.Checked = Program.Config.MainWindow.MinimizeAtCloseButton;
               this.checkLockOnMinimizeToTray.Checked = this.originalConfig.LockWorkspace.LockOnMinimizeToTray;
               this.checkLockOnMinimizeTaskbar.Checked = this.originalConfig.LockWorkspace.LockOnMinimizeTaskbar;

               this.colorComboRank0.Color = this.originalConfig.SecretRank.Rank0BackColor;
               this.colorComboRank1.Color = this.originalConfig.SecretRank.Rank1BackColor;
               this.colorComboRank2.Color = this.originalConfig.SecretRank.Rank2BackColor;
               this.colorComboRank3.Color = this.originalConfig.SecretRank.Rank3BackColor;

               this.textWorkDirectory.Text = Program.Config.WorkingDirectory;

               this.checkAutoRunAtStartup.Checked = NativeShellHelper.GetStartWithWindows(ApplicationDefines.AutoRunName);
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
               this.buttonCancel = new System.Windows.Forms.Button();
               this.buttonOK = new System.Windows.Forms.Button();
               this.numericLockScreenAfterTime = new System.Windows.Forms.NumericUpDown();
               this.checkLockScreenAfterTime = new System.Windows.Forms.CheckBox();
               this.checkLockWindowAfterTime = new System.Windows.Forms.CheckBox();
               this.numericLockWindowAfterTime = new System.Windows.Forms.NumericUpDown();
               this.checkAutoRunAtStartup = new System.Windows.Forms.CheckBox();
               this.tabControlMain = new System.Windows.Forms.TabControl();
               this.tabPageGeneral = new System.Windows.Forms.TabPage();
               this.checkTrayIconSingleClick = new System.Windows.Forms.CheckBox();
               this.checkMinimizeWindowToTray = new System.Windows.Forms.CheckBox();
               this.checkMinimizeAtCloseButton = new System.Windows.Forms.CheckBox();
               this.labelWorkDirectory = new System.Windows.Forms.Label();
               this.buttonChangeDirectory = new System.Windows.Forms.Button();
               this.textWorkDirectory = new System.Windows.Forms.TextBox();
               this.tabPageSecurity = new System.Windows.Forms.TabPage();
               this.checkExitInsteadOfLockAfterTime = new System.Windows.Forms.CheckBox();
               this.checkLockOnMinimizeToTray = new System.Windows.Forms.CheckBox();
               this.numericClearClipboardTime = new System.Windows.Forms.NumericUpDown();
               this.checkClearClipboardTime = new System.Windows.Forms.CheckBox();
               this.checkLockOnMinimizeTaskbar = new System.Windows.Forms.CheckBox();
               this.tabPageSecretLevel = new System.Windows.Forms.TabPage();
               this.labelSecretRank0 = new System.Windows.Forms.Label();
               this.labelSecretRank1 = new System.Windows.Forms.Label();
               this.labelSecretRank2 = new System.Windows.Forms.Label();
               this.labelSecretRank3 = new System.Windows.Forms.Label();
               this.colorComboRank0 = new HuiruiSoft.UI.Controls.ColorBoxCombo();
               this.colorComboRank3 = new HuiruiSoft.UI.Controls.ColorBoxCombo();
               this.colorComboRank1 = new HuiruiSoft.UI.Controls.ColorBoxCombo();
               this.colorComboRank2 = new HuiruiSoft.UI.Controls.ColorBoxCombo();
               ((System.ComponentModel.ISupportInitialize)(this.numericLockScreenAfterTime)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericLockWindowAfterTime)).BeginInit();
               this.tabControlMain.SuspendLayout();
               this.tabPageGeneral.SuspendLayout();
               this.tabPageSecurity.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.numericClearClipboardTime)).BeginInit();
               this.tabPageSecretLevel.SuspendLayout();
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
               // numericLockScreenAfterTime
               // 
               this.numericLockScreenAfterTime.Location = new System.Drawing.Point(580, 127);
               this.numericLockScreenAfterTime.Margin = new System.Windows.Forms.Padding(4);
               this.numericLockScreenAfterTime.Maximum = new decimal(new int[] {
            1209600,
            0,
            0,
            0});
               this.numericLockScreenAfterTime.Name = "numericLockScreenAfterTime";
               this.numericLockScreenAfterTime.Size = new System.Drawing.Size(100, 28);
               this.numericLockScreenAfterTime.TabIndex = 4;
               this.numericLockScreenAfterTime.ValueChanged += new System.EventHandler(this.OnLockScreenAfterTimeEditorValueChanged);
               // 
               // checkLockScreenAfterTime
               // 
               this.checkLockScreenAfterTime.AutoSize = true;
               this.checkLockScreenAfterTime.Location = new System.Drawing.Point(30, 130);
               this.checkLockScreenAfterTime.Margin = new System.Windows.Forms.Padding(4);
               this.checkLockScreenAfterTime.Name = "checkLockScreenAfterTime";
               this.checkLockScreenAfterTime.Size = new System.Drawing.Size(466, 22);
               this.checkLockScreenAfterTime.TabIndex = 3;
               this.checkLockScreenAfterTime.Text = "Operating system inactivity lock time (seconds):";
               this.checkLockScreenAfterTime.UseVisualStyleBackColor = true;
               this.checkLockScreenAfterTime.CheckedChanged += new System.EventHandler(this.OnLockScreenAfterTimeCheckedChanged);
               // 
               // checkLockWindowAfterTime
               // 
               this.checkLockWindowAfterTime.AutoSize = true;
               this.checkLockWindowAfterTime.Location = new System.Drawing.Point(30, 30);
               this.checkLockWindowAfterTime.Margin = new System.Windows.Forms.Padding(4);
               this.checkLockWindowAfterTime.Name = "checkLockWindowAfterTime";
               this.checkLockWindowAfterTime.Size = new System.Drawing.Size(493, 22);
               this.checkLockWindowAfterTime.TabIndex = 0;
               this.checkLockWindowAfterTime.Text = "Time the main window was locked inactive (seconds):";
               this.checkLockWindowAfterTime.UseVisualStyleBackColor = true;
               this.checkLockWindowAfterTime.CheckedChanged += new System.EventHandler(this.OnLockWindowAfterTimeCheckedChanged);
               // 
               // numericLockWindowAfterTime
               // 
               this.numericLockWindowAfterTime.Location = new System.Drawing.Point(580, 27);
               this.numericLockWindowAfterTime.Margin = new System.Windows.Forms.Padding(4);
               this.numericLockWindowAfterTime.Maximum = new decimal(new int[] {
            1209600,
            0,
            0,
            0});
               this.numericLockWindowAfterTime.Name = "numericLockWindowAfterTime";
               this.numericLockWindowAfterTime.Size = new System.Drawing.Size(100, 28);
               this.numericLockWindowAfterTime.TabIndex = 1;
               this.numericLockWindowAfterTime.ValueChanged += new System.EventHandler(this.OnLockWindowAfterTimeEditorValueChanged);
               // 
               // checkAutoRunAtStartup
               // 
               this.checkAutoRunAtStartup.AutoSize = true;
               this.checkAutoRunAtStartup.Location = new System.Drawing.Point(30, 30);
               this.checkAutoRunAtStartup.Name = "checkAutoRunAtStartup";
               this.checkAutoRunAtStartup.Size = new System.Drawing.Size(493, 22);
               this.checkAutoRunAtStartup.TabIndex = 0;
               this.checkAutoRunAtStartup.Text = "Auto run SafePass at Windows startup (current user)";
               this.checkAutoRunAtStartup.UseVisualStyleBackColor = true;
               this.checkAutoRunAtStartup.CheckedChanged += new System.EventHandler(this.OnAutoRunAtStartupCheckedChanged);
               // 
               // tabControlMain
               // 
               this.tabControlMain.Controls.Add(this.tabPageGeneral);
               this.tabControlMain.Controls.Add(this.tabPageSecurity);
               this.tabControlMain.Controls.Add(this.tabPageSecretLevel);
               this.tabControlMain.Location = new System.Drawing.Point(19, 29);
               this.tabControlMain.Name = "tabControlMain";
               this.tabControlMain.SelectedIndex = 0;
               this.tabControlMain.Size = new System.Drawing.Size(1040, 520);
               this.tabControlMain.TabIndex = 0;
               // 
               // tabPageGeneral
               // 
               this.tabPageGeneral.Controls.Add(this.checkTrayIconSingleClick);
               this.tabPageGeneral.Controls.Add(this.checkMinimizeWindowToTray);
               this.tabPageGeneral.Controls.Add(this.checkMinimizeAtCloseButton);
               this.tabPageGeneral.Controls.Add(this.labelWorkDirectory);
               this.tabPageGeneral.Controls.Add(this.buttonChangeDirectory);
               this.tabPageGeneral.Controls.Add(this.textWorkDirectory);
               this.tabPageGeneral.Controls.Add(this.checkAutoRunAtStartup);
               this.tabPageGeneral.Location = new System.Drawing.Point(4, 28);
               this.tabPageGeneral.Name = "tabPageGeneral";
               this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
               this.tabPageGeneral.Size = new System.Drawing.Size(1032, 488);
               this.tabPageGeneral.TabIndex = 0;
               this.tabPageGeneral.Text = "General";
               this.tabPageGeneral.UseVisualStyleBackColor = true;
               // 
               // checkTrayIconSingleClick
               // 
               this.checkTrayIconSingleClick.AutoSize = true;
               this.checkTrayIconSingleClick.Location = new System.Drawing.Point(30, 180);
               this.checkTrayIconSingleClick.Name = "checkTrayIconSingleClick";
               this.checkTrayIconSingleClick.Size = new System.Drawing.Size(619, 22);
               this.checkTrayIconSingleClick.TabIndex = 3;
               this.checkTrayIconSingleClick.Text = "Single click instead of double click to activate tray icon action";
               this.checkTrayIconSingleClick.UseVisualStyleBackColor = true;
               this.checkTrayIconSingleClick.CheckedChanged += new System.EventHandler(this.OnTrayIconSingleClickCheckedChanged);
               // 
               // checkMinimizeWindowToTray
               // 
               this.checkMinimizeWindowToTray.AutoSize = true;
               this.checkMinimizeWindowToTray.Location = new System.Drawing.Point(30, 130);
               this.checkMinimizeWindowToTray.Name = "checkMinimizeWindowToTray";
               this.checkMinimizeWindowToTray.Size = new System.Drawing.Size(349, 22);
               this.checkMinimizeWindowToTray.TabIndex = 2;
               this.checkMinimizeWindowToTray.Text = "Minimize to tray instead of taskbar";
               this.checkMinimizeWindowToTray.UseVisualStyleBackColor = true;
               this.checkMinimizeWindowToTray.CheckedChanged += new System.EventHandler(this.OnMinimizeWindowToTrayCheckedChanged);
               // 
               // checkMinimizeAtCloseButton
               // 
               this.checkMinimizeAtCloseButton.AutoSize = true;
               this.checkMinimizeAtCloseButton.Location = new System.Drawing.Point(30, 80);
               this.checkMinimizeAtCloseButton.Name = "checkMinimizeAtCloseButton";
               this.checkMinimizeAtCloseButton.Size = new System.Drawing.Size(799, 22);
               this.checkMinimizeAtCloseButton.TabIndex = 1;
               this.checkMinimizeAtCloseButton.Text = "Click the Close button to minimize the main window instead of exiting the applica" +
    "tion";
               this.checkMinimizeAtCloseButton.UseVisualStyleBackColor = true;
               this.checkMinimizeAtCloseButton.CheckedChanged += new System.EventHandler(this.OnMinimizeAtCloseButtonCheckedChanged);
               // 
               // labelWorkDirectory
               // 
               this.labelWorkDirectory.Location = new System.Drawing.Point(23, 255);
               this.labelWorkDirectory.Name = "labelWorkDirectory";
               this.labelWorkDirectory.Size = new System.Drawing.Size(165, 20);
               this.labelWorkDirectory.TabIndex = 4;
               this.labelWorkDirectory.Text = "Work directory:";
               this.labelWorkDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // buttonChangeDirectory
               // 
               this.buttonChangeDirectory.Location = new System.Drawing.Point(842, 235);
               this.buttonChangeDirectory.Name = "buttonChangeDirectory";
               this.buttonChangeDirectory.Size = new System.Drawing.Size(180, 60);
               this.buttonChangeDirectory.TabIndex = 6;
               this.buttonChangeDirectory.Text = "Change directory";
               this.buttonChangeDirectory.UseVisualStyleBackColor = true;
               this.buttonChangeDirectory.Click += new System.EventHandler(this.buttonChangeDirectory_Click);
               // 
               // textWorkDirectory
               // 
               this.textWorkDirectory.Location = new System.Drawing.Point(193, 251);
               this.textWorkDirectory.Name = "textWorkDirectory";
               this.textWorkDirectory.Size = new System.Drawing.Size(645, 28);
               this.textWorkDirectory.TabIndex = 5;
               // 
               // tabPageSecurity
               // 
               this.tabPageSecurity.Controls.Add(this.checkExitInsteadOfLockAfterTime);
               this.tabPageSecurity.Controls.Add(this.checkLockOnMinimizeToTray);
               this.tabPageSecurity.Controls.Add(this.numericClearClipboardTime);
               this.tabPageSecurity.Controls.Add(this.checkClearClipboardTime);
               this.tabPageSecurity.Controls.Add(this.checkLockOnMinimizeTaskbar);
               this.tabPageSecurity.Controls.Add(this.checkLockScreenAfterTime);
               this.tabPageSecurity.Controls.Add(this.numericLockWindowAfterTime);
               this.tabPageSecurity.Controls.Add(this.numericLockScreenAfterTime);
               this.tabPageSecurity.Controls.Add(this.checkLockWindowAfterTime);
               this.tabPageSecurity.Location = new System.Drawing.Point(4, 28);
               this.tabPageSecurity.Name = "tabPageSecurity";
               this.tabPageSecurity.Padding = new System.Windows.Forms.Padding(3);
               this.tabPageSecurity.Size = new System.Drawing.Size(1032, 488);
               this.tabPageSecurity.TabIndex = 1;
               this.tabPageSecurity.Text = "Security";
               this.tabPageSecurity.UseVisualStyleBackColor = true;
               // 
               // checkExitInsteadOfLockAfterTime
               // 
               this.checkExitInsteadOfLockAfterTime.AutoSize = true;
               this.checkExitInsteadOfLockAfterTime.Location = new System.Drawing.Point(70, 80);
               this.checkExitInsteadOfLockAfterTime.Margin = new System.Windows.Forms.Padding(4);
               this.checkExitInsteadOfLockAfterTime.Name = "checkExitInsteadOfLockAfterTime";
               this.checkExitInsteadOfLockAfterTime.Size = new System.Drawing.Size(673, 22);
               this.checkExitInsteadOfLockAfterTime.TabIndex = 2;
               this.checkExitInsteadOfLockAfterTime.Text = "Exit application instead of lock the workspace after the specified time";
               this.checkExitInsteadOfLockAfterTime.UseVisualStyleBackColor = true;
               this.checkExitInsteadOfLockAfterTime.CheckedChanged += new System.EventHandler(this.OnExitInsteadOfLockAfterTimeCheckedChanged);
               // 
               // checkLockOnMinimizeToTray
               // 
               this.checkLockOnMinimizeToTray.AutoSize = true;
               this.checkLockOnMinimizeToTray.Location = new System.Drawing.Point(30, 280);
               this.checkLockOnMinimizeToTray.Name = "checkLockOnMinimizeToTray";
               this.checkLockOnMinimizeToTray.Size = new System.Drawing.Size(538, 22);
               this.checkLockOnMinimizeToTray.TabIndex = 8;
               this.checkLockOnMinimizeToTray.Text = "Lock workspace when the main window is minimized to tray";
               this.checkLockOnMinimizeToTray.UseVisualStyleBackColor = true;
               this.checkLockOnMinimizeToTray.CheckedChanged += new System.EventHandler(this.OnLockOnMinimizeToTrayCheckedChanged);
               // 
               // numericClearClipboardTime
               // 
               this.numericClearClipboardTime.Location = new System.Drawing.Point(580, 177);
               this.numericClearClipboardTime.Margin = new System.Windows.Forms.Padding(4);
               this.numericClearClipboardTime.Maximum = new decimal(new int[] {
            1209600,
            0,
            0,
            0});
               this.numericClearClipboardTime.Name = "numericClearClipboardTime";
               this.numericClearClipboardTime.Size = new System.Drawing.Size(100, 28);
               this.numericClearClipboardTime.TabIndex = 6;
               this.numericClearClipboardTime.ValueChanged += new System.EventHandler(this.OnClearClipboardTimeEditorValueChanged);
               // 
               // checkClearClipboardTime
               // 
               this.checkClearClipboardTime.AutoSize = true;
               this.checkClearClipboardTime.Location = new System.Drawing.Point(30, 180);
               this.checkClearClipboardTime.Name = "checkClearClipboardTime";
               this.checkClearClipboardTime.Size = new System.Drawing.Size(403, 22);
               this.checkClearClipboardTime.TabIndex = 5;
               this.checkClearClipboardTime.Text = "Clipboard data auto-clear time (seconds):";
               this.checkClearClipboardTime.UseVisualStyleBackColor = true;
               this.checkClearClipboardTime.CheckedChanged += new System.EventHandler(this.OnClearClipboardTimeCheckedChanged);
               // 
               // checkLockOnMinimizeTaskbar
               // 
               this.checkLockOnMinimizeTaskbar.AutoSize = true;
               this.checkLockOnMinimizeTaskbar.Location = new System.Drawing.Point(30, 230);
               this.checkLockOnMinimizeTaskbar.Name = "checkLockOnMinimizeTaskbar";
               this.checkLockOnMinimizeTaskbar.Size = new System.Drawing.Size(565, 22);
               this.checkLockOnMinimizeTaskbar.TabIndex = 7;
               this.checkLockOnMinimizeTaskbar.Text = "Lock workspace when the main window is minimized to taskbar";
               this.checkLockOnMinimizeTaskbar.UseVisualStyleBackColor = true;
               this.checkLockOnMinimizeTaskbar.CheckedChanged += new System.EventHandler(this.OnLockOnMinimizeTaskbarCheckedChanged);
               // 
               // tabPageSecretLevel
               // 
               this.tabPageSecretLevel.Controls.Add(this.labelSecretRank0);
               this.tabPageSecretLevel.Controls.Add(this.labelSecretRank1);
               this.tabPageSecretLevel.Controls.Add(this.labelSecretRank2);
               this.tabPageSecretLevel.Controls.Add(this.labelSecretRank3);
               this.tabPageSecretLevel.Controls.Add(this.colorComboRank0);
               this.tabPageSecretLevel.Controls.Add(this.colorComboRank3);
               this.tabPageSecretLevel.Controls.Add(this.colorComboRank1);
               this.tabPageSecretLevel.Controls.Add(this.colorComboRank2);
               this.tabPageSecretLevel.Location = new System.Drawing.Point(4, 28);
               this.tabPageSecretLevel.Name = "tabPageSecretLevel";
               this.tabPageSecretLevel.Padding = new System.Windows.Forms.Padding(3);
               this.tabPageSecretLevel.Size = new System.Drawing.Size(1032, 488);
               this.tabPageSecretLevel.TabIndex = 2;
               this.tabPageSecretLevel.Text = "Secret level";
               this.tabPageSecretLevel.UseVisualStyleBackColor = true;
               // 
               // labelSecretRank0
               // 
               this.labelSecretRank0.Location = new System.Drawing.Point(32, 33);
               this.labelSecretRank0.Name = "labelSecretRank0";
               this.labelSecretRank0.Size = new System.Drawing.Size(170, 30);
               this.labelSecretRank0.TabIndex = 0;
               this.labelSecretRank0.Text = "public color:";
               this.labelSecretRank0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // labelSecretRank1
               // 
               this.labelSecretRank1.Location = new System.Drawing.Point(32, 90);
               this.labelSecretRank1.Name = "labelSecretRank1";
               this.labelSecretRank1.Size = new System.Drawing.Size(170, 30);
               this.labelSecretRank1.TabIndex = 2;
               this.labelSecretRank1.Text = "secret color:";
               this.labelSecretRank1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // labelSecretRank2
               // 
               this.labelSecretRank2.Location = new System.Drawing.Point(32, 147);
               this.labelSecretRank2.Name = "labelSecretRank2";
               this.labelSecretRank2.Size = new System.Drawing.Size(170, 30);
               this.labelSecretRank2.TabIndex = 4;
               this.labelSecretRank2.Text = "confidential color:";
               this.labelSecretRank2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // labelSecretRank3
               // 
               this.labelSecretRank3.Location = new System.Drawing.Point(32, 204);
               this.labelSecretRank3.Name = "labelSecretRank3";
               this.labelSecretRank3.Size = new System.Drawing.Size(170, 30);
               this.labelSecretRank3.TabIndex = 6;
               this.labelSecretRank3.Text = "Top secret color:";
               this.labelSecretRank3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // colorComboRank0
               // 
               this.colorComboRank0.Color = System.Drawing.Color.Empty;
               this.colorComboRank0.Location = new System.Drawing.Point(204, 25);
               this.colorComboRank0.MinimumSize = new System.Drawing.Size(160, 34);
               this.colorComboRank0.Name = "colorComboRank0";
               this.colorComboRank0.Size = new System.Drawing.Size(300, 47);
               this.colorComboRank0.TabIndex = 1;
               // 
               // colorComboRank3
               // 
               this.colorComboRank3.Color = System.Drawing.Color.Empty;
               this.colorComboRank3.Location = new System.Drawing.Point(204, 196);
               this.colorComboRank3.MinimumSize = new System.Drawing.Size(160, 34);
               this.colorComboRank3.Name = "colorComboRank3";
               this.colorComboRank3.Size = new System.Drawing.Size(300, 47);
               this.colorComboRank3.TabIndex = 7;
               // 
               // colorComboRank1
               // 
               this.colorComboRank1.Color = System.Drawing.Color.Empty;
               this.colorComboRank1.Location = new System.Drawing.Point(204, 82);
               this.colorComboRank1.MinimumSize = new System.Drawing.Size(160, 34);
               this.colorComboRank1.Name = "colorComboRank1";
               this.colorComboRank1.Size = new System.Drawing.Size(300, 47);
               this.colorComboRank1.TabIndex = 3;
               // 
               // colorComboRank2
               // 
               this.colorComboRank2.Color = System.Drawing.Color.Empty;
               this.colorComboRank2.Location = new System.Drawing.Point(204, 139);
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
               ((System.ComponentModel.ISupportInitialize)(this.numericLockScreenAfterTime)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericLockWindowAfterTime)).EndInit();
               this.tabControlMain.ResumeLayout(false);
               this.tabPageGeneral.ResumeLayout(false);
               this.tabPageGeneral.PerformLayout();
               this.tabPageSecurity.ResumeLayout(false);
               this.tabPageSecurity.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.numericClearClipboardTime)).EndInit();
               this.tabPageSecretLevel.ResumeLayout(false);
               this.ResumeLayout(false);

          }

          #endregion

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               if (!this.checkLockWindowAfterTime.Checked)
               {
                    this.originalConfig.LockWorkspace.LockWindowAfterTime = 0;
               }
               else
               {
                    this.originalConfig.LockWorkspace.LockWindowAfterTime = (uint)this.numericLockWindowAfterTime.Value;
               }

               this.originalConfig.LockWorkspace.ExitInsteadOfLockAfterTime = this.checkExitInsteadOfLockAfterTime.Checked;

               if (!this.checkLockScreenAfterTime.Checked)
               {
                    this.originalConfig.LockWorkspace.LockScreenAfterTime = 0;
               }
               else
               {
                    this.originalConfig.LockWorkspace.LockScreenAfterTime = (uint)this.numericLockScreenAfterTime.Value;
               }

               if (!this.checkClearClipboardTime.Checked)
               {
                    this.originalConfig.Clipboard.ClipboardClearAfterSeconds = 0;
               }
               else
               {
                    this.originalConfig.Clipboard.ClipboardClearAfterSeconds = (uint)this.numericClearClipboardTime.Value;
               }


               Program.Config.MainWindow.ActionTraySingleClick = this.checkTrayIconSingleClick.Checked;
               Program.Config.MainWindow.MinimizeWindowToTray = this.checkMinimizeWindowToTray.Checked;
               Program.Config.MainWindow.MinimizeAtCloseButton = this.checkMinimizeAtCloseButton.Checked;

               this.originalConfig.LockWorkspace.LockOnMinimizeToTray = this.checkLockOnMinimizeToTray.Checked;
               this.originalConfig.LockWorkspace.LockOnMinimizeTaskbar = this.checkLockOnMinimizeTaskbar.Checked;

               var tmpRequested = this.checkAutoRunAtStartup.Checked;
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

          private void OnAutoRunAtStartupCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnLockWindowAfterTimeCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnLockScreenAfterTimeCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnClearClipboardTimeCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnLockOnMinimizeTaskbarCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnMinimizeWindowToTrayCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnMinimizeAtCloseButtonCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnTrayIconSingleClickCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnLockOnMinimizeToTrayCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnExitInsteadOfLockAfterTimeCheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnLockWindowAfterTimeEditorValueChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnLockScreenAfterTimeEditorValueChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnClearClipboardTimeEditorValueChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnColorSelectorColorChanged(object sender, HuiruiSoft.UI.Controls.ColorChangedEventArgs args)
          {
               this.UpdateControlState();
          }

          private void UpdateControlState()
          {
               if (!this.blockUpdateControls)
               {
                    this.blockUpdateControls = true;
                    this.numericLockWindowAfterTime.Enabled = (this.checkLockWindowAfterTime.Checked && this.checkLockWindowAfterTime.Enabled);

                    if (WindowsUtils.IsWindows9x || NativeMethods.IsUnix())
                    {
                         this.checkLockScreenAfterTime.Checked = false;
                         this.checkLockScreenAfterTime.Enabled = false;
                         this.numericLockScreenAfterTime.Enabled = false;
                    }
                    else
                    {
                         this.numericLockScreenAfterTime.Enabled = (this.checkLockScreenAfterTime.Checked && this.checkLockScreenAfterTime.Enabled);
                    }

                    this.blockUpdateControls = false;

                    if (this.originalConfig != null)
                    {
                         var tmpNotModified = true;

                         if (tmpNotModified)
                         {
                              tmpNotModified = (this.originalConfig.LockWorkspace.LockWindowAfterTime == (uint)this.numericLockWindowAfterTime.Value);
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.originalConfig.LockWorkspace.LockScreenAfterTime == (uint)this.numericLockScreenAfterTime.Value;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.originalConfig.LockWorkspace.ExitInsteadOfLockAfterTime == this.checkExitInsteadOfLockAfterTime.Checked;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.originalConfig.Clipboard.ClipboardClearAfterSeconds == (uint)this.numericClearClipboardTime.Value;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.checkAutoRunAtStartup.Checked == NativeShellHelper.GetStartWithWindows(ApplicationDefines.AutoRunName);
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.checkTrayIconSingleClick.Checked == Program.Config.MainWindow.ActionTraySingleClick;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.checkMinimizeWindowToTray.Checked == Program.Config.MainWindow.MinimizeWindowToTray;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.checkMinimizeAtCloseButton.Checked == Program.Config.MainWindow.MinimizeAtCloseButton;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.checkLockOnMinimizeToTray.Checked == this.originalConfig.LockWorkspace.LockOnMinimizeToTray;
                         }

                         if (tmpNotModified)
                         {
                              tmpNotModified = this.checkLockOnMinimizeTaskbar.Checked == this.originalConfig.LockWorkspace.LockOnMinimizeTaskbar;
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
