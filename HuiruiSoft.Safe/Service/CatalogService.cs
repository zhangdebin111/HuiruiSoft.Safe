
using HuiruiSoft.Safe.ORM;
using HuiruiSoft.Safe.Data;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Convertor;

namespace HuiruiSoft.Safe.Service
{
     /// <summary>
     ///    定义账号目录管理的相关逻辑处理类。
     /// </summary>
     public class CatalogService
     {
          private HuiruiSoft.Data.DALFactory.ICatalogDataAccess catalogDataAccess;

          public CatalogService()
          {
               this.catalogDataAccess = DataAccessFactoryHelper.CreateCatalogDataAccess();
          }

          public bool New(AccountCatalog catalog)
          {
               var tmpCatalogEntity = AccountCatalogConvertor.Convert(catalog);
               tmpCatalogEntity.UpdateTime = tmpCatalogEntity.CreateTime = System.DateTime.Now;
               var tmpCreateResult = this.catalogDataAccess.Create(tmpCatalogEntity);
               if (tmpCreateResult)
               {
                    catalog.CatalogId = tmpCatalogEntity.CatalogId;
               }

               return tmpCreateResult;
          }

          public bool Update(AccountCatalog catalog)
          {
               var tmpCatalogEntity = AccountCatalogConvertor.Convert(catalog);
               tmpCatalogEntity.UpdateTime = System.DateTime.Now;
               bool tmpUpdateResult = this.catalogDataAccess.Update(tmpCatalogEntity);

               return tmpUpdateResult;
          }

          public bool Delete(int catalogId)
          {
               return this.catalogDataAccess.Delete(catalogId);
          }

          public bool Delete(AccountCatalog catalog)
          {
               var tmpCatalogEntity = AccountCatalogConvertor.Convert(catalog);
               bool tmpExecuteResult = this.catalogDataAccess.Delete(tmpCatalogEntity);

               return tmpExecuteResult;
          }

          public AccountCatalog GetAccountCatalog(int catalogId)
          {
               AccountCatalog tmpCatalogInfo = null;

               var tmpCatalogEntity = this.catalogDataAccess.GetCatalogEntity(catalogId);
               if (tmpCatalogEntity != null)
               {
                    tmpCatalogInfo = AccountCatalogConvertor.Convert(tmpCatalogEntity);
               }

               return tmpCatalogInfo;
          }

          public System.Data.DataTable GetCatalogTable()
          {
               return this.catalogDataAccess.GetCatalogTable();
          }

          public int GetChildCatalogCount(int catalogId)
          {
               return this.catalogDataAccess.GetChildCatalogCount(catalogId);
          }

          public System.Collections.Generic.IList<AccountCatalog> GetAccountCatalogs()
          {
               System.Collections.Generic.IList<AccountCatalog> tmpAccountCatalogs = null;

               var tmpCatalogEntities = this.catalogDataAccess.GetCatalogEntities();
               if (tmpCatalogEntities != null && tmpCatalogEntities.Count > 0)
               {
                    tmpAccountCatalogs = new System.Collections.Generic.List<AccountCatalog>(tmpCatalogEntities.Count);
                    foreach (AccountCatalogEntity tmpCatalogEntity in tmpCatalogEntities)
                    {
                         tmpAccountCatalogs.Add(AccountCatalogConvertor.Convert(tmpCatalogEntity));
                    }
               }

               return tmpAccountCatalogs;
          }
     }
}