using System;
using System.IO;

namespace DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Info archivo = new Info("datos.csv");
            archivo.Write();
        }
    }
}
