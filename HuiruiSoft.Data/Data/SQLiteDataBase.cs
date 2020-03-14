
namespace HuiruiSoft.Data.SQLite
{
     using System.Data;
     using System.Data.Common;
     using System.Data.SQLite;
     using HuiruiSoft.Safe.Data;
     using HuiruiSoft.Data.Configuration;

     public abstract class SQLiteDataBase : IDataBase
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private const string ConnectionStringTemplate = @"Data Source={0}; Password={1}; Version=3; Pooling=False; Max Pool Size=10;";
          
          public virtual string ConnectionString
          {
               get
               {
                    return string.Format(ConnectionStringTemplate, DataBaseConfig.DataSource, DataBaseConfig.Password);
               }
          }

          public SQLiteDataBase( )
          {
               DataBaseHelper.Provider = this;
          }

          DbConnection IDataBase.CreateConnection( )
          {
               return new SQLiteConnection( );
          }

          DbConnection IDataBase.CreateConnection(string connectionString)
          {
               return new SQLiteConnection(connectionString);
          }

          DbCommand IDataBase.CreateCommand( )
          {
               return new SQLiteCommand( );
          }

          DbCommand IDataBase.CreateCommand(string commandText)
          {
               return new SQLiteCommand(commandText);
          }

          DbCommand IDataBase.CreateCommand(DbConnection connection)
          {
               return new SQLiteCommand((SQLiteConnection)connection);
          }

          DbCommand IDataBase.CreateCommand(string commandText, DbConnection connection)
          {
               return new SQLiteCommand(commandText, (SQLiteConnection)connection);
          }

          DbCommand IDataBase.CreateCommand(string commandText, DbConnection connection, DbTransaction transaction)
          {
               return new SQLiteCommand(commandText, (SQLiteConnection)connection, (SQLiteTransaction)transaction);
          }

          DbParameter IDataBase.CreateParameter( )
          {
               return new SQLiteParameter( );
          }

          DbDataAdapter IDataBase.CreateDataAdapter( )
          {
               return new SQLiteDataAdapter( );
          }

          protected virtual void AddParameter(DbCommand command, string parameterName, DbType dbType)
          {
               this.AddParameter(command, parameterName, dbType, 0, string.Empty);
          }

          protected virtual void AddParameter(DbCommand command, string parameterName, DbType dbType, int size)
          {
               this.AddParameter(command, parameterName, dbType, size, string.Empty);
          }

          protected virtual void AddParameter(DbCommand command, string parameterName, DbType dbType, int size, string sourceColumn)
          {
               if(command != null)
               {
                    var tmpDataParameter = command.CreateParameter( );
                    tmpDataParameter.ParameterName = parameterName;
                    tmpDataParameter.DbType = dbType;

                    if(size > 0)
                    {
                         tmpDataParameter.Size = size;
                    }

                    if(!string.IsNullOrEmpty(sourceColumn))
                    {
                         tmpDataParameter.SourceColumn = sourceColumn;
                    }

                    command.Parameters.Add(tmpDataParameter);
               }
          }

          public DataTable GetDataTable(string commandText)
          {
               return this.GetDataTable(commandText, CommandType.Text);
          }

          public DataTable GetDataTable(string commandText, CommandType commandType)
          {
               DataTable tmpDataTableResult;
               try
               {
                    tmpDataTableResult = DataBaseHelper.ExecuteTable(this.ConnectionString, commandType, commandText, null);
               }
               catch(System.InvalidOperationException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }

               return tmpDataTableResult;
          }

          public int ExecuteNonQuery(DbCommand command)
          {
               int tmpAffectedCount = 0;

               if(command != null)
               {
                    if(command.Connection == null)
                    {
                         command.Connection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    }

                    if(command.Connection.State == ConnectionState.Closed || command.Connection.State == ConnectionState.Broken)
                    {
                         command.Connection.Open( );
                    }

                    tmpAffectedCount = command.ExecuteNonQuery( );

                    if(command.Connection != null)
                    {
                         command.Connection.Close( );
                    }
               }

               return tmpAffectedCount;
          }

          public IDataReader ExecuteReader(string commandText, DbConnection connection)
          {
               if(string.IsNullOrEmpty(commandText))
               {
                    throw new System.ArgumentNullException("参数 commandText 不能为空。");
               }

               return DataBaseHelper.ExecuteReader(connection, CommandType.Text, commandText, null);
          }

          public IDataReader ExecuteReader(DbCommand command)
          {
               IDataReader tmpDataReader = null;

               if(command != null)
               {
                    if(command.Connection == null)
                    {
                         command.Connection = ((IDataBase)this).CreateConnection(this.ConnectionString);
                    }

                    if(command.Connection.State == ConnectionState.Closed || command.Connection.State == ConnectionState.Broken)
                    {
                         command.Connection.Open( );
                    }

                    tmpDataReader = command.ExecuteReader( );
               }

               return tmpDataReader;
          }

          public bool ChangePassword(string password)
          {
               bool tmpChangeResult = false;

               var tmpDataConnection = ((IDataBase)this).CreateConnection(this.ConnectionString);
               try
               {
                    if (tmpDataConnection.State != ConnectionState.Open)
                    {
                         tmpDataConnection.Open();
                         ((SQLiteConnection)tmpDataConnection).ChangePassword(password);
                    }
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

               return tmpChangeResult;
          }

          public virtual void ReleaseConnection()
          {
               SQLiteConnection.ClearAllPools();
               System.GC.Collect();
               System.GC.WaitForPendingFinalizers();
          }
     }
}