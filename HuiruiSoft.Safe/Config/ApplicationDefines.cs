namespace HuiruiSoft.Safe.Configuration
{
     using HuiruiSoft.Utils;

     public static class ApplicationDefines
     {
          public static readonly int InvalidWindowValue = -16381;
          public static readonly int MessageRestoreWindow = 1;

          public static readonly string LanguagesDir = "Languages";

          public static readonly string AutoRunName = "SafePass";
          public static readonly string ProductName = "SafePass";
          public static readonly string MutexName = "SafePassMutex";
          public static readonly string MutexNameGlobal = "SafePassMutexGlobal";
          public static readonly string WindowMessageId = "EFD7F28308AC71F068A37D978DA3F663";
          public static readonly string MainConfigFile = @"config\SafePass.config.xml";
          public static readonly string SafePassDbFile = @"data\SafePassData.dat";
          public static readonly string Log4NetConfigFile = @"config\log4net.config";
          public static readonly string ChineseSimpLanguageFile = @"languages\ChineseSimp.lng";

          public static readonly string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";


          public static readonly System.Drawing.Font DefaultDataGridCellFont = new System.Drawing.Font("微软雅黑", 10, System.Drawing.FontStyle.Regular);
          public static readonly System.Drawing.Color ColorControlNormal = System.Drawing.SystemColors.Window;
          public static readonly System.Drawing.Color ColorControlDisabled = System.Drawing.SystemColors.Control;
          public static readonly System.Drawing.Color ColorControlEditError = System.Drawing.Color.FromArgb(255, 192, 192);

          public static readonly System.Drawing.Color ColorQualityLow = System.Drawing.Color.FromArgb(255, 128, 0);
          public static readonly System.Drawing.Color ColorQualityHigh = System.Drawing.Color.FromArgb(0, 255, 0);

          public static readonly string VersionNo = "1.0";
          public static readonly string Copyright = @"Copyright © 2020, HuiruiSoft";

          public static readonly string VersionUrl = "https://github.com/zhangdebin111";
          public static readonly string HomepageUrl = "http://www.huiruisoft.com/";


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
