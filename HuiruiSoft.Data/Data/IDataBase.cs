using System.Data.Common;

namespace HuiruiSoft.Safe.Data
{
     public interface IDBProvider
     {
          IDataBaseProvider CreateProvider( );
     }

     public interface IDataBase
     {
          string ConnectionString
          {
               get;
          }

          DbConnection CreateConnection( );

          DbConnection CreateConnection(string connectionString);

          DbCommand CreateCommand( );

          DbCommand CreateCommand(string commandText);

          DbCommand CreateCommand(DbConnection connection );

          DbCommand CreateCommand(string commandText, DbConnection connection );

          DbCommand CreateCommand(string commandText, DbConnection connection, DbTransaction transaction);


          DbParameter CreateParameter( );

          DbDataAdapter CreateDataAdapter( );
     }

     public interface IDataBaseProvider
     {
          System.Data.IDbConnection CreateConnection( );

          System.Data.IDbConnection CreateConnection(string connectionString);

          System.Data.IDbTransaction CreateTransaction(System.Data.IDbConnection connection);

          System.Data.IDataReader CreateDataReader(System.Data.IDbCommand command);

          System.Data.IDbDataAdapter CreateDataAdapter( );

          System.Data.IDbDataAdapter CreateDataAdapter(System.Data.IDbCommand command);

          System.Data.IDbDataAdapter CreateDataAdapter(string commandText, string connectionString);

          System.Data.IDbDataAdapter CreateDataAdapter(string commandText, System.Data.IDbConnection connection);

          DbDataAdapter CreateDbDataAdapter( );

          DbDataAdapter CreateDbDataAdapter(System.Data.IDbCommand command);

          DbDataAdapter CreateDbDataAdapter(string commandText, string connectionString);

          DbDataAdapter CreateDbDataAdapter(string commandText, System.Data.IDbConnection connection);

          System.Data.IDbCommand CreateCommand( );

          System.Data.IDbCommand CreateCommand(System.Data.IDbConnection connection);

          System.Data.IDbCommand CreateCommand(string commandText, System.Data.IDbConnection connection);

          System.Data.IDbCommand CreateCommand(string commandText, System.Data.IDbConnection connection, System.Data.IDbTransaction transaction);
     }

     public class DBProvider : IDBProvider
     {
          public IDataBaseProvider CreateProvider( )
          {
               return new DataBaseProvider( );
          }
     }

     public class DataBaseProvider : IDataBaseProvider
     {
          public System.Data.IDbConnection CreateConnection( )
          {
               return new System.Data.SqlClient.SqlConnection( );
          }

          public System.Data.IDbConnection CreateConnection(string connectionString)
          {
               return new System.Data.SqlClient.SqlConnection(connectionString);
          }

          public System.Data.IDbTransaction CreateTransaction(System.Data.IDbConnection connection)
          {
               return (System.Data.SqlClient.SqlTransaction)connection.BeginTransaction( );
          }

          public System.Data.IDataReader CreateDataReader(System.Data.IDbCommand command)
          {
               return (System.Data.SqlClient.SqlDataReader)command.ExecuteReader( );
          }

          public System.Data.IDbDataAdapter CreateDataAdapter( )
          {
               return new System.Data.SqlClient.SqlDataAdapter( );
          }

          public System.Data.IDbDataAdapter CreateDataAdapter(System.Data.IDbCommand command)
          {
               return new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command);
          }

          public System.Data.IDbDataAdapter CreateDataAdapter(string commandText, System.Data.IDbConnection connection)
          {
               return new System.Data.SqlClient.SqlDataAdapter(commandText, (System.Data.SqlClient.SqlConnection)connection);
          }

          public System.Data.IDbDataAdapter CreateDataAdapter(string commandText, string connectionString)
          {
               return new System.Data.SqlClient.SqlDataAdapter(commandText, new System.Data.SqlClient.SqlConnection(connectionString));
          }

          public DbDataAdapter CreateDbDataAdapter( )
          {
               return new System.Data.SqlClient.SqlDataAdapter( );
          }

          public DbDataAdapter CreateDbDataAdapter(System.Data.IDbCommand command)
          {
               return new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command);
          }

          public DbDataAdapter CreateDbDataAdapter(string commandText, System.Data.IDbConnection connection)
          {
               return new System.Data.SqlClient.SqlDataAdapter(commandText, (System.Data.SqlClient.SqlConnection)connection);
          }

          public DbDataAdapter CreateDbDataAdapter(string commandText, string connectionString)
          {
               return new System.Data.SqlClient.SqlDataAdapter(commandText, new System.Data.SqlClient.SqlConnection(connectionString));
          }

          public System.Data.IDbCommand CreateCommand( )
          {
               return new System.Data.SqlClient.SqlCommand( );
          }

          public System.Data.IDbCommand CreateCommand(System.Data.IDbConnection connection)
          {
               return (System.Data.SqlClient.SqlCommand)connection.CreateCommand( );
          }

          public System.Data.IDbCommand CreateCommand(string commandText, System.Data.IDbConnection connection)
          {
               return new System.Data.SqlClient.SqlCommand(commandText, (System.Data.SqlClient.SqlConnection)connection);
          }

          public System.Data.IDbCommand CreateCommand(string commandText, System.Data.IDbConnection connection, System.Data.IDbTransaction transaction)
          {
               System.Data.SqlClient.SqlCommand tmpSqlCommand = new System.Data.SqlClient.SqlCommand(commandText, (System.Data.SqlClient.SqlConnection)connection);
               tmpSqlCommand.Transaction = (System.Data.SqlClient.SqlTransaction)transaction;

               return tmpSqlCommand;
          }
     }
}