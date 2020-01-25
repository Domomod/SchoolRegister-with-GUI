using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace gui
{
    public class TeacherPanel : PersonPanel
    {
        public TeacherPanel(string pesel, MySqlCommand com, MySqlDataReader reader) : base(pesel, com, reader)
        {
        }

        public string MyData()
        {
            command.CommandText = $"select imie, nazwisko from dane_osobowe where pesel={PESEL}";
            dataReader = command.ExecuteReader();
            var info = "Zalogowany: " + dataReader[0].ToString() + " " + dataReader[1].ToString() + "\nDzieci pod opieką:";
            dataReader.Close();
            return info;
        }

        public void AddNote(string value, string date, string description, string category, string subject, string pesel)
        {
            command.CommandText = $"INSERT INTO ocena VALUES(NEXTVAL(ocenaSeq),{value},'{date}','{description}','{category}','{subject}',{pesel},{PESEL})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void ChangePresance(string presanceType, string pesel, string date)
        {
            command.CommandText = $" UPDATE obecnosc SET status= '{presanceType}' WHERE uczen_pesel={pesel} and data='{date}'";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void CkeckPresance(string date, string pesel, string dayOfUnit, string hourOfUnit, string minuteOfUnit, string classNum, string classLetter, string presanceType)
        {
            command.CommandText = $"INSERT INTO obecnosc VALUES('{date}',{pesel},'{dayOfUnit}',{hourOfUnit},{minuteOfUnit}, {classNum}, '{classLetter}' , '{presanceType}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void ChangeNote(string value, string id)
        {
            command.CommandText = $"UPDATE ocena SET ocena = {value} WHERE id={id}";
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void AddWarning(string whatDidStudentDo, string points, string pesel)
        {
            command.CommandText = $"INSERT INTO uwaga VALUES(NEXTVAL(uwagaSeq),'{whatDidStudentDo}', {points}, {PESEL}, {pesel}, CURRENT_DATE) ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void ShowEverythingNeededToCheckPresanceA()
        {
           
        }

        public void ShowEverythingNeededToCheckPresanceB(string classNum, string classLetter)
        {
            command.CommandText = $"SELECT imie, nazwisko from dane_osobowe join uczen on pesel=dane_osobowe_pesel WHERE klasa_rocznik={classNum} and klasa_literka='{classLetter}'";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + " " + dataReader[1].ToString());
            dataReader.Close();
        }



        public void ShowEverythingNeededToChangePresance()
        {

        }

        public void ShowEverythingNeededToAddNote()
        {

        }

        public void ShowEverythingNeededToChangeNote()
        {

        }

        public void ShowEverythingNeededToAddWarning()
        {

        }

    }
}
