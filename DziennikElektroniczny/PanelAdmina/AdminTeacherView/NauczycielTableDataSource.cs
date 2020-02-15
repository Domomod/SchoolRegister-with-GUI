using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace DziennikElektroniczny
{
    public class NauczycielTableDataSource : NSTableViewDataSource
    {
        Database database;

        #region Public Variables
        public List<Nauczyciel> Nauczyciele = new List<Nauczyciel>();
        #endregion

        #region Constructors
        public NauczycielTableDataSource()
        {
            database = Database.Instance;
            ReloadTable();
        }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Nauczyciele.Count;
        }
        #endregion

        #region Public Methods
        //TODO
        //Jak się nie powiedzie to rzucaj wyjątek. Odwoływać się do funkcji add i remove powinnaś z klasy NauczycielTableDelegate.
        //Ten delegat ma referencję do AdminNauczycieleViewControler, więc możesz z jego poziomu zmodyfikować StatusTextField, żeby
        //wyświetlić komunikat (więc to w nim łap wyjątki). Kocham Cię ;*, jak już to zrobisz to usuń ten komentarz. A i odowłania do TextFields'ów proszę zrób
        //też w delegacie, tutaj przekaż już same stringi + sprawdź ich poprawność -> niepoprawne rzuć wyjątek.
        public void AddNauczyciel(Nauczyciel nauczyciel) {
            var message = database.AddTeacher(nauczyciel.Pesel, nauczyciel.Imie, nauczyciel.Nazwisko, nauczyciel.Telefon, nauczyciel.Adres, nauczyciel.Email, nauczyciel.Etat);
            ReloadTable();
        }

        public void UpdateAt(int i) {
            database.UpdateParent(Nauczyciele[i].Pesel);
        }

        public void RemoveNauczyciel(int i) {
            database.DeleteParent(Nauczyciele[i].Pesel);
            //Tu usuń z bazy + podepnij pod przycisk
        }

        public void ReloadTable() {
            Nauczyciele = database.GetTeachers();
            //Tu pobierz z bazy
        }

        #endregion
    }
}