using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MyOperations.DAL;
using MyOperations.BAL;
using MyOperations;
using System.Data;

namespace RentSystem
{
    public partial class Details : System.Web.UI.Page
    {
        String connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            long Id = Convert.ToInt64(Request["CId"]);
            string cname = Convert.ToString(Request["CName"]);

            if (!IsPostBack)
            {
                if (cname == "Car")
                {
                    getCarData(Id);
                }
                else if (cname == "House")
                {
                    getHouseData(Id);
                }
                else if (cname == "Camera")
                {
                    getCameraData(Id);
                }
            }
        }
        protected void getCarData(long catid)
        {
            DataSet DsCar = SqlHelper.ExecuteDataset(connection, "Car_Details_GET_SP_DetailsPAGE");
            rptCarData.DataSource = DsCar.Tables[0];
            rptCarData.DataBind();
            rptCameraData.Visible = false;
            RptHouseData.Visible = false;
        }
        protected void getHouseData(long houseid)
        {
            DataSet DsHouse = SqlHelper.ExecuteDataset(connection, "House_Details_GET_SP_DetailsPAGE");
            RptHouseData.DataSource = DsHouse.Tables[0];
            RptHouseData.DataBind();
            rptCarData.Visible = false;
            rptCameraData.Visible = false;
        }
        protected void getCameraData(long cameraid)
        {
            DataSet DsCamera = SqlHelper.ExecuteDataset(connection, "Camera_Details_GET_SP_DetailsPAGE");
            rptCameraData.DataSource = DsCamera.Tables[0];
            rptCameraData.DataBind();
            rptCarData.Visible = false;
            RptHouseData.Visible = false;
        }
    }
}

