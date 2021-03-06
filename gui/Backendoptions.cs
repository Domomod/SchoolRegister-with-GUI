﻿using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace gui
{
    public class Backendoptions
    {
        private static string currentPesel;
        private static MySqlConnection sqlConnection;
        private static MySqlDataReader dataReader;
        private static MySqlCommand command;
        private static bool open = false;
        private static bool A = false;
        private static bool T = false;
        private static bool P = false;
        private static bool S = false;
        private static string currentClass = "";
        private static string currentChild = "";
        private static SQLChecker checker;


        static public bool IsChildSet()
        {
            return (currentChild != "");
        }
        static public bool IsClassSet()
        {
            return (currentClass != "");
        }
        static public void SetClass(string clas)
        {
            currentClass = clas;
        }
        static public void SetChild(string child)
        {
            var childdata = child.Split("(");
            currentChild = childdata[1].Remove(childdata[1].Length - 1);
        }
        static public bool IsOpen()
        {
            return open;
        }
        static public bool IsAdmin()
        {
            return A;
        }
        static public bool IsTeacher()
        {
            return T;
        }
        static public bool IsParent()
        {
            return P;
        }
        static public bool IsStudent()
        {
            return S;
        }
        static public void SetAdmin()
        {
            T = P = false;
            A = true;
        }

        static public bool OpenConnection()
        {
            try
            {
                checker = new SQLChecker();
                sqlConnection = new MySqlConnection("");
                sqlConnection.Open();
                command = sqlConnection.CreateCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT CURRENT_DATE FROM dual";
                open = true;
                return true;
            }
          catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        static public Tuple<string, string> GetPresanceThiSUnit(string unit)
        {
            string students = "";
            string presances = "";
            var unitparted = unit.Split(":");
            var classyear = currentClass.Remove(4);
            command.CommandText = $"select imie, nazwisko, pesel, status_nazwa from obecnosc join dane_osobowe on uczen_pesel=pesel WHERE data=CURRENT_DATE and lekcja_klasa_rocznik={classyear} and lekcja_klasa_literka='{currentClass[4].ToString()}' and lekcja_jednostka_godzina={unitparted[0]} and lekcja_jednostka_minuta={unitparted[1]}";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                students = students + dataReader[0].ToString() + " " + dataReader[1].ToString() + "(" + dataReader[2].ToString() + ")\n";
                presances = presances + dataReader[3].ToString() + "\n";
            }
            dataReader.Close();
            Tuple<string, string> tuple = new Tuple<string, string>(students, presances);
            return tuple;
        }

        static public string ParentInfo()
        {
            string data = "Dzieci pod moją opieką:\n";
            command.CommandText = $"select imie from dane_osobowe join opieka on pesel=uczen_pesel where opiekun_pesel={currentPesel} ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                data = data + dataReader[0].ToString() + ", ";
            dataReader.Close();
            data.Remove(data.Length - 1);
            return data;
        }

        static public bool WasPresanceChecked(string unit)
        {
            var unitParts = unit.Split(":");
            var clasyear = currentClass.Remove(4);
            command.CommandText=$"SELECT * from obecnosc where data=CURRENT_DATE and lekcja_klasa_rocznik={clasyear} and lekcja_klasa_literka='{currentClass[4].ToString()}' and lekcja_jednostka_godzina={unitParts[0]} and lekcja_jednostka_minuta={unitParts[1]}";
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                dataReader.Close();
                return true;
            }
            dataReader.Close();
            return false;
        }

        static public string GetAllParentsData()
        {
            var list = "Imię\t\t\tNazwisko\t\tPesel\t\tadres\t\t\ttelefon\tmejl\t\tdochod\n";
            command.CommandText = "SELECT imie, nazwisko, pesel, adres_zamieszkania, numer_telefonu, email, dochod from dane_osobowe natural join opiekun";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var record = string.Format("{0,15} {1,15}\t{2,11} {3,20} {4,12} {5,10} {6,10}\n", dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString());
                list += record;
                    }
            dataReader.Close();
            return list;
        }

        static public string GetAllStudentsData()
        {
            var list = "Imię\t\tNazwisko\tPesel\t\tadres\t\ttelefon\tmejl\tklasa\tdziennik\n";
            command.CommandText = "SELECT imie, nazwisko, pesel, adres_zamieszkania, numer_telefonu, email, klasa_rocznik, klasa_literka, nr_w_dzienniku from dane_osobowe join uczen on pesel=dane_osobowe_pesel";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var record = string.Format("{0,15} {1,15}\t{2,11} {3,20} {4,12} {5,10} {6,4}{7,1} {8,2}\n", dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString(), dataReader[7].ToString(), dataReader[8].ToString());
                list += record;
            }
            dataReader.Close();
            return list;
        }

        static public string GetAllTeachersData()
        {
            var list = "Imię\t\tNazwisko\tPesel\t\tadres\t\ttelefon\tmejl\tetat\n";
            command.CommandText = "SELECT imie, nazwisko, pesel, adres_zamieszkania, numer_telefonu, email, etat from dane_osobowe join nauczyciel on pesel=dane_osobowe_pesel where pesel!=666";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var record = string.Format("{0,15} {1,15}\t{2,11} {3,20} {4,12} {5,10} {6,4}\n", dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString());
                list += record;
            }
            dataReader.Close();
            return list;
        }

        static public string GetMyPresance()
        {
            var presance = "data\t\t\t godzina\t\t status\n";
            command.CommandText = $"SELECT data, lekcja_jednostka_godzina, lekcja_jednostka_minuta, status_nazwa FROM obecnosc where uczen_pesel={currentPesel} and CURRENT_DATE - data <14 ORDER BY data DESC";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var record = dataReader[0].ToString() + "\t" + dataReader[1].ToString() + ":" + dataReader[2].ToString() + "\t" + dataReader[3].ToString() + "\n";
                presance += record;
            }
            dataReader.Close();
            return presance;
        }

        static public string GetMyStudentInfo()
        {
            command.CommandText = $"select klasa_rocznik, klasa_literka, nr_w_dzienniku from uczen where dane_osobowe_pesel={currentPesel}";
            dataReader = command.ExecuteReader();
            dataReader.Read();
            var info = dataReader[0].ToString() + dataReader[1].ToString() + ", " + dataReader[2].ToString();
            dataReader.Close();
            return info;
        }

        static public string GetTopThree()
        {
            var classyear = currentClass.Remove(4);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "znajdz_najlepszych";
            command.Parameters.AddWithValue("@arg_rocznik", classyear);
            command.Parameters.AddWithValue("@arg_literka", currentClass[4].ToString());
            command.Parameters.Add("@ireturnvalue",MySqlDbType.Text);
            command.Parameters["@ireturnvalue"].Direction = ParameterDirection.ReturnValue;
            command.ExecuteScalar();
            string val = (command.Parameters["@ireturnvalue"].Value.ToString());
            command.CommandType = CommandType.Text;
            return val;
        }

        static public Tuple<string, int> GetMydWarnings()
        {
            string notes = "";
            int sum = 0;
            command.CommandText = $"select data, tresc, puntky_do_zachowania from uwaga where uczen_dane_osobowe_pesel={currentPesel}";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var record = dataReader[0].ToString() + "\t" + dataReader[1].ToString() + "\n";
                notes += record;
                sum += int.Parse(dataReader[2].ToString());
            }
            dataReader.Close();
            var tup = Tuple.Create<string, int>(notes, sum);
            return tup;
        }

        static public string GetMyNotes()
        {
            var notes = "";
            var subject = "";
            var record = "";
            command.CommandText = $"select przedmiot_nazwa_przedmiotu, ocena from ocena where uczen_dane_osobowe_pesel={currentPesel} order by przedmiot_nazwa_przedmiotu desc";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader[0].ToString() != subject)
                {
                    record += "\n";
                    notes += record;
                    subject = dataReader[0].ToString();
                    record = dataReader[0].ToString() + "\t" + dataReader[1].ToString();
                }
                else
                {
                    record = record + ", " + dataReader[1].ToString();
                }
            }
            notes += record;
            dataReader.Close();
            return notes;
        }

        static public string GetMyChildPresance()
        {
            var presance = "data\t\t\t godzina\t\t status\n";
            command.CommandText = $"SELECT data, lekcja_jednostka_godzina, lekcja_jednostka_minuta, status_nazwa FROM obecnosc where uczen_pesel={currentChild} and CURRENT_DATE - data <14 ORDER BY data DESC";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var record = dataReader[0].ToString() + "\t" + dataReader[1].ToString() + ":" + dataReader[2].ToString() + "\t" + dataReader[3].ToString() + "\n";
                presance += record;
            }
            dataReader.Close();
            return presance;
        }

        static public string GetMyChildWarnings()
        {
            string notes = "";
            command.CommandText = $"select data, tresc, puntky_do_zachowania from uwaga where uczen_dane_osobowe_pesel={currentChild}";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var record = dataReader[0].ToString() + "\t" + dataReader[2].ToString() + ":" + dataReader[1].ToString() + "\n";
                notes += record;
            }
            dataReader.Close();
            return notes;
        }

        static public string GetMyChildNotes()
        {
            var notes = "";
            var subject = "";
            var record = "";
            command.CommandText = $"select przedmiot_nazwa_przedmiotu, ocena from ocena where uczen_dane_osobowe_pesel={currentChild} order by przedmiot_nazwa_przedmiotu desc";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader[0].ToString() != subject)
                {
                    record += "\n";
                    notes += record;
                    subject = dataReader[0].ToString();
                    record = dataReader[0].ToString() + "\t" + dataReader[1].ToString();
                }
                else
                {
                    record = record + ", " + dataReader[1].ToString();
                }
            }
            notes += record;
            dataReader.Close();
            return notes;
        }

        static public void AddProfile(string profilname)
        {
            command.CommandText = $"INSERT INTO profil VALUES('{profilname}') ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddWarning(string whatDidStudentDo, string points, string pesel)
        {
            var lst = pesel.Split("(");
            lst[1].Remove(lst[1].Length - 1);
            command.CommandText = $"INSERT INTO uwaga VALUES(NULL,'{whatDidStudentDo}', {points}, {currentPesel}, {lst[1]}, CURRENT_DATE) ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddNote(string value, string description, string category, string subject, string pesel)
        {
            var lst = pesel.Split("(");
            var childpesel = lst[1].Remove(lst[1].Length - 1);
            command.CommandText = $"INSERT INTO ocena VALUES(NULL, {value},CURRENT_DATE,'{description}','{category}','{subject}',{childpesel},{currentPesel})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void ChangeNote(string newValue, string desc, string student)
        {
            var lst = student.Split("(");
            var pesel = lst[1].Remove(lst[1].Length - 1);
            var unpackeddata = desc.Split(","); //date, category, subject
            var date = checker.ReformatDate(unpackeddata[0]);
            command.CommandText = $"UPDATE ocena SET ocena={newValue} where data='{date}' and uczen_dane_osobowe_pesel={pesel} and nauczyciel_dane_osobowe_pesel={currentPesel} and kategoria_oceny_nazwa='{unpackeddata[1]}' and przedmiot_nazwa_przedmiotu='{unpackeddata[2]}' and opis='{unpackeddata[3]}'";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void ChangeStatus(string newValue, string date, string student)
        {
            var lst = student.Split("(");
            var pesel = lst[1].Remove(lst[1].Length - 1);
            var dayandunit = date.Split(",");
            var unit = dayandunit[1].Split(":");
            var day = checker.ReformatDate(dayandunit[0]);
            command.CommandText = $"UPDATE obecnosc SET status_nazwa='{newValue}' WHERE uczen_pesel={pesel} and data='{day}' and lekcja_jednostka_godzina={unit[0]} and lekcja_jednostka_minuta={unit[1]} ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void LegitimizeAbsence(string data)
        {
            var day = data.Split(" ");
            var normalDay = checker.ReformatDate(day[0]);
            command.CommandText = $"UPDATE obecnosc SET status_nazwa = 'usprawiedliwiony' WHERE  status_nazwa='nieobecny' and data='{normalDay}' and uczen_pesel={currentChild}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public List<string> GetUnits()
        {
            command.CommandText = $"SELECT * FROM jednostka";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + ":" + dataReader[1].ToString());
            dataReader.Close();
            return list;
        }

        static public List<string> GetRooms()
        {
            command.CommandText = $"SELECT * FROM sala";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + "." + dataReader[1].ToString());
            dataReader.Close();
            return list;
        }

        static public List<string> GetAllStudents()
        {
            command.CommandText = "SELECT imie, nazwisko, pesel FROM dane_osobowe JOIN uczen on pesel=dane_osobowe_pesel";
            List<string> list = new List<string>();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + " " + dataReader[1].ToString() + "(" + dataReader[2].ToString() + ")");
            dataReader.Close();
            return list;
        }

        static public List<string> GetAllParents()
        {
            command.CommandText = "SELECT imie, nazwisko, pesel FROM dane_osobowe NATURAL JOIN opiekun";
            List<string> list = new List<string>();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + " " + dataReader[1].ToString() + "(" + dataReader[2].ToString() + ")");
            dataReader.Close();
            return list;
        }

        static public List<string> GetCategories()
        {
            command.CommandText = $"SELECT * from kategoria_oceny";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString());
            dataReader.Close();
            return list;
        }

        static public List<string> GetSubjects()
        {
            command.CommandText = $"SELECT * from przedmiot";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString());
            dataReader.Close();
            return list;
        }

        static public List<string> GetTeachers()
        {
            command.CommandText = $"SELECT imie, nazwisko, pesel FROM dane_osobowe JOIN nauczyciel on pesel=dane_osobowe_pesel where pesel!=666 ";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + " " + dataReader[1].ToString() + "(" + dataReader[2].ToString() + ")");
            dataReader.Close();
            return list;
        }

        static public List<string> GetProfiles()
        {
            command.CommandText = $"SELECT * from profil";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString());
            dataReader.Close();
            return list;
        }


        static public List<string> GetAbsence()
        {
            command.CommandText = $"SELECT data, lekcja_dzien_tygodnia, lekcja_jednostka_godzina, lekcja_jednostka_minuta FROM obecnosc where uczen_pesel={currentChild} and status_nazwa='nieobecny' and CURRENT_DATE-data <14";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString());
            dataReader.Close();
            return list;
        }

        static public List<string> GetChildren()
        {
            command.CommandText = $"SELECT imie, pesel FROM dane_osobowe JOIN opieka on pesel=uczen_pesel where opiekun_pesel={currentPesel}";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + "(" + dataReader[1].ToString() + ")");
            dataReader.Close();
            return list;
        }

        static public List<string> GetLastNotes()
        {
            List<string> lis = new List<string>();
            command.CommandText = $"SELECT DISTINCT data, kategoria_oceny_nazwa, przedmiot_nazwa_przedmiotu, opis from ocena where current_date-data<14";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                lis.Add(dataReader[0].ToString() + "," + dataReader[1].ToString() + "," + dataReader[2].ToString() + "," + dataReader[3].ToString());
            }
            dataReader.Close();
            return lis;
        }
        
        static public List<string> GetStudents()
        {
            var letter = currentClass[4].ToString();
            var classyear = currentClass.Remove(4);
            command.CommandText = $"SELECT imie, nazwisko, pesel FROM dane_osobowe JOIn uczen on pesel=dane_osobowe_pesel WHERE klasa_rocznik={classyear} and klasa_literka='{letter}'";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                list.Add(dataReader[0].ToString() + " " + dataReader[1].ToString() + "(" + dataReader[2].ToString() + ")");
            }
            dataReader.Close();
            return list;
        }
        
        static public List<string> LastLessonsForClass()
        {
            List<string> list = new List<string>();
            var classyear = currentClass.Remove(4);
            command.CommandText = $"SELECT DISTINCT data, lekcja_jednostka_godzina, lekcja_jednostka_minuta from obecnosc where lekcja_klasa_rocznik={classyear} and lekcja_klasa_literka='{currentClass[4].ToString()}' and CURRENT_DATE-data<14";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                list.Add(dataReader[0].ToString() + ", " + dataReader[1].ToString() + ":" + dataReader[2].ToString());
            }
            dataReader.Close();
            return list;
        }

        static public void ChangeClass(string student, string clas)
        {
            var pesel = student.Split("(")[1];
            pesel = pesel.Remove(pesel.Length - 1);
            var classletter = clas[4].ToString();
            var classyear = currentClass.Remove(4);
            command.CommandText = $"UPDATE uczen SET klasa_rocznik={classyear}, klasa_literka='{classletter}' WHERE dane_osobowe_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void DeleteTeacher(string teacher)
        {
            try { 
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

        static public void DeleteGrill(string parent, string child)
        {
            var parentpesel = parent.Split("(")[1];
            parentpesel = parentpesel.Remove(parentpesel.Length - 1);
            var childpesel = child.Split("(")[1];
            childpesel = childpesel.Remove(childpesel.Length - 1);
            command.CommandText = $"DELETE from opieka WHERE uczen_pesel={childpesel} and opiekun_pesel={parentpesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void DeleteStudent(string student)
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

        static public void DeleteParent(string parent)
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

        static public List<string> GetStatuses()
        {
            command.CommandText = "SELECT * FROM status";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString());
            dataReader.Close();
            return list;
        }

        static public List<string> GetClasses()
        {
            command.CommandText = "SELECT rocznik, literka FROM klasa";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + dataReader[1].ToString());
            dataReader.Close();
            return list;
        }

        static public void AddParent(string pesel, string names, string lastName, string home, string phoneNum, string mail, string Money)
        {
            try
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

        static public void AddUnit(string hour, string minute)
        {
            command.CommandText = $"INSERT INTO jednostka VALUES ({hour},{minute})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddPresance(string hour, string pesel, string status)
        {
            var student = pesel.Split("(");
            student[1] = student[1].Remove(student[1].Length - 1);
            var unit = hour.Split(":");
            var classYear = currentClass.Remove(4);
            command.CommandText = $"INSERT INTO obecnosc VALUES (CURRENT_DATE, {student[1]},WEEKDAY(CURRENT_DATE)+1,{unit[0]}, {unit[1]},{classYear}, '{currentClass[4].ToString()}', '{status}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddTeacher(string pesel, string names, string lastName, string home, string phoneNum, string mail, string etat)
        {
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dodaj_nauczyciela";
                command.Parameters.AddWithValue("@pesel",pesel);
                command.Parameters.AddWithValue("@imie", names);
                command.Parameters.AddWithValue("@nazwisko", lastName);
                command.Parameters.AddWithValue("@telefon", phoneNum);
                command.Parameters.AddWithValue("adres", home);
                command.Parameters.AddWithValue("@email",mail);
                command.Parameters.AddWithValue("@etat",etat);
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

        static public void AddStudent(string pesel, string names, string lastName, string home, string phoneNum, string mail, string clas)
        {
            try { 
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

        static public void AddRoom(string floor, string number, string chairs)
        {
            command.CommandText = $"INSERT INTO sala VALUES ({floor},{number},{chairs})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddCategory(string name, string value)
        {
            command.CommandText = $"INSERT into kategoria_oceny VALUES ('{name}',{value})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddLesson(string dayOfUnit, string hourOfUnit, string classLetter, string roomNumber, string subject)
        {
            var unit = hourOfUnit.Split(":");
            var clas = classLetter[4].ToString();
            var classYear = classLetter.Remove(4);
            var room = roomNumber.Split(".");
            command.CommandText = $"INSERT INTO lekcja VALUES ('{dayOfUnit}', {unit[0]}, {unit[1]},{classYear},'{clas}', {room[0]},{room[1]},'{subject}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void Grill(string guardian, string child)
        {
            var lst = guardian.Split("(");
            var pesel = lst[1].Remove(lst[1].Length - 1);
            lst = child.Split("(");
            var chpesel = lst[1].Remove(lst[1].Length - 1);
            command.CommandText = $"INSERT INTO opieka VALUES ({chpesel},{pesel})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void ChangeFormTutor(string newFormTutor, string clas)
        {
            var lst = newFormTutor.Split("(");
            var pesel = lst[1].Remove(lst[1].Length - 1);
            var letter = clas[4].ToString();
            var year = clas.Remove(clas.Length - 1);
            command.CommandText = $"UPDATE klasa SET nauczyciel_dane_osobowe_pesel={pesel} WHERE literka='{letter}' and rocznik={year} ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddClass(string classYear, string classLetter, string formTutorPesel, string profile)
        {
            var lst = formTutorPesel.Split("(");
            lst[1] = lst[1].Remove(lst[1].Length - 1);
            command.CommandText = $"INSERT INTO klasa VALUES ({classYear},'{classLetter}', {lst[1]}, '{profile}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddSubject(string name)
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

        static public bool LogInAsStudent(string pesel)
        {
            try
            {
                command.CommandText = $"select * from uczen where dane_osobowe_pesel={pesel}";
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    A = T = P = false;
                    S = true;
                    dataReader.Close();
                    currentPesel = pesel;
                    return true;
                }
                dataReader.Close();
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        static public bool LogInAsParent(string pesel)
        {
            try
            {
                command.CommandText = $"select * from opiekun where pesel={pesel}";
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    dataReader.Close();
                    currentPesel = pesel;
                    P = true;
                    A = T = S = false;
                    return true;
                }
                dataReader.Close();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static public bool LogInAsTeacher(string pesel)
        {
            try
            {
                command.CommandText = $"select * from nauczyciel where dane_osobowe_pesel={pesel}";
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    dataReader.Close();
                    currentPesel = pesel;
                    T = true;
                    A = P = S = false;
                    return true;
                }
                dataReader.Close();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        static public bool CloseConnection()
        {
            sqlConnection.Close();
            return true;
        }


        static public bool FirstUse()
        {
            try
            {
                command.CommandText = "INSERT into przedmiot VALUES ('Matematyka')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into przedmiot VALUES ('Fizyka')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into przedmiot VALUES ('Chemia')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into przedmiot VALUES ('Informatyka')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into przedmiot VALUES ('Biologia')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into kategoria_oceny VALUES ('Sprawdzian',5)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into kategoria_oceny VALUES ('Kartkówka',3)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into kategoria_oceny VALUES ('Eksperyment',4)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into profil VALUES ('Chemiczno-informatyczny')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into profil VALUES ('Fizyczno-informatyczny')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into profil VALUES ('Biologiczno-matematyczny')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into jednostka VALUES ('8','00')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into jednostka VALUES ('8','55')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into jednostka VALUES ('9','50')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into status VALUES ('obecny')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into status VALUES ('nieobecny')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into status VALUES ('usprawiedliwiony')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into status VALUES('inny')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT INTO `dane_osobowe` (`pesel`, `imie`, `nazwisko`, `adres_zamieszkania`, `numer_telefonu`, `email`) VALUES ('666', 'Zwolniony', 'Pozorny', NULL, NULL, NULL); ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT INTO `nauczyciel` (`etat`, `dane_osobowe_pesel`) VALUES ('0', '666'); ";
                dataReader = command.ExecuteReader();
                dataReader.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
