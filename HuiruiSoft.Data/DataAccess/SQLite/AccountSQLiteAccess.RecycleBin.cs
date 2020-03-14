using HuiruiSoft.Safe.ORM;
using HuiruiSoft.Safe.Data;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Collections.Generic;

namespace HuiruiSoft.Data.SQLite
{
     public partial class AccountSQLiteAccess
     {
          public bool MoveToRecycleBin(IList<AccountEntity> items)
          {
               if(items == null)
               {
                    throw new System.ArgumentNullException("参数 items 不能为空。");
               }

               bool tmpExecuteResult = false;

               foreach(var item in items)
               {
                    tmpExecuteResult = this.MoveToRecycleBin(item);
               }

               return tmpExecuteResult;
          }

          public bool MoveToRecycleBin(AccountEntity item)
          {
               if(item == null)
               {
                    throw new System.ArgumentNullException("参数 item 不能为空。");
               }

               return this.MoveToRecycleBin(item.AccountGuid);
          }

          public bool MoveToRecycleBin(int accountId)
          {
               var tmpAccountIds = new List<int>(1);
               tmpAccountIds.Add(accountId);

               return this.UpdateDeleteStatus(tmpAccountIds, true);
          }

          public bool MoveToRecycleBin(string accountGuid)
          {
               var tmpAccountGuids = new List<string>(1);
               tmpAccountGuids.Add(accountGuid);

               return this.UpdateDeleteStatus(tmpAccountGuids, true);
          }

          public bool EmptyRecycleBin()
          {
               bool tmpDeleteResult = true;

               var tmpAccountEntities = this.GetRecycleBinEntities();
               if (tmpAccountEntities != null && tmpAccountEntities.Count > 0)
               {
                    tmpDeleteResult = false;

                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    var tmpDeleteCommand = ((IDataBase)this).CreateCommand();
                    tmpDeleteCommand.Connection = tmpDataConnection;
                    tmpDeleteCommand.CommandType = CommandType.Text;
                    tmpDeleteCommand.CommandText = Statement_DeleteOnPK;
                    tmpDeleteCommand.Parameters.Add(new SQLiteParameter("@AccountId", DbType.Int32));

                    tmpDataConnection.Open();
                    var tmpDbTransaction = tmpDataConnection.BeginTransaction();

                    var tmpAttributeAccess = new AccountAttributeSQLiteAccess();

                    try
                    {
                         tmpAccountEntities.ForEach(accountEntity =>
                         {
                              var tmpAccountId = accountEntity.AccountId;
                              tmpDeleteCommand.Parameters["@AccountId"].Value = tmpAccountId;
                              tmpDeleteResult = tmpDeleteCommand.ExecuteNonQuery() == 1;
                              if (tmpDeleteResult)
                              {
                                   tmpAttributeAccess.DeleteAccountAttributes(tmpAccountId, tmpDbTransaction);
                              }
                         });

                         tmpDbTransaction.Commit();
                         tmpDeleteResult = true;
                    }
                    catch (System.SystemException exception)
                    {
                         tmpDbTransaction.Rollback();
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         if (tmpDataConnection.State == ConnectionState.Open)
                         {
                              tmpDataConnection.Close();
                         }
                         tmpDataConnection.Dispose();
                    }
               }

               return tmpDeleteResult;
          }

          public bool RestoreFromRecycleBin(int accountId)
          {
               var tmpAccountIds = new List<int>(1);
               tmpAccountIds.Add(accountId);

               return this.UpdateDeleteStatus(tmpAccountIds, false);
          }

          public bool RestoreFromRecycleBin(string accountGuid)
          {
               var tmpAccountGuids = new List<string>(1);
               tmpAccountGuids.Add(accountGuid);

               return this.UpdateDeleteStatus(tmpAccountGuids, false);
          }

          public bool MoveToRecycleBin(IList<int> accountIds)
          {
               return this.UpdateDeleteStatus(accountIds, true);
          }

          public bool RestoreFromRecycleBin(IList<int> accountIds)
          {
               return this.UpdateDeleteStatus(accountIds, false);
          }

