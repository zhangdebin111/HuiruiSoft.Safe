using System.Xml;
using HuiruiSoft.Utils;

namespace HuiruiSoft.Safe.Configuration
{
     public sealed class FeedbackApiConfig
     {
          public string CreateImageCode
          {
               get;
               set;
          }

          public string CheckImageCode
          {
               get;
               set;
          }

          public string SendFeedback
          {
               get;
               set;
          }

          public string GetFeedbackSubjects
          {
               get;
               set;
          }
     }

     public static class FeedbackApiConfigSerializer
     {
          public static FeedbackApiConfig LoadFeedbackApiConfig()
          {
               var tmpFeedbackConfig = new FeedbackApiConfig();

               var tmpApiConfigFile = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, ApplicationDefines.ApiConfigFile);
               if (System.IO.File.Exists(tmpApiConfigFile))
               {
                    var tmpConfigDocument = new XmlDocument();
                    tmpConfigDocument.Load(tmpApiConfigFile);
                    var tmpConfigXmlNodes = tmpConfigDocument.SelectNodes("configuration/feedback/api/Url");
                    if (tmpConfigXmlNodes != null)
                    {
                         foreach (XmlElement tmpXmlElement in tmpConfigXmlNodes)
                         {
                              var tmpApiName = XmlDocumentHelper.GetAttributeString(tmpXmlElement, "name");
                              if (!string.IsNullOrEmpty(tmpApiName))
                              {
                                   if (string.Equals(tmpApiName, "CreateImageCode"))
                                   {
                                        tmpFeedbackConfig.CreateImageCode = XmlDocumentHelper.GetAttributeString(tmpXmlElement, "value");
                                   }
                                   else if (string.Equals(tmpApiName, "CheckImageCode"))
                                   {
                                        tmpFeedbackConfig.CheckImageCode = XmlDocumentHelper.GetAttributeString(tmpXmlElement, "value");
                                   }
                                   else if (string.Equals(tmpApiName, "SendFeedback"))
                                   {
                                        tmpFeedbackConfig.SendFeedback = XmlDocumentHelper.GetAttributeString(tmpXmlElement, "value");
                                   }
                                   else if (string.Equals(tmpApiName, "FeedbackSubjects"))
                                   {
                                        tmpFeedbackConfig.GetFeedbackSubjects = XmlDocumentHelper.GetAttributeString(tmpXmlElement, "value");
                                   }
                              }
                         }
                    }
               }

               return tmpFeedbackConfig;
          }
     }
}
