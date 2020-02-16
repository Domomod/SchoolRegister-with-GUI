using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace DziennikElektroniczny
{
    public class AbstractOsobaTableDataSource : NSTableViewDataSource
    {
        #region Constructors
        public AbstractOsobaTableDataSource() : base()
        {
        }
        #endregion

        #region Implement Methods
        //Porada, zapewnij jak¹œ formê type-safey w klasach pochodnych.


        public abstract string GetAt(string fieldName, int i)
        {
            var osoba = (Osoba)Data[i];
            switch (fieldName) {
                case "Imie":
                    return osoba.Imie;
                case "Nazwisko":
                    return osoba.Nazwisko;
                case "Pesel":
                    return osoba.Pesel;
                case "Email":
                    return osoba.Email;
                case "Adres":
                    return osoba.Adres;
                case "Numer telefonu":
                case "Numer":
                case "Telefon":
                    return osoba.Telefon;
                default:
                    return "";
            }
        }
        public virtual string GetRepresentationAt(int i) {
            ref Osoba osoba = (Osoba)Data[i];
            return $"{osoba.Imie} {osoba.Nazwisko}";
        }
        public abstract void SetAt(string fieldName, string value, int i) {
            ref Osoba osoba = (Osoba)Data[i];

            switch (fieldName)
            {
                case "Imie":
                    osoba.Imie = value;
                    break;
                case "Nazwisko":
                    osoba.Nazwisko = value;
                    break;
                case "Pesel":
                    osoba.Pesel = value;
                    break;
                case "Email":
                    osoba.Email = value;
                case "Adres":
                    osoba.Adres = value;
                    break;
                case "Numer telefonu":
                case "Numer":
                case "Telefon":
                    osoba.Telefon = value;
                    break;
                default:

            }
        }

        public abstract string GetColumnNameByRowNumber(int i)
        {
            switch (i)
            {
                case -1:
                case 0:
                    return "Imie";
                    break;
                case 1:
                    return "Nazwisko";
                    break;
                case 2:
                    return "Pesel";
                    break;
                case 3:
                    return "Adres";
                    break;
                case 4:
                    return "Email";
                    break;
                case 5:
                    return "Nr telefonu";
                    break;
                default:
                    return "";
            }
        }

        #endregion
    }
}