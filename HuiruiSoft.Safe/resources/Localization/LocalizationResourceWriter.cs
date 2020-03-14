
using System.IO;
using System.IO.Compression;
using HuiruiSoft.Utils.XmlSerialization;

namespace HuiruiSoft.Safe.Localization
{
     public static class LocalizationResourceWriter
     {
          public static bool SaveLocalResource(string localLanguageFile, LocalizationResources localResources)
          {
               System.Diagnostics.Debug.Assert(localResources != null);
               if (localResources == null)
               {
                    throw new System.ArgumentNullException("localResources");
               }

               bool tmpSaveResult = true;
               try
               {
                    using (var tmpFileStream = new FileStream(localLanguageFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                         using (var tmpGZipStream = new GZipStream(tmpFileStream, CompressionMode.Compress))
                         {
                              using (var tmpXmlWriter = HuiruiSoft.Utils.XmlDocumentHelper.CreateXmlWriter(tmpGZipStream))
                              {
                                   var tmpXmlSerializer = new XmlSerializerExtend(typeof(LocalizationResources));
                                   tmpXmlSerializer.Serialize(tmpXmlWriter, localResources);
                              }
                         }
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