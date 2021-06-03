using System;
using System.Collections.Generic;
using System.Text;

namespace RPN
{
    class DrawerTableConsole
    {
        public static void DrawerTable(string strTable)
        {
            Console.WriteLine(strTable);
        }

        public static int ReadData(string Text)
        {
            Console.WriteLine(Text);
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}
