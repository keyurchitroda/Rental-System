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


namespace RentSystem.admin
{
    public partial class renttype : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryBind();
                GetRentData(1);
            }

        }
        protected void CategoryBind()
        {
            DataSet categorydataset = new DataSet();
            categorydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_Rent_SP");
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
            if (hidrid.Value != "")
            {
                long categoryid = Convert.ToInt64(ddlCategory.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "RentType_CheckDuplicate_SP", txtrenttype.Text, categoryid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {

                    Bal_RentType b1 = new Bal_RentType();
                    b1.RentTypeName = txtrenttype.Text;
                    b1.RentTypeid = Convert.ToInt64(hidrid.Value);
                    b1.Categoryid = Convert.ToInt64(ddlCategory.SelectedValue);
                    Dal_RentType d1 = new Dal_RentType();
                    d1.FunUpdateData(b1);
                }
            }
            else
            {
                long categoryid = Convert.ToInt64(ddlCategory.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "RentType_CheckDuplicate_SP", txtrenttype.Text, categoryid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {

                    Bal_RentType b1 = new Bal_RentType();
                    b1.RentTypeName = txtrenttype.Text;
                    b1.Categoryid = Convert.ToInt64(ddlCategory.SelectedValue);
                    Dal_RentType d1 = new Dal_RentType();
                    d1.FunInsertData(b1);
                }
            }
            GetRentData(1);
            cleardata();
        }

        protected void cleardata()
        {
            txtrenttype.Text = "";
            ddlCategory.SelectedIndex = 0;
            hidrid.Value = "";
        }

        //protected void GetRentData()
        //{
        //    try
        //    {
        //        Dal_RentType d1 = new Dal_RentType();
        //        DataSet rentset = new DataSet();
        //        rentset = d1.FunUserData();
        //        if (rentset != null)
        //        {
        //            rptrentInfo.DataSource = rentset.Tables[0];
        //            rptrentInfo.DataBind();
        //        }
        //        else
        //        {
        //            rptrentInfo.DataSource = null;
        //            rptrentInfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}
        protected void SubRentUpdate(string rid)
        {
            try
            {
                long rid1 = Convert.ToInt64(rid);
                Dal_RentType d1 = new Dal_RentType();
                DataSet RentSet = new DataSet();
                RentSet = d1.RentTypeGetRecored(rid1);
                if (RentSet != null)
                {
                    foreach (DataRow Dr in RentSet.Tables[0].Rows)
                    {
                        ddlCategory.SelectedValue = Convert.ToString(Dr["CategoryId"]);
                        txtrenttype.Text = Convert.ToString(Dr["RentTypeName"]);
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

        protected void rptrentInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hidrid.Value = Convert.ToString(e.CommandArgument);
                    SubRentUpdate(hidrid.Value);
                    GetRentData(1);
                    break;
                case "status":
                    Dal_RentType d1 = new Dal_RentType();
                    long rid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(rid);
                    GetRentData(1);
                    break;

            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_RentType d1 = new Dal_RentType();
            DataSet rentdataset = new DataSet();
            rentdataset = d1.FunSearchByRentTypeName(txtsearch.Text);
            if (rentdataset.Tables[0].Rows.Count > 0)
            {
                rptrentInfo.DataSource = rentdataset.Tables[0];
                rptrentInfo.DataBind();

            }
            else
            {
                GetRentData(1);
                cleardata();
            }
        }
        #region pageing
        protected void GetRentData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet companydataset = new DataSet();
                companydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
                Bal_RentType b1 = new Bal_RentType();
                Dal_RentType d1 = new Dal_RentType();
                b1.RentTypeid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtsearch.Text.Trim();
                DataSet comDataset = d1.RentTypeMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptrentInfo.DataSource = comDataset.Tables[0];
                        rptrentInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptrentInfo.DataSource = null;
                    rptrentInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptrentInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRentData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetRentData(pageIndex);
        }
        #endregion
    }
}