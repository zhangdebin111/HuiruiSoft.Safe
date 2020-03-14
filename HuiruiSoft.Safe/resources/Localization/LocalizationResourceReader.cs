using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using HuiruiSoft.Utils.XmlSerialization;

namespace HuiruiSoft.Safe.Localization
{
     public static class LocalizationResourceReader
     {
          public static LocalizationResources ReadLocalResource(string localLanguageFile)
          {
               if (string.IsNullOrEmpty(localLanguageFile))
               {
                    throw new System.ArgumentNullException("localLanguageFile");
               }

               var tmpLocalLanguageFile = localLanguageFile;
               if (!File.Exists(tmpLocalLanguageFile))
               {
                    tmpLocalLanguageFile = Path.Combine(System.Windows.Forms.Application.StartupPath, localLanguageFile);
               }

               LocalizationResources localization = null;
               if (File.Exists(tmpLocalLanguageFile))
               {
                    using (var tmpFileStream = new FileStream(tmpLocalLanguageFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                         using (var tmpGZipStream = new GZipStream(tmpFileStream, CompressionMode.Decompress))
                         {
                              var tmpXmlSerializer = new XmlSerializerExtend(typeof(LocalizationResources));
                              localization = (tmpXmlSerializer.Deserialize(tmpGZipStream) as LocalizationResources);
                         }
                    }
               }

               return localization;
          }

          public static void ReadLocalizationResource(string localLanguageFile)
          {
               var tmpLocalization = ReadLocalResource(localLanguageFile);

               if (tmpLocalization != null && tmpLocalization.LocalizedStrings != null)
               {
                    var tmpLocalizedStrings = new Dictionary<string, string>();
                    if (tmpLocalization.LocalizedStrings.General != null)
                    {
                         tmpLocalization.LocalizedStrings.General.ForEach(item =>
                         {
                              tmpLocalizedStrings.Add(item.Name, item.Value);
                         });
                    }

                    if (tmpLocalization.LocalizedStrings.MainMenu != null)
                    {
                         tmpLocalization.LocalizedStrings.MainMenu.ForEach(item =>
                         {
                              tmpLocalizedStrings.Add(item.Name, item.Value);
                         });
                    }

                    if (tmpLocalization.LocalizedStrings.MainToolbar != null)
                    {
                         tmpLocalization.LocalizedStrings.MainToolbar.ForEach(item =>
                         {
                              tmpLocalizedStrings.Add(item.Name, item.Value);
                         });
                    }

                    if (tmpLocalization.LocalizedStrings.Windows != null)
                    {
                         tmpLocalization.LocalizedStrings.Windows.ForEach(item =>
                         {
                              tmpLocalizedStrings.Add(item.Name, item.Value);
                         });
                    }

                    HuiruiSoft.Safe.Resources.SafePassResource.SetLocalizedStrings(tmpLocalizedStrings);
               }
          }
     }
}