using System;
using System.Collections.Generic;
namespace gui
{
    public class SQLChecker
    {
        List<string> forbidden;

        public SQLChecker()
        {
            forbidden = new List<string>();
            forbidden.Add("DROP");
            forbidden.Add("ABORT");
            forbidden.Add("ALTER");
            forbidden.Add("AVG");
            forbidden.Add("BEGIN");
            forbidden.Add("CASCADE");
            forbidden.Add("COMMIT");
            forbidden.Add("CREATE");
            forbidden.Add("CURSOR");
            forbidden.Add("DELETE");
            forbidden.Add("DECLARE");
            forbidden.Add("FROM");
            forbidden.Add("GRANT");
            forbidden.Add("GROUP");
            forbidden.Add("HAVING");
            forbidden.Add("INSERT");
            forbidden.Add("JOIN");
            forbidden.Add("NEXT");
            forbidden.Add("OPEN");
            forbidden.Add("ORDER");
            forbidden.Add("REPLACE");
            forbidden.Add("RETURN");
            forbidden.Add("ROLLBACK");
            forbidden.Add("SELECT");
            forbidden.Add("VIEW");
        }

        public bool IsCorrect(string text)
        {
            text = text.ToUpper();
            foreach (var uglyWord in forbidden)
            {
                if (text.Contains(uglyWord))
                    return false;
            }
            return true;
        }


        public bool IsPesel(string text)
        {
            if (text.Length != 11)
                return false;
            int t;
            foreach (var num in text)
            {
                if (!int.TryParse(num.ToString(), out t))
                    return false;
            }
            return true;
        }
    }
}