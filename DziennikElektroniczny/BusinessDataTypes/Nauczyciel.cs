using System;

namespace DziennikElektroniczny
{
    public class Nauczyciel
    {
        #region Computed Properties
        public string Imie { get; set; } = "";
        public string Nazwisko { get; set; } = "";
        #endregion

        #region Constructors
        public Nauczyciel()
        {
        }

        public Nauczyciel(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }
        #endregion
    }
}