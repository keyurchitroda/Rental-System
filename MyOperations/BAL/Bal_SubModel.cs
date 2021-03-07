using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
    public class Bal_SubModel
    { 
        public long submid { get; set; }
        public string submname { get; set; }
        public string comid { get; set; }
        public string mid { get; set; }
        public int status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
}
