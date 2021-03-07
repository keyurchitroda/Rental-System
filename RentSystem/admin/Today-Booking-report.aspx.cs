using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MyOperations;


namespace RentSystem.admin
{
    public partial class Today_Booking_report : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetReportData();
            }

        }
        protected void GetReportData()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connection, "Today_Booking_SP");
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptreport.DataSource = ds.Tables[0];
                rptreport.DataBind();
            }
        }

    }
}