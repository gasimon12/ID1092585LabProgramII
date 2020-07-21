using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashSet
{
    class Program
    {
        public static string vpath = AppDomain.CurrentDomain.BaseDirectory + "datos.csv";
        public static Contenedores archivo = new Contenedores();
        static void Main(string[] args)
        {
            if (!File.Exists(vpath))
            {
                File.Create(vpath).Close();
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
                Load();
                int vopc;
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1)Editar");
                Console.WriteLine("2)Agregar");
                Console.WriteLine("3)Eliminar");
                Console.Write("Escoja una opcion [1/2/3]: ");
                vopc = Editor.Number();
                Console.Clear();
                switch (vopc)
                {
                    case 1:
                        Menu.Edit();
                        break;
                    case 2:
                        string vloop;
                        do
                        {
                            User user = Menu.Add();
                            if (archivo.Add(user))
                            {
                                Console.WriteLine("Registrado exitosamente!");
                            }
                            else
                            {
                                Console.WriteLine("Error, registro ya existia");
                            }
                            Console.Write("Desea registrar algun otro dato[s/n]? ");
                            vloop = Editor.Input(false);
                            Console.Clear();
                        } while (vloop == "s");
                        break;
                    case 3:
                        User key = Menu.Delete();
                        if (archivo.Remove(key))
                        {
                            Console.WriteLine("Eliminado exitosamente!");
                        }
                        else
                        {
                            Console.WriteLine("Error, registro no existia");
                        }
                        break;
                    default:
                        break;
                }
                Unload();
            }
        }
        public static void Load()
        {
            string[] Lines = File.ReadAllLines(vpath);
            if (Lines.Length > 1)
            {
                for (int i = 1; i < Lines.Length; i++)
                {
                    string[] vline = Lines[i].Split(',');
                    User user = new User(vline[0], vline[1], vline[2], vline[3], vline[4]);
                    archivo.Add(user);
                }
            }
        }
        public static void Unload()
        {
            File.WriteAllText(vpath, "Nombre,Apellido,Balance,Contraseña,Datos" + Environment.NewLine);
            foreach (var List in Contenedores.Segment)
            {
                IEnumerable<User> Sort =
                    from element in List
                    orderby element.vapellido ascending
                    select element;
                foreach (var user in Sort)
                {
                    File.AppendAllText(vpath, String.Join(',', user.vnombre, user.vapellido, user.vbal, user.vcontra, user.vbit + Environment.NewLine));
                }
            }
        }
    }
}
