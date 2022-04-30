using System.Xml;
using HuiruiSoft.Utils;

namespace HuiruiSoft.Safe.Configuration
{
     public sealed class AutoUpdateConfig
     {
          public string CheckUpdateUrl
          {
               get;
               set;
          }
     }

     public static class AutoUpdateConfigSerializer
     {
          public static AutoUpdateConfig LoadAutoUpdateConfig()
          {
               var tmpUpdateConfig = new AutoUpdateConfig();

               var tmpApiConfigFile = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, ApplicationDefines.UpdateConfigFile);
               if (System.IO.File.Exists(tmpApiConfigFile))
               {
                    var tmpConfigDocument = new XmlDocument();
                    tmpConfigDocument.Load(tmpApiConfigFile);
                    var tmpUpdateConfigNode = tmpConfigDocument.SelectSingleNode("configuration/update/Url");
                    if (tmpUpdateConfigNode != null)
                    {
                         tmpUpdateConfig.CheckUpdateUrl = XmlDocumentHelper.GetAttributeString((XmlElement)tmpUpdateConfigNode, "value");
                    }
               }

               return tmpUpdateConfig;
          }
     }
}
