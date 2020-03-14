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
          public bool DeleteOutright(int accountId)
          {
               var tmpAccountIds = new List<int>(1);
               tmpAccountIds.Add(accountId);

               return this.DeleteOutright(tmpAccountIds);
          }

          public bool DeleteOutright(string accountGuid)
          {
               var tmpAccountGuids = new List<string>(1);
               tmpAccountGuids.Add(accountGuid);

               return this.DeleteOutright(tmpAccountGuids);
          }

          public bool DeleteOutright(AccountEntity item)
          {
               if(item == null)
               {
                    throw new System.ArgumentNullException("参数 item 不能为空。");
               }

               return this.DeleteOutright(item.AccountGuid);
          }

          public bool DeleteOutright(IList<AccountEntity> items)
          {
               if(items == null)
               {
                    throw new System.ArgumentNullException("参数 items 不能为空。");
               }

               var tmpAccountIds = new List<int>(items.Count);
               foreach(var item in items)
               {
                    tmpAccountIds.Add(item.AccountId);
               }

               return this.DeleteOutright(tmpAccountIds);
          }

          public bool DeleteOutright(IList<int> accountIds)
          {
               bool tmpDeleteResult = false;

               #region DeleteOutrightAccounts

               if(accountIds != null && accountIds.Count > 0)
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    var tmpDeleteCommand = ((IDataBase)this).CreateCommand( );
                    tmpDeleteCommand.Connection = tmpDataConnection;
                    tmpDeleteCommand.CommandType = CommandType.Text;
                    tmpDeleteCommand.CommandText = Statement_DeleteOnPK;
                    tmpDeleteCommand.Parameters.Add(new SQLiteParameter("@AccountId", DbType.Int32));

                    tmpDataConnection.Open( );

                    using(DbTransaction tmpDbTransaction = tmpDataConnection.BeginTransaction( ))
                    {
                         try
                         {
                              var tmpAttributeAccess = new AccountAttributeSQLiteAccess();
                              foreach (int accountId in accountIds)
                              {
                                   tmpDeleteCommand.Parameters["@AccountId"].Value = accountId;
                                   tmpDeleteResult = tmpDeleteCommand.ExecuteNonQuery( ) == 1;

                                   if (tmpDeleteResult)
                                   {
                                        tmpAttributeAccess.DeleteAccountAttributes(accountId, tmpDbTransaction);
                                   }
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

               #endregion DeleteOutrightAccounts

               return tmpDeleteResult;
          }

          public bool DeleteOutright(IList<string> accountGuids)
          {
               bool tmpDeleteResult = false;

               #region DeleteOutrightAccounts

               if(accountGuids != null && accountGuids.Count > 0)
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    var tmpDeleteCommand = ((IDataBase)this).CreateCommand( );
                    tmpDeleteCommand.Connection = tmpDataConnection;
                    tmpDeleteCommand.CommandType = CommandType.Text;
                    tmpDeleteCommand.CommandText = Statement_DeleteByGuid;

                    tmpDeleteCommand.Parameters.Add(new SQLiteParameter("@AccountGuid", DbType.String));

                    tmpDataConnection.Open( );

                    using (DbTransaction tmpDbTransaction = tmpDataConnection.BeginTransaction( ))
                    {
                         try
                         {
                              var tmpAttributeAccess = new AccountAttributeSQLiteAccess();
                              foreach (var tmpAccountGuid in accountGuids)
                              {
                                   var tmpAccountEntity = this.GetAccountEntityByGuid(tmpAccountGuid, tmpDataConnection);
                                   if (tmpAccountEntity != null)
                                   {
                                        tmpDeleteCommand.Parameters["@AccountGuid"].Value = tmpAccountGuid;
                                        tmpDeleteResult = tmpDeleteCommand.ExecuteNonQuery() == 1;
                                        if (tmpDeleteResult)
                                        {
                                             tmpAttributeAccess.DeleteAccountAttributes(tmpAccountEntity.AccountId, tmpDbTransaction);
                                        }
                                   }
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

               #endregion DeleteOutrightAccounts

               return tmpDeleteResult;
          }
     }
}