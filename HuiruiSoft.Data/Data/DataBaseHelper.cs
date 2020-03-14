using System.Data;
using System.Data.Common;

namespace HuiruiSoft.Safe.Data
{
     public static class DataBaseHelper
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          public static void SetTimeoutDefault( )
          {
               Timeout = 30;
          }

          public static int Timeout = 30;

          public static IDataBase Provider = null;

          public static DbConnection Connection = null;

          /// <summary>关闭连接</summary>
          public static void CloseConnection( )
          {
               if(Connection != null)
               {
                    if(Connection.State == ConnectionState.Open)
                    {
                         Connection.Close( );
                    }
               }
          }

          public static int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );
               PrepareCommand(tmpDataCommand, connection, null, commandType, commandText, commandParameters);

               int tmpRowsAffected = tmpDataCommand.ExecuteNonQuery( );
               tmpDataCommand.Parameters.Clear( );

               Connection = connection;
               return tmpRowsAffected;
          }

          public static int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );
               PrepareCommand(tmpDataCommand, transaction.Connection, transaction, commandType, commandText, commandParameters);

               int tmpRowsAffected = tmpDataCommand.ExecuteNonQuery( );
               tmpDataCommand.Parameters.Clear( );

               Connection = transaction.Connection;
               return tmpRowsAffected;
          }

          public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );

               using(var tmpDataConnection = Provider.CreateConnection( ))
               {
                    try
                    {
                         tmpDataConnection.ConnectionString = connectionString;
                         PrepareCommand(tmpDataCommand, tmpDataConnection, null, commandType, commandText, commandParameters);

                         int tmpRowsAffected = tmpDataCommand.ExecuteNonQuery( );
                         //tmpDataCommand.Parameters.Clear( );
                         return tmpRowsAffected;
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
          }

          public static DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );

               var tmpCommandBehavior = CommandBehavior.Default;
               if(connection == null || connection.State != ConnectionState.Open)
               {
                    tmpCommandBehavior = System.Data.CommandBehavior.CloseConnection;
               }

               PrepareCommand(tmpDataCommand, connection, null, commandType, commandText, commandParameters);

               var tmpDataReader = tmpDataCommand.ExecuteReader(tmpCommandBehavior);
               tmpDataCommand.Parameters.Clear( );

               return tmpDataReader;
          }

          public static DbDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );

               var tmpDataConnection = Provider.CreateConnection( );
               tmpDataConnection.ConnectionString = connectionString;

               try
               {
                    if(tmpDataConnection.State != ConnectionState.Open)
                    {
                         tmpDataConnection.Open( );
                    }

                    PrepareCommand(tmpDataCommand, tmpDataConnection, null, commandType, commandText, commandParameters);

                    var tmpDataReader = tmpDataCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    tmpDataCommand.Parameters.Clear( );

                    Connection = tmpDataConnection;
                    return tmpDataReader;
               }
               catch(System.Data.Common.DbException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }
               catch(System.SystemException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }
               finally
               {
                    //
               }
          }

          public static object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );

               PrepareCommand(tmpDataCommand, connection, null, commandType, commandText, commandParameters);

               object tmpReturnResult = tmpDataCommand.ExecuteScalar( );
               tmpDataCommand.Parameters.Clear( );
               Connection = connection;

               return tmpReturnResult;
          }

          public static object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );
               PrepareCommand(tmpDataCommand, transaction.Connection, transaction, commandType, commandText, commandParameters);

               object tmpReturnResult = tmpDataCommand.ExecuteScalar( );
               tmpDataCommand.Parameters.Clear( );
               Connection = transaction.Connection;

               return tmpReturnResult;
          }

          public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );

               using(var tmpDbConnection = Provider.CreateConnection( ))
               {
                    try
                    {
                         tmpDbConnection.ConnectionString = connectionString;
                         PrepareCommand(tmpDataCommand, tmpDbConnection, null, commandType, commandText, commandParameters);

                         object tmpReturnResult = tmpDataCommand.ExecuteScalar( );
                         tmpDataCommand.Parameters.Clear( );

                         return tmpReturnResult;
                    }
                    catch(System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         if(tmpDbConnection.State == ConnectionState.Open)
                         {
                              tmpDbConnection.Close( );
                         }
                    }
               }
          }

          public static DataTable ExecuteTable(DbConnection connection, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );
               PrepareCommand(tmpDataCommand, connection, null, commandType, commandText, commandParameters);

               var tmpDataAdapter = Provider.CreateDataAdapter( );
               tmpDataAdapter.SelectCommand = tmpDataCommand;

               var tmpDataSet = new System.Data.DataSet( );
               tmpDataAdapter.Fill(tmpDataSet, "Result");
               tmpDataCommand.Parameters.Clear( );
               Connection = connection;

               return tmpDataSet.Tables["Result"];
          }

          public static DataTable ExecuteTable(string connectionString, CommandType commandType, string commandText, params DbParameter[ ] commandParameters)
          {
               var tmpDataCommand = Provider.CreateCommand( );

               using(var tmpDbConnection = Provider.CreateConnection( ))
               {
                    try
                    {
                         tmpDbConnection.ConnectionString = connectionString;

                         PrepareCommand(tmpDataCommand, tmpDbConnection, null, commandType, commandText, commandParameters);

                         var tmpDataAdapter = Provider.CreateDataAdapter( );
                         tmpDataAdapter.SelectCommand = tmpDataCommand;

                         var tmpDataTableResult = new System.Data.DataTable( );
                         tmpDataAdapter.Fill(tmpDataTableResult);
                         tmpDataCommand.Parameters.Clear( );

                         return tmpDataTableResult;
                    }
                    catch(System.InvalidOperationException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    catch(System.SystemException exception)
                    {
                         loger.Error(exception);
                         throw exception;
                    }
                    finally
                    {
                         if(tmpDbConnection.State == ConnectionState.Open)
                         {
                              tmpDbConnection.Close( );
                         }
                    }
               }
          }

          private static void PrepareCommand(DbCommand dataCommand, DbConnection dataConnection, DbTransaction transaction, CommandType commandType, string commandText, DbParameter[ ] commandParms)
          {
               if(dataConnection.State != ConnectionState.Open)
               {
                    dataConnection.Open( );
               }

               dataCommand.Connection = dataConnection;
               dataCommand.CommandText = commandText;

               if(transaction != null)
               {
                    dataCommand.Transaction = transaction;
               }

               dataCommand.CommandType = commandType;
               dataCommand.CommandTimeout = Timeout;

               if(commandParms != null)
               {
                    foreach(var tmpDbParameter in commandParms)
                    {
                         if(tmpDbParameter != null)
                         {
                              dataCommand.Parameters.Add(tmpDbParameter);
                         }
                    }
               }
          }
     }
}