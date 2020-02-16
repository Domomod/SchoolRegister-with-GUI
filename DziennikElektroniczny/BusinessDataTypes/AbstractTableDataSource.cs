using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace DziennikElektroniczny
{
    //Implementacja metod zawartych w tej klasie zezwala na komunikację UniversalTableDelegate z naszą konkretną implementacją TableDataSource,
    //używając jedynie nazw kolumn.
    public class AbstractTableDataSource : NSTableViewDataSource
    {
        protected Database database;

        #region Public Variables
        public List<Object> Data = new List<Nauczyciel>();
        #endregion

        #region Constructors
        public AbstractTableDataSource()
        {
            database = Database.Instance;
            ReloadTable();
        }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Data.Count;
        }
        #endregion

        #region Public Methods
        //Porada, zapewnij jakąś formę type-safey w klasach pochodnych.
        public abstract void Add(Object obj);
        public abstract void UpdateAt(int i); //Zapisz zmiany do bazy danych
        public abstract void RemoveAt(int i); //Usuń z bazy danych
        public abstract string GetAt(string fieldName, int i); //Zwróć wartość atrybutu o nazwie fieldName krotki i-tej. By default zwróć pusty ciąg.
        public virtual string GetRepresentationAt(int i) { return "rekord"; } // Zwraca ciąg znakó identyfikujący w jakiś sposób rekord, np imię + nazwisko. Nie trzeba nadpisywać.
        public abstract void SetAt(string fieldName, string value, int i); //Ustaw wartość atrybutu o nazie fieldName na value dla i-tej krotki
        public abstract void ReloadTable(); //Pobierz ponownie dane z bazy danych
        public abstract string GetColumnNameByRowNumber(int i);

        #endregion
    }
}