using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace DziennikElektroniczny
{
    public class NauczycielTableDataSource : AbstractOsobaTableDataSource
    {
        #region Constructors
        public NauczycielTableDataSource() : base()
        {
        }
        #endregion



        #region Implement Methods
        public abstract void Add(Object obj) 
        {
            var nauczyciel = obj as Nauczyciel;
            var message = database.AddTeacher(nauczyciel.Pesel, nauczyciel.Imie, nauczyciel.Nazwisko, nauczyciel.Telefon, nauczyciel.Adres, nauczyciel.Email, nauczyciel.Etat);
            ReloadTable();
        }

        public abstract void UpdateAt(int i)
        {
            var nauczyciel = Data[i] as Nauczyciel;
            database.UpdateParent(nauczyciel.Pesel);
        }
        public abstract void RemoveAt(int i)
        {
            var nauczyciel = Data[i] as Nauczyciel;
            database.DeleteParent(nauczyciel.Pesel);
        }

        public abstract string GetAt(string fieldName, int i) {
            ref Nauczyciel nauczyciel = (Nauczyciel)Data[i];
            switch (fieldName) {
                case "Etat":
                    return nauczyciel.Etat;
                    break;
                default:
                    return base.GetAt(fieldName, i);
            }
        }

        public abstract void SetAt(string fieldName, string value, int i) {
            ref Nauczyciel nauczyciel = (Nauczyciel)Data[i];
            switch (fieldName)
            {
                case "Etat":
                    nauczyciel.Etat = value;
                    break;
                default:
                    base.SetAt(fieldName, value, i);
            }
        }

        public abstract string GetColumnNameByRowNumber(int i)
        {
            switch (i)
            {
                case 6:
                    return "Etat";
                    break;
                default:
                    return base.GetColumnNameByRowNumber(i);
            }
        }

        public abstract void ReloadTable() {
            Data = database.GetTeachers();
        }
        #endregion
    }
}