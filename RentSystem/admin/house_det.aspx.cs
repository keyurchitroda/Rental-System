using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOperations.BAL;
using MyOperations.DAL;
using MyOperations;
using System.IO;


namespace RentSystem.admin
{
    public partial class house_det : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(Request["Id"]);
            if (!IsPostBack)
            {
                if (id > 0)
                {
                    getDetails(id);
                }
            }
        }

        protected void getDetails(long id)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(connection, "House_all_Details_Select_SP", id);
            DataSet dsImage = SqlHelper.ExecuteDataset(connection, "House_Image_Select_SP", id);
            if (dsImage.Tables[0].Rows.Count > 0)
            {
                rptImage.DataSource = dsImage.Tables[0];
                rptImage.DataBind();
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptHouseDetailsInfo.DataSource = dataSet.Tables[0];
                rptHouseDetailsInfo.DataBind();
            }
        }

    }
}