using System;
using System.Collections.Generic;
using System.Text;

namespace DateTime
{
    public class DateTime
    {
        public ulong year { get; }
        public ulong month { get; }
        public ulong day{ get; }
        public ulong hour { get; }
        public ulong minutes { get; }
        public uint seconds{ get; }
        public uint milliseconds { get; }
        public char timeZoneSign { get; }
        public string timeZone { get; }
        public string Encode()
        {
            string[] temp = timeZone.Split(':');
            uint zoneHour = uint.Parse(temp[0]);
            uint zoneMin = uint.Parse(temp[1]);
            uint zoneSign = 0;
            if (timeZoneSign == '+')
            {
                zoneSign = 2048;
            }
            ulong final = (year << 48) | (month << 44) | (day << 39) | (hour << 34) | (minutes << 28) | (seconds << 22) | (milliseconds << 12) | zoneSign | (zoneHour << 6) | zoneMin;
            return final.ToString();
        }

        public DateTime(string line)
        {
            string[] temp = line.Split('T');
            uint[] date = Date(temp[0]);
            year = date[0];
            month = date[1];
            day = date[2];
            char[] refer = { '+', '-' };
            string[] fullTime = temp[1].Split(refer);
            uint[] time = Time(fullTime[0]);
            hour = time[0];
            minutes = time[1];
            seconds = time[2];
            milliseconds = time[3];
            if (temp[1].Contains('+'))
            {
                timeZoneSign = '+';
            }
            else
            {
                timeZoneSign = '-';
            }
            timeZone = fullTime[1];
        }
        public static uint[] Date(string input)
        {
            uint[] fragm = new uint[3];
            string[] fullDate = input.Split("-");
            for (int i = 0; i < fullDate.Length; i++)
            {
                fragm[i] = uint.Parse(fullDate[i]);
            }
            return fragm;
        }
        public static uint[] Time(string input)
        {
            uint[] fragm = new uint[4];
            char[] refer = { ':', '.' };
            string[] fullTime = input.Split(refer);
            for (int i = 0; i < fullTime.Length; i++)
            {
                fragm[i] = uint.Parse(fullTime[i]);
            }
            return fragm;
        }
    }
}
