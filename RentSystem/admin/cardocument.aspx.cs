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
    public partial class cardocument : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarBind();
                ddlcardoc.Items.Insert(0, "-Select Document-");
                GetCarDocumentData(1);
            }
        }

        protected void CarBind()
        {
            DataSet cardataset = new DataSet();
            cardataset = SqlHelper.ExecuteDataset(connection, "Car_Get_SP");
            if (cardataset.Tables[0].Rows.Count > 0)
            {
                ddlCarNo.DataSource = cardataset.Tables[0];
                ddlCarNo.DataTextField = "CarNo";
                ddlCarNo.DataValueField = "CarDetailsId";
                ddlCarNo.DataBind();
                ddlCarNo.Items.Insert(0, "-Select CarNo-");
            }
        }



        protected void btnsub_Click(object sender, EventArgs e)
        {
            if (hiddocid.Value != "")
            {
                long carid = Convert.ToInt64(ddlCarNo.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "CarDocument_CheckDuplicate_SP", ddlCarNo.SelectedValue, ddlcardoc.SelectedValue));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {
                    string fname;
                    string DocImgName = "";

                    Bal_CarDocument b1 = new Bal_CarDocument();
                    b1.docid = Convert.ToInt64(hiddocid.Value);
                    b1.doctype = ddlcardoc.SelectedValue; ;
                    b1.cdid = Convert.ToInt64(ddlCarNo.SelectedValue);
                    string oldimagefile = @"H:\ASP\RentSystem\RentSystem\admin\CarDoc_Img\" + hidImageName.Value;
                    if (File.Exists(oldimagefile))
                    {
                        File.Delete(oldimagefile);
                    }

                    Dal_CarDocument d1 = new Dal_CarDocument();
                    fname = Convert.ToString(System.DateTime.Now.ToString("dd-MM-yyyy hh mm ss")).Replace("-", "").Replace(" ", "");
                    if (fpDocumentImages.HasFile)
                    {
                        fpDocumentImages.SaveAs(Server.MapPath("~/admin/CarDoc_Img/" + fname + ".jpg"));
                        DocImgName = fname + ".jpg";
                    }
                    b1.image = DocImgName;
                    d1.FunUpdateData(b1);
                }
            }
            else
            {
                {
                    long carid = Convert.ToInt64(ddlCarNo.SelectedValue);
                    int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "CarDocument_CheckDuplicate_SP", ddlCarNo.SelectedValue, ddlcardoc.SelectedValue));
                    if (cnt > 0)
                    {
                        lblduplicate.Visible = false;
                        lblduplicate.Visible = true;
                    }
                    else
                    {

                        string fname;
                        string DocImgName = "";

                        Bal_CarDocument b1 = new Bal_CarDocument();
                        b1.doctype = ddlcardoc.SelectedValue; ;
                        b1.cdid = Convert.ToInt64(ddlCarNo.SelectedValue);
                        Dal_CarDocument d1 = new Dal_CarDocument();

                        fname = Convert.ToString(System.DateTime.Now.ToString("dd-MM-yyyy hh mm ss")).Replace("-", "").Replace(" ", "");
                        if (fpDocumentImages.HasFile)
                        {
                            fpDocumentImages.SaveAs(Server.MapPath("~/admin/CarDoc_Img/" + fname + ".jpg"));
                            DocImgName = fname + ".jpg";
                        }
                        b1.image = DocImgName;
                        d1.FunInsertData(b1);
                    }

                    GetCarDocumentData(1);
                    cleardata();
                }
            }
        }

        protected void cleardata()
        {
            ddlCarNo.SelectedIndex = 0;
            ddlcardoc.SelectedIndex = 0;
            txtsearch.Text = "";
            hiddocid.Value = "";
            hidImageName.Value = "";
        }
        //protected void GetCarDocumentData()
        //{
        //    try
        //    {
        //        Dal_CarDocument d1 = new Dal_CarDocument();
        //        DataSet docset = new DataSet();
        //        docset = d1.FunUserData();
        //        if (docset != null)
        //        {
        //            rptCarDocInfo.DataSource = docset.Tables[0];
        //            rptCarDocInfo.DataBind();
        //        }
        //        else
        //        {
        //            rptCarDocInfo.DataSource = null;
        //            rptCarDocInfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        protected void CarDocUpdate(string docid1)
        {
            try
            {
                long docid = Convert.ToInt64(docid1);
                Dal_CarDocument d1 = new Dal_CarDocument();
                DataSet docSet = new DataSet();
                docSet = d1.CarDocGetRecored(docid);
                if (docSet != null)
                {
                    foreach (DataRow Dr in docSet.Tables[0].Rows)
                    {
                        ddlCarNo.SelectedValue = Convert.ToString(Dr["CarDetailsId"]);
                        ddlcardoc.SelectedValue = Convert.ToString(Dr["DocumentType"]);
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

        protected void rptCarDocInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hiddocid.Value = Convert.ToString(e.CommandArgument);
                    CarDocUpdate(hiddocid.Value);
                    GetCarDocumentData(1);
                    break;
                case "status":
                    Dal_CarDocument d1 = new Dal_CarDocument();
                    long docid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(docid);
                    GetCarDocumentData(1);
                    break;
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_CarDocument d1 = new Dal_CarDocument();
            DataSet cardocdataset = new DataSet();
            cardocdataset = d1.FunSearchByCarDocumentName(txtsearch.Text);
            if (cardocdataset.Tables[0].Rows.Count > 0)
            {
                rptCarDocInfo.DataSource = cardocdataset.Tables[0];
                rptCarDocInfo.DataBind();

            }
            else
            {
                GetCarDocumentData(1);
                cleardata();
            }
        }
        #region Pageing
        protected void GetCarDocumentData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet companydataset = new DataSet();
                companydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
                Bal_CarDocument b1 = new Bal_CarDocument();
                Dal_CarDocument d1 = new Dal_CarDocument();
                b1.cdid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtsearch.Text.Trim();
                DataSet comDataset = d1.CarDocument_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptCarDocInfo.DataSource = comDataset.Tables[0];
                        rptCarDocInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptCarDocInfo.DataSource = null;
                    rptCarDocInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptCarDocInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCarDocumentData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetCarDocumentData(pageIndex);
        }


        #endregion


    }
}