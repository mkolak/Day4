using System.Collections.Generic;
using System.Linq;

namespace Day4.Utilities
{
    public static class Filtering
    {
        public static List<string> Queries = new List<string>();

        public static List<string> AllowedOperators = new List<string>{ ">=", "<=", "!=", "<", ">", "=" };

        public static string GenerateString() {
            if (Queries[0] == "") return "";
            string retString = "WHERE ";
            bool comma = false;
            bool found;
            foreach (string query in Queries) {
                string[] splitStr;
                found = false;
                foreach (string op in AllowedOperators) {
                    splitStr = query.Split(new[] { op }, System.StringSplitOptions.None);
                    if (splitStr.Length == 2) {
                        if (comma) retString += " , ";
                        if (op == "!=")
                        {
                            retString += splitStr[0] + " <> '" + splitStr[1] + "'";
                        }
                        else {
                            retString += splitStr[0] + " " + op + " '" + splitStr[1] + "'";
                        }
                        found = true;
                        comma = true;
                        break;
                    }
                }
                if (!found) throw new System.Exception("Invalid filter query.");
            }
            Queries.Clear();
            return retString;
        }
    }
}
