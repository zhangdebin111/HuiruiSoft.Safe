
namespace HuiruiSoft.Data.DALFactory
{
     public interface ICatalogDataAccess
     {
          HuiruiSoft.Safe.ORM.AccountCatalogEntity GetCatalogEntity(int catalogId);

          bool Create(HuiruiSoft.Safe.ORM.AccountCatalogEntity entity);

          bool Update(HuiruiSoft.Safe.ORM.AccountCatalogEntity entity);

          bool Delete(int catalogId);

          bool Delete(HuiruiSoft.Safe.ORM.AccountCatalogEntity entity);

          System.Data.DataTable GetCatalogTable( );

          int GetChildCatalogCount(int catalogId);

          System.Collections.Generic.IList<HuiruiSoft.Safe.ORM.AccountCatalogEntity> GetCatalogEntities( );
     }
}