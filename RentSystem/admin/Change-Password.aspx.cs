using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations;
using MyOperations.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace RentSystem.admin
{
    public partial class Change_Password : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = Session["UserId"].ToString();
            Response.Write(userid);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int chek;
            chek = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Admin_get_LoginId_by_session_SP", userid));
            if (chek > 0)
            {
                SqlHelper.ExecuteNonQuery(connection, "Admin_Change_Password_SP", userid, txtNewPass.Text, txtOldPass.Text);
            }

        }
    }
}