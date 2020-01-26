using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace gui
{
    public class Backendoptions
    {
        private string currentPesel;
        private static MySqlConnection sqlConnection;
        private static MySqlDataReader dataReader;
        private static MySqlCommand command;

        public Backendoptions()
        {
        }




        public bool OpenConnection()
        {
            try
            {
                sqlConnection = new MySqlConnection("Server=192.168.64.2;  database=Dziennik; Uid=Julka ; pwd=Abby");
                sqlConnection.Open();
                command = sqlConnection.CreateCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT CURRENT_DATE FROM dual";
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public List<(string, string)> GetTeachers()
        {
            command.CommandText = $"SELECT imie, nazwisko, pesel FROM dane_osobowe JOIN nauczyciel on pesel=dane_osobowe_pesel ";
            dataReader = command.ExecuteReader();
            List<(string, string)> list = new List<(string, string)>();
            while (dataReader.Read())
                list.Add((dataReader[0].ToString()+" "+dataReader[1].ToString(), dataReader[2].ToString()));
            dataReader.Close();
            return list;
        }

        public List<string> GetProfiles(){
             command.CommandText = $"SELECT * from profil";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString());
            dataReader.Close();
            return list;
        }

        public List <(string, string)> GetLessonsForClass(string clas)
        {
            var classyear = clas[0].ToString() + clas[1].ToString() + clas[2].ToString() + clas[3].ToString();
            command.CommandText = $"SELECT dzien_tygodnia, lekcja_dzien_tygodnia, lekcja_jednostka_godzina, lekcja_jednostka_minuta FROM lekcja where klasa_rocznik={classyear} and klasa_literka={clas[4].ToString()} ";
            dataReader = command.ExecuteReader();
            List<(string,string)> list = new List<(string,string)>();
            while (dataReader.Read())
                list.Add((dataReader[0].ToString(), dataReader[1].ToString()+dataReader[2].ToString()));
            dataReader.Close();
            return list;
        }

        public List<string> GetAbsence(string pesel)
        {
            command.CommandText = $"SELECT data, lekcja_dzien_tygodnia, lekcja_jednostka_godzina, lekcja_jednostka_minuta FROM obecnosc where uczen_pesel={pesel} and status='nieobecny' and CURRENT_DATE-data <14";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString());
            dataReader.Close();
            return list;
        }

        public List<string> GetChildren()
        {
            command.CommandText = $"SELECT imie FROM dane_osobowe JOIN opieka on pesel=uczen_pesel where opiekun_pesel={currentPesel}";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString());
            dataReader.Close();
            return list;
        }

        public List<string> GetStudents(string clas)
        {
            var classyear = clas[0].ToString() + clas[1].ToString() + clas[2].ToString() + clas[3].ToString();
            command.CommandText = $"SELECT imie, nazwisko FROM dane_osobowe JOIn uczen where pesel=dane_osobowe_penel WHERE klasa_rocznik={classyear} and klasa_literka={clas[4].ToString()}";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
            {
                list.Add(dataReader[0].ToString() + " " + dataReader[1].ToString());
            }
            dataReader.Close();
            return list;
        }

        public List<string> GetClasses()
        {
            command.CommandText = "SELECT rocznik, literka FROM klasa";
            dataReader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dataReader.Read())
                list.Add(dataReader[0].ToString() + dataReader[1].ToString());
            dataReader.Close();
            return list;
        } 

        public void AddParent(string pesel, string names, string lastName, string home, string phoneNum, string mail, string Money)
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
        }

        public void AddUnit(string hour, string minute)
        {
            command.CommandText = $"INSERT INTO jednostka VALUES ({hour},{minute})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void AddTeacher(string pesel, string names, string lastName, string home, string phoneNum, string mail, string etat)
        {
            command.CommandText = $"SELECT * FROM dane_osobowe where pesel={pesel}";
            dataReader = command.ExecuteReader();
                if (!dataReader.Read()) {
                dataReader.Close();
                command.CommandText = $"INSERT INTO dane_osobowe VALUES({pesel},'{names}','{lastName}','{home}',{phoneNum},'{mail}')";
                dataReader = command.ExecuteReader();
                 }
            dataReader.Close();
            command.CommandText = $"INSERT INTO nauczyciel VALUES ({etat},{pesel})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void AddStudent(string pesel, string names, string lastName, string home, string phoneNum, string mail, string classYear, string numberInRegister, string classLetter )
        {
            command.CommandText = $"INSERT INTO dane_osobowe VALUES('{pesel}','{names}','{lastName}','{home}',{phoneNum},'{mail}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.CommandText = $"INSERT INTO uczen VALUES ({pesel},{classYear},{numberInRegister},'{classLetter}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void AddRoom( string floor, string number, string chairs)
        {
            command.CommandText = $"INSERT INTO sala VALUES ({floor},{number},{chairs})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void AddLesson(string dayOfUnit, string hourOfUnit, string minuteOfUnit, string classYear, string classLetter, string roomFloor, string roomNumber, string subject)
        {
            command.CommandText = $"INSERT INTO lekcja VALUES ('{dayOfUnit}', {hourOfUnit}, {minuteOfUnit},{classYear},'{classLetter}', {roomFloor},{roomNumber},'{subject}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void Grill(string guardian, string child)
        {
            command.CommandText = $"INSERT INTO opieka VALUES ({child},{guardian})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void ChangeFormTutor(string newFormTutor, string classYear, string classLetter)
        {
            command.CommandText = $"UPDATE klasa SET nauczyciel_pesel={newFormTutor} WHERE rocznik={classYear} and literka='{classLetter}'";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        public void AddClass(string classYear, string classLetter, string formTutorPesel, string profile)
        {
            command.CommandText = $"INSERT INTO klasa VALUES ({classYear},'{classLetter}', {formTutorPesel},'{profile}') ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
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

        public bool LogInAsStudent(string pesel)
        {
            try
            {

            command.CommandText = $"select * from uczen where dane_osobowe_pesel='{pesel}'";
                        dataReader = command.ExecuteReader();
                        if (dataReader.Read())
                        {
                            dataReader.Close();
                            currentPesel = pesel;
                            return true;
                        }
                        dataReader.Close();
                        return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }



        public bool LogInAsParent(string pesel)
        {
            try
            {
                command.CommandText = $"select * from opiekun where dane_osobowe_pesel='{pesel}'";
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    dataReader.Close();
                    currentPesel = pesel;
                    return true;
                }

                dataReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool LogInAsTeacher(string pesel)
        {
            try
            {
            command.CommandText = $"select * from nauczyciel where dane_osobowe_pesel='{pesel}'";
             dataReader = command.ExecuteReader();
                        if (dataReader.Read())
                        {
                            dataReader.Close();
                    currentPesel = pesel;
                    return true;
                        }
                        dataReader.Close();
                        return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool LogInAdminMode(string pesel)
        {
            if (pesel == "666")
                return true;
            return false;

        }

        public bool CloseConnection()
        {
            sqlConnection.Close();
            return true;
        }


        public bool FirstUse()
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

                command.CommandText = "INSERT into jednostka VALUES ('nieobecny')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "INSERT into jednostka VALUES ('usprawiedliwiony')";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                return true;
            }

            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
