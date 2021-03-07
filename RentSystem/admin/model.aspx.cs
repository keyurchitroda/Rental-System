using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MyOperations.DAL;
using MyOperations.BAL;
using MyOperations;

namespace RentSystem.admin
{
    public partial class model : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                CompanyBind();
                GetModelData(1);
            }
        }

        protected void CompanyBind()
        {
            DataSet comdataset = new DataSet();
            comdataset = SqlHelper.ExecuteDataset(connection, "Company_Get_SP");
            if (comdataset.Tables[0].Rows.Count > 0)
            {
                ddlCompany.DataSource = comdataset.Tables[0];
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, "-Select Company-");
            }
        }


        protected void cleardata()
        {
            txtModName.Text = "";
            ddlCompany.SelectedIndex = 0;
            hidModid.Value = "";
        }
        //protected void GetModelData()
        //{
        //    try
        //    {
        //        Dal_Model d1 = new Dal_Model();
        //        DataSet modset = new DataSet();
        //        modset = d1.FunUserData();
        //        if (modset != null)
        //        {
        //            rptModelInfo.DataSource = modset.Tables[0];
        //            rptModelInfo.DataBind();
        //        }
        //        else
        //        {
        //            rptModelInfo.DataSource = null;
        //            rptModelInfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        protected void rptModelInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hidModid.Value = Convert.ToString(e.CommandArgument);
                    ModelUpdate(hidModid.Value);
                    GetModelData(1);
                    break;
                case "status":
                    Dal_Model d1 = new Dal_Model();
                    long modid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(modid);
                    GetModelData(1);
                    break;

            }
        }


        protected void ModelUpdate(string modid1)
        {
            try
            {
                long modid = Convert.ToInt64(modid1);
                Dal_Model d1 = new Dal_Model();
                DataSet ModSet = new DataSet();
                ModSet = d1.ModelGetRecored(modid);
                if (ModSet != null)
                {
                    foreach (DataRow Dr in ModSet.Tables[0].Rows)
                    {
                        ddlCompany.SelectedValue = Convert.ToString(Dr["CompanyId"]);
                        txtModName.Text = Convert.ToString(Dr["ModelName"]);

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
            Dal_Model d1 = new Dal_Model();
            DataSet moddataset = new DataSet();
            moddataset = d1.FunSearchByModelName(txtSearch.Text);
            if (moddataset.Tables[0].Rows.Count > 0)
            {
                rptModelInfo.DataSource = moddataset.Tables[0];
                rptModelInfo.DataBind();

            }
            else
            {
                GetModelData(1);
                cleardata();
            }
        }




        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (hidModid.Value != "")
            {
                Bal_Model b1 = new Bal_Model();
                b1.modid = Convert.ToInt64(hidModid.Value);
                b1.mname = txtModName.Text;
                b1.comid = ddlCompany.SelectedValue;
                Dal_Model d1 = new Dal_Model();
                d1.FunUpdateData(b1);

            }
            else
            {
                long companyid = Convert.ToInt64(ddlCompany.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Model_CheckDuplicate_SP", txtModName.Text, companyid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {
                    
                    Bal_Model b1 = new Bal_Model();
                    b1.mname = txtModName.Text;
                    b1.comid = ddlCompany.SelectedValue;
                    Dal_Model d1 = new Dal_Model();
                    d1.FunInsertData(b1);
                }

            }
            GetModelData(1);
            cleardata();

        }
        #region Pageing
        protected void GetModelData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet companydataset = new DataSet();
                companydataset = SqlHelper.ExecuteDataset(connection, "Company_Get_SP");
                Bal_Model b1 = new Bal_Model();
                Dal_Model d1 = new Dal_Model();
                b1.modid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.CompanyMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptModelInfo.DataSource = comDataset.Tables[0];
                        rptModelInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptModelInfo.DataSource = null;
                    rptModelInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptModelInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetModelData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetModelData(pageIndex);
        }

        #endregion
    }

}