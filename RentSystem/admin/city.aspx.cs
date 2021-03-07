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
    public partial class city : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                StateBind();
                GetUserData(1);
            }
        }
        protected void StateBind()
        {
            DataSet statedataset = new DataSet();
            statedataset = SqlHelper.ExecuteDataset(connection, "State_Get_SP");
            if (statedataset.Tables[0].Rows.Count > 0)
            {
                ddlState.DataSource = statedataset.Tables[0];
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "-Select State-");
            }
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (hidCity.Value != "")
            {
                long stateid = Convert.ToInt64(ddlState.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "City_CheckDuplicate_SP", txtCity.Text, stateid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {
                    Bal_City b1 = new Bal_City();
                    b1.CityId = Convert.ToInt64(hidCity.Value);
                    b1.CityName = txtCity.Text;
                    b1.StateId = Convert.ToInt64(ddlState.SelectedValue);
                    Dal_City d1 = new Dal_City();
                    d1.FunUpdateData(b1);
                }
            }

            else
            {
                long stateid = Convert.ToInt64(ddlState.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "City_CheckDuplicate_SP", txtCity.Text, stateid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }

                Bal_City b1 = new Bal_City();
                b1.StateId = Convert.ToInt64(ddlState.SelectedValue);
                b1.CityName = txtCity.Text;
                Dal_City d1 = new Dal_City();
                d1.FunInsertCity(b1);
            }

            GetUserData(1);
            cleardata();

        }

        //protected void GetUserData()
        //{
        //    try
        //    {
        //        Dal_City d1 = new Dal_City();
        //        DataSet citydataset = new DataSet();
        //        citydataset = d1.FunUserData();

        //        if (citydataset != null)
        //        {
        //            rptUserInfo.DataSource = citydataset.Tables[0];
        //            rptUserInfo.DataBind();
        //        }
        //        else
        //        {
        //            rptUserInfo.DataSource = null;
        //            rptUserInfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }

        //}
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_City d1 = new Dal_City();
            DataSet citydataset = new DataSet();
            citydataset = d1.FunSearchByCityName(txtSearch.Text);
            if (citydataset.Tables[0].Rows.Count > 0)
            {
                rptUserInfo.DataSource = citydataset.Tables[0];
                rptUserInfo.DataBind();

            }
            else
            {
                GetUserData(1);
                cleardata();
            }

        }

        protected void CatUpdate(string cid1)
        {
            try
            {
                long cid = Convert.ToInt64(cid1);
                Dal_City d1 = new Dal_City();
                DataSet CatSet = new DataSet();
                CatSet = d1.SubCatGetRecored(cid);
                if (CatSet != null)
                {
                    foreach (DataRow Dr in CatSet.Tables[0].Rows)
                    {
                        ddlState.SelectedValue = Convert.ToString(Dr["StateId"]);
                        txtCity.Text = Convert.ToString(Dr["CityName"]);
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
        protected void rptUserInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hidCity.Value = Convert.ToString(e.CommandArgument);
                    CatUpdate(hidCity.Value);
                    GetUserData(1);
                    break;
                case "status":
                    Dal_City d1 = new Dal_City();
                    long cid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(cid);
                    GetUserData(1);
                    break;


            }

        }
        protected void cleardata()
        {
            txtCity.Text = "";
            ddlState.SelectedIndex = 0;
            hidCity.Value = "";
        }


        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            Dal_City d1 = new Dal_City();
            DataSet catdataset = new DataSet();
            catdataset = d1.FunSearchByCityName(txtCity.Text);
            if (catdataset.Tables[0].Rows.Count > 0)
            {
                rptUserInfo.DataSource = catdataset.Tables[0];
                rptUserInfo.DataBind();

            }
            else
            {
                GetUserData(1);
                cleardata();
            }

        }
        #region Pageing
        protected void GetUserData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet citydataset = new DataSet();
                citydataset = SqlHelper.ExecuteDataset(connection, "State_Get_SP");
                Bal_City b1 = new Bal_City();
                Dal_City d1 = new Dal_City();
                b1.CityId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet cityDataset = d1.CityMaster_Get_by_PageIndex(b1);
                if (cityDataset != null && cityDataset.Tables.Count > 0)
                {
                    if (cityDataset.Tables[0].Rows.Count > 0)
                    {
                        rptUserInfo.DataSource = cityDataset.Tables[0];
                        rptUserInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(cityDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptUserInfo.DataSource = null;
                    rptUserInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptUserInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }
        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUserData(1);
        }


        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetUserData(pageIndex);
        }

        #endregion     
    }
}