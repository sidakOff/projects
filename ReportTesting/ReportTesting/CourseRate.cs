using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportTesting
{
    public class CourseRate
    {
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyId { get; set; }
        public decimal Rate { get; set; }
    }
}

