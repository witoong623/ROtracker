using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace ROtracker.Extension
{
    public enum BornStatus { Already, NotYet }

    public class RoundDetail
    {
        public string Name { get; private set; }
        public string Map { get; private set; }
        public int RespawnInterval;
        private TimeSpan Interval;
        private DateTime DeadTime;
        private DateTime BornTime;
        public RoundTimer CountDown;
        private int NotifyCount;
        public BornStatus IsBorn { get; private set; }

        public RoundDetail (string name, string map, DateTime deadTime, int respawnInterval, int order)
        {
            Name = name;
            Map = map;
            DeadTime = deadTime;
            RespawnInterval = respawnInterval;
            BornTime = DeadTime.AddMinutes(RespawnInterval);
            Interval = BornTime.Subtract(DeadTime);
            // countdown 15 min remaining, NotifyCount is 0
            CountDown = new RoundTimer(Interval.Milliseconds - 900000, order);
            CountDown.Start();
            CountDown.Elapsed += new ElapsedEventHandler(NotifyClient);
        }

        private void NotifyClient(object sender, ElapsedEventArgs e)
        {
            NotifyCount++;

            if (NotifyCount == 1)
            {
                // 5 min remaining, NotifyCount is 1
                CountDown.Interval = 600000;
            }
            else if (NotifyCount == 2)
            {
                // 1 min remaining, NotifyCount is 2
                CountDown.Interval = 240000;
            }
            else if (NotifyCount == 3)
            {
                // boss will born in 1 min, NotifyCount is 3
                CountDown.Interval = 60000;

            }
            else
            {
                // End countdown
                CountDown.Stop();
                IsBorn = BornStatus.Already;
            }
        }
    }

    public class RoundTimer : Timer
    {
        public int Order { get; private set; }

        public RoundTimer(double interval, int order) : base(interval)
        {
            Order = order;
        }
    }
}