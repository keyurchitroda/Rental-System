using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
   public  class Bal_payment
    {
        public long bookingid { get; set; }
        public string cardno { get; set; }
        public string expirydate { get; set; }
        public int cvv { get; set; }
        public string cardowner { get; set; }
      
    }
}
