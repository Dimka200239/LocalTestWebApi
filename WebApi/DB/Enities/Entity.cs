using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.Enities
{
    public class Entity
    {
        public double price { get; set; }

        public DateTime time { get; set; }

        public void SetLocalTime()
        {
            time = time.ToLocalTime();
        }
    }
}
