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
    public partial class state : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserData(1);
        }
        //protected void GetUserData()
        //{
        //    try
        //    {
        //        Dal_State d1 = new Dal_State();
        //        DataSet Statedataset = new DataSet();
        //        Statedataset = d1.FunUserData();

        //        if (Statedataset != null)
        //        {
        //            rptUserInfo.DataSource = Statedataset.Tables[0];
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
        protected void CatUpdate(string cid1)
        {
            try
            {
                long cid = Convert.ToInt64(cid1);
                Dal_State d1 = new Dal_State();
                DataSet CatSet = new DataSet();
                CatSet = d1.SubCatGetRecored(cid);
                if (CatSet != null)
                {
                    foreach (DataRow Dr in CatSet.Tables[0].Rows)
                    {
                        txtState.Text = Convert.ToString(Dr["StateName"]);
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

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (hidState.Value != "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "State_CheckDuplicate_SP", txtState.Text));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {

                    Bal_State b1 = new Bal_State();

                    b1.StateId = Convert.ToInt64(hidState.Value);
                    b1.StateName = txtState.Text;

                    Dal_State d1 = new Dal_State();
                    d1.FunUpdateData(b1);
                }
            }

            else

            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "State_CheckDuplicate_SP", txtState.Text));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {

                    Bal_State b1 = new Bal_State();
                    b1.StateName = txtState.Text;

                    Dal_State d1 = new Dal_State();
                    d1.FunInsertData(b1);
                }
            }
            GetUserData(1);
            cleardata();

        }


        protected void cleardata()
        {
            txtState.Text = "";
            hidState.Value = "";
        }
        protected void FunUpdateData(string sid1)
        {
            try
            {
                long cid = Convert.ToInt64(sid1);
                Dal_State d1 = new Dal_State();
                DataSet CatSet = new DataSet();
                CatSet = d1.SubCatGetRecored(cid);
                if (CatSet != null)
                {
                    foreach (DataRow Dr in CatSet.Tables[0].Rows)
                    {
                        txtState.Text = Convert.ToString(Dr["CategoryName"]);
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
                    hidState.Value = Convert.ToString(e.CommandArgument);
                    CatUpdate(hidState.Value);
                    GetUserData(1);
                    break;
                case "status":
                    Dal_State d1 = new Dal_State();
                    long cid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(cid);
                    GetUserData(1);
                    break;


            }
        }


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_State d1 = new Dal_State();
            DataSet catdataset = new DataSet();
            catdataset = d1.FunSearchByStateName(txtSearch.Text);
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

                DataSet statedataset = new DataSet();
                statedataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
                Bal_State b1 = new Bal_State();
                Dal_State d1 = new Dal_State();
                b1.StateId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet stateDataset = d1.StateMaster_Get_by_PageIndex(b1);
                if (stateDataset != null && stateDataset.Tables.Count > 0)
                {
                    if (stateDataset.Tables[0].Rows.Count > 0)
                    {
                        rptUserInfo.DataSource = stateDataset.Tables[0];
                        rptUserInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(stateDataset.Tables[0].Rows[0]["RecordCount"]);
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
