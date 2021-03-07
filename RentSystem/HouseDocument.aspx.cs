using MyOperations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentSystem
{
    public partial class HouseDocument : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(Request["cid"]);
            if (!IsPostBack)
            {
                if (id > 0)
                {
                    getDocument(id);
                }
            }
        }
        protected void getDocument(long id)
        {
            DataSet dataDoc = SqlHelper.ExecuteDataset(connection, "HouseDoc_Select_SP", id);
            if (dataDoc.Tables[0].Rows.Count > 0)
            {
                rptDoc.DataSource = dataDoc.Tables[0];
                rptDoc.DataBind();
            }
        }
    }
}