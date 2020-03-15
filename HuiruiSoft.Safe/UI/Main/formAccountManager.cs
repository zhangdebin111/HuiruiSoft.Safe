using System.Windows.Forms;
using System.ComponentModel;
using HuiruiSoft.Win32;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formAccountManager : Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private bool initialized = false;
          private int clearClipboardMaximum = 0;
          private int clearClipboardCurrent = -1;
          private readonly int applicationMessage = Program.ApplicationMessage;
          private FormWindowState lastNotMinimizedState = FormWindowState.Normal;

          private System.Windows.Forms.Timer idleTickTimer = null;
          private HuiruiSoft.Safe.Service.AccountService accountService;
          private readonly string statusReady = SafePassResource.Ready;

          public formAccountManager( )
          {
               this.InitializeComponent( );
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
                    if(tmpAppConfig.MainWindow.X < tmpMinLocationX)
                    {
                         tmpAppConfig.MainWindow.X = 0;
                    }

                    if(tmpAppConfig.MainWindow.X > tmpScreenBounds.Width * 90 / 100)
                    {
                         tmpAppConfig.MainWindow.X = tmpScreenBounds.Width * 90 / 100;
                    }

                    if(tmpAppConfig.MainWindow.Y < tmpMinLocationY)
                    {
                         tmpAppConfig.MainWindow.Y = 0;
                    }

                    if(tmpAppConfig.MainWindow.Y > tmpScreenBounds.Height * 90 / 100)
                    {
                         tmpAppConfig.MainWindow.Y = tmpScreenBounds.Height * 90 / 100;
                    }

                    if(tmpAppConfig.MainWindow.Width < tmpMinimumWidth)
                    {
                         tmpAppConfig.MainWindow.Width = tmpMinimumWidth;
                    }

                    if(tmpAppConfig.MainWindow.Width > tmpScreenBounds.Width)
                    {
                         tmpAppConfig.MainWindow.Width = tmpScreenBounds.Width;
                    }

                    if(tmpAppConfig.MainWindow.Height < tmpMinimumHeight)
                    {
                         tmpAppConfig.MainWindow.Height = tmpMinimumHeight;
                    }

                    if(tmpAppConfig.MainWindow.Height > tmpScreenBounds.Height)
                    {
                         tmpAppConfig.MainWindow.Height = tmpScreenBounds.Height;
                    }

                    this.TopMost = tmpAppConfig.MainWindow.TopMost;
                    this.MinimumSize = new System.Drawing.Size(tmpMinimumWidth, tmpMinimumHeight);
                    this.Location = new System.Drawing.Point(tmpAppConfig.MainWindow.X, tmpAppConfig.MainWindow.Y);
                    this.ClientSize = new System.Drawing.Size(tmpAppConfig.MainWindow.Width, tmpAppConfig.MainWindow.Height);

                    if(Program.Config.MainWindow.Maximized)
                    {
                         this.WindowState = FormWindowState.Maximized;
                         this.lastNotMinimizedState = this.WindowState;
                    }
                    else if(Program.Config.MainWindow.Minimized)
                    {
                         this.WindowState = FormWindowState.Minimized;
                    }
                    else
                    {
                         this.WindowState = FormWindowState.Normal;
                    }

                    this.splitControls.Panel1MinSize = 150;
                    this.splitControls.Panel2MinSize = 200;
                    if (tmpAppConfig.MainWindow.SplitPosition >= 8)
                    {
                         this.splitControls.SplitterDistance = (int)(this.splitControls.Width * tmpAppConfig.MainWindow.SplitPosition / 100);
                    }

                    this.accountService = new HuiruiSoft.Safe.Service.AccountService( );

                    this.CreateRecycleBinNode( );
                    this.InitializeToolBar( );
                    this.InitializeTreeView( );
                    this.InitializeAccountDataGrid( );

                    this.idleTickTimer = new System.Windows.Forms.Timer( );
                    this.idleTickTimer.Tick += this.OnIdleTickTimerElapsed;
                    this.idleTickTimer.Interval = 1 * 1000;
                    this.idleTickTimer.Start( );

                    this.initialized = true;
                    this.Visible = true;
                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.lockTimerMaximum = (int)Program.Config.Application.Security.LockWorkspace.LockAfterTime;
                    this.clearClipboardMaximum = (int)Program.Config.Application.Security.Clipboard.ClipboardClearAfterSeconds;

                    this.NotifyUserActivity( );

                    this.treeViewCatalog.ContextMenuStrip = this.menuStripTreeView;
                    this.dataGridAccount.ContextMenuStrip = this.menuStripDataGrid;

                    this.GetCatalogChildAccounts( );

                    this.statusPartProgress.Visible = false;
                    this.statusPartClipboard.Visible = false;
                    this.UpdateClipboardStatus();

                    System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(OnFormLoadParallelAsync));
               }
          }

          private static void OnFormLoadParallelAsync(object stateInfo)
          {
               //
          }

          protected override void OnLocationChanged(System.EventArgs args)
          {
               base.OnLocationChanged(args);

               if(this.initialized)
               {
                    switch(this.WindowState)
                    {
                         case FormWindowState.Minimized:
                         case FormWindowState.Maximized:
                              break;

                         case FormWindowState.Normal:
                              if(Program.Config.MainWindow.X != this.Left)
                              {
                                   Program.Config.MainWindow.X = this.Left;
                              }

                              if(Program.Config.MainWindow.Y != this.Top)
                              {
                                   Program.Config.MainWindow.Y = this.Top;
                              }
                              break;
                    }
               }
          }

          protected override void OnResizeEnd(System.EventArgs args)
          {
               base.OnResizeEnd(args);

               if(this.initialized)
               {
                    switch(this.WindowState)
                    {
                         case FormWindowState.Minimized:
                         case FormWindowState.Maximized:
                              break;

                         case FormWindowState.Normal:
                              if(Program.Config.MainWindow.X != this.Left)
                              {
                                   Program.Config.MainWindow.X = this.Left;
                              }

                              if(Program.Config.MainWindow.Y != this.Top)
                              {
                                   Program.Config.MainWindow.Y = this.Top;
                              }

                              if(Program.Config.MainWindow.Width != this.ClientRectangle.Width)
                              {
                                   Program.Config.MainWindow.Width = this.ClientRectangle.Width;
                              }

                              if(Program.Config.MainWindow.Height != this.ClientRectangle.Height)
                              {
                                   Program.Config.MainWindow.Height = this.ClientRectangle.Height;
                              }
                              break;
                    }
               }
          }

          protected override void OnClosing(CancelEventArgs args)
          {
               base.OnClosing(args);

               if (this.WindowState != FormWindowState.Minimized)
               {
                    Program.Config.MainWindow.SplitPosition = ((this.splitControls.SplitterDistance + 8) * 100) / this.splitControls.Width;
               }

               Program.Config.MainWindow.Minimized = (this.WindowState == FormWindowState.Minimized);
               Program.Config.MainWindow.Maximized = (this.WindowState == FormWindowState.Maximized);

               ApplicationConfigSerializer.SaveApplicationConfig(Program.Config);
          }

          private bool restartApplication = false;

          protected override void OnFormClosed(FormClosedEventArgs args)
          {
               base.OnFormClosed(args);
               if (this.restartApplication)
               {
                    NativeShellHelper.StartProcess(WindowsUtils.GetExecutablePath());
               }
          }

          protected override void WndProc(ref Message message)
          {
               if (message.Msg == WindowsMessages.WM_HOTKEY)
               {
                    this.NotifyUserActivity();
               }
               else if (message.WParam.ToInt64() == (long)WindowMenuMessage.SC_MINIMIZE)
               {
                    this.lastNotMinimizedState = this.WindowState;
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

          public void EnsureVisibleForegroundWindow(bool restoreWindow)
          {
               if (restoreWindow && (this.WindowState == FormWindowState.Minimized))
               {
                    if (this.lastNotMinimizedState != FormWindowState.Minimized)
                    {
                         this.WindowState = this.lastNotMinimizedState;
                    }
               }

               if (this.Visible)
               {
                    this.BringToFront();
                    this.Activate();
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
                    ClipboardHelper.ClearIfOwner( );
                    this.UpdateControlState(false);
               }

               long tmpCurrentTicks = tmpCurrentTime.Ticks;
               if(this.Visible && tmpCurrentTicks >= this.lockAtInputTicks)
               {
                    try
                    {
                         this.BeginInvoke(new MethodInvoker(this.OpenLockWindow));
                         this.lockAtInputTicks = long.MaxValue;
                    }
                    catch(System.Exception exception)
                    {
                         loger.Error(exception);
                         System.Diagnostics.Debug.WriteLine(exception);
                    }
               }

               if(tmpCurrentTicks >= this.lockAtGlobalTicks)
               {
                    try
                    {
                         NativeMethods.LockWorkStation( );
                    }
                    catch(System.Exception exception)
                    {
                         loger.Error(exception);
                         System.Diagnostics.Debug.WriteLine(exception);
                    }
               }
          }

          private void UpdateClipboardStatus()
          {
               if (this.clearClipboardMaximum < 0 && this.clearClipboardCurrent > 0)
               {
                    this.clearClipboardCurrent = 0;
               }
               else if (clearClipboardCurrent > this.clearClipboardMaximum && this.clearClipboardMaximum >= 0)
               {
                    this.clearClipboardCurrent = this.clearClipboardMaximum;
               }

               if (this.clearClipboardCurrent > 0 && this.clearClipboardMaximum > 0)
               {
                    this.statusPartClipboard.Value = (this.clearClipboardCurrent * 100) / this.clearClipboardMaximum;
                    this.SetStatusText(string.Format("{0}{1}{2}", SafePassResource.ClipboardDataCopied, " ", string.Format(SafePassResource.ClipboardClearInSeconds, this.clearClipboardCurrent)));
               }
               else if (clearClipboardCurrent == 0)
               {
                    this.statusPartClipboard.Visible = false;
               }
          }

          public void StartClipboardCountdown()
          {
               if (this.clearClipboardMaximum >= 0)
               {
                    this.clearClipboardCurrent = this.clearClipboardMaximum;
                    this.statusPartClipboard.Visible = true;
                    this.UpdateClipboardStatus();
                    this.SetStatusText(string.Format("{0}{1}{2}", SafePassResource.ClipboardDataCopied, " ", string.Format(SafePassResource.ClipboardClearInSeconds, this.clearClipboardCurrent)));
               }
          }

          private bool HandleMainWindowKeyMessage(KeyEventArgs args, bool keyDown)
          {
               bool tmpMessageHandled = false;

               if(args != null)
               {
                    if(args.Control && !args.Alt)
                    {
                         if(args.KeyCode == Keys.I)
                         {
                              if(keyDown)
                              {
                                   this.OpenAccountCreator( );
                              }

                              tmpMessageHandled = true;
                         }
                    }

                    if(tmpMessageHandled)
                    {
                         args.Handled = tmpMessageHandled;
                         args.SuppressKeyPress = tmpMessageHandled;
                    }
               }

               return tmpMessageHandled;
          }
     }
}
