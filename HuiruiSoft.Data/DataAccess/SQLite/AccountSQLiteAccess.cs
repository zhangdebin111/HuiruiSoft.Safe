using HuiruiSoft.Safe.ORM;
using HuiruiSoft.Safe.Data;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Collections.Generic;

namespace HuiruiSoft.Data.SQLite
{
     public partial class AccountSQLiteAccess : SQLiteDataBase, HuiruiSoft.Data.DALFactory.IAccountDataAccess
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private const string TableName_Account = "safe_account";
          private static readonly string Statement_Insert = null;
          private static readonly string Statement_SelectAll = null;
          private static readonly string Statement_SelectOnPK = null;
          private static readonly string Statement_MoveToOnPK = null;
          private static readonly string Statement_UpdateOnPK = null;
          private static readonly string Statement_DeleteOnPK = null;
          private static readonly string Statement_SelectByGuid = null;
          private static readonly string Statement_DeleteByGuid = null;
          private static readonly string UpdateTopLevelByPkey = null;
          private static readonly string UpdateTopLevelByGuid = null;
          private static readonly string UpdateDeleteFlagByPK = null;
          private static readonly string UpdateDeleteFlagByGuid = null;
          private static readonly string Statement_SelectOnCatalog = null;
          private static readonly string Statement_SelectRecycleBin = null;

          static AccountSQLiteAccess( )
          {
               Statement_SelectOnPK = string.Format("SELECT * FROM {0} WHERE AccountId=@AccountId", TableName_Account);
               Statement_DeleteOnPK = string.Format("DELETE FROM {0} WHERE AccountId=@AccountId", TableName_Account);

               Statement_SelectRecycleBin = string.Format("SELECT * FROM {0} WHERE Deleted=1", TableName_Account);

               Statement_SelectAll = string.Format("SELECT * FROM {0} WHERE Deleted=0 ORDER BY TopMost DESC, OrderNo ASC", TableName_Account);
               Statement_SelectOnCatalog = string.Format("SELECT * FROM {0} WHERE CatalogId = {1} AND Deleted=0 ORDER BY TopMost DESC, OrderNo ASC", TableName_Account, "{0}");

               Statement_SelectByGuid = string.Format("SELECT * FROM {0} WHERE AccountGuid=@AccountGuid", TableName_Account);
               Statement_DeleteByGuid = string.Format("DELETE FROM {0} WHERE AccountGuid=@AccountGuid", TableName_Account);

               UpdateTopLevelByPkey = string.Format("UPDATE {0} SET TopMost=@TopMost, VersionNo=VersionNo+1 WHERE AccountId=@AccountId", TableName_Account);
               UpdateTopLevelByGuid = string.Format("UPDATE {0} SET TopMost=@TopMost, VersionNo=VersionNo+1 WHERE AccountGuid=@AccountGuid", TableName_Account);
               Statement_MoveToOnPK = string.Format("UPDATE {0} SET CatalogId=@CatalogId, VersionNo=VersionNo+1 WHERE AccountId=@AccountId", TableName_Account);

               UpdateDeleteFlagByPK = string.Format("UPDATE {0} SET Deleted=@Deleted, VersionNo=VersionNo+1 WHERE AccountId=@AccountId AND Deleted!=@Deleted", TableName_Account);
               UpdateDeleteFlagByGuid = string.Format("UPDATE {0} SET Deleted=@Deleted, VersionNo=VersionNo+1 WHERE AccountGuid=@AccountGuid AND Deleted!=@Deleted", TableName_Account);

               Statement_Insert = string.Format("INSERT INTO {0}(AccountGuid, CatalogId, Name, OrderNo, SecretRank, LoginName, Password, Email, Mobile, URL, CreateTime, UpdateTime, Comment)", TableName_Account);
               Statement_Insert += " VALUES (@AccountGuid, @CatalogId, @Name, @OrderNo, @SecretRank, @LoginName, @Password, @Email, @Mobile, @URL, DATETIME('NOW','LOCALTIME'), DATETIME('NOW','LOCALTIME'), @Comment); ";
               Statement_Insert += " SELECT LAST_INSERT_ROWID() AS AccountId";

               Statement_UpdateOnPK = string.Format("UPDATE {0}", TableName_Account);
               Statement_UpdateOnPK += " SET Name=@Name, OrderNo=@OrderNo, SecretRank=@SecretRank, LoginName=@LoginName, Password=@Password, Email=@Email, Mobile=@Mobile, URL=@URL, VersionNo=VersionNo+1, UpdateTime=DATETIME('NOW','LOCALTIME'), Comment=@Comment";
               Statement_UpdateOnPK += " WHERE AccountId=@AccountId AND VersionNo=@VersionNo";
          }

