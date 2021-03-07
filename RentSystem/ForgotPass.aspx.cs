using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MyOperations;
using MyOperations.DAL;
using System.Configuration;

namespace RentSystem
{
    public partial class ForgotPass : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Pass =Convert.ToString(SqlHelper.ExecuteScalar(connection, "Forgot_Password_Get_SP", txtEmailid.Text));
            if(Pass!="")
            {
                CommanFunction.SendEmail(txtEmailid.Text, "getPass", Pass);
                lblMsg.Text=CommanFunction.Success_MessageBox("Password Sent Your Email Id...");
                txtEmailid.Text = "";
            }
            else
            {
                lblMsg.Text = CommanFunction.Success_MessageBox("Please Contact to Administrator.");
            }

        }
    }
}