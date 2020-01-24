using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace gui
{
    public class PersonPanel
    {
        protected string PESEL;
        protected static MySqlCommand command;
        protected static MySqlDataReader dataReader;

        public PersonPanel(string pesel, MySqlCommand com, MySqlDataReader reader)
        {
            PESEL = pesel;
            command = com;
            dataReader = reader;
        }

        public void showTopStudents()
        {
            command.CommandText = " SELECT * FROM srednie_uczniow WHERE srednia >= 5";
            dataReader = command.ExecuteReader();
            List<(string, string, string, string, string)> list = new List<(string, string, string, string, string)>();
            while (dataReader.Read())
            {
                list.Add((dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString()));
            }
            dataReader.Close();
        }
    }
}
