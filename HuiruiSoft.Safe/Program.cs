
using HuiruiSoft.Utils;
using HuiruiSoft.Win32;
using HuiruiSoft.Safe.Configuration;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security.AccessControl;

namespace HuiruiSoft.Safe
{
     static class Program
     {
          private static AutoUpdateConfig autoUpdateConfig = null;
          private static FeedbackApiConfig apiConfiguration = null;
          private static SendFeedbackCache sendFeedbackCache = null;
          private static SafePassConfiguration  applicationConfig = null;

          public static int ApplicationMessage { get; private set; } = 0;

          public static formAccountManager MainWindow { get; private set; } = null;

          public static SafePassConfiguration Config
          {
               get
               {
                    if (applicationConfig == null)
                    {
                         applicationConfig = new SafePassConfiguration();
                    }

                    return applicationConfig;
               }
          }

          public static AutoUpdateConfig AutoUpdateConfig
          {
               get
               {
                    return autoUpdateConfig;
               }
          }

          public static FeedbackApiConfig FeedbackApiConfig
          {
               get
               {
                    return apiConfiguration;
               }
          }

          public static SendFeedbackCache FeedbackCache
          {
               get
               {
                    if (sendFeedbackCache == null)
                    {
                         sendFeedbackCache = new SendFeedbackCache();
                    }

                    return sendFeedbackCache;
               }
          }

          [System.STAThread]
          static void Main(string[] args)
          {
               System.AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
               HuiruiSoft.Utils.WindowsUtils.LoadImageFromResource(typeof(ResourceFinder));
               HuiruiSoft.Utils.WindowsUtils.LoadAppIconFromResource(typeof(ResourceFinder));

               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
               Application.DoEvents();

               var tmpCheckResult = ApplicationDefines.CheckApplicationReadied();
               if (!tmpCheckResult)
               {
                    if (System.Globalization.CultureInfo.CurrentCulture.Name == "zh-CN")
                    {
                         var localLanguageFile = Path.Combine(Application.StartupPath, ApplicationDefines.ChineseSimpLanguageFile);
                         HuiruiSoft.Safe.Localization.LocalizationResourceReader.ReadLocalizationResource(localLanguageFile);
                    }

                    var tmpInitializeWizard = new formNewSafeWizard();
                    if (tmpInitializeWizard.ShowDialog() == DialogResult.OK)
                    {
                         NativeShellHelper.StartProcess(WindowsUtils.GetExecutablePath());
                    }

                    return;
               }

               Log4NetConfigurator.Configure(); 

               applicationConfig = ApplicationConfigSerializer.LoadApplicationConfig();
               if (!string.IsNullOrEmpty(applicationConfig.Application.LanguageFile))
               {
                    Localization.LocalizationResourceReader.ReadLocalizationResource(applicationConfig.Application.LanguageFile);
               }

               autoUpdateConfig = AutoUpdateConfigSerializer.LoadAutoUpdateConfig();
               apiConfiguration = FeedbackApiConfigSerializer.LoadFeedbackApiConfig();

               try
               {
                    ApplicationMessage = NativeMethods.RegisterWindowMessage(ApplicationDefines.WindowMessageId);
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               bool tmpSingleLock = GlobalMutexPool.CreateMutex(ApplicationDefines.MutexName, true);
               if (!tmpSingleLock)
               {
                    ActivatePreviousInstance(args);
                    HuiruiSoft.Utils.GlobalMutexPool.ReleaseAll();
                    return;
               }

               var tmpGlobalNotify = TryGlobalInstanceNotify(ApplicationDefines.MutexNameGlobal);
               var formLoginWindow = new formLoginWindow();
               if (formLoginWindow.ShowDialog() != DialogResult.OK)
               {
                    Application.Exit();
               }
               else
               {
                    var tmpMessageFilter = new CustomMessageFilter();
                    Application.AddMessageFilter(tmpMessageFilter);

                    MainWindow = new formAccountManager();
                    Application.Run(MainWindow);

                    Application.RemoveMessageFilter(tmpMessageFilter);
               }

               if (tmpGlobalNotify != null)
               {
                    System.GC.KeepAlive(tmpGlobalNotify);
               }
          }

          public static bool IsAdministrator()
          {
               var tmpWindowsPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
               return tmpWindowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
          }

          private static void ActivatePreviousInstance(string[] args)
          {
               if (ApplicationMessage == 0 && !NativeMethods.IsUnix())
               {
                    System.Diagnostics.Debug.Assert(false);
                    return;
               }

               try
               {
                    BroadcastHelper.Send(ApplicationMessage, ApplicationDefines.MessageRestoreWindow, 0, false);
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }
          }

          internal static Mutex TryGlobalInstanceNotify(string baseName)
          {
               if (baseName == null)
               {
                    throw new System.ArgumentNullException("baseName");
               }

               try
               {
                    var tmpMutexSecurity = new MutexSecurity();
                    var tmpIdentity = string.Format("{0}\\{1}", System.Environment.UserDomainName, System.Environment.UserName);
                    tmpMutexSecurity.AddAccessRule(new MutexAccessRule(tmpIdentity, MutexRights.FullControl, AccessControlType.Allow));

                    var tmpIdentifier = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                    tmpMutexSecurity.AddAccessRule(new MutexAccessRule(tmpIdentifier, MutexRights.ReadPermissions | MutexRights.Synchronize, AccessControlType.Allow));

                    bool tmpCreatedNew;
                    var tmpMutexName = string.Format("Global\\{0}", baseName);
                    return new Mutex(false, tmpMutexName, out tmpCreatedNew, tmpMutexSecurity);
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return null;
          }

          public static void NotifyUserActivity()
          {
               if (MainWindow != null)
               {
                    MainWindow.NotifyUserActivity();
               }
          }

          public static System.IntPtr GetSafeMainWindowHandle()
          {
               try
               {
                    if (MainWindow != null)
                    {
                         return MainWindow.Handle;
                    }
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return System.IntPtr.Zero;
          }
     }
}
