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
        public double? Count { get; set; }
        public string? Text { get; set; }
        public DateTime? Date { get; set; }
        public Emission(Source _source, float _count, string _text, DateTime date)
        {
            Source = _source;
            Count = _count;
            Text = _text;
            Date = date;
        }
        public Emission()
        {

        }
    }
}
