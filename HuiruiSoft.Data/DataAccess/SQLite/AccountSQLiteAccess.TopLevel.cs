using HuiruiSoft.Safe.Data;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Collections.Generic;

namespace HuiruiSoft.Data.SQLite
{
     public partial class AccountSQLiteAccess
     {
          public bool SetTopMost(int accountId)
          {
               var tmpAccountIds = new List<int>(1);
               tmpAccountIds.Add(accountId);

               return this.UpdateTopLevel(tmpAccountIds, true);
          }

          public bool SetTopMost(IList<int> accountIds)
          {
               return this.UpdateTopLevel(accountIds, true);
          }

          public bool SetTopMost(string accountGuid)
          {
               var tmpAccountGuids = new List<string>(1);
               tmpAccountGuids.Add(accountGuid);

               return this.UpdateTopLevel(tmpAccountGuids, true);
          }

          public bool SetTopMost(IList<string> accountGuids)
          {
               return this.UpdateTopLevel(accountGuids, true);
          }

          public bool CancelTopMost(int accountId)
          {
               var tmpAccountIds = new List<int>(1);
               tmpAccountIds.Add(accountId);

               return this.UpdateTopLevel(tmpAccountIds, false);
          }

          public bool CancelTopMost(IList<int> accountIds)
          {
               return this.UpdateTopLevel(accountIds, false);
          }

          public bool CancelTopMost(string accountGuid)
          {
               var tmpAccountGuids = new List<string>(1);
               tmpAccountGuids.Add(accountGuid);

               return this.UpdateTopLevel(tmpAccountGuids, false);
          }

          public bool CancelTopMost(IList<string> accountGuids)
          {
               return this.UpdateTopLevel(accountGuids, false);
          }

          public bool UpdateTopLevel(IList<int> accountIds, bool topMost)
          {
               bool tmpUpdateResult = false;

               #region UpdateTopLevel

               if(accountIds != null && accountIds.Count > 0)
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    var tmpUpdateCommand = ((IDataBase)this).CreateCommand( );
                    tmpUpdateCommand.Connection = tmpDataConnection;
                    tmpUpdateCommand.CommandType = CommandType.Text;
                    tmpUpdateCommand.CommandText = UpdateTopLevelByPkey;

                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@TopMost", DbType.UInt16));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AccountId", DbType.Int32));

                    tmpDataConnection.Open( );

                    using(DbTransaction tmpDbTransaction = tmpDataConnection.BeginTransaction( ))
                    {
                         try
                         {
                              foreach(int accountId in accountIds)
                              {
                                   tmpUpdateCommand.Parameters["@TopMost"].Value = topMost ? 1 : 0;
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

               #endregion UpdateTopLevel

               return tmpUpdateResult;
          }

          private bool UpdateTopLevel(IList<string> accountGuids, bool topMost)
          {
               bool tmpUpdateResult = false;

               #region UpdateTopLevel

               if(accountGuids != null && accountGuids.Count > 0)
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    var tmpUpdateCommand = ((IDataBase)this).CreateCommand( );
                    tmpUpdateCommand.Connection = tmpDataConnection;
                    tmpUpdateCommand.CommandType = CommandType.Text;
                    tmpUpdateCommand.CommandText = UpdateTopLevelByGuid;

                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@TopMost", DbType.UInt16));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AccountGuid", DbType.String));

                    tmpDataConnection.Open( );

                    using(DbTransaction tmpDbTransaction = tmpDataConnection.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                         try
                         {
                              foreach(string accountGuid in accountGuids)
                              {
                                   tmpUpdateCommand.Parameters["@TopMost"].Value = topMost ? 1 : 0;
                                   tmpUpdateCommand.Parameters["@AccountGuid"].Value = accountGuid;
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

               #endregion UpdateTopLevel

               return tmpUpdateResult;
          }
     }
}