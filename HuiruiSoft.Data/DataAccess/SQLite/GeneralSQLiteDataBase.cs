using System.Data.SQLite;
using HuiruiSoft.Safe.Data;
using HuiruiSoft.Safe.Model;

namespace HuiruiSoft.Data.SQLite
{
     public class GeneralSQLiteDataBase : SQLiteDataBase
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          public string DataSource { get; set; } = null;

          public string Password { get; set; } = null;

          private const string connectionString = @"Data Source={0}; Password={1}; Version=3;";

          public override string ConnectionString
          {
               get
               {
                    return string.Format(connectionString, this.DataSource, this.Password);
               }
          }

          public bool CreateDataBase()
          {
               bool tmpExecuteResult = false;

               var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
               try
               {
                    tmpDataConnection.Open();
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

               return tmpExecuteResult;
          }

          public bool ReduceDataBase()
          {
               bool tmpExecuteResult = false;

               var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
               try
               {
                    if (tmpDataConnection.State != System.Data.ConnectionState.Open)
                    {
                         tmpDataConnection.Open();

                         var tmpExecuteCommand = ((IDataBase)this).CreateCommand(tmpDataConnection);
                         tmpExecuteCommand.CommandText = "Vacuum";
                         tmpExecuteCommand.ExecuteNonQuery();
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

               return tmpExecuteResult;
          }

          public bool DeleteTable(string tableName)
          {
               bool tmpExecuteResult = false;

               var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
               try
               {
                    if (tmpDataConnection.State != System.Data.ConnectionState.Open)
                    {
                         tmpDataConnection.Open();

                         var tmpExecuteCommand = ((IDataBase)this).CreateCommand(tmpDataConnection);
                         tmpExecuteCommand.CommandText = string.Format("DROP TABLE IF EXISTS {0}", tableName);
                         tmpExecuteCommand.ExecuteNonQuery();
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

               return tmpExecuteResult;
          }

          public bool RenameTable(string oldTableName, string newTableName)
          {
               bool tmpExecuteResult = false;

               var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
               try
               {
                    if (tmpDataConnection.State != System.Data.ConnectionState.Open)
                    {
                         tmpDataConnection.Open();

                         var tmpExecuteCommand = ((IDataBase)this).CreateCommand(tmpDataConnection);
                         tmpExecuteCommand.CommandText = string.Format("ALTER TABLE {0} RENAME TO {1}", oldTableName, newTableName);
                         tmpExecuteCommand.ExecuteNonQuery();
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

               return tmpExecuteResult;
          }

          public int ExecuteNonQuery(string command)
          {
               int tmpExecuteResult = 0;

               var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
               try
               {
                    if (tmpDataConnection.State != System.Data.ConnectionState.Open)
                    {
                         tmpDataConnection.Open();

                         var tmpExecuteCommand = ((IDataBase)this).CreateCommand(tmpDataConnection);
                         tmpExecuteCommand.CommandText = command;
                         tmpExecuteResult = tmpExecuteCommand.ExecuteNonQuery();
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

               return tmpExecuteResult;
          }

          public bool CreateRootCatalog(AccountCatalog catalog)
          {
               if (catalog == null)
               {
                    throw new System.ArgumentNullException("参数 catalog 不能为空。");
               }

               bool tmpExecuteResult = false;

               using (var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString))
               {
                    var tmpInsertCommand = ((IDataBase)this).CreateCommand();
                    tmpInsertCommand.Connection = tmpDataConnection;
                    tmpInsertCommand.CommandType = System.Data.CommandType.Text;
                    tmpInsertCommand.CommandText = "INSERT INTO safe_account_catalog(Name, ParentId, Depth, OrderNo, VersionNo, CreateTime, UpdateTime, Description) VALUES (@Name, @ParentId, @Depth, @OrderNo, 1, DATETIME('NOW','LOCALTIME'), DATETIME('NOW','LOCALTIME'), @Description); SELECT LAST_INSERT_ROWID() AS CatalogId";

                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Name", System.Data.DbType.String, 30));
                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@ParentId", System.Data.DbType.Int32));
                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@OrderNo", System.Data.DbType.Int32));
                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Depth", System.Data.DbType.Int32));
                    tmpInsertCommand.Parameters.Add(new SQLiteParameter("@Description", System.Data.DbType.String, 255));

                    try
                    {
                         tmpDataConnection.Open();

                         tmpInsertCommand.Parameters["@Name"].Value = catalog.Name;
                         tmpInsertCommand.Parameters["@ParentId"].Value = catalog.ParentId;
                         tmpInsertCommand.Parameters["@OrderNo"].Value = catalog.Order;
                         tmpInsertCommand.Parameters["@Depth"].Value = catalog.Depth;
                         tmpInsertCommand.Parameters["@Description"].Value = catalog.Description;

                         int tmpRowsAffected = tmpInsertCommand.ExecuteNonQuery();

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
     }
}