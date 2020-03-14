
namespace HuiruiSoft.Safe.Data
{
     public class DataAccessFactoryHelper
     {
          public static HuiruiSoft.Data.DALFactory.ICatalogDataAccess CreateCatalogDataAccess( )
          {
               return new HuiruiSoft.Data.SQLite.CatalogSQLiteAccess( );
          }

          public static HuiruiSoft.Data.DALFactory.IAccountDataAccess CreateAccountDataAccess( )
          {
               return new HuiruiSoft.Data.SQLite.AccountSQLiteAccess( );
          }

          public static HuiruiSoft.Data.DALFactory.IAccountAttributeDataAccess CreateAttributeDataAccess( )
          {
               return new HuiruiSoft.Data.SQLite.AccountAttributeSQLiteAccess( );
          }
     }
}