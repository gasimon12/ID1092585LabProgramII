using System;
using System.IO;
using System.Collections.Generic;

namespace DateTime
{
    public class Info
    {
        public static DateTime[] datesTimes;
        public static Weather[] weathers;
        public int count { get; }
        public Info(string path)
        {
            string[] temp = File.ReadAllLines(path);
            count = temp.Length;
            datesTimes = new DateTime[count];
            weathers = new Weather[count];
            for (int i = 0; i < count; i++)
            {
                string[] line = temp[i].Split(',');
                datesTimes[i] = new DateTime(line[0]);
                weathers[i] = new Weather(line[1],line[2],line[3]);
            }
        }

        public void Write()
        {
            string[] merge = new string[count];
            for (int i = 0; i < count; i++)
            {
                merge[i] = $"{ datesTimes[i].Encode() },{ weathers[i].Encode() }";
            }
            File.WriteAllLines("decode.csv", merge);
        }
    }
}
