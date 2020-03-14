
using HuiruiSoft.Utils.XmlSerialization;


namespace HuiruiSoft.Safe.Configuration
{
     public static class ApplicationConfigSerializer
     {
          public static SafePassConfiguration Load( )
          {
               var tmpWorkDirectory = HuiruiSoft.Utils.NativeShellHelper.GetWorkingDirectory();
               var tmpConfigFileName = System.IO.Path.Combine(tmpWorkDirectory, ApplicationDefines.MainConfigFile);
               var applicationConfig = LoadApplicationConfig(tmpConfigFileName);
               applicationConfig.WorkingDirectory = tmpWorkDirectory;

               return applicationConfig;
          }

          private static SafePassConfiguration LoadApplicationConfig(string filePath)
          {
               if(string.IsNullOrEmpty(filePath))
               {
                    return null;
               }

               SafePassConfiguration applicationConfig = null;

               try
               {
                    var tmpXmlSerializer = new XmlSerializerExtend(typeof(SafePassConfiguration));
                    using(var tmpFileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
                    {
                         applicationConfig = (SafePassConfiguration)tmpXmlSerializer.Deserialize(tmpFileStream);
                    }
               }
               catch(System.Exception exception)
               {
                    System.Diagnostics.Debug.WriteLine(exception.StackTrace);
               }

               return applicationConfig;
          }

          public static bool SaveApplicationConfig(SafePassConfiguration config)
          {
               System.Diagnostics.Debug.Assert(config != null);
               if(config == null)
               {
                    throw new System.ArgumentNullException("config");
               }

               bool tmpSaveResult = true;
               try
               {
                    var tmpWriterSettings = HuiruiSoft.Utils.XmlDocumentHelper.CreateXmlWriterSettings( );

                    var tmpWorkDirectory = HuiruiSoft.Utils.NativeShellHelper.GetWorkingDirectory();
                    var tmpConfigFileName = System.IO.Path.Combine(tmpWorkDirectory, ApplicationDefines.MainConfigFile);
                    using (var tmpXmlWriter = System.Xml.XmlWriter.Create(tmpConfigFileName, tmpWriterSettings))
                    {
                         var tmpXmlSerializer = new XmlSerializerExtend(typeof(SafePassConfiguration));
                         tmpXmlSerializer.Serialize(tmpXmlWriter, config);
                    }
               }
               catch(System.Exception)
               {
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
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false); tmpSaveResult = false;
               }

               return tmpSaveResult;
          }
     }
}