using System.Windows.Forms;
using HuiruiSoft.Win32;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formAccountManager : Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private bool mainWindowLoaded = false;
          private bool mainWindowLocked = false;
          private readonly int applicationMessage = Program.ApplicationMessage;
          private FormWindowState lastWindowState = FormWindowState.Normal;
          private System.Collections.Generic.List<AccountModel> allAccountEntries = null;

          private System.Windows.Forms.Timer idleTickTimer = null;
          private HuiruiSoft.Safe.Service.AccountService accountService;
          private readonly string statusReady = SafePassResource.Ready;

          public formAccountManager()
          {
               this.InitializeComponent();
               this.dataGridAccount.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
               this.StartPosition = FormStartPosition.CenterScreen;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Visible = false;
                    this.MinimizeBox = true;
                    this.MaximizeBox = true;
                    this.ShowInTaskbar = true;
                    this.StartPosition = FormStartPosition.Manual;
                    this.splitControls.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.treeViewCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.dataGridAccount.Dock = System.Windows.Forms.DockStyle.Fill;

                    var tmpScreenBounds = Screen.PrimaryScreen.Bounds;

                    int tmpMinLocationX = -1 * (tmpScreenBounds.Width * 80 / 100);
                    int tmpMinLocationY = -1 * (tmpScreenBounds.Height * 80 / 100);

                    int tmpMinimumWidth = tmpScreenBounds.Width * 40 / 100;
                    int tmpMinimumHeight = tmpScreenBounds.Height * 40 / 100;

                    var tmpAppConfig = HuiruiSoft.Safe.Program.Config;
                    if (tmpAppConfig.MainWindow.X < tmpMinLocationX)
                    {
                         tmpAppConfig.MainWindow.X = 0;
                    }

                    if (tmpAppConfig.MainWindow.X > tmpScreenBounds.Width * 90 / 100)
                    {
                         tmpAppConfig.MainWindow.X = tmpScreenBounds.Width * 90 / 100;
                    }

                    if (tmpAppConfig.MainWindow.Y < tmpMinLocationY)
                    {
                         tmpAppConfig.MainWindow.Y = 0;
                    }

                    if (tmpAppConfig.MainWindow.Y > tmpScreenBounds.Height * 90 / 100)
                    {
                         tmpAppConfig.MainWindow.Y = tmpScreenBounds.Height * 90 / 100;
                    }

                    if (tmpAppConfig.MainWindow.Width < tmpMinimumWidth)
                    {
                         tmpAppConfig.MainWindow.Width = tmpMinimumWidth;
                    }

                    if (tmpAppConfig.MainWindow.Width > tmpScreenBounds.Width)
                    {
                         tmpAppConfig.MainWindow.Width = tmpScreenBounds.Width;
                    }

                    if (tmpAppConfig.MainWindow.Height < tmpMinimumHeight)
                    {
                         tmpAppConfig.MainWindow.Height = tmpMinimumHeight;
                    }

                    if (tmpAppConfig.MainWindow.Height > tmpScreenBounds.Height)
                    {
                         tmpAppConfig.MainWindow.Height = tmpScreenBounds.Height;
                    }

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.TopMost = tmpAppConfig.MainWindow.TopMost;
                    this.MinimumSize = new System.Drawing.Size(tmpMinimumWidth, tmpMinimumHeight);
                    this.Location = new System.Drawing.Point(tmpAppConfig.MainWindow.X, tmpAppConfig.MainWindow.Y);
                    this.ClientSize = new System.Drawing.Size(tmpAppConfig.MainWindow.Width, tmpAppConfig.MainWindow.Height);

                    this.notifyIconTray.Icon = this.Icon;
                    this.notifyIconTray.Visible = true;
                    this.notifyIconTray.ContextMenuStrip = this.menuStripTray;

                    this.splitControls.Panel1MinSize = 150;
                    this.splitControls.Panel2MinSize = 200;
                    if (tmpAppConfig.MainWindow.SplitPosition >= 8)
                    {
                         this.splitControls.SplitterDistance = (int)(this.splitControls.Width * tmpAppConfig.MainWindow.SplitPosition / 100);
                    }

                    this.accountService = new HuiruiSoft.Safe.Service.AccountService();

                    this.CreateSpecialTreeNode();
                    this.InitializeToolBar();
                    this.InitializeTreeView();
                    this.InitializeAccountDataGrid();

                    this.toolComboBoxQuickFind.AutoCompleteMode = AutoCompleteMode.Suggest;
                    this.toolComboBoxQuickFind.AutoCompleteSource = AutoCompleteSource.ListItems;

                    this.idleTickTimer = new System.Windows.Forms.Timer();
                    this.idleTickTimer.Tick += this.OnIdleTickTimerElapsed;
                    this.idleTickTimer.Interval = 1 * 1000;
                    this.idleTickTimer.Start();

                    this.Visible = true;
                    this.NotifyUserActivity();

                    if (Program.Config.MainWindow.Maximized)
                    {
                         this.lastWindowState = this.WindowState;
                         WindowsUtils.SetWindowState(this, FormWindowState.Maximized);
                    }
                    else if (Program.Config.MainWindow.Minimized)
                    {
                         WindowsUtils.SetWindowState(this, FormWindowState.Minimized);
                    }
                    else
                    {
                         WindowsUtils.SetWindowState(this, FormWindowState.Normal);
                    }

                    this.treeViewCatalog.ContextMenuStrip = this.menuStripTreeView;
                    this.dataGridAccount.ContextMenuStrip = this.menuStripDataGrid;

                    this.GetCatalogChildAccounts(true);

                    this.statusPartProgress.Visible = false;
                    this.statusPartClipboard.Visible = false;
                    this.UpdateClipboardStatus();

                    System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(OnFormLoadParallelAsync));
               }

               this.mainWindowLoaded = true;
          }

          private static void OnFormLoadParallelAsync(object stateInfo)
          {
               //
          }

          protected override void OnLocationChanged(System.EventArgs args)
          {
               base.OnLocationChanged(args);

               if (this.mainWindowLoaded)
               {
                    this.SaveWindowClientRectangle();
               }
          }

          protected override void OnResizeEnd(System.EventArgs args)
          {
               base.OnResizeEnd(args);

               if (this.mainWindowLoaded)
               {
                    this.SaveWindowClientRectangle();
               }
          }

          private bool forceExitWorkspace = false;
          private bool restartApplication = false;

          protected override void OnFormClosed(FormClosedEventArgs args)
          {
               base.OnFormClosed(args);

               if (this.restartApplication)
               {
                    NativeShellHelper.StartProcess(WindowsUtils.GetExecutablePath());
               }
          }

          protected override void OnFormClosing(FormClosingEventArgs args)
          {
               base.OnFormClosing(args);

               this.SaveWindowClientRectangle();
               if (!this.forceExitWorkspace)
               {
                    switch (args.CloseReason)
                    {
                         case CloseReason.WindowsShutDown:
                         case CloseReason.TaskManagerClosing:
                         case CloseReason.ApplicationExitCall:
                              break;

                         case CloseReason.None:
                         case CloseReason.UserClosing:
                         case CloseReason.FormOwnerClosing:
                         default:
                              if (Program.Config.MainWindow.MinimizeAtCloseButton)
                              {
                                   args.Cancel = true;
                                   WindowsUtils.SetWindowState(this, FormWindowState.Minimized);
                                   return;
                              }
                              break;
                    }
               }

               this.forceExitWorkspace = false;
               GlobalWindowManager.CloseAllWindows();
               ApplicationConfigSerializer.SaveApplicationConfig(Program.Config);
          }

          protected override void WndProc(ref Message message)
          {
               if (message.Msg == WindowsMessages.WM_HOTKEY)
               {
                    this.NotifyUserActivity();
               }
               else if (message.WParam.ToInt64() == (long)WindowMenuMessage.SC_MINIMIZE)
               {
                    this.lastWindowState = this.WindowState;
               }
               else if (message.Msg == WindowsMessages.WM_SYSCOMMAND)
               {
                    if ((message.WParam == (System.IntPtr)WindowMenuMessage.SC_MINIMIZE) || (message.WParam == (System.IntPtr)WindowMenuMessage.SC_MAXIMIZE))
                    {
                         this.SaveWindowClientRectangle();
                    }
               }
               else if (message.Msg == applicationMessage && (applicationMessage != 0))
               {
                    this.NotifyUserActivity();
                    if (message.WParam.ToInt64() == ApplicationDefines.MessageRestoreWindow)
                    {
                         this.EnsureVisibleForegroundWindow(true);
                    }
               }

               base.WndProc(ref message);
          }

          public bool WindowIsTrayed()
          {
               return !this.Visible;
          }

          public void EnsureVisibleForegroundWindow(bool restoreWindow)
          {
               if (restoreWindow && (this.WindowState == FormWindowState.Minimized))
               {
                    if (this.lastWindowState != FormWindowState.Minimized)
                    {
                         this.WindowState = this.lastWindowState;
                    }
               }

               if (this.Visible)
               {
                    this.BringToFront();
                    this.Activate();
               }
          }

          private void SaveWindowClientRectangle()
          {
               if (!this.mainWindowLoaded)
               {
                    System.Diagnostics.Debug.Assert(false);
                    return;
               }

               var tmpCurrWindowState = this.WindowState;
               var tmpLastWindowState = this.lastWindowState;
               this.lastWindowState = tmpCurrWindowState;
               switch (tmpCurrWindowState)
               {
                    case FormWindowState.Minimized:
                         break;

                    case FormWindowState.Maximized:
                         Program.Config.MainWindow.Maximized = true;
                         break;

                    case FormWindowState.Normal:
                         Program.Config.MainWindow.Maximized = false;
                         Program.Config.MainWindow.X = this.Location.X;
                         Program.Config.MainWindow.Y = this.Location.Y;
                         Program.Config.MainWindow.Width = this.ClientSize.Width;
                         Program.Config.MainWindow.Height = this.ClientSize.Height;
                         break;
               }

               if (tmpCurrWindowState != FormWindowState.Minimized)
               {
                    if (this.splitControls.Width > 200)
                    {
                         Program.Config.MainWindow.SplitPosition = ((this.splitControls.SplitterDistance + 8) * 100) / this.splitControls.Width;
                    }
               }

               if (tmpCurrWindowState == FormWindowState.Minimized && tmpLastWindowState != tmpCurrWindowState)
               {
                    if (Program.Config.Application.Security.LockWorkspace.LockOnMinimizeTaskbar)
                    {
                         this.mainWindowLocked = true;
                    }

                    if (Program.Config.MainWindow.MinimizeWindowToTray)
                    {
                         this.MinimizeWindowToTray(true);
                    }
               }
          }

          private void MinimizeWindowToTray(bool minimize)
          {
               if (minimize)
               {
                    this.Visible = false;
                    this.mainWindowLocked = Program.Config.Application.Security.LockWorkspace.LockOnMinimizeToTray;
               }
               else
               {
                    if (this.mainWindowLocked)
                    {
                         this.OpenLockWindow();
                    }
                    else
                    {
                         this.Visible = true;
                         if (this.WindowState == FormWindowState.Minimized)
                         {
                              WindowsUtils.SetWindowState(this, (Program.Config.MainWindow.Maximized ? FormWindowState.Maximized : FormWindowState.Normal));
                         }
                    }
               }

               this.UpdateTrayIcon(false);
          }

          private void UpdateTrayIcon(bool refreshIcon)
          {
               if (this.notifyIconTray == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    return;
               }

               bool tmpWindowVisible = this.Visible;
               bool tmpTrayIsVisible = this.notifyIconTray.Visible;
               if (tmpWindowVisible && !tmpTrayIsVisible)
               {
                    this.notifyIconTray.Visible = true;
               }

               if (refreshIcon)
               {
                    //this.notifyIconTray.RefreshShellIcon();
               }
          }

          private void OnIdleTickTimerElapsed(object sender, System.EventArgs args)
          {
               var tmpCurrentTime = System.DateTime.UtcNow;
               this.UpdateGlobalLockTimeout(tmpCurrentTime);

               if (this.clearClipboardCurrent > 0)
               {
                    --this.clearClipboardCurrent;
                    this.UpdateClipboardStatus();
               }
               else if (this.clearClipboardCurrent == 0)
               {
                    this.clearClipboardCurrent = -1;
                    this.UpdateClipboardStatus();
                    ClipboardHelper.ClearIfOwner();
                    this.UpdateControlState(false);
               }

               long tmpCurrentTicks = tmpCurrentTime.Ticks;
               if ((this.Visible || this.mainWindowLocked) && tmpCurrentTicks >= this.lockAtInputTicks)
               {
                    try
                    {
                         if (Program.Config.Application.Security.LockWorkspace.ExitInsteadOfLockAfterTime)
                         {
                              this.OnExitWorkspaceMenuItemClick(this.menuItemExitWorkspace, System.EventArgs.Empty);
                         }
                         else
                         {
                              this.BeginInvoke(new MethodInvoker(this.OpenLockWindow));
                              this.lockAtInputTicks = long.MaxValue;
                         }
                    }
                    catch (System.Exception exception)
                    {
                         loger.Error(exception);
                         System.Diagnostics.Debug.WriteLine(exception);
                    }
               }

               if (tmpCurrentTicks >= this.lockAtGlobalTicks)
               {
                    try
                    {
                         NativeMethods.LockWorkStation();
                    }
                    catch (System.Exception exception)
                    {
                         loger.Error(exception);
                         System.Diagnostics.Debug.WriteLine(exception);
                    }
               }
          }

          private int clearClipboardCurrent = -1;

          private void UpdateClipboardStatus()
          {
               var tmpClearClipboardAfter = (int)Program.Config.Application.Security.Clipboard.ClipboardClearAfterSeconds;
               if (tmpClearClipboardAfter < 0 && this.clearClipboardCurrent > 0)
               {
                    this.clearClipboardCurrent = 0;
               }
               else if (clearClipboardCurrent > tmpClearClipboardAfter && tmpClearClipboardAfter >= 0)
               {
                    this.clearClipboardCurrent = tmpClearClipboardAfter;
               }

               if (this.clearClipboardCurrent > 0 && tmpClearClipboardAfter > 0)
               {
                    this.statusPartClipboard.Value = (this.clearClipboardCurrent * 100) / tmpClearClipboardAfter;
                    this.SetStatusText(string.Format("{0}{1}{2}", SafePassResource.ClipboardDataCopied, " ", string.Format(SafePassResource.ClipboardClearInSeconds, this.clearClipboardCurrent)));
               }
               else if (clearClipboardCurrent == 0)
               {
                    this.statusPartClipboard.Visible = false;
               }
          }

          public void StartClipboardCountDown()
          {
               var tmpClearClipboardAfter = (int)Program.Config.Application.Security.Clipboard.ClipboardClearAfterSeconds;
               if (tmpClearClipboardAfter >= 0)
               {
                    this.clearClipboardCurrent = tmpClearClipboardAfter;
                    this.statusPartClipboard.Visible = true;
                    this.UpdateClipboardStatus();
                    this.SetStatusText(string.Format("{0}{1}{2}", SafePassResource.ClipboardDataCopied, " ", string.Format(SafePassResource.ClipboardClearInSeconds, this.clearClipboardCurrent)));
               }
          }

          private bool HandleMainWindowKeyMessage(KeyEventArgs args, bool keyDown)
          {
               bool tmpMessageHandled = false;

               if (args != null)
               {
                    if (args.Control && !args.Alt)
                    {
                         if (args.KeyCode == Keys.I)
                         {
                              if (keyDown)
                              {
                                   this.OpenAccountCreator();
                              }

                              tmpMessageHandled = true;
                         }
                    }

                    if (tmpMessageHandled)
                    {
                         args.Handled = tmpMessageHandled;
                         args.SuppressKeyPress = tmpMessageHandled;
                    }
               }

               return tmpMessageHandled;
          }
     }
}
