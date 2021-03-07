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
    public partial class area : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StateBind();

                getAreaData(1);

                ddlCity.Items.Insert(0, "-Select city-");
                ddlState.Items.Insert(0, "-Select State-");
            }
        }
        protected void cleardata()
        {
            ddlState.SelectedIndex = 0;
            ddlCity.SelectedIndex = 0;
            txtareaname.Text = "";
            txtSearch.Text = "";
            hidaid.Value = "";
            lblduplicate.Text = "";

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (hidaid.Value != "")
            {
                long stateid = Convert.ToInt64(ddlState.SelectedValue);
                long cityid = Convert.ToInt64(ddlCity.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Area_CheckDuplicate_SP", txtareaname.Text, stateid, cityid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {
                    Bal_Area b1 = new Bal_Area();
                    b1.AreaId = Convert.ToInt64(hidaid.Value);
                    b1.AreaName = txtareaname.Text;
                    b1.StateId = ddlState.SelectedValue;
                    b1.CityId = ddlCity.SelectedValue;
                    Dal_Area d1 = new Dal_Area();
                    d1.funupdateData(b1);
                }
            }
            else
            {
                long stateid = Convert.ToInt64(ddlState.SelectedValue);
                long cityid = Convert.ToInt64(ddlCity.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Area_CheckDuplicate_SP", txtareaname.Text, stateid, cityid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else

                {
                    Bal_Area b1 = new Bal_Area();
                    b1.AreaName = txtareaname.Text;
                    b1.StateId = ddlState.SelectedValue;
                    b1.CityId = ddlCity.SelectedValue;
                    Dal_Area d1 = new Dal_Area();
                    d1.funInsertArea(b1);
                }
            }
            getAreaData(1);
            cleardata();
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

        protected void CityBind(long cid)
        {
            DataSet citydataset = new DataSet();
            citydataset = SqlHelper.ExecuteDataset(connection, "City_Get_By_StateId_SP", cid);
            if (citydataset.Tables[0].Rows.Count > 0)
            {
                ddlCity.DataSource = citydataset.Tables[0];
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityId";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, "-Select city-");
            }
        }
        protected void funAreaUpdate(string AreaId)
        {
            try
            {
                long Aid = Convert.ToInt64(AreaId);
                Dal_Area d1 = new Dal_Area();
                DataSet mydataset = new DataSet();
                mydataset = d1.getArea(Aid);

                if (mydataset != null)
                {
                    foreach (DataRow Dr in mydataset.Tables[0].Rows)
                    {
                        ddlState.SelectedValue = Convert.ToString(Dr["StateId"]);
                        CityBind(Convert.ToInt64(Dr["StateId"]));
                        ddlCity.SelectedValue = Convert.ToString(Dr["CityId"]);
                        txtareaname.Text = Convert.ToString(Dr["AreaName"]);
                    }
                }
                else
                {
                    throw new Exception("Record not Found........");
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
                case "status":
                    long AreaId = Convert.ToInt64(e.CommandArgument);
                    Dal_Area d1 = new Dal_Area();
                    d1.funStatusUpdate(AreaId);
                    getAreaData(1);
                    break;
                case "edit":
                    hidaid.Value = Convert.ToString(e.CommandArgument);
                    funAreaUpdate(hidaid.Value);
                    getAreaData(1);
                    break;


            }
        }
        //protected void getAreaData()
        //{
        //    Dal_Area d1 = new Dal_Area();
        //    DataSet areadataset = new DataSet();
        //    areadataset = d1.functionselectarea();
        //    if(areadataset!=null)
        //    {
        //        rptUserInfo.DataSource = areadataset.Tables[0];
        //        rptUserInfo.DataBind();
        //    }
        //    else
        //    {
        //        rptUserInfo.DataSource = null;
        //        rptUserInfo.DataBind();
        //    }
        //}

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_Area d1 = new Dal_Area();
            DataSet mydataset = new DataSet();
            mydataset = d1.funsearchData(txtSearch.Text);
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                rptUserInfo.DataSource = mydataset.Tables[0];
                rptUserInfo.DataBind();
            }
            else
            {
                getAreaData(1);
                cleardata();
            }
        }

        protected void ddlState_TextChanged(object sender, EventArgs e)
        {
            long cid = Convert.ToInt64(ddlState.SelectedValue);
            CityBind(cid);
        }
        #region Pageing
        protected void getAreaData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet companydataset = new DataSet();
                companydataset = SqlHelper.ExecuteDataset(connection, "State_Get_SP");
                Bal_Area b1 = new Bal_Area();
                Dal_Area d1 = new Dal_Area();
                b1.AreaId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.CompanyMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptUserInfo.DataSource = comDataset.Tables[0];
                        rptUserInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
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
            getAreaData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.getAreaData(pageIndex);
        }

        #endregion
    }
}