using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations.BAL;
using MyOperations.DAL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MyOperations;

namespace RentSystem.admin
{
    public partial class category : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategoryData(1);
            }
        }
        //protected void GetCategoryData()
        //{
        //    try
        //    {
        //        Dal_Category d1 = new Dal_Category();
        //        DataSet catset = new DataSet();
        //        catset = d1.FunUserData();
        //        if (catset != null)
        //        {
        //            rptcatinfo.DataSource = catset.Tables[0];
        //            rptcatinfo.DataBind();
        //        }
        //        else
        //        {
        //            rptcatinfo.DataSource = null;
        //            rptcatinfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}


        protected void cleardata()
        {
            txtcname.Text = "";
            hidcid.Value = "";
        }
        protected void CatUpdate(string cid1)
        {
            try
            {
                long cid = Convert.ToInt64(cid1);
                Dal_Category d1 = new Dal_Category();
                DataSet CatSet = new DataSet();
                CatSet = d1.CatGetRecored(cid);
                if (CatSet != null)
                {
                    foreach (DataRow Dr in CatSet.Tables[0].Rows)
                    {
                        txtcname.Text = Convert.ToString(Dr["CategoryName"]);
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
        protected void rptcatinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hidcid.Value = Convert.ToString(e.CommandArgument);
                    CatUpdate(hidcid.Value);
                    GetCategoryData(1);
                    break;
                case "status":
                    Dal_Category d1 = new Dal_Category();
                    long cid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(cid);
                    GetCategoryData(1);
                    break;

            }
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (hidcid.Value != "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Category_CheckDuplicate_SP", txtcname.Text));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {
                    Bal_Category b1 = new Bal_Category();

                    b1.cid = Convert.ToInt64(hidcid.Value);
                    b1.cname = txtcname.Text;

                    Dal_Category d1 = new Dal_Category();
                    d1.FunUpdateData(b1);
                }
            }

            else
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Category_CheckDuplicate_SP", txtcname.Text));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {
                    Bal_Category b1 = new Bal_Category();
                    b1.cname = txtcname.Text;

                    Dal_Category d1 = new Dal_Category();
                    d1.FunInsertData(b1);
                    CommanFunction.Success_MessageBox("Category Added Successfully.");
                }
            }
            GetCategoryData(1);
            cleardata();

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_Category d1 = new Dal_Category();
            DataSet catdataset = new DataSet();
            catdataset = d1.FunSearchByCategoryName(txtSearch.Text);
            if (catdataset.Tables[0].Rows.Count > 0)
            {
                rptcatinfo.DataSource = catdataset.Tables[0];
                rptcatinfo.DataBind();

            }
            else
            {
                GetCategoryData(1);
                cleardata();
            }
        }
        #region Pageing
        protected void GetCategoryData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet categorydataset = new DataSet();
                categorydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
                Bal_Category b1 = new Bal_Category();
                Dal_Category d1 = new Dal_Category();
                b1.cid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet catDataset = d1.CategoryMaster_Get_by_PageIndex(b1);
                if (catDataset != null && catDataset.Tables.Count > 0)
                {
                    if (catDataset.Tables[0].Rows.Count > 0)
                    {
                        rptcatinfo.DataSource = catDataset.Tables[0];
                        rptcatinfo.DataBind();
                        int iRecordCount = Convert.ToInt16(catDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptcatinfo.DataSource = null;
                    rptcatinfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptcatinfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCategoryData(1);
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetCategoryData(pageIndex);
        }

        #endregion

    }
}


