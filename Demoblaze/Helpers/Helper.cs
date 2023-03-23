using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using TechTalk.SpecFlow;

namespace Demoblaze.Helpers
{
    public class Helper
    {
        public static int tHigh = 5000;
        public static int tMedium = 3000;
        public static int tLow = 1000;
        public static DataTable resultTable;

        public static void wait(int time)
        {
            Thread.Sleep(time);
        }

        public static int generateRandomNumber(int initial, int final) => new Random().Next(initial, final);
        public static string generateLetter() => ((char)(((int)'A') + generateRandomNumber(0, 25))).ToString();
    }
}
