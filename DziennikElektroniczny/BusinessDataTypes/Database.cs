using System.Collections.Generic;
using System.Data;
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
            sqlConnection = new MySqlConnection("Server=51.38.134.103; database=Dziennik; Uid= Julka; pwd=Abby; ");
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

        public void Close()
        {
            sqlConnection.Close();
        }


    public string AddTeacher(string pesel, string names, string lastName, string phoneNum, string home, string mail, string etat)
        {
            
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dodaj_nauczyciela";
                command.Parameters.AddWithValue("@pesel", pesel);
                command.Parameters.AddWithValue("@imie", names);
                command.Parameters.AddWithValue("@nazwisko", lastName);
                command.Parameters.AddWithValue("@telefon", phoneNum);
                command.Parameters.AddWithValue("adres", home);
                command.Parameters.AddWithValue("@email", mail);
                command.Parameters.AddWithValue("@etat", etat);
                dataReader = command.ExecuteReader();
                 var message = "";
                while (dataReader.Read())
                    message = dataReader[0].ToString();
                dataReader.Close();
                command.CommandType = CommandType.Text;
            return message;
            
        }


        public string AddStudent(string pesel, string names, string lastName, string home, string phoneNum, string mail, string clas)
        {
            
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dodaj_ucznia";
                command.Parameters.AddWithValue("@pesel", pesel);
                command.Parameters.AddWithValue("@imie", names);
                command.Parameters.AddWithValue("@nazwisko", lastName);
                command.Parameters.AddWithValue("@telefon", phoneNum);
                command.Parameters.AddWithValue("adres", home);
                command.Parameters.AddWithValue("@email", mail);
                command.Parameters.AddWithValue("@rocznik", clas.Remove(4));
                command.Parameters.AddWithValue("@literka", clas[4].ToString());
                dataReader = command.ExecuteReader();
                var message = "";
                while (dataReader.Read())
                {
                message = dataReader[0].ToString();
                }
                dataReader.Close();
                command.CommandType = CommandType.Text;
                return message;
        }

        public string AddParent(string pesel, string names, string lastName, string home, string phoneNum, string mail, string Money)
        {

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dodaj_opiekuna";
                command.Parameters.AddWithValue("@pesel", pesel);
                command.Parameters.AddWithValue("@imie", names);
                command.Parameters.AddWithValue("@nazwisko", lastName);
                command.Parameters.AddWithValue("@telefon", phoneNum);
                command.Parameters.AddWithValue("adres", home);
                command.Parameters.AddWithValue("@email", mail);
                command.Parameters.AddWithValue("@dochod", Money);
                dataReader = command.ExecuteReader();
                var messsage = "";
                while (dataReader.Read())
                {
                    messsage = dataReader[0].ToString();
    
                }
                dataReader.Close();
                command.CommandType = CommandType.Text;
            return messsage;
        }

    }
}