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

        public void AddSubject()
        {

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
