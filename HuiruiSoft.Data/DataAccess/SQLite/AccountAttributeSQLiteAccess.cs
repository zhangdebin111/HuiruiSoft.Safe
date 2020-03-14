using HuiruiSoft.Safe.ORM;
using HuiruiSoft.Safe.Data;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Collections.Generic;

namespace HuiruiSoft.Data.SQLite
{
     public class AccountAttributeSQLiteAccess : SQLiteDataBase, HuiruiSoft.Data.DALFactory.IAccountAttributeDataAccess
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private const string TableName_Attribute = "safe_account_attribute";
          private static readonly string Statement_InsertAttribute = null;
          private static readonly string Statement_DeleteOnAccount = null;
          private static readonly string Statement_UpdateOnPrimary = null;

          static AccountAttributeSQLiteAccess( )
          {
               Statement_DeleteOnAccount = string.Format("DELETE FROM {0} WHERE AccountId=@AccountId", TableName_Attribute);

               Statement_InsertAttribute = string.Format("INSERT INTO {0}(AccountId, OrderNo, Encrypted, AttrName, AttrValue) VALUES (@AccountId, @OrderNo, @Encrypted, @AttrName, @AttrValue); SELECT LAST_INSERT_ROWID() AS AttrId", TableName_Attribute);
               Statement_UpdateOnPrimary = string.Format("UPDATE {0} SET OrderNo=@OrderNo, Encrypted=@Encrypted, AttrName=@AttrName, AttrValue=@AttrValue WHERE AttrId=@AttrId AND AccountId=@AccountId", TableName_Attribute);
          }

