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
    public partial class HouseDocument : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetHouseDocumentData(1);
                HouseTypeBind();
                ddlhouseno.Items.Insert(0, "-Select HouseNo/Name-");

            }

        }
        //protected void GetHouseDocumentData()
        //{
        //    Dal_housedocument d1 = new Dal_housedocument();
        //    DataSet mydataset = new DataSet();
        //    mydataset = d1.funSelectHouseDocument();
        //    if (mydataset != null)
        //    {
        //        rptHouseDocument.DataSource = mydataset.Tables[0];
        //        rptHouseDocument.DataBind();
        //    }
        //    else
        //    {
        //        rptHouseDocument.DataSource = null;
        //        rptHouseDocument.DataBind();
        //    }
        //}
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (hdocid.Value != "")
            {
                //long HouseTypid = Convert.ToInt64(ddlDocument.SelectedValue);
                //long houseid = Convert.ToInt64(ddlhouseno.SelectedValue);
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "HouseDocument_CheckDuplicate_SP", txtdocument.Text, HouseTypid, houseid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{


                    string fname;
                    string HouseImageName = "";

                    Bal_Housedocument b1 = new Bal_Housedocument();
                    b1.Did = Convert.ToInt64(hdocid.Value);
                    b1.Hid = Convert.ToInt64(ddlDocument.SelectedValue);
                    b1.houseid = Convert.ToInt64(ddlhouseno.SelectedValue);
                    b1.DocumentType = txtdocument.Text;
                    string oldimagefile = @"H:\ASP\RentSystem\RentSystem\admin\HouseDoc_Img\" + hidImageName.Value;
                    if (File.Exists(oldimagefile))
                    {
                        File.Delete(oldimagefile);
                    }

                    fname = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss ")).Replace("-", " ").Replace(" ", "");
                    if (fpImages.HasFile)
                    {
                        fpImages.SaveAs(Server.MapPath("~/admin/HouseDoc_Img/" + fname + ".jpg"));
                        HouseImageName = fname + ".jpg";
                    }
                    b1.HImage = HouseImageName;

                    Dal_housedocument d1 = new Dal_housedocument();
                    d1.FunUpdateData(b1);
                
            }
            else
            {

                //long HouseTypid = Convert.ToInt64(ddlDocument.SelectedValue);
                //long houseid = Convert.ToInt64(ddlhouseno.SelectedValue);
               
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "HouseDocument_CheckDuplicate_SP", txtdocument.Text, HouseTypid, houseid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{

                    string fname;
                    string HouseImageName = "";

                    Bal_Housedocument b1 = new Bal_Housedocument();
                    b1.Hid = Convert.ToInt64(ddlDocument.SelectedValue);
                    b1.houseid = Convert.ToInt64(ddlhouseno.SelectedValue);
                    b1.DocumentType = txtdocument.Text;

                    fname = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss ")).Replace("-", " ").Replace(" ", "");
                    if (fpImages.HasFile)
                    {
                        fpImages.SaveAs(Server.MapPath("~/admin/HouseDoc_Img/" + fname + ".jpg"));
                        HouseImageName = fname + ".jpg";
                    }
                    b1.HImage = HouseImageName;
                    Dal_housedocument d1 = new Dal_housedocument();
                    d1.funInsertHouseDocument(b1);
                }
                GetHouseDocumentData(1);
                cleardata();

            
        }
        protected void cleardata()
        {
            txtdocument.Text = "";
            ddlhouseno.SelectedIndex = 0;
            HouseTypeBind();
            hdocid.Value = "";
            hidImageName.Value = "";
        }
        protected void HouseTypeBind()
        {
            DataSet mydataset = new DataSet();
            mydataset = SqlHelper.ExecuteDataset(connection, "HouseType_Get_SP");
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                ddlDocument.DataSource = mydataset.Tables[0];
                ddlDocument.DataTextField = "HouseTypeName";
                ddlDocument.DataValueField = "HouseTypeId";
                ddlDocument.DataBind();
                ddlDocument.Items.Insert(0, "-Select HouseType-");
            }
        }

        protected void HouseNoBind(long houseid)
        {
            DataSet mydataset = new DataSet();
            mydataset = SqlHelper.ExecuteDataset(connection, "HouseNo_Get_By_HouseTypeId_SP", houseid);
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                ddlhouseno.DataSource = mydataset.Tables[0];
                ddlhouseno.DataTextField = "HouseNo";
                ddlhouseno.DataValueField = "HouseId";
                ddlhouseno.DataBind();
                ddlhouseno.Items.Insert(0, "-Select HouseNo/Name-");
            }
        }


        protected void HouseDocUpdate(string docid1)
        {
            try
            {
                long docid = Convert.ToInt64(docid1);
                Dal_housedocument d1 = new Dal_housedocument();
                DataSet docSet = new DataSet();
                docSet = d1.HouseDocGetRecored(docid);
                if (docSet != null)
                {
                    foreach (DataRow Dr in docSet.Tables[0].Rows)
                    {
                        ddlDocument.SelectedValue = Convert.ToString(Dr["HouseTypeId"]);
                        HouseNoBind(Convert.ToInt64(Dr["HouseTypeId"]));
                        ddlhouseno.SelectedValue = Convert.ToString(Dr["HouseId"]);
                        txtdocument.Text = Convert.ToString(Dr["DocumentType"]);
                        hidImageName.Value = Convert.ToString(Dr["Images"]);
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

        protected void rptHouseDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    hdocid.Value = Convert.ToString(e.CommandArgument);
                    HouseDocUpdate(hdocid.Value);
                    GetHouseDocumentData(1);
                    break;
                case "status":
                    Dal_housedocument d1 = new Dal_housedocument();
                    long docid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(docid);
                    GetHouseDocumentData(1);
                    break;

            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Dal_housedocument d1 = new Dal_housedocument();
            DataSet mydataset = new DataSet();
            mydataset = d1.FunSearchByHouseDocumentName(txtSearch.Text);
            if (mydataset.Tables[0].Rows.Count > 0)
            {
                rptHouseDocument.DataSource = mydataset.Tables[0];
                rptHouseDocument.DataBind();
            }
            else
            {
                GetHouseDocumentData(1);
                cleardata();
            }
        }
        #region Pageing
        protected void GetHouseDocumentData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet housedocumentdataset = new DataSet();
                housedocumentdataset = SqlHelper.ExecuteDataset(connection, "HouseDocument_Select_SP");
                Bal_Housedocument b1 = new Bal_Housedocument();
                Dal_housedocument d1 = new Dal_housedocument();
                b1.Hid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet docDataset = d1.HouseDocumentMaster_Get_by_PageIndex(b1);
                if (docDataset != null && docDataset.Tables.Count > 0)
                {
                    if (docDataset.Tables[0].Rows.Count > 0)
                    {
                        rptHouseDocument.DataSource = docDataset.Tables[0];
                        rptHouseDocument.DataBind();
                        int iRecordCount = Convert.ToInt16(docDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptHouseDocument.DataSource = null;
                    rptHouseDocument.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptHouseDocument.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetHouseDocumentData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetHouseDocumentData(pageIndex);
        }


        #endregion

        protected void ddlDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            long houseid = Convert.ToInt64(ddlDocument.SelectedValue);
            HouseNoBind(houseid);
        }
    }

}