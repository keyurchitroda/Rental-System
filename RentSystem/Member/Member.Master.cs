using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MyOperations;

namespace RentSystem.Member
{
    
    public partial class Member : System.Web.UI.MasterPage
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["EmailId"] == null)
                    {

                        Response.Redirect("~/login.aspx");
                    }
                    else
                    {
                        lblmsg.Text = Session["EmailId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/login.aspx");
            }
            getCategory();
        }
        protected void getCategory()
        {
            DataSet DSCategory = SqlHelper.ExecuteDataset(connection, "Category_Select_SP");
            if (DSCategory.Tables[0].Rows.Count > 0)
            {
                rptCategory.DataSource = DSCategory.Tables[0];
                rptCategory.DataBind();
            }
            else
            {
                rptCategory.DataSource = null;
                rptCategory.DataBind();
            }
        }
    }
}