using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkaMonitorTWO.DB_classes
{
    public class Emission
    {
        public int Id { get; set; }
        public Source Source { get; set; }
        public string? Count { get; set; }
        public string? Text { get; set; }
        public DateTime? Date { get; set; }
    }
}
