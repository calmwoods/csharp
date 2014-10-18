using System;
using FileIOManager;
using MealMenu;
using System.IO;

namespace MealStarter
{
    class Program
    {
        static string LINE_SEPERATOR = ",";
        static string TIME_LUNCH = "lunch";
        static string TIME_DINNER = "dinner";
        static int OUTFILE_EXTRA_LINE_CNT = 3;

        static void ParseTimeNameCost( ref string time, ref string name, ref decimal cost, string line )
        {
            int firstSeperatorPosition = line.IndexOf(LINE_SEPERATOR);
            time = line.Substring(0, firstSeperatorPosition);

            int lastSeperatorPosition = line.LastIndexOf(LINE_SEPERATOR);
            int nameLength = lastSeperatorPosition - firstSeperatorPosition - 1 ;
            name = line.Substring(firstSeperatorPosition + 1, nameLength);

            string strCost = line.Substring(lastSeperatorPosition + 1);
            strCost = strCost.Trim();
            strCost = strCost.Replace("$", "");
            cost = Convert.ToDecimal(strCost);
        }

        static void MakeMenuFile(MenuItem[] lunchList, MenuItem[] dinnerList)
        {
            string buf = "* Lunch Items *" ; 
            FileWriter.CreateText(buf);

            for( int i=0; i < lunchList.Length; i++ )
            {
                buf = String.Format("{0, 7:C}\t{1}", lunchList[i].Price, lunchList[i].Name);
                FileWriter.AppendText(buf);
            }

            FileWriter.AppendText("");
            FileWriter.AppendText("* Dinner Items *");

            for( int i=0; i < dinnerList.Length; i++ )
            {
                buf = String.Format("{0, 7:C}\t{1}", dinnerList[i].Price, dinnerList[i].Name);
                FileWriter.AppendText(buf);
            }
        }

        static void Main(string[] args)
        {
            // Read
            string[] inputLines = FileReader.ReadLines(); 

            // Save
            MenuItem[] arrMenuItem = new MenuItem[inputLines.Length];
            for (int i = 0; i < inputLines.Length; i++ )
            {
                string mealTime = "";
                string mealName = "" ;
                decimal mealCost = 0;
                ParseTimeNameCost(ref mealTime, ref mealName, ref mealCost, inputLines[i]);

                arrMenuItem[i] = new MenuItem(mealTime, mealName, mealCost); 
            }

            // Sort 
            MenuItem[] lunchList = MenuItem.GetMenuListByTime(TIME_LUNCH, arrMenuItem);
            MenuItem[] dinnerList = MenuItem.GetMenuListByTime(TIME_DINNER, arrMenuItem);

            // Write 
            MakeMenuFile(lunchList, dinnerList);

            Console.ReadLine(); 
        }
    }
}
