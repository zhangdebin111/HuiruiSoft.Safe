namespace HuiruiSoft.Safe.Configuration
{
     using HuiruiSoft.Utils;

     public static class ApplicationDefines
     {
          public static readonly int InvalidWindowValue = -16381;
          public static readonly int MessageRestoreWindow = 1;

          public static readonly string LanguagesDir = "Languages";

          public static readonly int    AppCode = 51000001;
          public static readonly string AutoRunName = "SafePass";
          public static readonly string ProductName = "SafePass";
          public static readonly string GroupName = "HuiruiSoft";
          public static readonly string MutexName = "SafePassMutex";
          public static readonly string MutexNameGlobal = "SafePassMutexGlobal";
          public static readonly string WindowMessageId = "EFD7F28308AC71F068A37D978DA3F663";
          public static readonly string MainConfigFile = @"config\SafePass.config.xml";
          public static readonly string MainConfigTemp = @"config\SafePass.config.tmp";
          public static readonly string MainConfigBack = @"config\SafePass.config.bak";
          public static readonly string SafePassDbFile = @"data\SafePassData.dat";

          public static readonly string NoneUpdateHtml = @"html\NoneUpdate.html";
          public static readonly string ApiConfigFile = @"config\Feedback.config";
          public static readonly string UpdateConfigFile = @"config\Update.config";
          public static readonly string Log4NetConfigFile = @"config\log4net.config";
          public static readonly string ChineseSimpLanguageFile = @"languages\ChineseSimp.lng";

          public static readonly string DateTimeFormat = DateTimeHelper.DefaultDateTimePattern;

          public static readonly System.Drawing.Font DefaultDataGridCellFont = new System.Drawing.Font("微软雅黑", 10, System.Drawing.FontStyle.Regular);
          public static readonly System.Drawing.Color ColorControlNormal = System.Drawing.SystemColors.Window;
          public static readonly System.Drawing.Color ColorControlDisabled = System.Drawing.SystemColors.Control;
          public static readonly System.Drawing.Color ColorControlEditError = System.Drawing.Color.FromArgb(255, 192, 192);

          public static readonly System.Drawing.Color ColorQualityLow = System.Drawing.Color.FromArgb(255, 128, 0);
          public static readonly System.Drawing.Color ColorQualityHigh = System.Drawing.Color.FromArgb(0, 255, 0);

          public static readonly string Copyright = string.Format(@"Copyright © {0}, HuiruiSoft", System.DateTime.Today.Year);
          public static readonly string VersionNo = System.Reflection.Assembly.GetAssembly(typeof(ResourceFinder)).GetName().Version.ToString();

          public static readonly string LicenseUrl = "";
          public static readonly string HomepageUrl = "http://help.huiruisoft.com/safepass/index.html";
          public static readonly string HelpCenterUrl = "http://help.huiruisoft.com/safepass/index.html";
          public static readonly string OpenSourceUrl = "https://github.com/zhangdebin111/HuiruiSoft.Safe";


          public static bool CheckApplicationReadied()
          {
               var tmpWorkDirectory = NativeShellHelper.GetWorkingDirectory();
               if (string.IsNullOrEmpty(tmpWorkDirectory))
               {
                    return false;
               }

               var tmpConfigFileName = System.IO.Path.Combine(tmpWorkDirectory, MainConfigFile);
               if (!System.IO.File.Exists(tmpConfigFileName))
               {
                    return false;
               }

               var tmpDataDirectory = System.IO.Path.Combine(tmpWorkDirectory, ApplicationDefines.SafePassDbFile);
               return System.IO.File.Exists(tmpDataDirectory);
          }
     }
}
