using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HuiruiSoft.Safe.Configuration
{
     public sealed class Log4NetConfigurator
     {
          public static void Configure()
          {
               log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(Application.StartupPath, ApplicationDefines.Log4NetConfigFile)));

               var tmpWorkDirectory = HuiruiSoft.Utils.NativeShellHelper.GetWorkingDirectory();
               if (string.IsNullOrEmpty(tmpWorkDirectory))
               {
                    return;
               }

               var tmpRepository = log4net.LogManager.GetRepository();
               var tmpFileAppenders = tmpRepository.GetAppenders();
               if (tmpFileAppenders == null)
               {
                    return;
               }

               var tmpErrorAppender = tmpFileAppenders.First(appender => appender.Name == "ErrorAppender") as log4net.Appender.RollingFileAppender;
               if (tmpErrorAppender != null)
               {
                    var tmpLogFilePath = Path.Combine(tmpWorkDirectory, "logs\\");
                    if (!System.IO.Directory.Exists(tmpLogFilePath))
                    {
                         Directory.CreateDirectory(tmpLogFilePath);
                    }

                    if (System.IO.Directory.Exists(tmpLogFilePath))
                    {
                         tmpErrorAppender.File = tmpLogFilePath;
                         tmpErrorAppender.ActivateOptions();
                    }
               }
          }
     }
}