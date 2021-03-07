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
using MyOperations.DAL;

namespace RentSystem.admin
{
    public partial class Monthwise_Booking_report : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        protected void GetReportData()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connection, "Monthwise_Booking_SP");
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptreport.DataSource = ds.Tables[0];
                rptreport.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           DataSet ds=SqlHelper.ExecuteDataset(connection, "Monthwise_Report", Convert.ToInt32(ddlmonth.SelectedValue.ToString()));
            if(ds.Tables[0].Rows.Count>0)
            {
                ltrMsg.Visible = false;
                rptreport.DataSource = ds.Tables[0];
                rptreport.DataBind();
            }
            else
            {
                ltrMsg.Visible = true;
                ltrMsg.Text = CommanFunction.Alert_MessageBox("No Recored Found.");
                rptreport.DataSource = null;
                rptreport.DataBind();
            }
        }
    }
}