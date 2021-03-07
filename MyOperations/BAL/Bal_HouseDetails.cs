using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
    public class Bal_HouseDetails
    {
        public long HouseId { get; set; }
        public string HouseNo { get; set; }
        public string HouseOwner { get; set; }
        public string HouseAddress { get; set; }
        public string MobileNo { get; set; }
        public long StateId { get; set; }
        public long CityId { get; set; }
        public long AreaId { get; set; }
        public string HImage { get; set; }
        public long HouseTypeId { get; set; }
        public int Status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
