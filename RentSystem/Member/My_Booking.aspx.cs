using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOperations;
using MyOperations.BAL;
using MyOperations.DAL;



namespace RentSystem.Member
{
    public partial class My_Booking : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getBookingData();
        }
        protected void getBookingData()
        {
          
                
                DataSet mydataset = new DataSet();
                mydataset = SqlHelper.ExecuteDataset(connection, "Booking_getData_SP", Session["EmailId"].ToString());
                if (mydataset.Tables[0].Rows.Count>0)
                {
                    rptBooking.DataSource = mydataset.Tables[0];
                    rptBooking.DataBind();
                }
                else
                {
                    rptBooking.DataSource = null;
                    rptBooking.DataBind();
                }
          
        }
    }
}