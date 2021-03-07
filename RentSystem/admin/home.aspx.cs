using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace RentSystem.admin
{
    public partial class home : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTotalbooking.Text = "(" + Convert.ToString(SqlHelper.ExecuteScalar(connection, "Admin_Get_All_Booking")) + ")";
                lblTodaybooking.Text = "(" + Convert.ToString(SqlHelper.ExecuteScalar(connection, "Admin_Get_Today_Booking")) + ")";
                lblmonthwise.Text = "(" + Convert.ToString(SqlHelper.ExecuteScalar(connection, "Admin_Get_Monthwise_Booking")) + ")";
                lbltotaluser.Text = "(" + Convert.ToString(SqlHelper.ExecuteScalar(connection, "Admin_Get_TotalUser")) + ")";
                lbltodayuser.Text = "(" + Convert.ToString(SqlHelper.ExecuteScalar(connection, "Admin_Get_ToDayUser")) + ")";
                //lblDatewise.Text = "(" + Convert.ToString(SqlHelper.ExecuteScalar(connection, "Admin_Get_Datewise_Booking")) + ")";
                lblBookingCancel.Text = "(" + Convert.ToString(SqlHelper.ExecuteScalar(connection, "Admin_Get_Booking_Cancel")) + ")";
            }
        }
    }
}