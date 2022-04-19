using AutoUpdaterDotNET;
using System.Windows.Forms;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formAutoUpdater : Form
     {
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
                    this.Text = SafePassResource.AutoUpdateWindowCaption;
                    this.Icon = HuiruiSoft.Utils.WindowsUtils.DefaultAppIcon;
                    this.checkSkipUpdate.Text = SafePassResource.AutoUpdateWindowCheckBoxSkipUpdate;
                    this.buttonStartUpdate.Text = SafePassResource.AutoUpdateWindowButtonStartUpdate;
                    this.buttonCheckForUpdate.Text = SafePassResource.AutoUpdateWindowButtonCheckUpdate;

                    this.installedVersion = System.Reflection.Assembly.GetAssembly(typeof(ResourceFinder)).GetName().Version;

                    this.flashBar.ForeColor = System.Drawing.Color.WhiteSmoke;
                    this.flashBar.Title = ApplicationDefines.ProductName;
                    this.flashBar.Message = string.Format(SafePassResource.AutoUpdateWindowLabelVersion, this.installedVersion);
                    this.pictureBoxIcon.Image = HuiruiSoft.Safe.Properties.Resources.LockWindow;

                    this.webBrowser.ScrollBarsEnabled = true;
                    this.webBrowser.AllowWebBrowserDrop = false;
                    this.webBrowser.ScriptErrorsSuppressed = false;
                    this.webBrowser.WebBrowserShortcutsEnabled = false;
                    this.webBrowser.IsWebBrowserContextMenuEnabled = false;
                    this.webBrowser.Url = new System.Uri("about:blank");

                    AutoUpdater.Synchronous = true;
                    AutoUpdater.ReportErrors = true;
                    AutoUpdater.HttpUserAgent = "AutoUpdater";
                    AutoUpdater.UpdateFormSize = new System.Drawing.Size(800, 600);
                    AutoUpdater.AppTitle = string.Format("{0} {1}", ApplicationDefines.ProductName, SafePassResource.AutoUpdateWindowCaption);
                    AutoUpdater.CheckForUpdateEvent += this.OnAutoUpdaterCheckForUpdateEvent;
                    AutoUpdater.ParseUpdateInfoEvent += this.OnAutoUpdaterParseUpdateInfoEvent;
                    AutoUpdater.ApplicationExitEvent += this.OnAutoUpdaterApplicationExitEvent;

                    this.AutoUpdaterStarter();
               }
          }

          protected override void OnFormClosing(FormClosingEventArgs args)
          {
               AutoUpdater.CheckForUpdateEvent -= this.OnAutoUpdaterCheckForUpdateEvent;
               AutoUpdater.ParseUpdateInfoEvent -= this.OnAutoUpdaterParseUpdateInfoEvent;
               AutoUpdater.ApplicationExitEvent -= this.OnAutoUpdaterApplicationExitEvent;

               base.OnFormClosing(args);
          }

          private void checkSkipUpdate_CheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateStartUpdateButtonStatus();
          }

          private void UpdateStartUpdateButtonStatus()
          {
               if (this.updateInfoArgs == null || !this.updateInfoArgs.IsUpdateAvailable)
               {
                    this.buttonStartUpdate.Enabled = false;
               }
               else
               {
                    this.buttonStartUpdate.Enabled = !this.checkSkipUpdate.Checked;
               }
          }

          private void AutoUpdaterStarter()
          {
               AutoUpdater.Start("http://download.huiruisoft.com/safepass/updates/AutoUpdate.json");
          }

          private void buttonCheckForUpdate_Click(object sender, System.EventArgs args)
          {
               this.AutoUpdaterStarter();
               this.UpdateStartUpdateButtonStatus();

               if (this.updateInfoArgs != null)
               {
                    if (this.updateInfoArgs.IsUpdateAvailable)
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
               if (this.updateInfoArgs != null)
               {
                    if (this.updateInfoArgs.IsUpdateAvailable)
                    {
                         var tmpDownloadPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Temp");
                         if (!System.IO.Directory.Exists(tmpDownloadPath))
                         {
                              try
                              {
                                   System.IO.Directory.CreateDirectory(tmpDownloadPath);
                              }
                              catch (System.SystemException exception)
                              {
                                   System.Diagnostics.Debug.WriteLine(exception.Message);
                              }
                         }

                         AutoUpdater.DownloadPath = tmpDownloadPath;
                         AutoUpdater.InstallationPath = System.Environment.CurrentDirectory;

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

               this.flashBar.Title = string.Format(SafePassResource.AutoUpdateWindowCurrentVersion, ApplicationDefines.ProductName, this.installedVersion);
               if (tmpUpdateJson.Mandatory.Value)
               {
                    this.flashBar.Message = string.Format(SafePassResource.AutoUpdateWindowMandatoryVersion, tmpUpdateJson.Version);
               }
               else
               {
                    this.flashBar.Message = string.Format(SafePassResource.AutoUpdateWindowAvailableVersion, tmpUpdateJson.Version);
               }

               if (!string.IsNullOrEmpty(tmpUpdateJson.Changelog))
               {
                    if (this.webBrowser != null && !this.webBrowser.IsDisposed)
                    {
                         this.webBrowser.Navigate(tmpUpdateJson.Changelog);
                    }
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

               if (args.IsUpdateAvailable)
               {
                    this.checkSkipUpdate.Checked = false;
                    this.checkSkipUpdate.Enabled = !args.Mandatory.Value;
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
