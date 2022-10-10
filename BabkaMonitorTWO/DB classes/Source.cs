using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkaMonitorTWO.DB_classes
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Source(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public Source() { }
    }
}
