using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using MyOperations.BAL;

namespace MyOperations.DAL
{
    public class Dal_Booking
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public long funInsertBooking(Bal_Booking b1)
        {
           return Convert.ToInt64(SqlHelper.ExecuteScalar(connection, "Booking_Car_insert_sp",
             b1.userid,b1.catid,b1.catname,b1.startdate,b1.enddate,b1.depamount));
        }
    }
}
