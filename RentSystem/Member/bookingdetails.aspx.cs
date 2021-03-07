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
    public partial class bookingdetails : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            long Id = Convert.ToInt64(Request["cid"]);
            if (!IsPostBack)
            {
                if (Id > 0)
                {
                    string Ctype = Request.QueryString["CType"];
                    if (Ctype == "Car")
                    {
                        GetCarBookingDetailsData(Id, Ctype);
                    }
                    else if (Ctype == "House")
                    {
                        GetHouseBookingDetailsData(Id, Ctype);
                    }
                    else if (Ctype == "Camera")
                    {
                        GetCameraBookingDetailsData(Id, Ctype);
                    }
                }
            }
        }
        protected void GetCarBookingDetailsData(long Cid, string Ctype)
        {

            //long cid = Convert.ToInt64(Request["CID"]);
            //string cname = Convert.ToString(Request["CType"]);
            DataSet mydataset = new DataSet();
            mydataset = SqlHelper.ExecuteDataset(connection, "Booking_Car_Details_Get_SP", Cid, Ctype);
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                rptBookingDetails.DataSource = mydataset.Tables[0];
                rptBookingDetails.DataBind();
            }
            else
            {
                rptBookingDetails.DataSource = null;
                rptBookingDetails.DataBind();
            }


        }

        protected void GetHouseBookingDetailsData(long Cid, string Ctype)
        {

            //long cid = Convert.ToInt64(Request["CID"]);
            //string cname = Convert.ToString(Request["CType"]);
            DataSet mydataset = new DataSet();
            mydataset = SqlHelper.ExecuteDataset(connection, "Booking_House_Details_Get_SP", Cid, Ctype);
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                rptHouseBooking.DataSource = mydataset.Tables[0];
                rptHouseBooking.DataBind();
            }
            else
            {
                rptHouseBooking.DataSource = null;
                rptHouseBooking.DataBind();
            }


        }

        protected void GetCameraBookingDetailsData(long Cid, string Ctype)
        {

            //long cid = Convert.ToInt64(Request["CID"]);
            //string cname = Convert.ToString(Request["CType"]);
            DataSet mydataset = new DataSet();
            mydataset = SqlHelper.ExecuteDataset(connection, "Booking_Camera_Details_Get_SP", Cid, Ctype);
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                rptCamraBooking.DataSource = mydataset.Tables[0];
                rptCamraBooking.DataBind();
            }
            else
            {
                rptCamraBooking.DataSource = null;
                rptCamraBooking.DataBind();
            }


        }
    }
}