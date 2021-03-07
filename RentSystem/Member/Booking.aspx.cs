using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOperations;
using MyOperations.BAL;
using MyOperations.DAL;



namespace RentSystem.Member
{
    public partial class Booking : System.Web.UI.Page
    {
        String connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            long Id = Convert.ToInt64(Request["cid"]);
            //string cname = Convert.ToString(Request["CName"]);

            if (!IsPostBack)
            {
                if (Id > 0)
                {
                    getCarData();
                }
            }
        }

        protected void getCarData()
        {
            try
            {
                long cid = Convert.ToInt64(Request["CatId"]);
                DataSet mydataset = new DataSet();
                mydataset = SqlHelper.ExecuteDataset(connection, "Booking_Get_Names", Session["EmailId"], cid);
                if (mydataset != null)
                {
                    foreach (DataRow Dr in mydataset.Tables[0].Rows)
                    {
                        UserName.Text = Convert.ToString(Dr["Name"]);
                        CName.Text = Convert.ToString(Dr["CatName"]);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
        
            Bal_Booking b1 = new Bal_Booking();
            Dal_Booking d1 = new Dal_Booking();
            b1.userid = Session["EmailId"].ToString();
            b1.catid = Convert.ToInt64(Request["cid"]);
            b1.catname = CName.Text;
            b1.startdate = txtstartdate.Text;
            b1.enddate = txtenddate.Text;
            b1.depamount = Convert.ToDecimal(txtdepamount.Text);
            long BookingId = d1.funInsertBooking(b1);

            Bal_payment B1 = new Bal_payment();
            Dal_Payment D1 = new Dal_Payment();
            B1.bookingid = BookingId;
            B1.cardno = txtcardno1.Text + txtcardno2.Text + txtcardno3.Text + txtcardno4.Text;
            B1.expirydate = ddlmonth.SelectedItem.Text +""+ ddlyear.SelectedItem.Text;
            B1.cvv = Convert.ToInt32(txtcvv.Text);
            B1.cardowner = txtcardowner.Text;


            //  Dal_Booking d1 = new Dal_Booking();
            D1.funInsertPayment(B1);
            lblMsg.Text = CommanFunction.Alert_MessageBox("Succefully Booking");
            lblMsg.Visible = true;
            cleardata();
        
        }


        protected void cleardata()
        {
            UserName.Text = "";
            CName.Text = "";
            txtstartdate.Text = "";
            txtenddate.Text = "";
            txtcardno1.Text = "";
            txtcardno2.Text = "";
            txtcardno3.Text = "";
            txtcardno4.Text = "";
            ddlmonth.Text = "";
            ddlyear.Text = "";
            txtcvv.Text = "";
            txtcardowner.Text = "";

        
        }
    }
}