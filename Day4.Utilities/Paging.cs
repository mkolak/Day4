using System;

namespace Day4.Utilities
{
    public static class Paging
    {
        public static int PageNum = 0;

        public static int GrabPerPage = 10;

        public static string GenerateString() {
            string retString = "OFFSET " + PageNum * GrabPerPage + " ROWS FETCH NEXT " + GrabPerPage + " ROW ONLY";
            PageNum = 0;
            GrabPerPage = 10;
            return retString;
        }
    }
}
