using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace gui
{
    public class ParentPanel : PersonPanel
    {
        List<string> Dzieci;

        public ParentPanel(string pesel, MySqlCommand com, MySqlDataReader reader) : base(pesel, com, reader)
        {
            Dzieci = new List<string>();
            command.CommandText = $"select * from opieka where opiekun_pesel={PESEL}";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                Dzieci.Add(dataReader[0].ToString());
            dataReader.Close();

        }

        public string MyData()
        {

            command.CommandText = $"select imie, nazwisko from dane_osobowe where pesel={PESEL}";
            dataReader = command.ExecuteReader();
            var info = "Zalogowany: " + dataReader[0].ToString() + " " + dataReader[1].ToString() + "\nDzieci pod opieką:";
            dataReader.Close();
            foreach(var pesel in Dzieci) {
                command.CommandText = $"select imie from dane_osobowe where pesel={pesel}";
                dataReader = command.ExecuteReader();
                info = info + dataReader[0].ToString() + ", ";
                dataReader.Close();
            }
            return info;
        }

        public void ShowMyChildrenNotes()
        {
            foreach(var pesel in Dzieci)
            {
                command.CommandText = $"select przedmiot_nazwa_przedmiotu, ocena, opis, kategoria_oceny_nazwa, waga from (ocena JOIN uczen ON uczen_dane_osobowe_pesel = dane_osobowe_pesel) JOIN kategoria on kategoria_oceny_nazwa=nazwa WHERE pesel={pesel} ORDER by przedmiot_nazwa";
                dataReader = command.ExecuteReader();
                var subject = "";
                var sum = 0;
                var div = 0;
                List<(string, string, string)> list = new List<(string, string, string)>();
                var notes = "";
                var average = "";
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString() != subject)
                    {
                        if (sum > 0)
                        {
                            average = (sum / div).ToString();
                            list.Add((subject, notes, average));
                            sum = 0;
                            div = 0;
                        }
                        subject = dataReader[0].ToString();
                        notes = "";
                    }
                    notes = notes + ", " + dataReader[4].ToString();
                    sum += int.Parse(dataReader[1].ToString()) * int.Parse(dataReader[4].ToString());
                    div += int.Parse(dataReader[4].ToString());
                }
                dataReader.Close();
                average = (sum / div).ToString();
                list.Add((subject, notes, average));
            }
        }

        public void ShowMyChildWarnings()
        {
            foreach (var pesel in Dzieci)
            {
                command.CommandText = $"SELECT data, tresc, puntky_do_zachowania FROM uwaga WHERE uczen_dane_osobowe_pesel = {pesel}";
                dataReader = command.ExecuteReader();
                List<(string, string, string)> list = new List<(string, string, string)>();
                var sum = 0;
                while (dataReader.Read())
                {
                    list.Add((dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString()));
                    sum += int.Parse(dataReader[2].ToString());
                }
                dataReader.Close();
            }
        }

        public void ShowMyChildrenPresance()
        {
            foreach(var pesel in Dzieci)
            {
                command.CommandText = $"SELECT data, lekcja_jednostka_godzina, lekcja_jednostka_minuta, status FROM obecnosc WHERE pesel = {pesel}";
                dataReader = command.ExecuteReader();
                List<(string, string, string)> list = new List<(string, string, string)>();
                while (dataReader.Read())
                    list.Add((dataReader[0].ToString(), dataReader[1].ToString() + dataReader[2].ToString(), dataReader[3].ToString()));
                dataReader.Close();
            }
        }

        public void LegitimizeAbsence(string date, string child)
        {
            command.CommandText = $"UPDATE obecnosc SET status='usprawiedliwiony' WHERE data={date} AND uczen_pesel={child}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void ShowEverythingNeededToLegitimize()
        {
            List<(string, string)> list = new List<(string, string)>();
            foreach(var pesel in Dzieci)
            {
                command.CommandText =$"SELECT data, pesel FROM obecnosc WHERE uczen_pesel = {pesel} and status='nieobecny'";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    list.Add((dataReader[0].ToString(), dataReader[1].ToString()));
                dataReader.Close();
            }

        }
    }
}
