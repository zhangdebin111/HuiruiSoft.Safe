using System.Collections.Generic;
using HuiruiSoft.Safe.ORM;
using HuiruiSoft.Safe.Model;

namespace HuiruiSoft.Safe.Convertor
{
     public static class AccountCatalogConvertor
     {
          public static List<AccountCatalog> Convert(List<AccountCatalogEntity> entities)
          {
               var tmpCatalogModels = new List<AccountCatalog>();
               if (entities != null)
               {
                    foreach (var entity in entities)
                    {
                         tmpCatalogModels.Add(Convert(entity));
                    }
               }

               return tmpCatalogModels;
          }

          public static List<AccountCatalogEntity> Convert(List<AccountCatalog> catalogs)
          {
               var tmpCatalogEntities = new List<AccountCatalogEntity>();
               if (catalogs != null)
               {
                    foreach (var catalog in catalogs)
                    {
                         tmpCatalogEntities.Add(Convert(catalog));
                    }
               }

               return tmpCatalogEntities;
          }

          public static AccountCatalog Convert(AccountCatalogEntity entity)
          {
               AccountCatalog tmpCatalogModel = null;
               if (entity != null)
               {
                    tmpCatalogModel = new AccountCatalog();

                    tmpCatalogModel.CatalogId = entity.CatalogId;
                    tmpCatalogModel.Name = entity.Name;
                    tmpCatalogModel.Depth = entity.Depth;
                    tmpCatalogModel.Order = entity.Order;
                    tmpCatalogModel.ParentId = entity.ParentId;
                    tmpCatalogModel.VersionNo = entity.VersionNo;
                    tmpCatalogModel.CreateTime = entity.CreateTime;
                    tmpCatalogModel.UpdateTime = entity.UpdateTime;
                    tmpCatalogModel.Description = entity.Description;
               }

               return tmpCatalogModel;
          }

          public static AccountCatalogEntity Convert(AccountCatalog catalog)
          {
               AccountCatalogEntity tmpCatalogEntity = null;
               if (catalog != null)
               {
                    tmpCatalogEntity = new AccountCatalogEntity();

                    tmpCatalogEntity.CatalogId = catalog.CatalogId;
                    tmpCatalogEntity.Name = catalog.Name;
                    tmpCatalogEntity.Depth = catalog.Depth;
                    tmpCatalogEntity.Order = catalog.Order;
                    tmpCatalogEntity.ParentId = catalog.ParentId;
                    tmpCatalogEntity.VersionNo = catalog.VersionNo;
                    tmpCatalogEntity.CreateTime = catalog.CreateTime;
                    tmpCatalogEntity.UpdateTime = catalog.UpdateTime;
                    tmpCatalogEntity.Description = catalog.Description;
               }

               return tmpCatalogEntity;
          }
     }
}
