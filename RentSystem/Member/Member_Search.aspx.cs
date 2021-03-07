using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using MyOperations;
using MyOperations.BAL;
using MyOperations.DAL;
using System.Configuration;


namespace RentSystem.Member
{
    public partial class Member_Search : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string CTYPE = Request.QueryString.Get("CType").ToString();
            if (CTYPE == "car")
            {
                long CompanyId = Convert.ToInt64(Request.QueryString.Get("Company"));
                long ModelId = Convert.ToInt64(Request.QueryString.Get("Model"));
                long subModelId = Convert.ToInt64(Request.QueryString.Get("CarSubModel"));

                DataSet ds = SqlHelper.ExecuteDataset(connection, "Car_Search_All_SP", CompanyId, ModelId, subModelId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ltrMsg.Text = "";
                    rptCarData.DataSource = ds.Tables[0];
                    rptCarData.DataBind();
                }
                else
                {
                    rptCarData.DataSource = ds.Tables[0];
                    rptCarData.DataBind();
                    ltrMsg.Text = CommanFunction.Alert_MessageBox("No Recored Found");
                }
            }

            if (CTYPE == "camera")
            {
                long CompanyId = Convert.ToInt64(Request.QueryString.Get("Company"));
                long ModelId = Convert.ToInt64(Request.QueryString.Get("Model"));
                long subModelId = Convert.ToInt64(Request.QueryString.Get("CameraSubModel"));

                DataSet ds = SqlHelper.ExecuteDataset(connection, "Camera_Search_All_SP", CompanyId, ModelId,subModelId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ltrMsg.Text = "";
                    rptCameraData.DataSource = ds.Tables[0];
                    rptCameraData.DataBind();
                }
                else
                {
                    rptCameraData.DataSource = ds.Tables[0];
                    rptCameraData.DataBind();
                    ltrMsg.Text = CommanFunction.Alert_MessageBox("No Recored Found");
                }
            }

            if (CTYPE == "house")
            {
                long StateId = Convert.ToInt64(Request.QueryString.Get("State"));
                long CityId = Convert.ToInt64(Request.QueryString.Get("City"));
                long AreaId = Convert.ToInt64(Request.QueryString.Get("Area"));
                long HouseTypeId = Convert.ToInt64(Request.QueryString.Get("HouseType"));

                DataSet ds = SqlHelper.ExecuteDataset(connection, "House_Search_All_SP", StateId, CityId, AreaId, HouseTypeId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ltrMsg.Text = "";
                    RptHouseData.DataSource = ds.Tables[0];
                    RptHouseData.DataBind();
                }
                else
                {
                    RptHouseData.DataSource = ds.Tables[0];
                    RptHouseData.DataBind();
                    ltrMsg.Text = CommanFunction.Alert_MessageBox("No Recored Found");
                }
            }

        }
    }
}
