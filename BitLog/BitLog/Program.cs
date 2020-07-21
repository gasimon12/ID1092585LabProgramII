using System;
using System.Collections.Generic;
using System.IO;

namespace BitLog
{
    class Program
    {
        public static string vpath = AppDomain.CurrentDomain.BaseDirectory + "datos.csv";
        static void Main(string[] args)
        {
            if (!File.Exists(vpath))
            {
                File.AppendAllText(vpath, "Nombre,Apellido,Balance,Contraseña,Datos" + Environment.NewLine);
            }
            if (args.Length > 0 && args[0] == "--r")
            {
                string[] Lines = File.ReadAllLines(vpath);
                for (int i = 1; i < Lines.Length; i++)
                {
                    string[] vline = Lines[i].Split(',');
                    int.TryParse(vline[4], out int vprocess);
                    string psex, plic, pcar, pact;
                    if ((vprocess & 1) == 1)
                    {
                        psex = "masculino";
                    }
                    else
                    {
                        psex = "femenino";
                    }
                    if ((vprocess & 2) == 2)
                    {
                        plic = "tiene licencia";
                    }
                    else
                    {
                        plic = "no tiene licencia";
                    }
                    if ((vprocess & 4) == 4)
                    {
                        pcar = "tiene auto";
                    }
                    else
                    {
                        pcar = "no tiene auto";
                    }
                    if ((vprocess & 8) == 8)
                    {
                        pact = "esta activo";
                    }
                    else
                    {
                        pact = "no esta activo";
                    }
                    Console.WriteLine($"{vline[0]}, {psex}, {plic}, {pcar}, {pact}, {vprocess >> 4 ^ 0}");
                }
            }
            else
            {
                int vopc;
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1)Editar");
                Console.WriteLine("2)Agregar");
                Console.Write("Escoja una opcion [1/2]: ");
                vopc = Editor.Number();
                Console.Clear();
                switch (vopc)
                {
                    case 1:
                        Menu.Edit();
                        break;
                    case 2:
                        Menu.Add();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}