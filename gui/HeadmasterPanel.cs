using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace gui
{
    public class HeadmasterPanel
    {
        private MySqlCommand command;
        private MySqlDataReader dataReader;

        public HeadmasterPanel(MySqlCommand com, MySqlDataReader reader)
        {
            command = com;
            dataReader = reader;
        }


        public void AddWorker()
        {

        }

        public void AddLegalGuardian()
        {

        }

        public void AddStudent()
        {

        }

        public void AddGrill() //word "opieka" means "[he/she] grills" or "caring", lingual joke
        {

        }

        public void AddClassroom()
        {

        }

        public void AddLesson()
        {

        }

        public void AddUnit()
        {

        }

        public void AddSubject(string name)
        {
            command.CommandText = $"SELECT * from przedmiot where nazwa_przedmiotu='{name}'";
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                dataReader.Close();
                return;
            }
            dataReader.Close();
            command.CommandText = $"INSERT INTO przedmiot VALUES ('{name}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void ShowParentsAndChildren()
        {

        }

        public void ShowFormTutorsAndClasses()
        {

        }

        public void ShowEverythingNeededToCreateLesson()
        {

        }

        public void ShowEverythingNeededToCreateClass()
        {

        }
    }
}
