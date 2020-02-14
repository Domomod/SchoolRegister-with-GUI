using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DziennikElektroniczny
{
    public sealed class Database
    {
        private static Database instance = null;
        private static readonly object padlock = new object();
        private static MySqlConnection sqlConnection;
        private static MySqlDataReader dataReader;
        private static MySqlCommand command;
        
        Database()
        {
            sqlConnection = new MySqlConnection("Server=51.38.134.103; database=Dziennik; Uid= ; pwd=; ");
            sqlConnection.Open();
            command = sqlConnection.CreateCommand();
            command.Connection = sqlConnection;
            command.CommandText = "SELECT CURRENT_DATE FROM dual";
        }

        public static Database Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Database();
                    }
                    return instance;
                }
            }
        }
        
        
        
    }
}