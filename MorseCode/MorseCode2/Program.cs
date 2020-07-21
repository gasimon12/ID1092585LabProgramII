using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace MorseCode2
{
    class Program
    {
        const int dot = 145, dash = dot * 3, pause = dot * 7, freq = 450;
        static int count = 0;
        static bool mode;
        static void Main(string[] args)
        {
            #region Diccionario
            string[] vident = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] vmorse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----" };
            Dictionary<string, string> library = new Dictionary<string, string>(36);
            for (int i = 0; i < vident.Length; i++)
            {
                library.Add(vident[i], vmorse[i]);
            }
            #endregion

            #region Procesamiento
            if (args[0] == "--count")
            {
                args = args.Where(w => w != args[0]).ToArray();
                mode = true;
            }

            List<string> processed = new List<string>();
            foreach (string word in args) //Palabra
            {
                string palabra = word.ToUpper();
                foreach (char letter in palabra) //Letra
                {
                    string letra = letter.ToString();
                    if (!library.ContainsKey(letra)) //Verif letra en diccionario
                    {
                        palabra = palabra.Replace(letra, "");
                    }
                }
                if (palabra != "")
                {
                    processed.Add(palabra);
                }
            }
            #endregion

            foreach (string word in processed) //Palabra
            {
                foreach (char letter in word) //Letra
                {
                    string letra = letter.ToString();
                    string translate = library[letra];
                    foreach (char unit in translate) //Dot/Dash
                    {
                        switch (mode)
                        {
                            case true:
                                Count(unit);
                                count += dot;
                                break;
                            case false:
                                Beep(unit);
                                Thread.Sleep(dot);
                                break;
                        }
                    }
                    if (!mode) { Thread.Sleep(dash); }
                    count += dash;
                }
                if (!mode) { Thread.Sleep(pause); }
                count += pause;
            }
            if (mode) 
            {
                Console.WriteLine($"El mensaje \"{string.Join(" ", processed).ToLower()}\", tardara {count / 1000} sgs en reproducirse");
            }
        }
        static void Beep(char unit)
        {
            if (unit == '.')
            {
                Console.Beep(freq, dot);
            }
            else if (unit == '-')
            {
                Console.Beep(freq, dash);
            }
        }
        static void Count(char unit)
        {
            if (unit == '.')
            {
                count += dot;
            }
            else if (unit == '-')
            {
                count += dash;
            }
        }
    }
}
