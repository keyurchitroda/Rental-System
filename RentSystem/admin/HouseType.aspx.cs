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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RentBind();
                getHouseTypeData(1);

            }
        }
        protected void RentBind()
        {
            DataSet rentdataset = new DataSet();
            rentdataset = SqlHelper.ExecuteDataset(connection, "Rent_Get_SP");
            if (rentdataset.Tables[0].Rows.Count > 0)
            {
                ddlrenttype.DataSource = rentdataset.Tables[0];
                ddlrenttype.DataTextField = "RentTypeName";
                ddlrenttype.DataValueField = "RentTypeId";
                ddlrenttype.DataBind();
                ddlrenttype.Items.Insert(0, "-Select RentType-");
            }
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (hidtid.Value != "")
            {
                //long RentTypeid = Convert.ToInt64(ddlrenttype.SelectedValue);
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "HouseType_CheckDuplicate_SP", txthousetype.Text, RentTypeid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{

                    Bal_HouseType b1 = new Bal_HouseType();
                    b1.HouseTypeId = Convert.ToInt64(hidtid.Value);
                    b1.HouseType = txthousetype.Text;
                    b1.rentTypeId = ddlrenttype.SelectedValue;
                    b1.Price = Convert.ToDecimal(txtprice.Text);
                    Dal_HouseType d1 = new Dal_HouseType();
                    d1.HouseUpdateData(b1);
                
            }
            else
            {
                //{
                //    long RentTypeid = Convert.ToInt64(ddlrenttype.SelectedValue);
                //    int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "HouseType_CheckDuplicate_SP", txthousetype.Text, RentTypeid));
                //    if (cnt > 0)
                //    {
                //        lblduplicate.Visible = false;
                //        lblduplicate.Visible = true;
                //    }
                //    else
                //    {

                       Bal_HouseType b1 = new Bal_HouseType();
                        b1.HouseType = txthousetype.Text;
                        b1.rentTypeId = ddlrenttype.SelectedValue;
                        b1.Price = Convert.ToDecimal(txtprice.Text);
                        Dal_HouseType d1 = new Dal_HouseType();
                        d1.funInsertHouse(b1);

                    }

                    getHouseTypeData(1);
                    cleardata();
                
            
        }
        protected void cleardata()
        {
            txthousetype.Text = "";
            txtprice.Text = "";
            hidtid.Value = "";
            ddlrenttype.SelectedIndex = 0;
        }
        //protected void GetUserData()
        //{
        //    try
        //    {
        //        Dal_HouseType d1 = new Dal_HouseType();
        //        DataSet mydataset = new DataSet();
        //        mydataset = d1.HotelTypeGetUser();
        //        if (mydataset != null)
        //        {
        //            rptHouseInfo.DataSource = mydataset.Tables[0];
        //            rptHouseInfo.DataBind();
        //        }
        //        else
        //        {
        //            throw new Exception("record not found");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        protected void rptHouseInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "edit":
                    hidtid.Value = Convert.ToString(e.CommandArgument);
                    HouseUpdate(hidtid.Value);
                    getHouseTypeData(1);
                    break;

                case "status":
                    long hid = Convert.ToInt64(e.CommandArgument);
                    Dal_HouseType d1 = new Dal_HouseType();
                    d1.funStatusUpdate(hid);
                    getHouseTypeData(1);
                    break;
            }
        }

        protected void HouseUpdate(string hid)
        {
            try
            {
                long htid = Convert.ToInt64(hid);
                Dal_HouseType d1 = new Dal_HouseType();
                DataSet mydataset = new DataSet();
                mydataset = d1.getrecord(htid);
                if (mydataset != null)
                {
                    foreach (DataRow Dr in mydataset.Tables[0].Rows)
                    {
                        txthousetype.Text = Convert.ToString(Dr["HouseTypeName"]);
                        ddlrenttype.SelectedValue = Convert.ToString(Dr["RentTypeId"]);
                        txtprice.Text = Convert.ToString(Dr["Price"]);
                    }
                }
                else
                {
                    throw new Exception("record not found");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_HouseType d1 = new Dal_HouseType();
            DataSet mydataset = new DataSet();
            mydataset = d1.FunSearchByHouseTypeName(txtSearch.Text);
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                rptHouseInfo.DataSource = mydataset.Tables[0];
                rptHouseInfo.DataBind();

            }
            else
            {
                getHouseTypeData(1);
                cleardata();
            }

        }
        #region Pageing
        protected void getHouseTypeData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet companydataset = new DataSet();
                companydataset = SqlHelper.ExecuteDataset(connection, "HouseType_Select_SP");
                Bal_HouseType b1 = new Bal_HouseType();
                Dal_HouseType d1 = new Dal_HouseType();
                b1.HouseTypeId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.CompanyMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptHouseInfo.DataSource = comDataset.Tables[0];
                        rptHouseInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptHouseInfo.DataSource = null;
                    rptHouseInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptHouseInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getHouseTypeData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.getHouseTypeData(pageIndex);
        }

        #endregion

    }
}

