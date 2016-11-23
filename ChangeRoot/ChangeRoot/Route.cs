using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeRoot
{
    public class Route
    {
        public int RouteId { get; set; }

        [DisplayName("RouteName")]
        public string RouteName { get; set; }
    }
}