          public bool Create(AccountEntity entity)
          {
               if(entity == null)
               {
                    throw new System.ArgumentNullException("参数 entity 不能为空。");
               }

               return this.Create(entity, null);
          }

          public bool Create(AccountEntity entity, DbTransaction transaction = null)
          {
               if(entity == null)
               {
                    throw new System.ArgumentNullException("参数 entity 不能为空。");
               }

               bool tmpExecuteResult = false;
               bool tmpNewConnection = false;

               #region Create

               var tmpInsertCommand = ((IDataBase)this).CreateCommand( );
               tmpInsertCommand.CommandType = CommandType.Text;
               tmpInsertCommand.CommandText = Statement_Insert;

               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@AccountGuid", DbType.String, 36));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@CatalogId", DbType.Int32));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Name", DbType.String, 50));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@OrderNo", DbType.Int32));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@SecretRank", DbType.Int16));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@LoginName", DbType.String, 80));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Password", DbType.String, 80));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Email", DbType.String, 80));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Mobile", DbType.String, 80));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@URL", DbType.String, 160));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Comment", DbType.String, 5000));

               DbConnection tmpDataConnection = null;
               if (transaction != null && transaction.Connection != null)
               {
                    if (transaction.Connection.State == ConnectionState.Open)
                    {
                         tmpDataConnection = transaction.Connection;
                         tmpInsertCommand.Transaction = transaction;
                    }
               }

               if (tmpDataConnection == null)
               {
                    tmpNewConnection = true;
                    tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    tmpDataConnection.Open();
               }

               try
               {
                    tmpInsertCommand.Connection = tmpDataConnection;

                    tmpInsertCommand.Parameters["@AccountGuid"].Value = entity.AccountGuid;
                    tmpInsertCommand.Parameters["@CatalogId"].Value = entity.CatalogId;
                    tmpInsertCommand.Parameters["@Name"].Value = entity.Name;
                    tmpInsertCommand.Parameters["@OrderNo"].Value = entity.Order;
                    tmpInsertCommand.Parameters["@SecretRank"].Value = entity.SecretRank;
                    tmpInsertCommand.Parameters["@LoginName"].Value = entity.LoginName;
                    tmpInsertCommand.Parameters["@Password"].Value = entity.Password;
                    tmpInsertCommand.Parameters["@Email"].Value = entity.Email;
                    tmpInsertCommand.Parameters["@Mobile"].Value = entity.Mobile;
                    tmpInsertCommand.Parameters["@URL"].Value = entity.URL;
                    tmpInsertCommand.Parameters["@Comment"].Value = entity.Comment;

                    var tmpInsertResult = tmpInsertCommand.ExecuteScalar();
                    if (tmpInsertResult != null && tmpInsertResult != System.DBNull.Value)
                    {
                         tmpExecuteResult = true;
                         entity.AccountId = System.Convert.ToInt32(tmpInsertResult);
                    }
               }
               catch(System.SystemException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }
               finally
               {
                    if (tmpNewConnection)
                    {
                         if (tmpDataConnection.State == ConnectionState.Open)
                         {
                              tmpDataConnection.Close();
                         }
                         tmpDataConnection.Dispose();
                    }
               }

               #endregion Create

               return tmpExecuteResult;
          }

          public bool Update(AccountEntity entity, DbTransaction transaction = null)
          {
               if (entity == null)
               {
                    throw new System.ArgumentNullException("参数 entity 不能为空。");
               }

               bool tmpUpdateResult = false;
               bool tmpNewConnection = false;

               #region Update

               var tmpUpdateCommand = ((IDataBase)this).CreateCommand();
               tmpUpdateCommand.CommandType = CommandType.Text;
               tmpUpdateCommand.CommandText = Statement_UpdateOnPK;

               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Name", DbType.String, 50));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@OrderNo", DbType.Int32));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@SecretRank", DbType.Int16));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@LoginName", DbType.String, 80));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Password", DbType.String, 80));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Email", DbType.String, 80));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Mobile", DbType.String, 80));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@URL", DbType.String, 160));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Comment", DbType.String, 5000));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AccountId", DbType.Int32));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@VersionNo", DbType.Int32));

               DbConnection tmpDataConnection = null;
               if (transaction != null && transaction.Connection != null)
               {
                    if (transaction.Connection.State == ConnectionState.Open)
                    {
                         tmpDataConnection = transaction.Connection;
                         tmpUpdateCommand.Transaction = transaction;
                    }
               }

               if (tmpDataConnection == null)
               {
                    tmpNewConnection = true;
                    tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    tmpDataConnection.Open();
               }

               try
               {
                    tmpUpdateCommand.Connection = tmpDataConnection;

                    tmpUpdateCommand.Parameters["@Name"].Value = entity.Name;
                    tmpUpdateCommand.Parameters["@OrderNo"].Value = entity.Order;
                    tmpUpdateCommand.Parameters["@SecretRank"].Value = entity.SecretRank;
                    tmpUpdateCommand.Parameters["@LoginName"].Value = entity.LoginName;
                    tmpUpdateCommand.Parameters["@Password"].Value = entity.Password;
                    tmpUpdateCommand.Parameters["@Email"].Value = entity.Email;
                    tmpUpdateCommand.Parameters["@Mobile"].Value = entity.Mobile;
                    tmpUpdateCommand.Parameters["@URL"].Value = entity.URL;
                    tmpUpdateCommand.Parameters["@Comment"].Value = entity.Comment;
                    tmpUpdateCommand.Parameters["@AccountId"].Value = entity.AccountId;
                    tmpUpdateCommand.Parameters["@VersionNo"].Value = entity.VersionNo;

                    int tmpRowsAffected = tmpUpdateCommand.ExecuteNonQuery();

                    tmpUpdateResult = tmpRowsAffected > 0;
               }
               catch (System.SystemException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }
               finally
               {
                    if (tmpNewConnection)
                    {
                         if (tmpDataConnection.State == ConnectionState.Open)
                         {
                              tmpDataConnection.Close();
                         }
                         tmpDataConnection.Dispose();
                    }
               }

               #endregion Update

               return tmpUpdateResult;
          }

          public bool MoveToCatalog(IList<int> accountIds, int catalogId)
          {
               bool tmpMoveResult = false;

               #region MoveToCatalog

               if(accountIds != null && accountIds.Count > 0)
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    var tmpUpdateCommand = ((IDataBase)this).CreateCommand( );
                    tmpUpdateCommand.Connection = tmpDataConnection;
                    tmpUpdateCommand.CommandType = CommandType.Text;
                    tmpUpdateCommand.CommandText = Statement_MoveToOnPK;

                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@CatalogId", DbType.Int32));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AccountId", DbType.Int32));

                    tmpDataConnection.Open( );

                    using(DbTransaction tmpDbTransaction = tmpDataConnection.BeginTransaction( ))
                    {
                         try
                         {
                              tmpUpdateCommand.Parameters["@CatalogId"].Value = catalogId;

                              foreach(int accountId in accountIds)
                              {
                                   tmpUpdateCommand.Parameters["@AccountId"].Value = accountId;
                                   tmpMoveResult = tmpUpdateCommand.ExecuteNonQuery( ) == 1;
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

               #endregion MoveToCatalog

               return tmpMoveResult;
          }
          

          public AccountEntity GetAccountEntity(int accountId)
          {
               AccountEntity tmpAccountEntity = null;

               #region GetAccountEntity

               using(var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    var tmpSelectCommand = ((IDataBase)this).CreateCommand( );
                    tmpSelectCommand.Connection = tmpDataConnection;
                    tmpSelectCommand.CommandType = CommandType.Text;
                    tmpSelectCommand.CommandText = Statement_SelectOnPK;

                    tmpSelectCommand.Parameters.Add(new SQLiteParameter("@AccountId", DbType.Int32));
                    tmpSelectCommand.Parameters["@AccountId"].Value = accountId;

                    try
                    {
                         tmpDataConnection.Open( );

                         var tempDataReader = this.ExecuteReader(tmpSelectCommand);
                         var tmpAccountEntities = this.ReadAccountEntities(tempDataReader);
                         tempDataReader.Close( );

                         if(tmpAccountEntities != null && tmpAccountEntities.Count > 0)
                         {
                              tmpAccountEntity = tmpAccountEntities[0];
                         }
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

               #endregion GetAccountEntity

               return tmpAccountEntity;
          }

          public AccountEntity GetAccountEntityByGuid(string accountGuid)
          {
               AccountEntity tmpAccountEntity = null;

               #region GetAccountEntityByGuid

               using(var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    var tmpSelectCommand = ((IDataBase)this).CreateCommand( );
                    tmpSelectCommand.Connection = tmpDataConnection;
                    tmpSelectCommand.CommandType = CommandType.Text;
                    tmpSelectCommand.CommandText = Statement_SelectByGuid;

                    tmpSelectCommand.Parameters.Add(new SQLiteParameter("@AccountGuid", DbType.String));
                    tmpSelectCommand.Parameters["@AccountGuid"].Value = accountGuid;

                    try
                    {
                         tmpDataConnection.Open( );

                         var tempDataReader = this.ExecuteReader(tmpSelectCommand);
                         var tmpAccountEntities = this.ReadAccountEntities(tempDataReader);
                         tempDataReader.Close( );

                         if(tmpAccountEntities != null && tmpAccountEntities.Count > 0)
                         {
                              tmpAccountEntity = tmpAccountEntities[0];
                         }
                    }
                    catch(System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         tmpDataConnection.Close();
                         tmpDataConnection.Dispose( );
                    }
               }

               #endregion GetAccountEntityByGuid

               return tmpAccountEntity;
          }

          public AccountEntity GetAccountEntityByGuid(string accountGuid, DbConnection connection = null)
          {
               AccountEntity tmpAccountEntity = null;

               #region GetAccountEntityByGuid

               var tmpSelectCommand = ((IDataBase)this).CreateCommand( );
               tmpSelectCommand.CommandType = CommandType.Text;
               tmpSelectCommand.CommandText = Statement_SelectByGuid;
               tmpSelectCommand.Parameters.Add(new SQLiteParameter("@AccountGuid", DbType.String));
               tmpSelectCommand.Parameters["@AccountGuid"].Value = accountGuid;

               DbConnection tmpDataConnection = null;
               if(connection != null && connection.State == ConnectionState.Open)
               {
                    tmpSelectCommand.Connection = connection;
               }
               else
               {
                    tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    tmpDataConnection.Open( );
                    tmpSelectCommand.Connection = tmpDataConnection;
               }

               try
               {
                    var tempDataReader = this.ExecuteReader(tmpSelectCommand);
                    var tmpAccountEntities = this.ReadAccountEntities(tempDataReader);
                    tempDataReader.Close( );

                    if(tmpAccountEntities != null && tmpAccountEntities.Count > 0)
                    {
                         tmpAccountEntity = tmpAccountEntities[0];
                    }
               }
               catch(System.SystemException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }
               finally
               {
                    if(tmpDataConnection != null)
                    {
                         if(tmpDataConnection.State == ConnectionState.Open)
                         {
                              tmpDataConnection.Close( );
                         }

                         tmpDataConnection.Dispose( );
                    }
               }

               #endregion GetAccountEntityByGuid

               return tmpAccountEntity;
          }

          public int GetBelongAccountCount(int catalogId)
          {
               int tmpRecordCount = -1;

               string tmpSelectCommand = string.Format("SELECT COUNT(CatalogId) FROM {0} WHERE CatalogId = {1}", TableName_Account, catalogId);
               var tmpDataReader = DataBaseHelper.ExecuteReader(base.ConnectionString, System.Data.CommandType.Text, tmpSelectCommand, null);
               if (tmpDataReader != null)
               {
                    while (tmpDataReader.Read())
                    {
                         tmpRecordCount = tmpDataReader.GetInt32(0);
                         break;
                    }

                    tmpDataReader.Close();
               }

               return tmpRecordCount;
          }

          public IList<AccountEntity> GetAccountEntities( )
          {
               IList<AccountEntity> tmpAccountEntities = null;

               using(var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    try
                    {
                         tmpDataConnection.Open( );

                         var tempDataReader = this.ExecuteReader(Statement_SelectAll, tmpDataConnection);
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
                         tmpDataConnection.Close();
                         tmpDataConnection.Dispose( );
                    }
               }

               return tmpAccountEntities;
          }

          public IList<AccountEntity> GetAccountEntities(int catalogId)
          {
               IList<AccountEntity> tmpAccountEntities = null;

               #region GetAccountEntities

               using (var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    try
                    {
                         tmpDataConnection.Open();

                         var tempDataReader = this.ExecuteReader(string.Format(Statement_SelectOnCatalog, catalogId), tmpDataConnection);
                         tmpAccountEntities = this.ReadAccountEntities(tempDataReader);
                         tempDataReader.Close();
                    }
                    catch (System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         tmpDataConnection.Close();
                         tmpDataConnection.Dispose();
                    }
               }

               #endregion GetAccountEntities

               return tmpAccountEntities;
          }

          private List<AccountEntity> ReadAccountEntities(IDataReader dataReader)
          {
               List<AccountEntity> tmpAccountEntities = null;

               #region ReadAccountEntities

               if(dataReader != null)
               {
                    tmpAccountEntities = new List<AccountEntity>( );

                    while(dataReader.Read( ))
                    {
                         var tmpAccountEntity = new AccountEntity( );

                         string tmpColumnName;
                         for(int index = 0; index < dataReader.FieldCount; index++)
                         {
                              if(dataReader.IsDBNull(index))
                              {
                                   continue;
                              }

                              tmpColumnName = dataReader.GetName(index);
                              switch(tmpColumnName.ToLower( ))
                              {
                                   case "accountid":
                                        tmpAccountEntity.AccountId = dataReader.GetInt32(index);
                                        break;

                                   case "accountguid":
                                        tmpAccountEntity.AccountGuid = dataReader.GetString(index);
                                        break;

                                   case "catalogid":
                                        tmpAccountEntity.CatalogId = dataReader.GetInt32(index);
                                        break;

                                   case "name":
                                        tmpAccountEntity.Name = dataReader.GetString(index);
                                        break;

                                   case "orderno":
                                        tmpAccountEntity.Order = dataReader.GetInt32(index);
                                        break;

                                   case "topmost":
                                        tmpAccountEntity.TopMost = dataReader.GetInt16(index);
                                        break;

                                   case "deleted":
                                        tmpAccountEntity.Deleted = dataReader.GetBoolean(index);
                                        break;

                                   case "secretrank":
                                        tmpAccountEntity.SecretRank = (ushort)dataReader.GetInt16(index);
                                        break;

                                   case "loginname":
                                        tmpAccountEntity.LoginName = dataReader.GetString(index);
                                        break;

                                   case "password":
                                        tmpAccountEntity.Password = dataReader.GetString(index);
                                        break;

                                   case "email":
                                        tmpAccountEntity.Email = dataReader.GetString(index);
                                        break;

                                   case "mobile":
                                        tmpAccountEntity.Mobile = dataReader.GetString(index);
                                        break;

                                   case "url":
                                        tmpAccountEntity.URL = dataReader.GetString(index);
                                        break;

                                   case "comment":
                                        tmpAccountEntity.Comment = dataReader.GetString(index);
                                        break;

                                   case "versionno":
                                        tmpAccountEntity.VersionNo = dataReader.GetInt32(index);
                                        break;

                                   case "createtime":
                                        tmpAccountEntity.CreateTime = dataReader.GetDateTime(index);
                                        break;

                                   case "updatetime":
                                        tmpAccountEntity.UpdateTime = dataReader.GetDateTime(index);
                                        break;

                                   default:
                                        break;
                              }
                         }

                         tmpAccountEntities.Add(tmpAccountEntity);
                    }
               }

               #endregion ReadAccountEntities

               return tmpAccountEntities;
          }
     }
}