using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
   public class Bal_Area
    {
        public long AreaId { get; set; }
        public string StateId { get; set; }
        public string CityId { get; set; }
        public string AreaName { get; set; }
        public int Status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
