using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROtracker.Extension
{
    public enum BornStatus { Already, NotYet }

    public class RoundDetail
    {
        public string Name { get; private set; }
        public string Map { get; private set; }
        public double Interval { get; private set; }
        public int[] Cordinate { get; private set; }
        public DateTime DeadTime { get; private set; }
        public DateTime NextTime { get; private set; }
        public TimeSpan TimeRemaining { get; private set; }
        public int HrRemaining { get; private set; }
        public int MinRemaining { get; private set; }
        public int SecRemaining { get; private set; }
        public BornStatus IsBorn { get; private set; }

        public RoundDetail(string name, double interval, DateTime deadTime, string map, int[] cordinate)
        {
            Name = name;
            Interval = interval;
            DeadTime = deadTime;
            Map = map;
            Cordinate = cordinate;
            NextTime = DeadTime.AddMinutes(Interval);
            TimeRemaining = NextTime.Subtract(DeadTime);
            HrRemaining = TimeRemaining.Hours;
            MinRemaining = TimeRemaining.Minutes;
            SecRemaining = TimeRemaining.Seconds;
            IsBorn = BornStatus.NotYet;
        }

        public void Countdown()
        {
            if (HrRemaining > 0)
            {
                MinRemaining--;
                if (MinRemaining == 0)
                {
                    HrRemaining--;
                }
            }
            else if (MinRemaining > 0)
            {
                MinRemaining--;
            }
            else
            {
                SecRemaining--;
                if (SecRemaining == 0)
                {
                    IsBorn = BornStatus.Already;
                }
            }
        }
    }
}