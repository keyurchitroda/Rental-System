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
    public class Dal_Reg
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public long FuncInsertUser(Bal_Reg  b1)
        {
            return Convert.ToInt64(SqlHelper.ExecuteScalar(con, "User_Insert_SP", b1.FirstName, b1.LastName,b1.address, b1.EmailId, b1.Password, b1.Birthdate, b1.Gender, b1.MobileNo));

        }
        public long FuncUpdateChangePass(Bal_Reg b1)
        {
            return Convert.ToInt64(SqlHelper.ExecuteScalar(con, "User_ChangePassword",  b1.EmailId, b1.Password,b1.OldPass ));

        }
    }
}
