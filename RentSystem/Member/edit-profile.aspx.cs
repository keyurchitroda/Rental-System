using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations;
using MyOperations.BAL;
using MyOperations.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RentSystem.Member
{
    public partial class edit_profile : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getUserInfo();
            }
        }
        protected void getUserInfo()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connection, "User_EditProfile_Get", Session["EmailId"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                txtFirst.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLast.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmailId.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtadd.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtBirthDate.Text = ds.Tables[0].Rows[0]["Birthdate"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            {
                Bal_editprofile b1 = new Bal_editprofile();
                Dal_editprofile d1 = new Dal_editprofile();
                b1.Emailid = Session["EmailId"].ToString();
                b1.Firstname = txtFirst.Text.Trim();
                b1.Lastname = txtLast.Text.Trim();
                b1.Mobile = txtMobile.Text.Trim();
                b1.address = txtadd.Text.Trim();
                b1.Birthdate = txtBirthDate.Text.Trim();
                d1.funupdateEditprofile(b1);
                cleardata();

            }
           
        }

        protected void cleardata()
        {
            txtFirst.Text = "";
            txtLast.Text = "";
            txtMobile.Text = "";
            txtadd.Text = "";
            txtBirthDate.Text = "";
            txtEmailId.Text = "";

        }
    }
}