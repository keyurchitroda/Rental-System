using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.BAL
{
   public class Bal_Login
    {
        public long UserId { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
    }
}
