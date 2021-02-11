using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Utilities
{
    public static class Sorting
    {
        public static List<string> Queries = new List<string>();

        public static string GenerateString() {
            if (Queries[0] == "") return "";
            string retString = " ORDER BY ";
            bool comma = false;
            foreach (string query in Queries) {
                string[] splitStr = query.Split('+');
                string append = "";
                if (comma) retString += ", ";
                if (splitStr.Length == 2) {
                    append = splitStr[1];
                }
                retString += splitStr[0] + " " + append + " ";
                comma = true;
            }
            Queries.Clear();
            return retString;
        }
    }
}
