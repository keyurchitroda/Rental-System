using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
    public class Bal_camera
    {
       public long cameraId { get; set; }
        public long companyId { get; set; }
        public long modelId { get; set; }
        public long submodelId { get; set; }
        public long rentTypeId { get; set; }
        public string owner { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public int status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
}
