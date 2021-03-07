using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations.DAL;
using MyOperations.BAL;
using System.Configuration;
using MyOperations;
namespace RentSystem
{
    public partial class Login : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
        }

        protected void txtUserid_TextChanged(object sender, EventArgs e)
        {
            if (txtUserid.Text == "")
            {
                txtOTP.Visible = false;
            }
            else
            {
                int check;
                int statusEmail = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Check_Email_Status", txtUserid.Text));
                if (statusEmail == 1)
                {
                    lblMsg.Visible = false;
                    check = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Email_Verifaction_status", txtUserid.Text));
                    if (check == 0)
                    {
                        txtOTP.Visible = true;
                    }
                    else
                    {
                        txtOTP.Visible = false;
                    }
                }
                else
                {
                    txtOTP.Visible = false;
                    lblMsg.Text = CommanFunction.Alert_MessageBox("User Id Not Valid.");
                    lblMsg.Visible = true;
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblMsg.Visible == false)
            {
                if (txtOTP.Visible == true)
                {
                    int checkstatus = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Check_User_OTP", txtUserid.Text, txtpass.Text, txtOTP.Text));
                    if (checkstatus == 1)
                    {
                        SqlHelper.ExecuteNonQuery(connection, "Login_Update_Email_Verification", txtUserid.Text, 1);
                        Session["EmailId"] = txtUserid.Text;
                        Response.Redirect("Member/Index.aspx");
                        lblMsg.Visible = false;
                    }
                    else
                    {
                        lblMsg1.Text = CommanFunction.Alert_MessageBox("Please Check Your OTP in your Email Id");
                        lblMsg1.Visible = true;
                    }
                }
                else
                {
                    int checkStatus = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Login_User_Data", txtUserid.Text, txtpass.Text));
                    if (checkStatus == 1)
                    {
                        lblMsg.Visible = false;
                        Session["EmailId"] = txtUserid.Text;
                        Response.Redirect("Member/Index.aspx");
                    }
                    else
                    {
                        lblMsg.Text = CommanFunction.Alert_MessageBox("Please Checkyour UserId and Password");
                        lblMsg.Visible = true;
                    }



                }
            }
        }

        protected void btnsingin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnforgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPass.aspx");
        }

        protected void btnforgot_Click1(object sender, EventArgs e)
        {

        }
    }
}