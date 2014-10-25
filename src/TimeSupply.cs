using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROtracker.Extension;

namespace ROtracker
{
    public class TimeSupply
    {
        private DBConnector Database;

        public TimeSupply()
        {
            Database = new DBConnector();
        }
    }
}
