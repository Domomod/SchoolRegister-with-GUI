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
        #region Public Variables
        public List<Nauczyciel> Nauczyciele = new List<Nauczyciel>();
        #endregion

        #region Constructors
        public NauczycielTableDataSource()
        {
            //Tu pobierz z bazy
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
        public void AddNauczyciel(String imie, String nazwisko) {
            //Tu wprowadź do bazy + podepnij pod przycisk
        }

        public void RemoveNauczyciel(String imie, String nazwisko) {
            //Tu usuń z bazy + podepnij pod przycisk
        }

        public void ReloadTable() {
            //Tu pobierz z bazy
        }

        #endregion
    }
}