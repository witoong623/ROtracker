using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROtracker.src
{
    class TimeSupply
    {
        private string[] notificationString;
        private double nextTimeBorn;
        private DBConnector Database;

        public TimeSupply()
        {
            Database = new DBConnector();
        }

        public string[] NotificationString
        {
            get
            {
                return notificationString;
            }
        }

        public int NextTimeBorn
        {
            get
            {
                return (int)nextTimeBorn;
            }
        }
    }
}
