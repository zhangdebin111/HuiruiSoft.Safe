
namespace HuiruiSoft.Safe.Exchange
{
     internal sealed class SafePassXml1x : FileFormatProvider
     {
          public override bool SupportsImport
          {
               get
               {
                    return true;
               }
          }

          public override bool SupportsExport
          {
               get
               {
                    return true;
               }
          }

          public override string FormatName
          {
               get
               {
                    return "SafePass XML (1.x)";
               }
          }

          public override string DefaultExtension
          {
               get
               {
                    return "xml";
               }
          }
     }
}
