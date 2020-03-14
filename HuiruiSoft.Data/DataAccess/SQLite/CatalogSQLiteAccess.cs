using HuiruiSoft.Safe.ORM;
using HuiruiSoft.Safe.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace HuiruiSoft.Data.SQLite
{
     public class CatalogSQLiteAccess : SQLiteDataBase, HuiruiSoft.Data.DALFactory.ICatalogDataAccess
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private const string TableName_Catalog = "safe_account_catalog";
          private static readonly string Statement_Insert = null;
          private static readonly string Statement_SelectOnPK = null;
          private static readonly string Statement_DeleteOnPK = null;
          private static readonly string Statement_UpdateOnPK = null;

          static CatalogSQLiteAccess()
          {
               Statement_Insert = string.Format("INSERT INTO {0}(Name, ParentId, Depth, OrderNo, VersionNo, CreateTime, UpdateTime, Description)", TableName_Catalog);
               Statement_Insert += " VALUES (@Name, @ParentId, @Depth, @OrderNo, 1, DATETIME('NOW','LOCALTIME'), DATETIME('NOW','LOCALTIME'), @Description); ";
               Statement_Insert += " SELECT LAST_INSERT_ROWID() AS CatalogId";

               Statement_SelectOnPK = string.Format("SELECT * FROM {0} WHERE CatalogId=@CatalogId", TableName_Catalog);
               Statement_DeleteOnPK = string.Format("DELETE FROM {0} WHERE CatalogId=@CatalogId", TableName_Catalog);
               Statement_UpdateOnPK = string.Format("UPDATE {0} SET Name=@Name, OrderNo=@OrderNo, Depth=@Depth, VersionNo=VersionNo+1, UpdateTime=DATETIME('NOW','LOCALTIME'), Description=@Description WHERE CatalogId=@CatalogId AND VersionNo=@VersionNo", TableName_Catalog);
          }

          public bool Create(AccountCatalogEntity entity)
          {
               if (entity == null)
               {
                    throw new System.ArgumentNullException("参数 entity 不能为空。");
               }

               bool tmpExecuteResult = false;

               using (var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    var tmpInsertCommand = ((IDataBase)this).CreateCommand();
                    tmpInsertCommand.Connection = tmpDataConnection;
                    tmpInsertCommand.CommandType = System.Data.CommandType.Text;
                    tmpInsertCommand.CommandText = Statement_Insert;

                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Name", System.Data.DbType.String, 30));
                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@ParentId", System.Data.DbType.Int32));
                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@OrderNo", System.Data.DbType.Int32));
                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Depth", System.Data.DbType.Int32));
                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Description", System.Data.DbType.String, 255));

                    try
                    {
                         tmpDataConnection.Open();

                         tmpInsertCommand.Parameters["@Name"].Value = entity.Name;
                         tmpInsertCommand.Parameters["@ParentId"].Value = entity.ParentId;
                         tmpInsertCommand.Parameters["@OrderNo"].Value = entity.Order;
                         tmpInsertCommand.Parameters["@Depth"].Value = entity.Depth;
                         tmpInsertCommand.Parameters["@Description"].Value = entity.Description;

                         var tmpInsertResult = tmpInsertCommand.ExecuteScalar();
                         if (tmpInsertResult != null && tmpInsertResult != System.DBNull.Value)
                         {
                              tmpExecuteResult = true;
                              entity.CatalogId = System.Convert.ToInt32(tmpInsertResult);
                         }
                    }
                    catch (System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         if (tmpDataConnection.State == System.Data.ConnectionState.Open)
                         {
                              tmpDataConnection.Close();
                         }
                         tmpDataConnection.Dispose();
                    }
               }

               return tmpExecuteResult;
          }

          public bool Delete(AccountCatalogEntity item)
          {
               if (item == null)
               {
                    throw new System.ArgumentNullException("参数 item 不能为空。");
               }

               return this.Delete(item.CatalogId);
          }

          public bool Delete(int catalogId)
          {
               bool tmpExecuteResult = false;

               using (var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    var tmpDeleteCommand = ((IDataBase)this).CreateCommand();
                    tmpDeleteCommand.Connection = tmpDataConnection;
                    tmpDeleteCommand.CommandType = System.Data.CommandType.Text;
                    tmpDeleteCommand.CommandText = Statement_DeleteOnPK;

                    tmpDeleteCommand.Parameters.Add(new SQLiteParameter("@CatalogId", System.Data.DbType.Int32));

                    try
                    {
                         tmpDataConnection.Open();
                         tmpDeleteCommand.Parameters["@CatalogId"].Value = catalogId;

                         int tmpRowsAffected = tmpDeleteCommand.ExecuteNonQuery();

                         tmpExecuteResult = tmpRowsAffected > 0;
                    }
                    catch (System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         if (tmpDataConnection.State == System.Data.ConnectionState.Open)
                         {
                              tmpDataConnection.Close();
                         }
                         tmpDataConnection.Dispose();
                    }
               }

               return tmpExecuteResult;
          }

          public bool Update(AccountCatalogEntity entity)
          {
               if (entity == null)
               {
                    throw new System.ArgumentNullException("参数 entity 不能为空。");
               }

               bool tmpUpdateResult = false;

               using (var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    var tmpUpdateCommand = ((IDataBase)this).CreateCommand();
                    tmpUpdateCommand.Connection = tmpDataConnection;
                    tmpUpdateCommand.CommandType = System.Data.CommandType.Text;
                    tmpUpdateCommand.CommandText = Statement_UpdateOnPK;

                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Name", System.Data.DbType.String, 30));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@OrderNo", System.Data.DbType.Int32));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Depth", System.Data.DbType.Int32));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@Description", System.Data.DbType.String, 255));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@CatalogId", System.Data.DbType.Int32));
                    tmpUpdateCommand.Parameters.Add(new SQLiteParameter("@VersionNo", System.Data.DbType.Int32));

                    try
                    {
                         tmpDataConnection.Open();

                         tmpUpdateCommand.Parameters["@Name"].Value = entity.Name;
                         tmpUpdateCommand.Parameters["@OrderNo"].Value = entity.Order;
                         tmpUpdateCommand.Parameters["@Depth"].Value = entity.Depth;
                         tmpUpdateCommand.Parameters["@Description"].Value = entity.Description;
                         tmpUpdateCommand.Parameters["@CatalogId"].Value = entity.CatalogId;
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
                         if (tmpDataConnection.State == System.Data.ConnectionState.Open)
                         {
                              tmpDataConnection.Close();
                         }
                         tmpDataConnection.Dispose();
                    }
               }

               return tmpUpdateResult;
          }

          public IList<AccountCatalogEntity> GetCatalogEntities()
          {
               IList<AccountCatalogEntity> tmpCatalogEntities = null;

               using (var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    try
                    {
                         tmpDataConnection.Open();

                         var tempDataReader = this.ExecuteReader(string.Format("SELECT * FROM {0}", TableName_Catalog), tmpDataConnection);
                         tmpCatalogEntities = this.ReadCatalogEntities(tempDataReader);
                         tempDataReader.Close();
                    }
                    catch (System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         if (tmpDataConnection.State == System.Data.ConnectionState.Open)
                         {
                              tmpDataConnection.Close();
                         }
                         tmpDataConnection.Dispose();
                    }
               }

               return tmpCatalogEntities;
          }

          public AccountCatalogEntity GetCatalogEntity(int catalogId)
          {
               AccountCatalogEntity tmpCatalogEntity = null;

               using (var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    var tmpSelectCommand = ((IDataBase)this).CreateCommand();
                    tmpSelectCommand.Connection = tmpDataConnection;
                    tmpSelectCommand.CommandType = System.Data.CommandType.Text;
                    tmpSelectCommand.CommandText = Statement_SelectOnPK;

                    tmpSelectCommand.Parameters.Add(new SQLiteParameter("@CatalogId", System.Data.DbType.Int32));
                    tmpSelectCommand.Parameters["@CatalogId"].Value = catalogId;

                    try
                    {
                         tmpDataConnection.Open();

                         var tempDataReader = this.ExecuteReader(tmpSelectCommand);
                         var tmpCatalogEntities = this.ReadCatalogEntities(tempDataReader);
                         tempDataReader.Close();

                         if (tmpCatalogEntities != null && tmpCatalogEntities.Count > 0)
                         {
                              tmpCatalogEntity = tmpCatalogEntities[0];
                         }
                    }
                    catch (System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         if (tmpDataConnection.State == System.Data.ConnectionState.Open)
                         {
                              tmpDataConnection.Close();
                         }
                         tmpDataConnection.Dispose();
                    }
               }

               return tmpCatalogEntity;
          }

          private IList<AccountCatalogEntity> ReadCatalogEntities(System.Data.IDataReader dataReader)
          {
               IList<AccountCatalogEntity> tmpCatalogEntities = null;

               if (dataReader != null)
               {
                    tmpCatalogEntities = new List<AccountCatalogEntity>();

                    while (dataReader.Read())
                    {
                         var tmpCatalogEntity = new AccountCatalogEntity();

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
                                   case "catalogid":
                                        tmpCatalogEntity.CatalogId = dataReader.GetInt32(index);
                                        break;

                                   case "name":
                                        tmpCatalogEntity.Name = dataReader.GetString(index);
                                        break;

                                   case "parentid":
                                        tmpCatalogEntity.ParentId = dataReader.GetInt32(index);
                                        break;

                                   case "depth":
                                        tmpCatalogEntity.Depth = dataReader.GetInt32(index);
                                        break;

                                   case "orderno":
                                        tmpCatalogEntity.Order = dataReader.GetInt32(index);
                                        break;

                                   case "versionno":
                                        tmpCatalogEntity.VersionNo = dataReader.GetInt32(index);
                                        break;

                                   case "createtime":
                                        tmpCatalogEntity.CreateTime = dataReader.GetDateTime(index);
                                        break;

                                   case "updatetime":
                                        tmpCatalogEntity.UpdateTime = dataReader.GetDateTime(index);
                                        break;

                                   case "description":
                                        tmpCatalogEntity.Description = dataReader.GetString(index);
                                        break;

                                   default:
                                        break;
                              }
                         }

                         tmpCatalogEntities.Add(tmpCatalogEntity);
                    }
               }

               return tmpCatalogEntities;
          }


          public System.Data.DataTable GetCatalogTable()
          {
               if (DataBaseHelper.Provider == null)
               {
                    DataBaseHelper.Provider = this;
               }

               var tmpSelectCommand = string.Format("SELECT * FROM {0}", TableName_Catalog);
               var tmpTableResult = DataBaseHelper.ExecuteTable(base.ConnectionString, System.Data.CommandType.Text, tmpSelectCommand, null);

               return tmpTableResult;
          }

          public int GetChildCatalogCount(int catalogId)
          {
               int tmpRecordCount = -1;

               var tmpSelectCommand = string.Format("SELECT COUNT(CatalogId) FROM {0} WHERE ParentID = {1}", TableName_Catalog, catalogId);

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
     }
}