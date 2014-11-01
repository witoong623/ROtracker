using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROtracker.Extension
{
    public class RoundDetail
    {
        public string Name { get; private set; }
        public string Map { get; private set; }
        public double Interval { get; private set; }
        public int[] Cordinate { get; private set; }
        public DateTime DeadTime { get; private set; }
        public DateTime NextTime { get; private set; }
        public TimeSpan TimeRemaining { get; private set; }
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Secounds { get; private set; }

        public RoundDetail(string name, double interval, DateTime deadTime, string map, int[] cordinate)
        {
            Name = name;
            Interval = interval;
            DeadTime = deadTime;
            Map = map;
            Cordinate = cordinate;
            NextTime = DeadTime.AddMinutes(Interval);
            TimeRemaining = NextTime.Subtract(DeadTime);
            Hours = TimeRemaining.Hours;
            Minutes = TimeRemaining.Minutes;
            Secounds = TimeRemaining.Seconds;
        }
    }
}