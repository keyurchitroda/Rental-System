using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
    public class Bal_Housedocument
    {
        public long Did { get; set; }
        public long Hid { get; set; }
        public long houseid { get; set; }
        public string DocumentType { get; set; }
        public string HImage { get; set; }
        public int status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
