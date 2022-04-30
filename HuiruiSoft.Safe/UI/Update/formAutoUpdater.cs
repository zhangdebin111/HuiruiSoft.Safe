using AutoUpdaterDotNET;
using System.IO;
using System.Windows.Forms;
using System.Security.AccessControl;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formAutoUpdater : Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private System.Version installedVersion;

          public formAutoUpdater()
          {
               InitializeComponent();

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
                    this.KeyPreview = true;
                    this.Text = SafePassResource.AutoUpdateWindowCaption;
                    this.Icon = HuiruiSoft.Utils.WindowsUtils.DefaultAppIcon;
                    this.checkSkipUpdate.Text = SafePassResource.AutoUpdateWindowCheckBoxSkipUpdate;
                    this.buttonStartUpdate.Text = SafePassResource.AutoUpdateWindowButtonStartUpdate;
                    this.buttonCheckForUpdate.Text = SafePassResource.AutoUpdateWindowButtonCheckUpdate;

                    this.installedVersion = System.Reflection.Assembly.GetAssembly(typeof(ResourceFinder)).GetName().Version;

                    this.pictureBoxIcon.Image = HuiruiSoft.Safe.Properties.Resources.LockWindow;

                    this.flashBar.ForeColor = System.Drawing.Color.WhiteSmoke;
                    this.flashBar.Title = ApplicationDefines.ProductName;
                    this.flashBar.Message = string.Format(SafePassResource.AutoUpdateWindowLabelVersion, this.installedVersion);

                    this.webBrowser.ScrollBarsEnabled = true;
                    this.webBrowser.AllowWebBrowserDrop = false;
                    this.webBrowser.ScriptErrorsSuppressed = false;
                    this.webBrowser.WebBrowserShortcutsEnabled = false;
                    this.webBrowser.IsWebBrowserContextMenuEnabled = false;

                    var tmpNoneUpdateFile = System.IO.Path.Combine(Application.StartupPath, ApplicationDefines.NoneUpdateHtml);
                    if (System.IO.File.Exists(tmpNoneUpdateFile))
                    {
                         this.webBrowser.Navigate(tmpNoneUpdateFile);
                    }
                    else
                    {
                         this.webBrowser.Navigate("about:blank");
                    }

                    AutoUpdater.Synchronous = true;
                    AutoUpdater.ReportErrors = true;
                    AutoUpdater.RunUpdateAsAdmin = true;
                    AutoUpdater.HttpUserAgent = "AutoUpdater";
                    AutoUpdater.UpdateFormSize = new System.Drawing.Size(800, 600);
                    AutoUpdater.AppTitle = string.Format("{0} {1}", ApplicationDefines.ProductName, SafePassResource.AutoUpdateWindowCaption);
                    AutoUpdater.CheckForUpdateEvent += this.OnAutoUpdaterCheckForUpdateEvent;
                    AutoUpdater.ParseUpdateInfoEvent += this.OnAutoUpdaterParseUpdateInfoEvent;
                    AutoUpdater.ApplicationExitEvent += this.OnAutoUpdaterApplicationExitEvent;

                    this.AutoUpdaterStarter();
               }
          }

          protected override void OnKeyUp(KeyEventArgs args)
          {
               if (args.KeyCode == Keys.Escape)
               {
                    this.Close();
                    args.Handled = true;
               }
               else
               {
                    base.OnKeyUp(args);
                    args.Handled = true;
               }
          }

          protected override void OnFormClosing(FormClosingEventArgs args)
          {
               AutoUpdater.CheckForUpdateEvent -= this.OnAutoUpdaterCheckForUpdateEvent;
               AutoUpdater.ParseUpdateInfoEvent -= this.OnAutoUpdaterParseUpdateInfoEvent;
               AutoUpdater.ApplicationExitEvent -= this.OnAutoUpdaterApplicationExitEvent;

               base.OnFormClosing(args);
          }

          private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs args)
          {
               var tmpHtmlElement = this.webBrowser.Document.GetElementById("noneUpdateVersion");
               if (tmpHtmlElement != null)
               {
                    tmpHtmlElement.InnerHtml = string.Format(SafePassResource.AutoUpdateWindowNoUpdateVersion, this.installedVersion);
               }
          }

          private void checkSkipUpdate_CheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateStartUpdateButtonStatus();
          }

          private void UpdateStartUpdateButtonStatus()
          {
               if (this.updateInfoArgs == null)
               {
                    this.checkSkipUpdate.Enabled = false;
                    this.buttonStartUpdate.Enabled = false;
               }
               else if (this.updateInfoArgs.IsUpdateAvailable)
               {
                    this.checkSkipUpdate.Enabled = true;
                    this.buttonStartUpdate.Enabled = !this.checkSkipUpdate.Checked;
               }
               else
               {
                    this.checkSkipUpdate.Enabled = false;
                    this.buttonStartUpdate.Enabled = false;
               }
          }

          private void AutoUpdaterStarter()
          {
               if (!string.IsNullOrEmpty(Program.AutoUpdateConfig.CheckUpdateUrl))
               {
                    AutoUpdater.Start(Program.AutoUpdateConfig.CheckUpdateUrl);
               }

               this.UpdateStartUpdateButtonStatus();
          }

          private void buttonCheckForUpdate_Click(object sender, System.EventArgs args)
          {
               this.AutoUpdaterStarter();

               if (this.updateInfoArgs != null)
               {
                    if (!this.updateInfoArgs.IsUpdateAvailable)
                    {
                         MessageBox.Show(string.Format(SafePassResource.AutoUpdateWindowNoUpdateVersion, this.installedVersion), SafePassResource.AutoUpdateMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                         if (this.updateInfoArgs.Mandatory.Value)
                         {
                              MessageBox.Show(string.Format(SafePassResource.AutoUpdateMessageBoxMandatoryVersion, this.updateInfoArgs.CurrentVersion, this.installedVersion), SafePassResource.AutoUpdateMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                         else
                         {
                              MessageBox.Show(string.Format(SafePassResource.AutoUpdateMessageBoxAvailableVersion, this.updateInfoArgs.CurrentVersion, this.installedVersion), SafePassResource.AutoUpdateMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                    }
               }
          }

          private UpdateInfoEventArgs updateInfoArgs;

          private void buttonStartUpdate_Click(object sender, System.EventArgs args)
          {
               if (this.updateInfoArgs != null && this.updateInfoArgs.IsUpdateAvailable)
               {
                    string tmpDownloadPath;
                    tmpDownloadPath = Path.Combine(Path.GetTempPath(), ApplicationDefines.GroupName);
                    tmpDownloadPath = Path.Combine(tmpDownloadPath, ApplicationDefines.ProductName);
                    if (!Directory.Exists(tmpDownloadPath))
                    {
                         System.IO.Directory.CreateDirectory(tmpDownloadPath);
                    }

                    if (Directory.Exists(tmpDownloadPath))
                    {
                         AutoUpdater.DownloadPath = tmpDownloadPath;
                         AutoUpdater.InstallationPath = Application.StartupPath;

                         if (!this.updateInfoArgs.Mandatory.Value)
                         {
                              AutoUpdater.ShowSkipButton = this.checkSkipUpdate.Checked;
                         }

                         if (AutoUpdater.DownloadUpdate(this.updateInfoArgs))
                         {
                              Application.Exit();
                         }
                    }
               }
          }

          private void OnAutoUpdaterParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
          {
               try
               {
                    var tmpUpdateJson = Newtonsoft.Json.JsonConvert.DeserializeObject<AutoUpdaterInfo>(args.RemoteData);
                    args.UpdateInfo = new UpdateInfoEventArgs
                    {
                         DownloadURL = tmpUpdateJson.Url,
                         CurrentVersion = tmpUpdateJson.Version,
                         ChangelogURL = tmpUpdateJson.Changelog,
                         Mandatory = new Mandatory
                         {
                              Value = tmpUpdateJson.Mandatory.Value,
                              UpdateMode = tmpUpdateJson.Mandatory.UpdateMode,
                              MinimumVersion = tmpUpdateJson.Mandatory.MinimumVersion
                         },
                         CheckSum = new CheckSum
                         {
                              Value = tmpUpdateJson.checksum.Value,
                              HashingAlgorithm = tmpUpdateJson.checksum.HashingAlgorithm
                         }
                    };
               }
               catch (Newtonsoft.Json.JsonReaderException exception)
               {
                    loger.Error(exception);
               }
          }

          private void OnAutoUpdaterApplicationExitEvent()
          {
               Text = SafePassResource.AutoUpdateWindowCloseApplication;
               System.Threading.Thread.Sleep(5000);
               System.Windows.Forms.Application.Exit();
          }

          private void OnAutoUpdaterCheckForUpdateEvent(UpdateInfoEventArgs args)
          {
               this.updateInfoArgs = args;

               if (!args.IsUpdateAvailable)
               {
                    this.flashBar.Message = string.Format(SafePassResource.AutoUpdateWindowNoUpdateVersion, this.installedVersion);
               }
               else
               {
                    this.checkSkipUpdate.Checked = false;
                    this.checkSkipUpdate.Enabled = !args.Mandatory.Value;
                    if (!string.IsNullOrEmpty(args.ChangelogURL))
                    {
                         if (this.webBrowser != null && !this.webBrowser.IsDisposed)
                         {
                              this.webBrowser.Navigate(args.ChangelogURL);
                         }
                    }

                    if (args.Mandatory.Value)
                    {
                         this.flashBar.Message = string.Format(SafePassResource.AutoUpdateWindowMandatoryVersion, args.CurrentVersion);
                    }
                    else
                    {
                         this.flashBar.Message = string.Format(SafePassResource.AutoUpdateWindowAvailableVersion, args.CurrentVersion);
                    }
               }
          }

          public class AutoUpdaterInfo
          {
               public string Url { get; set; }

               public string Changelog { get; set; }

               public string Version { get; set; }

               public CheckSum checksum { get; set; }

               public Mandatory Mandatory { get; set; }
          }
     }
}
