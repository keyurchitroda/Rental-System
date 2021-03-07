using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MyOperations.BAL;
using MyOperations.DAL;
using MyOperations;
using System.Configuration;
using System.IO;

namespace RentSystem.admin
{
    public partial class housedetails : System.Web.UI.Page

    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StateBind();
                HouseTypeBind();
                getHouseData(1);
                ddlCity.Items.Insert(0, "-Select city-");
                ddlArea.Items.Insert(0, "-Select Area-");
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (Hidhouse.Value != "")
            {
                //long HouseTypeid = Convert.ToInt64(ddlhousetype.SelectedValue);
                //long Areaid = Convert.ToInt64(ddlArea.SelectedValue);
                //long stateid = Convert.ToInt64(ddlState.SelectedValue);
                //long cityid = Convert.ToInt64(ddlCity.SelectedValue);
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "HouseDetails_CheckDuplicate_SP", txthouse.Text, txtmobile.Text, txthouseno.Text, HouseTypeid, Areaid, stateid, cityid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{

                    string fname;
                    string HouseImageName = "";
                    Bal_HouseDetails b1 = new Bal_HouseDetails();
                    b1.HouseId = Convert.ToInt64(Hidhouse.Value);
                    b1.HouseNo = txthouseno.Text;
                    b1.HouseOwner = txthouse.Text;
                    b1.HouseAddress = txthouseaddr.Text;
                    b1.MobileNo = txtmobile.Text;
                    b1.StateId = Convert.ToInt64(ddlState.SelectedValue);
                    b1.CityId = Convert.ToInt64(ddlCity.SelectedValue);
                    b1.AreaId = Convert.ToInt64(ddlArea.SelectedValue);
                    b1.HouseTypeId = Convert.ToInt64(ddlhousetype.SelectedValue);
                    string oldimagefile = @"H:\ASP\RentSystem\RentSystem\admin\HouseImage\" + HidImage.Value;
                    if (File.Exists(oldimagefile))
                    {
                        File.Delete(oldimagefile);
                    }

                    fname = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss ")).Replace("-", " ").Replace(" ", "");
                    if (HouseImages.HasFile)
                    {
                        HouseImages.SaveAs(Server.MapPath("~/admin/HouseImage/" + fname + ".jpg"));
                        HouseImageName = fname + ".jpg";
                    }
                    b1.HImage = HouseImageName;

                    Dal_HouseDetails d1 = new Dal_HouseDetails();
                    d1.HouseUpdate(b1);

                
            }
            else
            {
                //{
                //    long HouseTypeid = Convert.ToInt64(ddlhousetype.SelectedValue);
                //    long Areaid = Convert.ToInt64(ddlArea.SelectedValue);
                //    long stateid = Convert.ToInt64(ddlState.SelectedValue);
                //    long cityid = Convert.ToInt64(ddlCity.SelectedValue);
                //    int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "HouseDetails_CheckDuplicate_SP", txthouse.Text, txtmobile.Text, txthouseno.Text, HouseTypeid, Areaid, stateid, cityid));
                //    if (cnt > 0)
                //    {
                //        lblduplicate.Visible = false;
                //        lblduplicate.Visible = true;
                //    }
                //    else
                //    {


                        string fname;
                        string HouseImageName = "";
                        Bal_HouseDetails b1 = new Bal_HouseDetails();
                        b1.HouseNo = txthouseno.Text;
                        b1.HouseOwner = txthouse.Text;
                        b1.HouseAddress = txthouseaddr.Text;
                        b1.MobileNo = txtmobile.Text;
                        b1.StateId = Convert.ToInt64(ddlState.SelectedValue);
                        b1.CityId = Convert.ToInt64(ddlCity.SelectedValue);
                        b1.AreaId = Convert.ToInt64(ddlArea.SelectedValue);
                        b1.HouseTypeId = Convert.ToInt64(ddlhousetype.SelectedValue);
                        fname = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss ")).Replace("-", " ").Replace(" ", "");
                        if (HouseImages.HasFile)
                        {
                            HouseImages.SaveAs(Server.MapPath("~/admin/HouseImage/" + fname + ".jpg"));
                            HouseImageName = fname + ".jpg";
                        }
                        b1.HImage = HouseImageName;
                        Dal_HouseDetails d1 = new Dal_HouseDetails();
                        d1.FunInsertHouse(b1);
                    }

                    getHouseData(1);
                    cleardata();
                
            
        }
        protected void cleardata()
        {
            txthouseno.Text = "";
            txthouse.Text = "";
            txthouseaddr.Text = "";
            txtmobile.Text = "";
            StateBind();
            ddlCity.SelectedIndex = 0;
            ddlArea.SelectedIndex = 0;
            ddlhousetype.SelectedIndex = 0;
            Hidhouse.Value = "";
            HidImage.Value = "";

        }
        protected void rptHouseDetinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Dal_HouseDetails d1 = new Dal_HouseDetails();
            switch (e.CommandName)
            {
                case "edit":
                    Hidhouse.Value = Convert.ToString(e.CommandArgument);
                    Houseupdate(Hidhouse.Value);
                    getHouseData(1);
                    break;
                case "status":
                    long hid = Convert.ToInt64(e.CommandArgument);
                    d1.funStatusUpdate(hid);
                    getHouseData(1);
                    break;

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

        protected void AreaBind(long aid)
        {
            ddlArea.Items.Clear();
            DataSet areadataset = new DataSet();
            areadataset = SqlHelper.ExecuteDataset(connection, "Area_Get_By_CityId_SP", aid);
            if (areadataset.Tables[0].Rows.Count > 0)
            {
                ddlArea.DataSource = areadataset.Tables[0];
                ddlArea.DataTextField = "AreaName";
                ddlArea.DataValueField = "AreaId";
                ddlArea.DataBind();

            }
            ddlArea.Items.Insert(0, "-Select Area-");
        }

        protected void HouseTypeBind()
        {
            DataSet housetypedataset = new DataSet();
            housetypedataset = SqlHelper.ExecuteDataset(connection, "HouseType_Get_SP");
            if (housetypedataset.Tables[0].Rows.Count > 0)
            {
                ddlhousetype.DataSource = housetypedataset.Tables[0];
                ddlhousetype.DataTextField = "HouseTypeName";
                ddlhousetype.DataValueField = "HouseTypeId";
                ddlhousetype.DataBind();
                ddlhousetype.Items.Insert(0, "-Select HouseType-");
            }
        }


        protected void ddlCity_TextChanged(object sender, EventArgs e)
        {
            long aid = Convert.ToInt64(ddlCity.SelectedValue);
            AreaBind(aid);
        }

        protected void ddlState_TextChanged(object sender, EventArgs e)
        {
            long cid = Convert.ToInt64(ddlState.SelectedValue);
            CityBind(cid);
        }

        //protected void getuserdata()
        //{
        //    try
        //    {
        //        Dal_HouseDetails d1 = new Dal_HouseDetails();
        //        DataSet mydataset = new DataSet();
        //        mydataset = d1.fungethouse();
        //        if (mydataset != null)
        //        {
        //            rptHouseDetinfo.DataSource = mydataset.Tables[0];
        //            rptHouseDetinfo.DataBind();
        //        }
        //        else
        //        {
        //            throw new Exception("recoed not found");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}
        protected void Houseupdate(string hid)
        {
            try
            {
                long hdid = Convert.ToInt64(hid);
                Dal_HouseDetails d1 = new Dal_HouseDetails();
                DataSet mydataset = new DataSet();
                mydataset = d1.HouseGetRecord(hdid);
                if (mydataset != null)
                {
                    foreach (DataRow Dr in mydataset.Tables[0].Rows)
                    {
                        txthouseno.Text = Convert.ToString(Dr["HouseNo"]);
                        txthouse.Text = Convert.ToString(Dr["HouseOwner"]);
                        txthouseaddr.Text = Convert.ToString(Dr["HouseAddress"]);
                        txtmobile.Text = Convert.ToString(Dr["MobileNo"]);
                        ddlState.SelectedValue = Convert.ToString(Dr["StateId"]);
                        CityBind(Convert.ToInt64(Dr["StateId"]));
                        ddlCity.SelectedValue = Convert.ToString(Dr["CityId"]);
                        AreaBind(Convert.ToInt64(Dr["CityId"]));
                        ddlArea.SelectedValue = Convert.ToString(Dr["AreaId"]);
                        ddlhousetype.SelectedValue = Convert.ToString(Dr["HouseTypeId"]);
                        HidImage.Value = Convert.ToString(Dr["Images"]);
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
            Dal_HouseDetails d1 = new Dal_HouseDetails();
            DataSet mydataset = new DataSet();
            mydataset = d1.FunSearchByHouseDetails(txtSearch.Text);
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                rptHouseDetinfo.DataSource = mydataset.Tables[0];
                rptHouseDetinfo.DataBind();

            }
            else
            {
                getHouseData(1);
                cleardata();
            }

        }
        #region Pageing
        protected void getHouseData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet companydataset = new DataSet();
                companydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
                Bal_HouseDetails b1 = new Bal_HouseDetails();
                Dal_HouseDetails d1 = new Dal_HouseDetails();
                b1.HouseId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.CompanyMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptHouseDetinfo.DataSource = comDataset.Tables[0];
                        rptHouseDetinfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptHouseDetinfo.DataSource = null;
                    rptHouseDetinfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptHouseDetinfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getHouseData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.getHouseData(pageIndex);
        }

        #endregion
    }
}