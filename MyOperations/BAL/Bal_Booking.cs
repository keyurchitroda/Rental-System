using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
   public class Bal_Booking
    {
       public long bookingid { get; set; }
        public string userid { get; set; }
        public long catid { get; set; }
        public string catname { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string qty { get; set;}
        public string cardno { get; set; }
        public string expirydate { get; set; }
        public int cvv { get; set; }
        public string cardowner { get; set; }
        public string paymentdate { get; set; }
        public decimal depamount { get; set; }

    }
}
