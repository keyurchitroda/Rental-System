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
using System.Data.SqlClient;
using MyOperations;

namespace RentSystem.admin
{
    public partial class company : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CategoryBind();
                GetCompanyData(1);
            }
        }
        protected void CategoryBind()
        {
            DataSet categorydataset = new DataSet();
            categorydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
            if (categorydataset.Tables[0].Rows.Count > 0)
            {
                ddlCategory.DataSource = categorydataset.Tables[0];
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "-Select Category-");
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (hidComid.Value != "")
            {
                long categoryid = Convert.ToInt64(ddlCategory.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Company_CheckDuplicate_SP", txtComName.Text, categoryid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {

                    Bal_Company b1 = new Bal_Company();
                    b1.comid = Convert.ToInt64(hidComid.Value);
                    b1.cname = txtComName.Text;
                    b1.catid = ddlCategory.SelectedValue;
                    Dal_Company d1 = new Dal_Company();
                    d1.FunUpdateData(b1);
                }
            }
            else
            {

                long categoryid = Convert.ToInt64(ddlCategory.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Company_CheckDuplicate_SP", txtComName.Text, categoryid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {
                    Bal_Company b1 = new Bal_Company();
                    b1.cname = txtComName.Text;
                    b1.catid = ddlCategory.SelectedValue;
                    Dal_Company d1 = new Dal_Company();
                    d1.FunInsertData(b1);
                }
            }
            GetCompanyData(1);
            cleardata();

        }
        protected void cleardata()
        {
            txtComName.Text = "";
            CategoryBind();
            hidComid.Value = "";
        }
        //protected void GetCompanyData()
        //{
        //    try
        //    {
        //        Dal_Company d1 = new Dal_Company();
        //        DataSet comset = new DataSet();
        //        comset = d1.FunUserData();
        //        if (comset != null)
        //        {
        //            rptCompanyInfo.DataSource = comset.Tables[0];
        //            rptCompanyInfo.DataBind();
        //        }
        //        else
        //        {
        //            rptCompanyInfo.DataSource = null;
        //            rptCompanyInfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        protected void rptCompanyInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hidComid.Value = Convert.ToString(e.CommandArgument);
                    CompanyUpdate(hidComid.Value);
                    GetCompanyData(1);
                    break;
                case "status":
                    Dal_Company d1 = new Dal_Company();
                    long scid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(scid);
                    GetCompanyData(1);
                    break;

            }
        }


        protected void CompanyUpdate(string comid1)
        {
            try
            {
                long comid = Convert.ToInt64(comid1);
                Dal_Company d1 = new Dal_Company();
                DataSet ComSet = new DataSet();
                ComSet = d1.CompanyGetRecored(comid);
                if (ComSet != null)
                {
                    foreach (DataRow Dr in ComSet.Tables[0].Rows)
                    {
                        ddlCategory.SelectedValue = Convert.ToString(Dr["CategoryId"]);
                        txtComName.Text = Convert.ToString(Dr["CompanyName"]);

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

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_Company d1 = new Dal_Company();
            DataSet comdataset = new DataSet();
            comdataset = d1.FunSearchByCompanyName(txtSearch.Text);
            if (comdataset.Tables[0].Rows.Count > 0)
            {
                rptCompanyInfo.DataSource = comdataset.Tables[0];
                rptCompanyInfo.DataBind();

            }
            else
            {
                GetCompanyData(1);
                cleardata();
            }
        }
        #region Pageing
        protected void GetCompanyData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet companydataset = new DataSet();
                companydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
                Bal_Company b1 = new Bal_Company();
                Dal_Company d1 = new Dal_Company();
                b1.comid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.CompanyMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptCompanyInfo.DataSource = comDataset.Tables[0];
                        rptCompanyInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptCompanyInfo.DataSource = null;
                    rptCompanyInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptCompanyInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCompanyData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetCompanyData(pageIndex);
        }

        #endregion
    }
}