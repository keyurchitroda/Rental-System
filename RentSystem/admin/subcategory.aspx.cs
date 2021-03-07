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
    public partial class subcategory : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CategoryBind();
                GetSubCategoryData(1);
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
            if (hidscid.Value != "")
            {
                long categoryid = Convert.ToInt64(ddlCategory.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "SubCategory_CheckDuplicate_SP", txtScname.Text, categoryid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {

                    Bal_SubCategory b1 = new Bal_SubCategory();
                    b1.scid = Convert.ToInt64(hidscid.Value);
                    b1.scname = txtScname.Text;
                    b1.cid = ddlCategory.SelectedValue;
                    Dal_SubCategory d1 = new Dal_SubCategory();
                    d1.FunUpdateData(b1);
                }
            }
            else

            {
                long categoryid = Convert.ToInt64(ddlCategory.SelectedValue);
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "SubCategory_CheckDuplicate_SP", txtScname.Text, categoryid));
                if (cnt > 0)
                {
                    lblduplicate.Visible = false;
                    lblduplicate.Visible = true;
                }
                else
                {
                    Bal_SubCategory b1 = new Bal_SubCategory();
                    b1.scname = txtScname.Text;
                    b1.cid = ddlCategory.SelectedValue;
                    Dal_SubCategory d1 = new Dal_SubCategory();
                    d1.FunInsertData(b1);
                }
            }
            GetSubCategoryData(1);
            cleardata();
        }
        protected void cleardata()
        {
            txtScname.Text = "";
            ddlCategory.SelectedIndex = 0;
            hidscid.Value = "";
        }

        protected void rptSubCatInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hidscid.Value = Convert.ToString(e.CommandArgument);
                    SubCatUpdate(hidscid.Value);
                    GetSubCategoryData(1);
                    break;
                case "status":
                    Dal_SubCategory d1 = new Dal_SubCategory();
                    long scid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(scid);
                    GetSubCategoryData(1);
                    break;

            }
        }

        //protected void GetSubCategoryData()
        //{
        //    try
        //    {
        //        Dal_SubCategory d1 = new Dal_SubCategory();
        //        DataSet catset = new DataSet();
        //        catset = d1.FunUserData();
        //        if (catset != null)
        //        {
        //            rptSubCatInfo.DataSource = catset.Tables[0];
        //            rptSubCatInfo.DataBind();
        //        }
        //        else
        //        {
        //            rptSubCatInfo.DataSource = null;
        //            rptSubCatInfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        protected void SubCatUpdate(string scid1)
        {
            try
            {
                long scid = Convert.ToInt64(scid1);
                Dal_SubCategory d1 = new Dal_SubCategory();
                DataSet CatSet = new DataSet();
                CatSet = d1.SubCatGetRecored(scid);
                if (CatSet != null)
                {
                    foreach (DataRow Dr in CatSet.Tables[0].Rows)
                    {
                        ddlCategory.SelectedValue = Convert.ToString(Dr["CategoryId"]);
                        txtScname.Text = Convert.ToString(Dr["SubCategoryName"]);

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
            Dal_SubCategory d1 = new Dal_SubCategory();
            DataSet subcatdataset = new DataSet();
            subcatdataset = d1.FunSearchBySubCategoryName(txtSearch.Text);
            if (subcatdataset.Tables[0].Rows.Count > 0)
            {
                rptSubCatInfo.DataSource = subcatdataset.Tables[0];
                rptSubCatInfo.DataBind();

            }
            else
            {
                GetSubCategoryData(1);
                cleardata();
            }
        }
        #region Pageing
        protected void GetSubCategoryData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet subcatdataset = new DataSet();
                subcatdataset = SqlHelper.ExecuteDataset(connection, "Category_Get_SP");
                Bal_SubCategory b1 = new Bal_SubCategory();
                Dal_SubCategory d1 = new Dal_SubCategory();
                b1.scid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.SubCategoryMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptSubCatInfo.DataSource = comDataset.Tables[0];
                        rptSubCatInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptSubCatInfo.DataSource = null;
                    rptSubCatInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptSubCatInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCategoryData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetSubCategoryData(pageIndex);
        }

        #endregion

        //        protected void btnExport_Click(object sender, EventArgs e)
        //        {
        //            Response.Clear();
        //            Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attechment;filename=Subcat" + DateTime.Now.ToString() + ".xls");
        //            Response.Charset = "";
        //            Response.ContentType = "appliaction/vnd.ms-excel";
        //            System.IO.StringWriter stringwrite = new System.IO.StringWriter();
        //            System.Web.UI.HtmlTextWriter htmlwriter = new HtmlTextWriter(stringwrite);
        //            rptSubCatInfo.RenderControl(htmlwriter);
        //            Response.Output.Write(stringwrite.ToString());
        //            Response.Flush();
        //            Response.End();
        //        }
    }
}