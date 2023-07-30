using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListOfClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lists = new List<ABC>();
            var addlist=new List<XYZ>();
            addlist.Add(new XYZ { Name = "1" });
            addlist.Add(new XYZ { Name = "2" });
            addlist.Add(new XYZ { Name = "3" });

            addlist[2]=new XYZ { Name = "4" };//update
        }
    }

    class XYZ
    {
        public string Name;//{ get; set; }
    }

    class ABC
    {
        public List<XYZ> list { get; set; }
    }
}
