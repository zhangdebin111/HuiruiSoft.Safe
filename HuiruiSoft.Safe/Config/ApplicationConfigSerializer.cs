
using HuiruiSoft.Utils.XmlSerialization;


namespace HuiruiSoft.Safe.Configuration
{
     public static class ApplicationConfigSerializer
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          public static SafePassConfiguration LoadApplicationConfig( )
          {
               SafePassConfiguration applicationConfig = null;

               var tmpWorkDirectory = HuiruiSoft.Utils.NativeShellHelper.GetWorkingDirectory();
               var tmpConfigFileName = System.IO.Path.Combine(tmpWorkDirectory, ApplicationDefines.MainConfigFile);
               if (System.IO.File.Exists(tmpConfigFileName))
               {
                    try
                    {
                         var tmpXmlSerializer = new XmlSerializerExtend(typeof(SafePassConfiguration));
                         using (var tmpFileStream = new System.IO.FileStream(tmpConfigFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
                         {
                              applicationConfig = (SafePassConfiguration)tmpXmlSerializer.Deserialize(tmpFileStream);
                              applicationConfig.WorkingDirectory = tmpWorkDirectory;
                         }
                    }
                    catch (System.Exception exception)
                    {
                         loger.Error(exception);
                         System.Diagnostics.Debug.WriteLine(exception.StackTrace);
                    }
               }

               return applicationConfig;
          }

          public static bool SaveApplicationConfig(SafePassConfiguration configuration)
          {
               System.Diagnostics.Debug.Assert(configuration != null);
               if(configuration == null)
               {
                    throw new System.ArgumentNullException("config");
               }

               bool tmpSaveResult = true;
               try
               {
                    var tmpWriterSettings = HuiruiSoft.Utils.XmlDocumentHelper.CreateXmlWriterSettings( );

                    var tmpWorkDirectory = HuiruiSoft.Utils.NativeShellHelper.GetWorkingDirectory();
                    var tmpTempConfigFile = new System.IO.FileInfo(System.IO.Path.Combine(tmpWorkDirectory, ApplicationDefines.MainConfigTemp));
                    using (var tmpXmlWriter = System.Xml.XmlWriter.Create(tmpTempConfigFile.FullName, tmpWriterSettings))
                    {
                         var tmpXmlSerializer = new XmlSerializerExtend(typeof(SafePassConfiguration));
                         tmpXmlSerializer.Serialize(tmpXmlWriter, configuration);
                    }
                    
                    if (tmpTempConfigFile.Exists && tmpTempConfigFile.Length > 500)
                    {
                         var tmpConfigFileName = System.IO.Path.Combine(tmpWorkDirectory, ApplicationDefines.MainConfigFile);
                         var tmpConfigFileBack = System.IO.Path.Combine(tmpWorkDirectory, ApplicationDefines.MainConfigBack);
                         tmpTempConfigFile.Replace(tmpConfigFileName, tmpConfigFileBack);
                    }
               }
               catch(System.Exception exception)
               {
                    loger.Error(exception);
                    System.Diagnostics.Debug.Assert(false); tmpSaveResult = false;
               }

               return tmpSaveResult;
          }

          public static bool SaveApplicationConfig(string fileName, SafePassConfiguration config)
          {
               System.Diagnostics.Debug.Assert(config != null);
               if (config == null)
               {
                    throw new System.ArgumentNullException("config");
               }

               bool tmpSaveResult = true;
               try
               {
                    var tmpWriterSettings = HuiruiSoft.Utils.XmlDocumentHelper.CreateXmlWriterSettings();
                    using (var tmpXmlWriter = System.Xml.XmlWriter.Create(fileName, tmpWriterSettings))
                    {
                         var tmpXmlSerializer = new XmlSerializerExtend(typeof(SafePassConfiguration));
                         tmpXmlSerializer.Serialize(tmpXmlWriter, config);
                    }
               }
               catch (System.Exception exception)
               {
                    loger.Error(exception);
                    System.Diagnostics.Debug.Assert(false); tmpSaveResult = false;
               }

               return tmpSaveResult;
          }
     }
}