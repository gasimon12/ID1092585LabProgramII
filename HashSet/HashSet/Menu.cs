using System;
using System.IO;

namespace HashSet
{
    class Menu
    {
        public static string vpath = AppDomain.CurrentDomain.BaseDirectory + "datos.csv";
        public static User Add()
        {
            string vname, vlast;
            Console.Write("Ingrese su nombre: ");
            vname = Editor.Input(false);
            Console.WriteLine(vname);
            Console.Write("Ingrese su apellido: ");
            vlast = Editor.Input(false);
            Console.WriteLine(vlast);
            Console.Write("Ingrese su edad: ");
            int v5 = Editor.Number();
            Console.WriteLine(v5);
            Console.Write("Ingrese su balance: ");
            decimal vbalance = Editor.PNumber();
            Console.WriteLine(vbalance);
            #region Codificacion
            int v1 = 0, v2 = 0, v3 = 0, v4 = 0;
            Console.Write("Masculino/Femenino[m/f]: ");
            string vsex = Editor.Input(false);
            if (vsex == "m")
            {
                v1 = 1;
            }
            else { }
            Console.Write("Tiene licencia de conducir?[s/n]: ");
            string vlic = Editor.Input(false);
            if (vlic == "s")
            {
                v2 = 2;
            }
            else { }
            Console.Write("Tiene auto?[s/n]: ");
            string vcar = Editor.Input(false);
            if (vcar == "s")
            {
                v3 = 4;
            }
            else { }
            Console.Write("Esta activo?[s/n]: ");
            string vact = Editor.Input(false);
            if (vact == "s")
            {
                v4 = 8;
            }
            else { }
            int vdatos = (v1 | v2 | v3 | v3 | v4) | (v5 << 4);
            #endregion
            Console.Write("Ingrese su contraseña: ");
            string vpass = Editor.Input(true);
            Console.Write("Confirme su contraseña: ");
            string vconf = Editor.Input(true);
            if (vpass != vconf)
            {
                do
                {
                    Console.Write("Las contraseñas no son iguales, desear insertar de nuevo [s/n]: ");
                    string vopc = Editor.Input(false);
                    if (vopc == "s")
                    {
                        Console.Write("Confirme de nuevo: ");
                        vconf = Editor.Input(true);
                    }
                    else
                    {
                        break;
                    }
                } while (vpass != vconf);
            }
            if (vpass == vconf)
            {
                return new User(vname, vlast, vbalance.ToString(), vpass, vdatos.ToString());
            }
            return null;
        }
        public static void Edit()
        {
            string vname, vlast;
            Console.Write("Ingrese su nombre: ");
            vname = Editor.Input(false);
            Console.WriteLine(vname);
            Console.Write("Ingrese su apellido: ");
            vlast = Editor.Input(false);
            Console.WriteLine(vlast);
            if (!Editor.Srch(ref vname, ref vlast))
            {
                Console.WriteLine("Error, la persona no existe, no se puede editar");
            }
            else
            {
                int vopc, vloc;
                vloc = Editor.Find(vname + vlast);
                Console.WriteLine("\t\tQue desea editar?");
                Console.WriteLine("1)Edad");
                Console.WriteLine("2)Balance");
                Console.WriteLine("3)Sexo");
                Console.WriteLine("4)Licencia");
                Console.WriteLine("5)Auto");
                Console.WriteLine("6)Estado");
                Console.WriteLine("7)Contraseña");
                Console.Write("Escoja un numero: ");
                vopc = Editor.Number();
                switch (vopc)
                {
                    case 1:
                        Console.Write("Ingrese su edad: ");
                        int v5 = Editor.Number();
                        Console.WriteLine(v5);
                        Editor.ReAge(vloc, v5);
                        break;
                    case 2:
                        Console.Write("Ingrese su balance: ");
                        decimal vbalance = Editor.PNumber();
                        Console.WriteLine(vbalance);
                        Editor.Change(vloc, 2, vbalance.ToString());
                        break;
                    case 3:
                        int v1;
                        Console.Write("Masculino/Femenino[m/f]: ");
                        string vsex = Editor.Input(false);
                        if (vsex == "m")
                        {
                            v1 = 1 | Editor.Extract(vloc);
                        }
                        else
                        { v1 = ~1 & Editor.Extract(vloc); }
                        Editor.Change(vloc, 4, v1.ToString());
                        break;
                    case 4:
                        int v2;
                        Console.Write("Tiene licencia de conducir?[s/n]: ");
                        string vlic = Editor.Input(false);
                        if (vlic == "s")
                        {
                            v2 = (2 | Editor.Extract(vloc));
                        }
                        else
                        { v2 = ~2 & Editor.Extract(vloc); }
                        Editor.Change(vloc, 4, v2.ToString());
                        break;
                    case 5:
                        int v3;
                        Console.Write("Tiene auto?[s/n]: ");
                        string vcar = Editor.Input(false);
                        if (vcar == "s")
                        {
                            v3 = 4 | Editor.Extract(vloc);
                        }
                        else
                        { v3 = ~4 & Editor.Extract(vloc); }
                        Editor.Change(vloc, 4, v3.ToString());
                        break;
                    case 6:
                        int v4;
                        Console.Write("Esta activo?[s/n]: ");
                        string vact = Editor.Input(false);
                        if (vact == "s")
                        {
                            v4 = 8 | Editor.Extract(vloc);
                        }
                        else
                        { v4 = ~8 & Editor.Extract(vloc); }
                        Editor.Change(vloc, 4, v4.ToString());
                        break;
                    case 7:
                        Console.Write("Ingrese su contraseña: ");
                        string vpass = Editor.Input(true);
                        Console.Write("Confirme su contraseña: ");
                        string vconf = Editor.Input(true);
                        if (vpass != vconf)
                        {
                            do
                            {
                                Console.Write("Las contraseñas no son iguales, desear insertar de nuevo [s/n]: ");
                                string vsel = Editor.Input(false);
                                if (vsel == "s")
                                {
                                    Console.Write("Confirme de nuevo: ");
                                    vconf = Editor.Input(true);
                                }
                                else
                                {
                                    break;
                                }
                            } while (vpass != vconf);
                        }
                        if (vpass == vconf)
                        {
                            Editor.Change(vloc, 3, vpass);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static User Delete()
        {
            string vname, vlast;
            Console.Write("Ingrese su nombre: ");
            vname = Editor.Input(false);
            Console.WriteLine(vname);
            Console.Write("Ingrese su apellido: ");
            vlast = Editor.Input(false);
            Console.WriteLine(vlast);
            return new User(vname, vlast);
        }
    }
}
