using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Controllers
{
    public static class DbConnection
    {
        public static string connectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";

        public static SqliteConnection getConnection()
        {
            var masterConnection = new SqliteConnection(connectionString);
            masterConnection.Open();
            return masterConnection;
        }


        public static void CreateTables()
        {
            string connectionString = DbConnection.connectionString;
            var masterConnection = DbConnection.getConnection();
            var createCommand = masterConnection.CreateCommand();
            createCommand.CommandText =
            @"
                CREATE TABLE NUMBER (
                    id INTEGER PRIMARY KEY AUTOINCREMENT , number INT
                )
            ";
            createCommand.ExecuteNonQuery();
            using (var firstConnection = new SqliteConnection(connectionString))
            {
                firstConnection.Open();

                var updateCommand = firstConnection.CreateCommand();
                updateCommand.CommandText =
                @"
                    INSERT INTO NUMBER (number)
                    VALUES (22)
                ";
                updateCommand.ExecuteNonQuery();

                updateCommand.CommandText =
                @"
                    INSERT INTO RAM (type,price)
                    VALUES ('16GB','87.88')
                ";
                updateCommand.ExecuteNonQuery();
            }
           
        }
    }
}