          public bool New(IList<AccountAttributeEntity> items, DbTransaction dataTransaction)
          {
               if(items == null)
               {
                    throw new System.ArgumentNullException("参数 items 不能为空。");
               }

               if(dataTransaction == null)
               {
                    throw new System.ArgumentNullException("参数 dataTransaction 不能为空。");
               }

               bool tmpExecuteResult = false;

               var tmpInsertCommand = ((IDataBase)this).CreateCommand( );
               tmpInsertCommand.CommandType = System.Data.CommandType.Text;
               tmpInsertCommand.CommandText = Statement_InsertAttribute;
               tmpInsertCommand.Connection = dataTransaction.Connection;
               tmpInsertCommand.Transaction = dataTransaction;

               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@AccountId", System.Data.DbType.Int32));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@OrderNo", System.Data.DbType.Int32));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Encrypted", System.Data.DbType.Boolean));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@AttrName", System.Data.DbType.String, 50));
               tmpInsertCommand.Parameters.Add(new SQLiteParameter("@AttrValue", System.Data.DbType.String, 500));

               try
               {
                    foreach(var item in items)
                    {
                         tmpInsertCommand.Parameters["@AccountId"].Value = item.AccountId;
                         tmpInsertCommand.Parameters["@OrderNo"].Value = item.Order;
                         tmpInsertCommand.Parameters["@Encrypted"].Value = item.Encrypted;
                         tmpInsertCommand.Parameters["@AttrName"].Value = item.Name;
                         tmpInsertCommand.Parameters["@AttrValue"].Value = item.Value;

                         var tmpInsertResult = tmpInsertCommand.ExecuteScalar();
                         if (tmpInsertResult != null && tmpInsertResult != System.DBNull.Value)
                         {
                              tmpExecuteResult = true;
                              item.AccountId = System.Convert.ToInt32(tmpInsertResult);
                         }
                    }
               }
               catch(System.SystemException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }

               return tmpExecuteResult;
          }

          public bool Update(IList<AccountAttributeEntity> items, DbTransaction dataTransaction = null)
          {
               if(items == null)
               {
                    throw new System.ArgumentNullException("参数 entity 不能为空。");
               }

               if(dataTransaction == null)
               {
                    throw new System.ArgumentNullException("参数 dataTransaction 不能为空。");
               }

               bool tmpUpdateResult = false;

               var tmpUpdateCommand = ((IDataBase)this).CreateCommand( );
               tmpUpdateCommand.CommandType = System.Data.CommandType.Text;
               tmpUpdateCommand.CommandText = Statement_UpdateOnPrimary;
               tmpUpdateCommand.Connection = dataTransaction.Connection;
               tmpUpdateCommand.Transaction = dataTransaction;

               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@OrderNo", System.Data.DbType.Int32));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Encrypted", System.Data.DbType.Boolean));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AttrName", System.Data.DbType.String, 50));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AttrValue", System.Data.DbType.String, 500));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AttrId", System.Data.DbType.Int32));
               tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@AccountId", System.Data.DbType.Int32));

               try
               {
                    foreach(var item in items)
                    {
                         tmpUpdateCommand.Parameters["@OrderNo"].Value = item.Order;
                         tmpUpdateCommand.Parameters["@Encrypted"].Value = item.Encrypted;
                         tmpUpdateCommand.Parameters["@AttrName"].Value = item.Name;
                         tmpUpdateCommand.Parameters["@AttrValue"].Value = item.Value;
                         tmpUpdateCommand.Parameters["@AttrId"].Value = item.AttributeId;
                         tmpUpdateCommand.Parameters["@AccountId"].Value = item.AccountId;

                         tmpUpdateResult = tmpUpdateCommand.ExecuteNonQuery() > 0;
                    }
               }
               catch(System.SystemException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }

               return tmpUpdateResult;
          }

          public bool Delete(IList<AccountAttributeEntity> items, DbTransaction dataTransaction = null)
          {
               if(items == null)
               {
                    throw new System.ArgumentNullException("参数 items 不能为空。");
               }

               if(dataTransaction == null)
               {
                    throw new System.ArgumentNullException("参数 dataTransaction 不能为空。");
               }

               bool tmpExecuteResult = false;

               DbCommand tmpDataCommand = ((IDataBase)this).CreateCommand( );
               tmpDataCommand.CommandType = System.Data.CommandType.Text;
               tmpDataCommand.CommandText = string.Format("DELETE FROM {0} WHERE AttrId=@AttrId AND AccountId=@AccountId", TableName_Attribute);
               tmpDataCommand.Connection = dataTransaction.Connection;
               tmpDataCommand.Transaction = dataTransaction;
               tmpDataCommand.Parameters.Add(new SQLiteParameter("@AttrId", System.Data.DbType.Int32));
               tmpDataCommand.Parameters.Add(new SQLiteParameter("@AccountId", System.Data.DbType.Int32));

               foreach(var item in items)
               {
                    tmpDataCommand.Parameters["@AttrId"].Value = item.AttributeId;
                    tmpDataCommand.Parameters["@AccountId"].Value = item.AccountId;

                    tmpExecuteResult = (base.ExecuteNonQuery(tmpDataCommand) == 1);
                    if(!tmpExecuteResult)
                    {
                         break;
                    }
               }

               return tmpExecuteResult;
          }

          public bool DeleteAccountAttributes(int accountId, DbTransaction dataTransaction)
          {
               if (dataTransaction == null)
               {
                    throw new System.ArgumentNullException("参数 dataTransaction 不能为空。");
               }

               DbCommand tmpDeleteCommand = ((IDataBase)this).CreateCommand();
               tmpDeleteCommand.CommandType = System.Data.CommandType.Text;
               tmpDeleteCommand.CommandText = Statement_DeleteOnAccount;
               tmpDeleteCommand.Connection = dataTransaction.Connection;
               tmpDeleteCommand.Transaction = dataTransaction;
               tmpDeleteCommand.Parameters.Add(new SQLiteParameter("@AccountId", System.Data.DbType.Int32));
               tmpDeleteCommand.Parameters["@AccountId"].Value = accountId;

               bool tmpExecuteResult;
               try
               {
                    tmpDeleteCommand.ExecuteNonQuery();
                    tmpExecuteResult = true;
               }
               catch (System.SystemException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }

               return tmpExecuteResult;
          }

          public IList<AccountAttributeEntity> GetAccountAttributeEntities(DbConnection dataConnection)
          {
               IList<AccountAttributeEntity> tmpAttributeEntities = null;

               IDataReader tmpDataReader;
               var tmpSelectCommand =  string.Format("SELECT * FROM {0}", TableName_Attribute);
               if (dataConnection != null && dataConnection.State == ConnectionState.Open)
               {
                    tmpDataReader = this.ExecuteReader(tmpSelectCommand, dataConnection);
                    tmpAttributeEntities = this.ReadAttributeEntities(tmpDataReader);
                    tmpDataReader.Close();
               }
               else
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);

                    try
                    {
                         tmpDataConnection.Open();

                         tmpDataReader = this.ExecuteReader(tmpSelectCommand, tmpDataConnection);
                         tmpAttributeEntities = this.ReadAttributeEntities(tmpDataReader);
                         tmpDataReader.Close();
                    }
                    catch (System.SystemException exception)
                    {
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

               return tmpAttributeEntities;
          }

          public IList<AccountAttributeEntity> GetAccountAttributeEntities(int accountId, DbConnection dataConnection)
          {
               IList<AccountAttributeEntity> tmpAttributeEntities = null;

               IDataReader tmpDataReader;
               const string SelectCommand = "SELECT * FROM {0} WHERE AccountId = {1}";
               if (dataConnection != null && dataConnection.State == ConnectionState.Open)
               {
                    tmpDataReader = this.ExecuteReader(string.Format(SelectCommand, TableName_Attribute, accountId), dataConnection);
                    tmpAttributeEntities = this.ReadAttributeEntities(tmpDataReader);
                    tmpDataReader.Close();
               }
               else
               {
                    var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);

                    try
                    {
                         tmpDataConnection.Open();

                         tmpDataReader = this.ExecuteReader(string.Format(SelectCommand, TableName_Attribute, accountId), tmpDataConnection);
                         tmpAttributeEntities = this.ReadAttributeEntities(tmpDataReader);
                         tmpDataReader.Close();
                    }
                    catch (System.SystemException exception)
                    {
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

               return tmpAttributeEntities;
          }


          private IList<AccountAttributeEntity> ReadAttributeEntities(IDataReader dataReader)
          {
               if (dataReader == null)
               {
                    return null;
               }

               var tmpAttributeEntities = new List<AccountAttributeEntity>();
               while (dataReader.Read())
               {
                    var tmpAttributeEntity = new AccountAttributeEntity();

                    string tmpColumnName;
                    for (int index = 0; index < dataReader.FieldCount; index++)
                    {
                         if (dataReader.IsDBNull(index))
                         {
                              continue;
                         }

                         tmpColumnName = dataReader.GetName(index);
                         switch (tmpColumnName.ToLower())
                         {
                              case "attrid":
                                   tmpAttributeEntity.AttributeId = dataReader.GetInt32(index);
                                   break;

                              case "accountid":
                                   tmpAttributeEntity.AccountId = dataReader.GetInt32(index);
                                   break;

                              case "orderno":
                                   tmpAttributeEntity.Order = dataReader.GetInt16(index);
                                   break;

                              case "encrypted":
                                   tmpAttributeEntity.Encrypted = dataReader.GetBoolean(index);
                                   break;

                              case "attrname":
                                   tmpAttributeEntity.Name = dataReader.GetString(index);
                                   break;

                              case "attrvalue":
                                   tmpAttributeEntity.Value = dataReader.GetString(index);
                                   break;

                              default:
                                   break;
                         }
                    }

                    tmpAttributeEntities.Add(tmpAttributeEntity);
               }

               return tmpAttributeEntities;
          }
     }
}