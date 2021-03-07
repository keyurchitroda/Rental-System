using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
    public class Bal_CarDocument
    {
        public long docid { get; set; }
        public long cdid { get; set; }
        public string doctype { get; set; }
        public string image { get; set; }
        public int status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
}
