using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSST.ROADM;

namespace RoademMiodMalina
{
    class Program
    {
        static void Main(string[] args)
        {
            var roadm = new ROADM();
            var t = roadm.Initialize("./config.xml", "192.168.0.17", 5555);
            t.Wait();
            roadm.Send();
        }
    }
}
