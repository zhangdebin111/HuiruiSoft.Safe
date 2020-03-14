
namespace HuiruiSoft.Safe.Exchange
{
     public abstract class FileFormatProvider
     {
          public virtual string FileName
          {
               get;
               set;
          }

          public abstract bool SupportsImport
          {
               get;
          }

          public abstract bool SupportsExport
          {
               get;
          }

          public abstract string FormatName
          {
               get;
          }

          public virtual string DisplayName
          {
               get
               {
                    return this.FormatName;
               }
          }

          public virtual string DefaultExtension
          {
               get
               {
                    return string.Empty;
               }
          }
     }
}