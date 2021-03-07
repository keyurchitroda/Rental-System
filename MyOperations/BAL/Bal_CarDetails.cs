using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
   public class Bal_CarDetails
    {
        public long cdid { get; set; }
        public long sid { get; set; }
        public long cid { get; set; }
        public long comid { get; set; }
        public long modid { get; set; }
        public long submid { get; set; }
        public string cno { get; set; }
        public string cregno { get; set; }
        public string cowner { get; set; }
        public string comobile { get; set; }
        public string coadd { get; set; }
        public decimal price { get; set; }
        public string cimage { get; set; }
        public int status { get; set; }
        public long renttypeid { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
}
