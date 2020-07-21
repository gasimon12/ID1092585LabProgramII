using System;
using System.IO;

namespace DecodifDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("decode.csv"); //args[0]);
            foreach (string item in lines)
            {
                string[] entry = item.Split(',');
                ulong dateTime = ulong.Parse(entry[0]);
                int year = (int)(dateTime >> 48 & 0b111111_111111); //12
                int month = (int)(dateTime >> 44 & 0b1111); //4
                int day = (int)(dateTime >> 39 & 0b11111); //5
                int hour = (int)(dateTime >> 34 & 0b11111); //5
                int minute = (int)(dateTime >> 28 & 0b111111); //6
                int second = (int)(dateTime >> 22 & 0b111111); //6
                int millisec = (int)(dateTime >> 12 & 0b1111111111); //10
                int tSign = (int)dateTime >> 11 & 1; //1
                char sign;
                if (tSign == 1)
                {
                    sign = '+';
                }
                else
                {
                    sign = '-';
                }
                int tHour = (int)(dateTime >> 6 & 0b11111); //5
                int tMin = (int)(dateTime & 0b111111); //6
                string part1 = $"{year}-{month}-{day}T{hour}:{minute}:{second}.{millisec}";
                string pHour;
                if (tHour < 10)
                {
                    pHour = '0' + tHour.ToString();
                }
                else
                {
                    pHour = tHour.ToString();
                }
                string pMin;
                if (tMin < 10)
                {
                    pMin = '0' + tMin.ToString();
                }
                else
                {
                    pMin = tMin.ToString();
                }
                int weather = int.Parse(entry[1]);
                int v7 = 0b1111111;
                int MinTemp = weather >> 14 & v7;
                int MaxTemp = weather >> 7 & v7;
                int Precip = weather & v7;
                string part2 = sign + pHour.ToString() + ':' + pMin.ToString();
                string part3 = $"{MinTemp},{MaxTemp},{Precip}";
                Console.WriteLine(part1 + part2 + " Weather: " + part3);
            }
        }
    }
}
