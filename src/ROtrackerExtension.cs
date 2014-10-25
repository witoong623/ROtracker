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
        public DateTime DeadTime { get; private set; }
        public string Map { get; private set; }
        public int[] Cordinate { get; private set; }

        public RoundDetail(string name, DateTime deadTime, string map, int[] cordinate)
        {
            Name = name;
            DeadTime = deadTime;
            Map = map;
            Cordinate = cordinate;
        }
    }
}