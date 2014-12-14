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
        public Timer CountDown;
        private int NotifyCount;
        public BornStatus IsBorn { get; private set; }

        public RoundDetail (string name, string map, DateTime deadTime, int respawnInterval)
        {
            Name = name;
            Map = map;
            DeadTime = deadTime;
            RespawnInterval = respawnInterval;
            BornTime = DeadTime.AddMinutes(RespawnInterval);
            Interval = BornTime.Subtract(DeadTime);
            // countdown 15 min remaining, NotifyCount is 0
            CountDown = new Timer(Interval.Milliseconds - 900000);
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
}