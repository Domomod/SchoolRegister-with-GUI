using System;
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

        public List<Nauczyciel> GetTeachers()
        {
            command.CommandText = $"SELECT imie, nazwisko, pesel, etat, adres_zamieszkania, numer_telefonu, email FROM dane_osobowe JOIN nauczyciel on pesel=dane_osobowe_pesel where pesel!=666 ";
            dataReader = command.ExecuteReader();
            List<Nauczyciel> list = new List<Nauczyciel>();
            while (dataReader.Read())
            {
                list.Add(new Nauczyciel(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[5].ToString(), dataReader[4].ToString(),dataReader[6].ToString(), dataReader[3].ToString()));
            }
            dataReader.Close();
            return list;
        }


        public void AddRoom(string floor, string number, string chairs)
        {
            command.CommandText = $"INSERT INTO sala VALUES ({floor},{number},{chairs})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void AddUnit(string hour, string minute)
        {
            command.CommandText = $"INSERT INTO jednostka VALUES ({hour},{minute})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void AddProfile(string profilname)
        {
            command.CommandText = $"INSERT INTO profil VALUES('{profilname}') ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
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


        public void UpdateTeacher()
        {

        }

        public void UpdateParent(string pesel)
        {

        }

        public void UpdateStudent()
        {

        }

        public void DeleteTeacher(string teacher)
        {
            try
            {
                var pesel = teacher.Split("(")[1];
                pesel = pesel.Remove(pesel.Length - 1);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usun_nauczyciela";
                command.Parameters.AddWithValue("@arg_pesel", pesel);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString() != "ok")
                        throw new Exception();
                }
                dataReader.Close();
                command.CommandType = CommandType.Text;
            }
            catch (Exception)
            {
                dataReader.Close();
                command.CommandType = CommandType.Text;
                throw new Exception();
            }

        }

        public void DeleteStudent(string student)
        {
            var pesel = student.Split("(")[1];
            pesel = pesel.Remove(pesel.Length - 1);
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usun_ucznia";
                command.Parameters.AddWithValue("@arg_pesel", pesel);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString() != "ok")
                        throw new Exception();
                }
                dataReader.Close();
                command.CommandType = CommandType.Text;
            }
            catch (Exception)
            {
                dataReader.Close();
                command.CommandType = CommandType.Text;
                throw new Exception();
            }
        }

        public void DeleteParent(string parent)
        {
            var pesel = parent.Split("(")[1];
            pesel = pesel.Remove(pesel.Length - 1);
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usun_opiekuna";
                command.Parameters.AddWithValue("@arg_pesel", pesel);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString() != "ok")
                        throw new Exception();
                }
                dataReader.Close();
                command.CommandType = CommandType.Text;
            }
            catch (Exception)
            {
                dataReader.Close();
                command.CommandType = CommandType.Text;
                throw new Exception();
            }
        }
    }
}