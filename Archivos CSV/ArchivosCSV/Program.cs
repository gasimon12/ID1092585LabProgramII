using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoginData
{
    class Program
    {
        static void Main(string[] args)
        {
            string vpath = AppDomain.CurrentDomain.BaseDirectory + "datos.csv";
            if (!File.Exists(vpath))
            {
                File.AppendAllText(vpath, "Nombre,Apellido,Edad,Balance,Contraseña" + Environment.NewLine);
            }
            string vloop;
            do
            {
                Console.Write("Ingrese su nombre: ");
                string vname = Input(false);
                Console.WriteLine(vname);
                Console.Write("Ingrese su apellido: ");
                string vlast = Input(false);
                Console.WriteLine(vlast);
                Console.Write("Ingrese su edad: ");
                int vage = Number();
                Console.WriteLine(vage);
                Console.Write("Ingrese su balance: ");
                decimal vbalance = PNumber();
                Console.WriteLine(vbalance);
                Console.Write("Ingrese su contraseña: ");
                string vpass = Input(true);
                Console.Write("Confirme su contraseña: ");
                string vconf = Input(true);
                if (vpass != vconf)
                {
                    do
                    {
                        Console.Write("Las contraseñas no son iguales, desear insertar de nuevo [s/n]: ");
                        string vopc = Input(false);
                        if (vopc == "s")
                        {
                            Console.Write("Confirme de nuevo: ");
                            vconf = Input(true);
                        }
                        else
                        {
                            break;
                        }
                    } while (vpass != vconf);
                }
                if (vpass == vconf)
                {
                    File.AppendAllText(vpath, string.Format("{0},{1},{2},{3},{4}" + Environment.NewLine, vname, vlast, vage.ToString(), vbalance.ToString(), vpass));
                }
                Console.Write("Desea registrar algun otro dato[s/n]? ");
                vloop = Input(false);
                Console.Clear();
            } while (vloop == "s");
        }
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
            return new string(vchar.ToArray());
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
    }
}