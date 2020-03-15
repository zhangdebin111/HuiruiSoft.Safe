
using System.Collections.Generic;

namespace HuiruiSoft.Safe.Resources
{
     public static partial class SafePassResource
     {
          private static string TryGetLocalizedString(Dictionary<string, string> localizedStringTable, string stringKey, string defaultString)
          {
               string tmpLocalizeString;
               if (localizedStringTable.TryGetValue(stringKey, out tmpLocalizeString))
               {
                    return tmpLocalizeString;
               }
               else
               {
                    return defaultString;
               }
          }

          public static void SetLocalizedStrings(Dictionary<string, string> localizedStringTable)
          {
               if (localizedStringTable == null)
               {
                    throw new System.ArgumentNullException("localizedStringTable");
               }

               var tmpResourceType = typeof(SafePassResource);
               var properties = tmpResourceType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
               foreach (var tmpPropertyInfo in properties)
               {
                    if (tmpPropertyInfo.CanRead && tmpPropertyInfo.CanWrite)
                    {
                         var tmpPropertyName = tmpPropertyInfo.Name;

                         var tmpDefaultString = string.Format("{0}", tmpPropertyInfo.GetValue(tmpPropertyName, null));
                         var tmpLocalizedString = TryGetLocalizedString(localizedStringTable, tmpPropertyName, tmpDefaultString);

                         if (tmpDefaultString != tmpLocalizedString)
                         {
                              if (tmpLocalizedString.Contains(@"\n"))
                              {
                                   tmpLocalizedString = tmpLocalizedString.Replace(@"\n", System.Environment.NewLine);
                              }
                              tmpPropertyInfo.SetValue(tmpPropertyName, tmpLocalizedString, null);
                         }
                         else
                         {
                              System.Diagnostics.Debug.WriteLine(tmpPropertyName + "\t" + tmpDefaultString);
                         }
                    }
               }
          }
     }
}