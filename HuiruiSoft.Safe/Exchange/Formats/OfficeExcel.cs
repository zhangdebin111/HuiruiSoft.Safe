
namespace HuiruiSoft.Safe.Exchange
{
     internal sealed class OfficeExcel : FileFormatProvider
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
                    return "Excel 工作簿";
               }
          }

          public override string DefaultExtension
          {
               get
               {
                    return "xlsx";
               }
          }
     }
}