﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MyOperations;
using System.Data;
using System.Data.SqlClient;

namespace RentSystem
{
    public partial class housedetails : System.Web.UI.Page
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
            DataSet dataSet = SqlHelper.ExecuteDataset(connection, "house_Details_GET_SP_DetailsPAGE_By_Id", id);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rpthouseDetails.DataSource = dataSet.Tables[0];
                rpthouseDetails.DataBind();
            }
        }

    }
}