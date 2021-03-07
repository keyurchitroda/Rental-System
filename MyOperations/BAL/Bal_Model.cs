using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
    public class Bal_Model
    {
        public long modid { get; set; }
        public string mname { get; set; }
        public string comid { get; set; }
        public int status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
