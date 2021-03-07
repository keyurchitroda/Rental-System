using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
   public class Bal_HouseType
    {
        public long HouseTypeId { get; set; }
        public string HouseType { get; set; }
        public string rentTypeId { get; set; }
        public decimal Price { get; set; }
        public string Himage { get; set; }
        public int status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
