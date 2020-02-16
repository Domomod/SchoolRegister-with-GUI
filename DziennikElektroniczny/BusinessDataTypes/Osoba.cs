using System;
using System.Text.RegularExpressions;

namespace DziennikElektroniczny
{
    public class Osoba
    {
        #region Static Regexps
        Regex ImieNazwiskoRegex = new Regex(@"^[\p{L}]+$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        Regex PeselRegex = new Regex(@"^[0-9]{11}$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        Regex AdresRegex = new Regex(@"^(\w+\.)?(\s\w+)+(\s\d((\\|\/)\d)?)?$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        Regex EmailRegexp = new Regex(@"^[a-z\d]+[\w\d.-]*@(?:[a-z\d]+[a-z\d-]+\.){1,5}[a-z]{2,6}$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        Regex TelefonRegexp = new Regex(@"[0-9]{9}",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        #endregion

        #region Private Members
        private string imie;
        private string nazwisko;
        private string email;
        private string pesel;
        private string telefon;
        private string adres;
        #endregion

        #region Public Properties
        public string Imie
        {
            get
            {
                return imie;
            }
            set
            {
                if (!ImieNazwiskoRegex.IsMatch(value)) throw new ArgumentException("Niepoprawne imie.");
                imie = value;
            }
        }

        public string Nazwisko
        {
            get
            {
                return nazwisko;
            }
            set
            {
                if (!ImieNazwiskoRegex.IsMatch(value)) throw new ArgumentException("Niepoprawne nazwisko.");
                nazwisko = value;
            }
        }

        public string Pesel
        {
            get
            {
                return pesel;
            }
            set
            {
                if (!PeselRegex.IsMatch(value)) throw new ArgumentException("Niepoprawny pesel.");
                pesel = value;
            }
        }

        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                if (value.ToUpper() == "NULL" || value == "") value = "";
                else if (!TelefonRegexp.IsMatch(value)) throw new ArgumentException("Telefon powinien byæ ci¹giem 9 cyfr.");
                telefon = value;
            }
        }

        public string Adres
        {
            get
            {
                return adres;
            }
            set
            {
                if (value.ToUpper() == "NULL" || value == "") value = "";
                else if (!AdresRegex.IsMatch(value)) throw new ArgumentException("Niepoprawny adres.");
                adres = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value.ToUpper() == "NULL" || value == "") value = "";
                else if (!EmailRegexp.IsMatch(value)) throw new ArgumentException("Niepoprawne email.");
                email = value;

            }
        }
        #endregion

        #region Constructors
        public Osoba()
        {
        }

        public Osoba(string imie, string nazwisko, string pesel, string telefon, string adres, string email)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Pesel = pesel;
            this.Telefon = telefon;
            this.Adres = adres;
            this.Email = email;
        }
        #endregion
    }
}