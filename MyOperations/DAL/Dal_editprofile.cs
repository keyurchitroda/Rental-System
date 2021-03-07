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
using MyOperations;

namespace MyOperations.DAL
{


    public class Dal_editprofile
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public long funupdateEditprofile(Bal_editprofile b1)
        {
           return Convert.ToInt64(SqlHelper.ExecuteScalar(connection, "User_editProfile_Update_SP", b1.Emailid, b1.Firstname, b1.Lastname, b1.Mobile, b1.address, b1.Birthdate));
        }

       
    }
}
