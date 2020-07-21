using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace HashSet
{
    class Editor
    {
        public static string vpath = AppDomain.CurrentDomain.BaseDirectory + "datos.csv";
        public static string Input(bool mode)
        {
            List<char> vchar = new List<char>();
            ConsoleKeyInfo vkey;
            int vcode;
            do
            {
                vkey = Console.ReadKey(true);
                vcode = vkey.KeyChar;
                switch (vcode)
                {
                    case 8:
                        if (vchar.Count > 0)
                        {
                            vchar.RemoveAt(vchar.Count - 1);
                            Console.Write("\b \b");
                        }
                        break;

                    case 13:
                        Console.WriteLine();
                        break;

                    default:
                        vchar.Add((char)vcode);
                        if (mode == true)
                        {
                            Console.Write('*');
                        }
                        else
                        {
                            Console.Write(vkey.KeyChar);
                        }
                        break;
                }
            } while (vcode != 13);
            return new string(vchar.ToArray()).Trim().Replace(",", String.Empty);
        }
        public static int Number()
        {
            List<char> vchar = new List<char>();
            ConsoleKeyInfo vkey;
            int vcode;
            do
            {
                vkey = Console.ReadKey(true);
                vcode = vkey.KeyChar;
                switch (vcode)
                {
                    case 8:
                        if (vchar.Count > 0)
                        {
                            vchar.RemoveAt(vchar.Count - 1);
                            Console.Write("\b \b");
                        }
                        break;

                    case 13:
                        Console.WriteLine();
                        break;

                    default:
                        char vcar = (char)vcode;
                        if (Char.IsDigit(vcar))
                        {
                            vchar.Add(vcar);
                            Console.Write(vkey.KeyChar);
                        }
                        break;
                }
            } while (vcode != 13);
            int vnumber = int.Parse(vchar.ToArray());
            return vnumber;
        }
        public static decimal PNumber()
        {
            List<char> vchar = new List<char>();
            ConsoleKeyInfo vkey;
            int vcode;
            do
            {
                vkey = Console.ReadKey(true);
                vcode = vkey.KeyChar;
                switch (vcode)
                {
                    case 8:
                        if (vchar.Count > 0)
                        {
                            vchar.RemoveAt(vchar.Count - 1);
                            Console.Write("\b \b");
                        }
                        break;

                    case 13:
                        Console.WriteLine();
                        break;

                    default:
                        char vcar = (char)vcode;
                        if (Char.IsDigit(vcar) || (vcar == 46 && !vchar.Contains('.')))
                        {
                            vchar.Add(vcar);
                            Console.Write(vkey.KeyChar);
                        }
                        break;
                }
            } while (vcode != 13);
            string vconver = new string(vchar.ToArray());
            decimal pnumber = decimal.Parse(vconver);
            return pnumber;
        }
        public static bool Srch(ref string vname, ref string vlast)
        {
            bool vfound = false;
            string[] Lines = File.ReadAllLines(vpath);
            for (int i = 1; i < Lines.Length; i++)
            {
                string[] vline = Lines[i].Split(',');
                if (String.Compare(vname + vlast, vline[0] + vline[1], CultureInfo.InvariantCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                {
                    vfound = true;
                }
            }
            return vfound;
        }
        public static int Find(string vkey)
        {
            int vloc = 0;
            string[] Lines = File.ReadAllLines(vpath);
            for (int i = 1; i < Lines.Length; i++)
            {
                string[] vline = Lines[i].Split(',');
                if (String.Compare(vkey, vline[0] + vline[1], CultureInfo.InvariantCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                {
                    vloc = i;
                }
            }
            return vloc;
        }
        public static void Change(int vloc, int vcolumn, string vinput)
        {
            string[] Lines = File.ReadAllLines(vpath);
            string[] vline = Lines[vloc].Split(',');
            vline[vcolumn] = vinput;
            StringBuilder temp = new StringBuilder();
            Lines[vloc] = temp.AppendJoin(',', vline).ToString();
            File.WriteAllLines(vpath, Lines);
        }
        public static int Extract(int vloc)
        {
            string[] Lines = File.ReadAllLines(vpath);
            string[] vline = Lines[vloc].Split(',');
            return Convert.ToInt32(vline[4]);
        }
        public static void ReAge(int vloc, int vnum)
        {
            string[] Lines = File.ReadAllLines(vpath);
            string[] vline = Lines[vloc].Split(',');
            int vtemp = (15 & Convert.ToInt32(vline[4]));
            vline[4] = (vtemp | vnum << 4).ToString();
            StringBuilder temp = new StringBuilder();
            Lines[vloc] = temp.AppendJoin(',', vline).ToString();
            File.WriteAllLines(vpath, Lines);
        }
    }
}
