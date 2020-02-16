using System;
using System.Text.RegularExpressions;

namespace DziennikElektroniczny
{
    public class NSTextFieldProxy
    {
        private NSTextField textField; //Czy to na pewno referencja???

        public string StringValue { 
            set 
            {
                TextField.StringValue = value;
            }

            get 
            {
                return TextField.StringValue;
            }
        }

        #region Constructors
        public Osoba(NSTextFieldProxy TextField)
        {
            this.textField = TextField;
        }
        #endregion
    }
}