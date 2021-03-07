using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MyOperations.BAL;
using MyOperations.DAL;
using MyOperations;
using System.IO;

namespace RentSystem.admin
{
    public partial class CameraDocument : System.Web.UI.Page
    {

        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompanyBind();
                GetCameraDocumentData(1);
            }
        }

        protected void CompanyBind()
        {
            DataSet comdataset = new DataSet();
            comdataset = SqlHelper.ExecuteDataset(connection, "Company_Get_SP");
            if (comdataset.Tables[0].Rows.Count > 0)
            {
                ddlcompany.DataSource = comdataset.Tables[0];
                ddlcompany.DataTextField = "CompanyName";
                ddlcompany.DataValueField = "CompanyId";
                ddlcompany.DataBind();
                ddlcompany.Items.Insert(0, "-Select Company-");
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (hidcardocid.Value != "")
            {
                //long companyid = Convert.ToInt64(ddlcompany.SelectedValue);
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "CamearDocument_CheckDuplicate_SP", txtdocumentname.Text, companyid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{


                    string fname;
                    string CameraDocumentImage = " ";


                    Bal_CameraDocument b1 = new Bal_CameraDocument();
                    Dal_CameraDocument d1 = new Dal_CameraDocument();
                    b1.companyId = Convert.ToInt64(ddlcompany.SelectedValue);
                    b1.DocumentName = txtdocumentname.Text;
                    b1.DocumentId = Convert.ToInt64(hidcardocid.Value);
                    string oldimagefile = @"H:\ASP\RentSystem\RentSystem\admin\CameraDocument_Img\" + hidImageName.Value;
                    if (File.Exists(oldimagefile))
                    {
                        File.Delete(oldimagefile);
                    }


                    fname = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss")).Replace("-", "").Replace(" ", "");
                    if (fpCameraDocumentImages.HasFile)
                    {
                        fpCameraDocumentImages.SaveAs(Server.MapPath("~/admin/CameraDocument_Img/" + fname + ".jpg"));
                        CameraDocumentImage = fname + ".jpg";
                    }
                    b1.Image = CameraDocumentImage;
                    d1.FunUpdateData(b1);
                
            }
            else
            {
                //long companyid = Convert.ToInt64(ddlcompany.SelectedValue);
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "CamearDocument_CheckDuplicate_SP", txtdocumentname.Text, companyid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{
                     string fname;
                    string CameraDocumentImage = " ";


                    Bal_CameraDocument b1 = new Bal_CameraDocument();
                    Dal_CameraDocument d1 = new Dal_CameraDocument();
                    b1.companyId = Convert.ToInt64(ddlcompany.SelectedValue);
                    b1.DocumentName = txtdocumentname.Text;

                    fname = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss")).Replace("-", "").Replace(" ", "");
                    if (fpCameraDocumentImages.HasFile)
                    {
                        fpCameraDocumentImages.SaveAs(Server.MapPath("~/admin/CameraDocument_Img/" + fname + ".jpg"));
                        CameraDocumentImage = fname + ".jpg";
                    }
                    b1.Image = CameraDocumentImage;
                    d1.FunInsertCameraDocument(b1);
                }
                GetCameraDocumentData(1);
                cleardata();

            
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_CameraDocument d1 = new Dal_CameraDocument();
            DataSet comdataset = new DataSet();
            comdataset = d1.FunSearchByDocName(Tsearch.Text);
            if (comdataset.Tables[0].Rows.Count > 0)
            {
             rptinfoCameraDocument.DataSource = comdataset.Tables[0];
                rptinfoCameraDocument.DataBind();

            }
            else
            {
                GetCameraDocumentData(1);
                cleardata();
            }
        }
        protected void cleardata()
        {
            ddlcompany.SelectedIndex = 0;
            txtdocumentname.Text = "";
            hidcardocid.Value = "";
            hidImageName.Value = "";
        }
        protected void rptinfoCameraDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hidcardocid.Value = Convert.ToString(e.CommandArgument);
                    CarDocUpdate(hidcardocid.Value);
                    GetCameraDocumentData(1);
                    break;
                case "status":
                    Dal_CameraDocument d1 = new Dal_CameraDocument();
                    long cid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(cid);
                    GetCameraDocumentData(1);
                    break;

            }
        }

        protected void CarDocUpdate(string cdid1)
        {
            try
            {
                long cdid = Convert.ToInt64(cdid1);
                Dal_CameraDocument d1 = new Dal_CameraDocument();
                DataSet CDSet = new DataSet();
                CDSet = d1.CameraDocGetRecored(cdid);
                if (CDSet != null)
                {
                    foreach (DataRow Dr in CDSet.Tables[0].Rows)
                    {
                        ddlcompany.SelectedValue = Convert.ToString(Dr["CompanyId"]);
                        txtdocumentname.Text = Convert.ToString(Dr["DocumentName"]);
                        hidImageName.Value = Convert.ToString(Dr["Image"]);
                    }

                }
                else
                {
                    throw new Exception("Recored Not Found.....!");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        
        #region pageing
        protected void GetCameraDocumentData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet companydataset = new DataSet();
                companydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
                Bal_CameraDocument b1 = new Bal_CameraDocument();
                Dal_CameraDocument d1 = new Dal_CameraDocument();
                b1.DocumentId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = Tsearch.Text.Trim();
                DataSet comDataset = d1.CompanyDocumentMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptinfoCameraDocument.DataSource = comDataset.Tables[0];
                        rptinfoCameraDocument.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptinfoCameraDocument.DataSource = null;
                    rptinfoCameraDocument.DataBind();
                }
            }
            catch (Exception ex)
            {
                ltrMsg.Text = ex.Message;
            }
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            List<ListItem> pages = new List<ListItem>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(cboPageSize.SelectedValue));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("First", "1"));
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("Last", pageCount.ToString()));
            }

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptinfoCameraDocument.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCameraDocumentData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetCameraDocumentData(pageIndex);
        }
        #endregion

    }
}