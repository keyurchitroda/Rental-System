using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations.DAL;
using MyOperations;
using System.Configuration;

namespace RentSystem.Member
{
    public partial class bookingcancel : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                txtamount.Text = Request.QueryString["amount"].ToString();
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            long bid = Convert.ToInt64(Request.QueryString["bid"].ToString());
            SqlHelper.ExecuteNonQuery(connection, "BookingCancel_insert_SP", bid, txtbankname.Text, txtIFSCcode.Text, txtholdername.Text, txtaccountNo.Text);
            SqlHelper.ExecuteNonQuery(connection, "BookingCancel_Status_Update_SP", bid);
            cleardata();

        }

        protected void cleardata()
        {
            txtbankname.Text = "";
            txtholdername.Text = "";
            txtIFSCcode.Text = "";
            txtaccountNo.Text = "";
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("My_Booking.aspx");
        }
    }
}