          public bool UpdateDeleteStatus(IList<int> accountIds, bool deleting)
          {
               bool tmpUpdateResult = false;

               #region UpdateDeleteStatus

               if(accountIds != null && accountIds.Count > 0)
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    var tmpUpdateCommand = ((IDataBase)this).CreateCommand( );
                    tmpUpdateCommand.Connection = tmpDataConnection;
                    tmpUpdateCommand.CommandType = CommandType.Text;
                    tmpUpdateCommand.CommandText = UpdateDeleteFlagByPK;

                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Deleted", DbType.UInt16));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AccountId", DbType.Int32));

                    tmpDataConnection.Open( );

                    using(DbTransaction tmpDbTransaction = tmpDataConnection.BeginTransaction( ))
                    {
                         try
                         {
                              tmpUpdateCommand.Parameters["@Deleted"].Value = deleting ? 1 : 0;

                              foreach(int accountId in accountIds)
                              {
                                   tmpUpdateCommand.Parameters["@AccountId"].Value = accountId;
                                   tmpUpdateResult = tmpUpdateCommand.ExecuteNonQuery( ) == 1;
                              }
                              tmpDbTransaction.Commit( );
                         }
                         catch(System.SystemException exception)
                         {
                              tmpDbTransaction.Rollback( );
                              loger.Error(exception);
                              throw exception;
                         }
                         finally
                         {
                              if(tmpDataConnection.State == ConnectionState.Open)
                              {
                                   tmpDataConnection.Close( );
                              }
                              tmpDataConnection.Dispose( );
                         }
                    }
               }

               #endregion UpdateDeleteStatus

               return tmpUpdateResult;
          }

          private bool UpdateDeleteStatus(IList<string> accountGuids, bool deleting)
          {
               bool tmpUpdateResult = false;

               #region UpdateDeleteStatus

               if(accountGuids != null && accountGuids.Count > 0)
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    var tmpUpdateCommand = ((IDataBase)this).CreateCommand( );
                    tmpUpdateCommand.Connection = tmpDataConnection;
                    tmpUpdateCommand.CommandType = CommandType.Text;
                    tmpUpdateCommand.CommandText = UpdateDeleteFlagByGuid;

                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Deleted", DbType.UInt16));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AccountGuid", DbType.String));

                    tmpDataConnection.Open( );

                    using(DbTransaction tmpDbTransaction = tmpDataConnection.BeginTransaction( ))
                    {
                         try
                         {
                              tmpUpdateCommand.Parameters["@Deleted"].Value = deleting ? 1 : 0;

                              foreach(string tmpAccountGuid in accountGuids)
                              {
                                   tmpUpdateCommand.Parameters["@AccountGuid"].Value = tmpAccountGuid;
                                   tmpUpdateResult = tmpUpdateCommand.ExecuteNonQuery( ) == 1;
                              }
                              tmpDbTransaction.Commit( );
                         }
                         catch(System.SystemException exception)
                         {
                              tmpDbTransaction.Rollback( );
                              loger.Error(exception);
                              throw exception;
                         }
                         finally
                         {
                              if(tmpDataConnection.State == ConnectionState.Open)
                              {
                                   tmpDataConnection.Close( );
                              }
                              tmpDataConnection.Dispose( );
                         }
                    }
               }

               #endregion UpdateDeleteStatus

               return tmpUpdateResult;
          }

          public List<AccountEntity> GetRecycleBinEntities( )
          {
               List<AccountEntity> tmpAccountEntities = null;

               using(var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    try
                    {
                         tmpDataConnection.Open( );

                         var tempDataReader = this.ExecuteReader(Statement_SelectRecycleBin, tmpDataConnection);
                         tmpAccountEntities = this.ReadAccountEntities(tempDataReader);
                         tempDataReader.Close( );
                    }
                    catch(System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         if(tmpDataConnection.State == ConnectionState.Open)
                         {
                              tmpDataConnection.Close( );
                         }
                         tmpDataConnection.Dispose( );
                    }
               }

               return tmpAccountEntities;
          }
     }
}