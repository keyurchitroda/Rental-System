using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOperations.BAL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MyOperations;


namespace MyOperations.DAL
{
    public class Dal_Login
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FuncLoginInsert(Bal_Login b1)
        {
            SqlHelper.ExecuteScalar(con, "Login_Insert_SP", b1.UserId, b1.EmailID, b1.Password, b1.OTP);

        }
    }
}
