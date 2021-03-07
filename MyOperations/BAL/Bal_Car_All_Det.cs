using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
    public class Bal_Car_All_Det
    {
        public long companyid { get; set; }
        public long modelId { get; set; }
        public long submodelId { get; set; }
        public string carregno { get; set; }
        public long stateid { get; set; }
        public long cityid { get; set; }
        public string coadd { get; set; }
        public decimal price { get; set; }
        public long renttypeid { get; set; }

    }
}
