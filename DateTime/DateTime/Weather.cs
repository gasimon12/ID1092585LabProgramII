using System;
using System.Collections.Generic;
using System.Text;

namespace DateTime
{
    public class Weather
    {
        public int MinTemp { get; }
        public int MaxTemp { get; }
        public int Precipitation { get; }

        public Weather(string minTemp, string maxTemp, string precipitation)
            => (MinTemp, MaxTemp, Precipitation) = (int.Parse(minTemp), int.Parse(maxTemp), int.Parse(precipitation));

        public string Encode()
        {
            int final = (MinTemp << 14) | (MaxTemp << 7) | Precipitation;
            return final.ToString();
        }
    }
}
