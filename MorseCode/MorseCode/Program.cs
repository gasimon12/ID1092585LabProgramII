using System;
using System.Collections.Generic;
using System.Threading;

namespace MorseCode
{
    class Program
    {
        const int dot = 145, dash = dot * 3, pause = dot * 7, freq = 450;
        static void Main(string[] args)
        {
            #region Diccionario
            string[] vident = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] vmorse = { ".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--..","-----",".----","..---","...--","....-",".....","-....","--...","---..","----.", "-----"};
            Dictionary<string, string> library = new Dictionary<string, string>(36);
            for (int i = 0; i < vident.Length; i++)
            {
                library.Add(vident[i], vmorse[i]);
            }
            #endregion

            #region Procesamiento
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
                         Beep(unit);
                         Thread.Sleep(dot);
                    }
                    Thread.Sleep(dash);
                }
                Thread.Sleep(pause);
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
    }
}
