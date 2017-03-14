using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologTest
{
    public class Test
    {
        public int TestSimple()
        {
            string binDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin");

            var obj = new LogicServer();
            obj.Init("");
            obj.Load(Path.Combine(binDir, "family.xpl"));
            obj.ExecStr("assert(house(1)).");

            var t = obj.ExecStr("house(1).");
            return Convert.ToInt32(t);
        }
    }
}
