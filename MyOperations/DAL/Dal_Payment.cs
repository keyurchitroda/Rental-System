using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MyOperations.BAL;

namespace MyOperations.DAL
{
    public class Dal_Payment
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void funInsertPayment(Bal_payment b1)
        {
            SqlHelper.ExecuteScalar(connection, "Payment_insert_sp",
             b1.bookingid, b1.cardno, b1.expirydate, b1.cvv, b1.cardowner);
        }
    }
}
