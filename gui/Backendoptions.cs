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
                sqlConnection = new MySqlConnection("Server=192.168.64.2;  database=Dziennik; Uid=Julka ; pwd=Abby");
                sqlConnection.Open();
                command = sqlConnection.CreateCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT CURRENT_DATE FROM dual";
                open = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        //TO DO: Wybiera 3 najlepszych z danej klasy - procedura/funkcja
        static public List<string> GetTopThree()
        {
            List<string> list = new List<string>();
            list.Add("1: it will");
            list.Add("2: be implemented");
            list.Add("3: later");
            command.CommandText = $"select imie, nazwisko, srednia from srednie_uczniow";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
            }
            dataReader.Close();
            return list;
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


        static public void AddWarning(string whatDidStudentDo, string points, string pesel)
        {
            var lst = pesel.Split("(");
            lst[1].Remove(lst[1].Length - 1);
            command.CommandText = $"INSERT INTO uwaga VALUES(NEXTVAL(uwagaSeq),'{whatDidStudentDo}', {points}, {currentPesel}, {lst[1]}, CURRENT_DATE) ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddNote(string value, string description, string category, string subject, string pesel)
        {
            var lst = pesel.Split("(");
            var childpesel = lst[1].Remove(lst[1].Length - 1);
            command.CommandText = $"INSERT INTO ocena VALUES(NEXTVAL(ocenaSeq),{value},CURRENT_DATE,'{description}','{category}','{subject}',{childpesel},{currentPesel})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        //DATA!!!
        static public void ChangeNote(string newValue, string desc, string student)
        {
            var lst = student.Split("(");
            var pesel = lst[1].Remove(lst[1].Length - 1);
            var unpackeddata = desc.Split(","); //date, category, subject
            command.CommandText = $"UPDATE ocena SET ocena=STR_TO_DATE{newValue} where data=STR_TO_DATE('{unpackeddata[0]}', '%d/%m/%y %h%i') and uczen_dane_osobowe_peel={pesel} and nauczyciel_dane_osobowe_pesel={currentPesel} and kategoria_oceny_nazwa='{unpackeddata[1]}', przedmiot_nazwa_przedmiotu='{unpackeddata[2]}' and opis='{unpackeddata[3]}'";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        //DATA!!!
        static public void ChangeStatus(string newValue, string date, string student)
        {
            var lst = student.Split("(");
            var pesel = lst[1].Remove(lst[1].Length - 1);
            var dayandunit = date.Split(",");
            var unit = dayandunit[1].Split(":");
            command.CommandText = $"UPDATE obecnosc SET status_nazwa='{newValue}' WHERE uczen_pesel={pesel} and data={dayandunit[0]} and lekcja_jednostka_godzina={unit[0]} and lekcja_jednostka_minuta={unit[1]} ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        //DATA!!!!
        static public void LegitimizeAbsence(string data)
        {
            var day = data.Split(" ");
            var cutDay = day[0].Split("/");
            command.CommandText = $"UPDATE obecnosc SET status_nazwa = 'usprawiedliwiony' WHERE  status_nazwa='nieobecny' and data=STR_TO_DATE('{cutDay}','%d/%m/%Y') and uczen_pesel={currentChild}";
            dataReader = command.ExecuteReader();
            dataReader.Close();

        }

        static public string ChildPesel(string imie)
        {
            command.CommandText = $"SELECT pesel from dane_osobowe join opieka on pesel=uczen_pesel where imie='{imie}' and opiekun_pesel={currentPesel}";
            dataReader = command.ExecuteReader();
            var pesel = dataReader[0].ToString();
            dataReader.Close();
            return pesel;
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
            lis.Add("It will be implemented later");
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
            list.Add("It will be implemented later");
            command.CommandText = $"SELECT data, lekcja_jednostka_godzina, lekcja_jednostka_minuta from obecnosc where lekcja_klasa_rocznik={classyear} and lekcja_klasa_literka='{currentClass[4].ToString()}' and CURRENT_DATE-data<14";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                list.Add(dataReader[0].ToString() + ", " + dataReader[1].ToString() + ":" + dataReader[2].ToString());
            }
            dataReader.Close();
            return list;
        }

        //TO DO FINISH
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
            var pesel = teacher.Split("(")[1];
            pesel = pesel.Remove(pesel.Length - 1);
            command.CommandText = $"UPDATE ocena SET nauczyciel_dane_osobowe_pesel=666 WHERE nauczyciel_dane_osobowe_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"UPDATE uwaga SET nauczyciel_dane_osobowe_pesel=666 WHERE nauczyciel_dane_osobowe_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"UPDATE klasa SET nauczyciel_dane_osobowe_pesel=666 WHERE nauczyciel_dane_osobowe_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"DELETE from nauczyciel where dane_osobowe_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
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
        //TO DO FINISH: delete student, his notes, presance and warnings
        static public void DeleteStudent(string student)
        {
            var pesel = student.Split("(")[1];
            pesel = pesel.Remove(pesel.Length - 1);
            command.CommandText = $"DELETE FROM ocena WHERE uczen_dane_osobowe_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"DELETE FROM obecnosc WHERE uczen_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"DELETE FROM uwaga where uczen_dane_osobowe_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"DELETE FROM opieka WHERE uczen_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"DELETE FROM uczen WHERE dane_osobowe_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }
        //TO DO FINISH: delete from opiekun, opieka (nor dane_osobowe)
        static public void DeleteParent(string parent)
        {
            var pesel = parent.Split("(")[1];
            pesel = pesel.Remove(pesel.Length - 1);
            command.CommandText = $"DELETE FROM opieka WHERE opiekun_pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"DELETE FROM opiekun where pesel={pesel}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
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
            command.CommandText = $"SELECT * FROM dane_osobowe where pesel={pesel}";
            dataReader = command.ExecuteReader();
            if (!dataReader.Read())
            {
                dataReader.Close();
                command.CommandText = $"INSERT INTO dane_osobowe VALUES({pesel},'{names}','{lastName}','{home}',{phoneNum},'{mail}')";
                dataReader = command.ExecuteReader();
            }
            dataReader.Close();
            command.CommandText = $"INSERT INTO opiekun VALUES ({Money}, {pesel})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddUnit(string hour, string minute)
        {
            command.CommandText = $"INSERT INTO jednostka VALUES ({hour},{minute})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }
        //TO DO FINISH
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
            command.CommandText = $"SELECT * FROM dane_osobowe where pesel={pesel}";
            dataReader = command.ExecuteReader();
            if (!dataReader.Read())
            {
                dataReader.Close();
                command.CommandText = $"INSERT INTO dane_osobowe VALUES({pesel},'{names}','{lastName}','{home}',{phoneNum},'{mail}')";
                dataReader = command.ExecuteReader();
            }
            dataReader.Close();
            command.CommandText = $"INSERT INTO nauczyciel VALUES ({etat},{pesel})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }


        //Dodać procedurę
        static public void AddStudent(string pesel, string names, string lastName, string home, string phoneNum, string mail, string clas, string numberInRegister)
        {
            command.CommandText = $"INSERT INTO dane_osobowe VALUES('{pesel}','{names}','{lastName}','{home}',{phoneNum},'{mail}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            var classLetter = clas[4].ToString();
            var classYear = clas.Remove(4);
            command.CommandText = $"INSERT INTO uczen VALUES ({pesel},{classYear},{numberInRegister},'{classLetter}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddRoom(string floor, string number, string chairs)
        {
            command.CommandText = $"INSERT INTO sala VALUES ({floor},{number},{chairs})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        static public void AddCategory(string name, string value)
        {
            command.CommandText = $"INSERT into kategoria VALUES ('{name}',{value})";
        }

        //TO DO: CHANGE SQL (SYNTAX ERROR)
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
                command.CommandText = "CREATE TABLE dane_osobowe(  pesel NUMERIC(11) NOT NULL,  imie  CHAR(20) NOT NULL,  nazwisko  CHAR(50) NOT NULL,  adres_zamieszkania  CHAR(100),  numer_telefonu NUMERIC(9),  email   CHAR(50))";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE dane_osobowe ADD CONSTRAINT dane_osobowe_pk PRIMARY KEY ( pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE jednostka (godzina NUMERIC(2) NOT NULL,  minuta  NUMERIC(2) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE jednostka ADD CONSTRAINT jednostka_pk PRIMARY KEY ( godzina,minuta ) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE kategoria_oceny(  nazwa  CHAR(20) NOT NULL,  waga  NUMERIC(1) NOT NULL) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE kategoria_oceny ADD CONSTRAINT kategoria_oceny_pk PRIMARY KEY ( nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE klasa (rocznik NUMERIC(4) NOT NULL,literka  CHAR(1) NOT NULL, nauczyciel_dane_osobowe_pesel NUMERIC(11),  profil_nazwa  CHAR(50) NOT NULL) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE klasa ADD CONSTRAINT klasa_pk PRIMARY KEY ( rocznik, literka ) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE lekcja (  dzien_tygodnia NUMERIC(1) NOT NULL,jednostka_godzina  NUMERIC(2) NOT NULL,jednostka_minuta NUMERIC(2) NOT NULL,klasa_rocznik  NUMERIC(4) NOT NULL,klasa_literka   CHAR(1) NOT NULL,sala_pietro  NUMERIC(1) NOT NULL,sala_numer NUMERIC(2) NOT NULL,przedmiot_nazwa_przedmiotu  CHAR(20) NOT NULL) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_pk PRIMARY KEY(klasa_rocznik, jednostka_godzina, jednostka_minuta, dzien_tygodnia, klasa_literka)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE nauczyciel (  etat NUMERIC(3, 2) NOT NULL,dane_osobowe_pesel NUMERIC(11) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE nauczyciel ADD CONSTRAINT nauczyciel_pk PRIMARY KEY ( dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE obecnosc (  data DATE NOT NULL,uczen_pesel  NUMERIC(11) NOT NULL, lekcja_dzien_tygodnia  NUMERIC(1) NOT NULL,lekcja_jednostka_godzina NUMERIC(2) NOT NULL,lekcja_jednostka_minuta  NUMERIC(2) NOT NULL,lekcja_klasa_rocznik NUMERIC(4) NOT NULL,lekcja_klasa_literka  CHAR(1) NOT NULL,status_nazwa  CHAR(20) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE obecnosc  ADD CONSTRAINT obecnosc_pk PRIMARY KEY(data,uczen_pesel,lekcja_jednostka_godzina,lekcja_jednostka_minuta,lekcja_dzien_tygodnia) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE ocena (  id INTEGER NOT NULL,ocena NUMERIC(1) NOT NULL,data  DATE NOT NULL,  opis  CHAR(255) NOT NULL,kategoria_oceny_nazwa  CHAR(20) NOT NULL,przedmiot_nazwa_przedmiotu   CHAR(20) NOT NULL,uczen_dane_osobowe_pesel  NUMERIC(11) NOT NULL,nauczyciel_dane_osobowe_pesel NUMERIC(11) NOT NULL); ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena ADD CONSTRAINT ocena_pk PRIMARY KEY ( id )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE opieka (  uczen_pesel NUMERIC(11) NOT NULL,opiekun_pesel NUMERIC(11) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opieka ADD CONSTRAINT relation_35_pk PRIMARY KEY ( uczen_pesel, opiekun_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE opiekun (  dochod NUMERIC(10, 2) NOT NULL,  pesel  NUMERIC(11) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opiekun ADD CONSTRAINT opiekun_pk PRIMARY KEY ( pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE profil (  nazwa CHAR(50) NOT NULL); ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE profil ADD CONSTRAINT profil_pk PRIMARY KEY ( nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE przedmiot (  nazwa_przedmiotu  CHAR(20) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE przedmiot ADD CONSTRAINT przedmiot_pk PRIMARY KEY ( nazwa_przedmiotu )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE sala (  pietro NUMERIC(1) NOT NULL,numer NUMERIC(2) NOT NULL,liczba_miejsc NUMERIC(2) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE sala ADD CONSTRAINT sala_pk PRIMARY KEY ( numer,  pietro )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE status (  nazwa  CHAR(20) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE status ADD CONSTRAINT status_pk PRIMARY KEY ( nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE uczen (  dane_osobowe_pesel NUMERIC(11) NOT NULL,  klasa_rocznik  NUMERIC(4) NOT NULL,  nr_w_dzienniku NUMERIC(2) NOT NULL,  klasa_literka   CHAR(1) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uczen ADD CONSTRAINT uczen_pk PRIMARY KEY(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE uwaga (  id INTEGER NOT NULL,tresc  CHAR(300) NOT NULL,puntky_do_zachowania  NUMERIC(2),  uczen_dane_osobowe_pesel NUMERIC(11) NOT NULL,nauczyciel_dane_osobowe_pesel NUMERIC(11) NOT NULL,data  DATE)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uwaga ADD CONSTRAINT uwaga_pk PRIMARY KEY ( id )";
                dataReader = command.ExecuteReader();
                dataReader.Close();
                command.CommandText = "CREATE TABLE klasa (  rocznik NUMERIC(4) NOT NULL,  literka CHAR(1) NOT NULL,  nauczyciel_dane_osobowe_pesel NUMERIC(11),  profil_nazwa CHAR(50) NOT NULL); ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE klasa  ADD CONSTRAINT klasa_nauczyciel_fk FOREIGN KEY(nauczyciel_dane_osobowe_pesel)  REFERENCES nauczyciel(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE klasa  ADD CONSTRAINT klasa_profil_fk FOREIGN KEY(profil_nazwa)  REFERENCES profil(nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_jednostka_fk FOREIGN KEY(jednostka_godzina,   jednostka_minuta)  REFERENCES jednostka(godzina,  minuta )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_klasa_fk FOREIGN KEY(klasa_rocznik,   klasa_literka)  REFERENCES klasa(rocznik, literka )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_przedmiot_fk FOREIGN KEY(przedmiot_nazwa_przedmiotu)  REFERENCES przedmiot(nazwa_przedmiotu )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_sala_fk FOREIGN KEY(sala_numer,  sala_pietro)  REFERENCES sala(numer,  pietro )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE nauczyciel  ADD CONSTRAINT nauczyciel_dane_osobowe_fk FOREIGN KEY(dane_osobowe_pesel)  REFERENCES dane_osobowe(pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE obecnosc  ADD CONSTRAINT obecnosc_lekcja_fk FOREIGN KEY(lekcja_klasa_rocznik,  lekcja_jednostka_godzina,  lekcja_jednostka_minuta,  lekcja_dzien_tygodnia,  lekcja_klasa_literka)  REFERENCES lekcja(klasa_rocznik,  jednostka_godzina,  jednostka_minuta,  dzien_tygodnia,  klasa_literka )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE obecnosc  ADD CONSTRAINT obecnosc_status_fk FOREIGN KEY(status_nazwa)  REFERENCES status(nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE obecnosc  ADD CONSTRAINT obecnosc_uczen_fk FOREIGN KEY(uczen_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena  ADD CONSTRAINT ocena_kategoria_oceny_fk FOREIGN KEY(kategoria_oceny_nazwa)  REFERENCES kategoria_oceny(nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena  ADD CONSTRAINT ocena_nauczyciel_fk FOREIGN KEY(nauczyciel_dane_osobowe_pesel)  REFERENCES nauczyciel(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena  ADD CONSTRAINT ocena_przedmiot_fk FOREIGN KEY(przedmiot_nazwa_przedmiotu)  REFERENCES przedmiot(nazwa_przedmiotu )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena  ADD CONSTRAINT ocena_uczen_fk FOREIGN KEY(uczen_dane_osobowe_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opiekun  ADD CONSTRAINT opiekun_dane_osobowe_fk FOREIGN KEY(pesel)  REFERENCES dane_osobowe(pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opieka  ADD CONSTRAINT relation_35_opiekun_fk FOREIGN KEY(opiekun_pesel)  REFERENCES opiekun(pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opieka  ADD CONSTRAINT relation_35_uczen_fk FOREIGN KEY(uczen_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opieka  ADD CONSTRAINT relation_35_uczen_fk FOREIGN KEY(uczen_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uczen  ADD CONSTRAINT uczen_dane_osobowe_fk FOREIGN KEY(dane_osobowe_pesel)  REFERENCES dane_osobowe(pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uczen  ADD CONSTRAINT uczen_klasa_fk FOREIGN KEY(klasa_rocznik,  klasa_literka)  REFERENCES klasa(rocznik, literka )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uwaga  ADD CONSTRAINT uwaga_nauczyciel_fk FOREIGN KEY(nauczyciel_dane_osobowe_pesel)  REFERENCES nauczyciel(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uwaga  ADD CONSTRAINT uwaga_uczen_fk FOREIGN KEY(uczen_dane_osobowe_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE OR REPLACE SEQUENCE ocenaSeq INCREMENT By 1 ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE OR REPLACE SEQUENCE uwagaSeq INCREMENT By 1 ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE VIEW średnie_z_przedmiotow AS SELECT sum(ocena*waga)/sum(waga) AS srednia, uczen_dane_osobowe_pesel, przedmiot_nazwa_przedmiotu FROM ocena join uczen on uczen_dane_osobowe_pesel=dane_osobowe_pesel join kategoria_oceny on kategoria_oceny_nazwa=nazwa GROUP by uczen_dane_osobowe_pesel, przedmiot_nazwa_przedmiotu ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE VIEW srednie_uczniow AS SELECT avg(srednia), imie, nazwisko, rocznik, literka FROM `średnie_z_przedmiotow` join dane_osobowe on uczen_dane_osobowe_pesel=pesel join uczen on uczen_dane_osobowe_pesel=pesel JOIN klasa on klasa_rocznik=rocznik and klasa_literka=literka GROUP By uczen_dane_osobowe_pesel";
                dataReader = command.ExecuteReader();
                dataReader.Close();

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
