using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
   public class Bal_SubCategory
    {
        public long scid { get; set; }
        public string cid { get; set; }
        public string scname { get; set; }
        public int status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
}
