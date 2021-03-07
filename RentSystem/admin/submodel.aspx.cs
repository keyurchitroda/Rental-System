using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOperations.DAL;
using MyOperations.BAL;
using MyOperations;

namespace RentSystem.admin
{
    public partial class submodel : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompanyBind();
                GetSubModelData(1);
                ddlModel.Items.Insert(0, "-Select Model-");
            }
        }
        protected void CompanyBind()
        {
            DataSet companydataset = new DataSet();
            companydataset = SqlHelper.ExecuteDataset(connection, "Company_Get_SP");
            if (companydataset.Tables[0].Rows.Count > 0)
            {
                ddlCompany.DataSource = companydataset.Tables[0];
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, "-Select Company-");
            }
        }
        protected void ModelBind(long mid)
        {
            DataSet modeldataset = new DataSet();
            modeldataset = SqlHelper.ExecuteDataset(connection, "Model_Get_By_CompanyId_SP", mid);
            if (modeldataset.Tables[0].Rows.Count > 0)
            {
                ddlModel.DataSource = modeldataset.Tables[0];
                ddlModel.DataTextField = "ModelName";
                ddlModel.DataValueField = "ModelId";
                ddlModel.DataBind();
                ddlModel.Items.Insert(0, "-Select Model-");
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            if (hidsmid.Value != "")
            {
                long companyid = Convert.ToInt64(ddlCompany.SelectedValue);
                long modelid = Convert.ToInt64(ddlModel.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "SubModel_CheckDuplicate_SP", txtSmname.Text, companyid, modelid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {

                    Bal_SubModel b1 = new Bal_SubModel();
                    b1.submid = Convert.ToInt64(hidsmid.Value);
                    b1.comid = ddlCompany.SelectedValue;
                    b1.mid = ddlModel.SelectedValue;
                    b1.submname = txtSmname.Text;
                    Dal_SubModel d1 = new Dal_SubModel();
                    d1.FunUpdateData(b1);
                }
            }
            else
            {
                long companyid = Convert.ToInt64(ddlCompany.SelectedValue);
                long modelid = Convert.ToInt64(ddlModel.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "SubModel_CheckDuplicate_SP", txtSmname.Text, companyid, modelid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {

                    Bal_SubModel b1 = new Bal_SubModel();
                    b1.submname = txtSmname.Text;
                    b1.comid = ddlCompany.SelectedValue;
                    b1.mid = ddlModel.SelectedValue;
                    Dal_SubModel d1 = new Dal_SubModel();
                    d1.FunInsertData(b1);
                }
            }
            GetSubModelData(1);
            cleardata();
        }
        protected void cleardata()
        {
            txtSmname.Text = "";
            CompanyBind();
            ddlModel.SelectedIndex = 0;
            hidsmid.Value = "";
        }
        //protected void GetSubModelData()
        //{
        //    try
        //    {
        //        Dal_SubModel d1 = new Dal_SubModel();
        //        DataSet submodset = new DataSet();
        //        submodset = d1.FunUserData();
        //        if (submodset != null)
        //        {
        //            rptSubModelInfo.DataSource = submodset.Tables[0];
        //            rptSubModelInfo.DataBind();
        //        }
        //        else
        //        {
        //            rptSubModelInfo.DataSource = null;
        //            rptSubModelInfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        protected void ddlCompany_TextChanged(object sender, EventArgs e)
        {
            long mid = Convert.ToInt64(ddlCompany.SelectedValue);
            ModelBind(mid);
        }

        protected void rptSubModelInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "edit":
                    hidsmid.Value = Convert.ToString(e.CommandArgument);
                    SubModUpdate(hidsmid.Value);
                    GetSubModelData(1);
                    break;
                case "status":
                    Dal_SubModel d1 = new Dal_SubModel();
                    long smid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(smid);
                    GetSubModelData(1);
                    break;
            }
        }

        protected void SubModUpdate(string smid1)
        {
            try
            {
                long smid = Convert.ToInt64(smid1);
                Dal_SubModel d1 = new Dal_SubModel();
                DataSet SubMSet = new DataSet();
                SubMSet = d1.SubModGetRecored(smid);
                if (SubMSet != null)
                {
                    foreach (DataRow Dr in SubMSet.Tables[0].Rows)
                    {
                        ddlCompany.SelectedValue = Convert.ToString(Dr["CompanyId"]);
                        ModelBind(Convert.ToInt64(Dr["CompanyId"]));
                        ddlModel.SelectedValue = Convert.ToString(Dr["ModelId"]);
                        txtSmname.Text = Convert.ToString(Dr["SubModelName"]);

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
            Dal_SubModel d1 = new Dal_SubModel();
            DataSet submoddataset = new DataSet();
            submoddataset = d1.FunSearchBySubModelName(txtSearch.Text);
            if (submoddataset.Tables[0].Rows.Count > 0)
            {
                rptSubModelInfo.DataSource = submoddataset.Tables[0];
                rptSubModelInfo.DataBind();

            }
            else
            {
                GetSubModelData(1);
                cleardata();
            }
        }
        #region Pageing
        protected void GetSubModelData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet submodeldataset = new DataSet();
                submodeldataset = SqlHelper.ExecuteDataset(connection, "SubModel_Select_SP");
                Bal_SubModel b1 = new Bal_SubModel();
                Dal_SubModel d1 = new Dal_SubModel();
                b1.submid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.SubModelMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptSubModelInfo.DataSource = comDataset.Tables[0];
                        rptSubModelInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptSubModelInfo.DataSource = null;
                    rptSubModelInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptSubModelInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubModelData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetSubModelData(pageIndex);
        }

        #endregion

    }
}
