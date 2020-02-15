using System;
using System.Text.RegularExpressions;

namespace DziennikElektroniczny
{
    public class Nauczyciel
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

        Regex EtatRegexp = new Regex(@"[0-9]+(\\.[0-9]+)?",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        #endregion

        #region Computed Properties
        private string imie;
        public string Imie
        {
            get {
                return imie;
            }
            set {
                if (!ImieNazwiskoRegex.IsMatch(value)) throw new ArgumentException("Niepoprawne imie.");
                imie = value;
            }
        }

        private string nazwisko;
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

        private string pesel;
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

        private string telefon;
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                if (value.ToUpper() == "NULL" || value == "") value = "";
                else if (!TelefonRegexp.IsMatch(value)) throw new ArgumentException("Telefon powinien być ciągiem 9 cyfr.");
                telefon = value;
            }
        }

        private string adres;
        public string Adres
        {
            get
            {
                return adres;
            }
            set
            {
                if (value.ToUpper() == "NULL" || value == "") value = "";
                else if(!AdresRegex.IsMatch(value)) throw new ArgumentException("Niepoprawny adres.");
                adres = value;
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value.ToUpper() == "NULL" || value == "") value = "";
                else if(!EmailRegexp.IsMatch(value)) throw new ArgumentException("Niepoprawne email.");
                email = value;

            }
        }

        private string etat;
        public string Etat
        {
            get
            {
                return etat;
            }
            set
            {
                if (!EtatRegexp.IsMatch(value)) throw new ArgumentException("Etat powinien być liczbą ułamkową.");
                etat = value;
            }
        }
        #endregion

        #region Constructors
        public Nauczyciel()
        {
        }

        public Nauczyciel(string imie, string nazwisko, string pesel, string telefon, string adres, string email, string etat)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Pesel = pesel;
            this.Telefon = telefon;
            this.Adres = adres;
            this.Email = email;
            this.Etat = etat;
        }
        #endregion
    }
}