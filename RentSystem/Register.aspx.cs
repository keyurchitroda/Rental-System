using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations.DAL;
using MyOperations.BAL;
using System.Data;
using System.Configuration;
using MyOperations;
namespace RentSystem
{
    public partial class Register : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtVerificationCode.Text.ToLower() == Session["CaptchaVerify"].ToString())
            {
                Dal_Reg d1 = new Dal_Reg();
                Bal_Reg b1 = new Bal_Reg();

                b1.FirstName = txtfname.Text.Trim();
                b1.LastName = txtlname.Text.Trim();
                b1.address = txtaddress.Text.Trim();
                b1.EmailId = txtemail.Text.Trim();
                b1.Password = txtpass.Text.Trim();
                b1.Birthdate = txtBirthdate.Text.Trim();
                b1.Gender = ddlGender.SelectedValue.ToString();
                b1.MobileNo = txtmob.Text.Trim();

                int checkDuplicate = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Check_Email_Status", txtemail.Text));
                if (checkDuplicate == 1)
                {
                     ltrMsg.Text = CommanFunction.Alert_MessageBox("User Already Exits...");
                }
                else
                {
                    long UserID = d1.FuncInsertUser(b1);

                    string OTP = CommanFunction.GenerateCode(5);

                    Bal_Login BL = new Bal_Login();
                    Dal_Login DL = new Dal_Login();
                    BL.UserId = UserID;
                    BL.EmailID = txtemail.Text.Trim();
                    BL.Password = txtpass.Text.Trim();
                    BL.OTP = OTP;
                    DL.FuncLoginInsert(BL);

                    CommanFunction.SendEmail(txtemail.Text, "EMAIL_VARIFICATION", OTP);
                    Response.Redirect("reg-result.aspx?EID=" + txtemail.Text);
                }
                cleardata();
            }
            else
            {
                lblCaptchaMessage.Text = "Please enter correct captcha !";
                lblCaptchaMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void cleardata()
        {
            txtfname.Text = "";
            txtlname.Text = "";
            txtmob.Text = "";
            txtpass.Text = "";
            txtcompass.Text = "";
            txtemail.Text = "";
            ddlGender.SelectedIndex = 0;
            txtBirthdate.Text = "";
            txtaddress.Text = "";

        }

    }



}