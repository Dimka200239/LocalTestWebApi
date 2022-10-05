using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebConsole
{
    class Entity
    {
        public double price { get; set; }

        public DateTime time { get; set; }

        public void SetLocalTime()
        {
            time = time.ToLocalTime();
        }
    }
}
