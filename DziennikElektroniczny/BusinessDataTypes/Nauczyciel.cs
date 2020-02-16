using System;
using System.Text.RegularExpressions;

namespace DziennikElektroniczny
{
    public class Nauczyciel : Osoba
    {
        #region Static Regexps
        Regex EtatRegexp = new Regex(@"[0-9]+(\\.[0-9]+)?",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        #endregion

        #region Private Fields
        private string etat;
        #endregion

        #region Public Properties
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

        public Nauczyciel(string imie, string nazwisko, string pesel, string telefon, string adres, string email, string etat) : base(imie, nazwisko, pesel, telefon, adres, email)
        {
            this.Etat = etat;
        }
        #endregion
    }
}