using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations;
using System.Data;
using MyOperations.DAL;
using System.Data.SqlClient;
using System.Configuration;



namespace RentSystem.admin
{
    public partial class index : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet Ds = new DataSet();
            Ds = SqlHelper.ExecuteDataset(connection, "Admin_Login_Get", txtUserId.Text, txtPassword.Text);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                Session["UserId"] = Ds.Tables[0].Rows[0]["LoginId"].ToString();
                Response.Redirect("~/admin/home.aspx");
            }

        }
    }
}