
namespace HuiruiSoft.Data.DALFactory
{
     using HuiruiSoft.Safe.ORM;
     using System.Data.Common;
     using System.Collections.Generic;

     public interface IAccountDataAccess
     {
          bool ChangePassword(string password);

          bool Create(AccountEntity entity);

          bool Create(AccountEntity entity, DbTransaction transaction);

          bool Update(AccountEntity accountEntity, DbTransaction transaction = null);

          bool SetTopMost(int accountId);

          bool SetTopMost(IList<int> accountIds);

          bool SetTopMost(string accountGuid);

          bool SetTopMost(IList<string> accountGuids);

          bool CancelTopMost(int accountId);

          bool CancelTopMost(IList<int> accountIds);

          bool CancelTopMost(string accountGuid);

          bool CancelTopMost(IList<string> accountGuids);

          bool MoveToCatalog(IList<int> accountIds, int catalogId);

          bool EmptyRecycleBin( );

          bool MoveToRecycleBin(int accountId);

          bool MoveToRecycleBin(AccountEntity entity);

          bool RestoreFromRecycleBin(int accountId);

          bool RestoreFromRecycleBin(string accountGuid);

          bool MoveToRecycleBin(IList<int> accountIds);

          bool RestoreFromRecycleBin(IList<int> accountIds);

          bool DeleteOutright(int accountId);

          bool DeleteOutright(AccountEntity entity);

          bool DeleteOutright(IList<int> accountIds);

          AccountEntity GetAccountEntity(int accountId);

          AccountEntity GetAccountEntityByGuid(string accountGuid);

          AccountEntity GetAccountEntityByGuid(string accountGuid, DbConnection dataConnection = null);

          int GetBelongAccountCount(int catalogId);

          IList<AccountEntity> GetAccountEntities( );

          List<AccountEntity> GetRecycleBinEntities( );

          IList<AccountEntity> GetAccountEntities(int catalogId);
     }
}