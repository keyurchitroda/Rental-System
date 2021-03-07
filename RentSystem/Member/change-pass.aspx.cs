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
namespace RentSystem.Member
{
    public partial class change_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Bal_Reg b1 = new Bal_Reg();
            Dal_Reg d1 = new Dal_Reg();
            b1.EmailId = Session["EmailId"].ToString();
            b1.Password = txtPass.Text.Trim();
            b1.OldPass = txtOldPass.Text.Trim();
            int cnt = Convert.ToInt32(d1.FuncUpdateChangePass(b1));
            if (cnt > 0)
            {
                lblMSG.Text = CommanFunction.Success_MessageBox("Change Password SucessFully.");
            }
            else
            {
                lblMSG.Text=CommanFunction.Alert_MessageBox("Your Password Not Updated.");
            }
            cleardata();

        }
        protected void cleardata()
        {
            txtPass.Text = "";
            txtOldPass.Text = "";
            txtCpass.Text = "";
        }
    }
}