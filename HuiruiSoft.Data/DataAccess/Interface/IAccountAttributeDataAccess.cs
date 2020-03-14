
namespace HuiruiSoft.Data.DALFactory
{
     using HuiruiSoft.Safe.ORM;
     using System.Data.Common;
     using System.Collections.Generic;

     public interface IAccountAttributeDataAccess
     {
          bool New(IList<AccountAttributeEntity> items, DbTransaction dataTransaction = null);

          bool Update(IList<AccountAttributeEntity> items, DbTransaction dataTransaction = null);

          bool Delete(IList<AccountAttributeEntity> items, DbTransaction dataTransaction = null);

          IList<AccountAttributeEntity> GetAccountAttributeEntities(DbConnection dataConnection = null);

          IList<AccountAttributeEntity> GetAccountAttributeEntities(int accountId, DbConnection dataConnection = null);
     }
}