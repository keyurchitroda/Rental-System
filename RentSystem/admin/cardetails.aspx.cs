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
using MyOperations;
using System.IO;

namespace RentSystem.admin
{
    public partial class cardetails : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompanyBind();
                ddlmodel.Items.Insert(0, "-Select Model-");
                ddlsubmodel.Items.Insert(0, "-Select SubModel-");
                StateBind();
                RentBind();
                ddlcarcity.Items.Insert(0, "-Select City-");
                GetCarDetailsData(1);
            }
        }
        protected void CompanyBind()
        {
            DataSet comdataset = new DataSet();
            comdataset = SqlHelper.ExecuteDataset(connection, "Company_Get_SP");
            if (comdataset.Tables[0].Rows.Count > 0)
            {
                ddlcompany.DataSource = comdataset.Tables[0];
                ddlcompany.DataTextField = "CompanyName";
                ddlcompany.DataValueField = "CompanyId";
                ddlcompany.DataBind();
                ddlcompany.Items.Insert(0, "-Select Company-");
            }
        }
        protected void ModelBind(long mid)
        {
            DataSet moddataset = new DataSet();
            moddataset = SqlHelper.ExecuteDataset(connection, "Model_Get_By_CompanyId_SP", mid);
            if (moddataset.Tables[0].Rows.Count > 0)
            {
                ddlmodel.DataSource = moddataset.Tables[0];
                ddlmodel.DataTextField = "ModelName";
                ddlmodel.DataValueField = "ModelId";
                ddlmodel.DataBind();
                ddlmodel.Items.Insert(0, "-Select Model-");
            }
        }
        protected void SubModelBind(long smid)
        {
            DataSet submoddataset = new DataSet();
            submoddataset = SqlHelper.ExecuteDataset(connection, "SubModel_Get_By_ModelId_SP", smid);
            if (submoddataset.Tables[0].Rows.Count > 0)
            {
                ddlsubmodel.DataSource = submoddataset.Tables[0];
                ddlsubmodel.DataTextField = "SubModelName";
                ddlsubmodel.DataValueField = "SubModelId";
                ddlsubmodel.DataBind();
                ddlsubmodel.Items.Insert(0, "-Select SubModel-");
            }
        }
        protected void StateBind()
        {
            DataSet cardataset = new DataSet();
            cardataset = SqlHelper.ExecuteDataset(connection, "State_Get_SP");
            if (cardataset.Tables[0].Rows.Count > 0)
            {
                ddlcarstate.DataSource = cardataset.Tables[0];
                ddlcarstate.DataTextField = "StateName";
                ddlcarstate.DataValueField = "StateId";
                ddlcarstate.DataBind();
                ddlcarstate.Items.Insert(0, "-Select State-");
            }
        }
        protected void CityBind(long id)
        {
            DataSet citydataset = new DataSet();
            citydataset = SqlHelper.ExecuteDataset(connection, "City_Get_By_StateId_SP", id);
            if (citydataset.Tables[0].Rows.Count > 0)
            {
                ddlcarcity.DataSource = citydataset.Tables[0];
                ddlcarcity.DataTextField = "CityName";
                ddlcarcity.DataValueField = "CityId";
                ddlcarcity.DataBind();
                ddlcarcity.Items.Insert(0, "-Select City-");
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
        protected void ddlcarstate_TextChanged(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(ddlcarstate.SelectedValue);
            CityBind(id);
        }

        protected void ddlcompany_TextChanged(object sender, EventArgs e)
        {
            long mid = Convert.ToInt64(ddlcompany.SelectedValue);
            ModelBind(mid);
        }

        protected void ddlmodel_TextChanged(object sender, EventArgs e)
        {
            long smid = Convert.ToInt64(ddlmodel.SelectedValue);
            SubModelBind(smid);

        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (Hidcardetailsid.Value != "")
            {
                //long companyid = Convert.ToInt64(ddlcompany.SelectedValue);
                //long modelid = Convert.ToInt64(ddlmodel.SelectedValue);
                //long submodelid = Convert.ToInt64(ddlsubmodel.SelectedValue);
                //long stateid = Convert.ToInt64(ddlcarstate.SelectedValue);
                //long cityid = Convert.ToInt64(ddlcarcity.SelectedValue);
                //long renttypeid = Convert.ToInt64(ddlrenttype.SelectedValue);
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "CarDetails_CheckDuplicate_SP", txtcarowner.Text, txtcarregno.Text, txtownermob.Text, txtcarowneradd.Text, txtcarno.Text, companyid, modelid, submodelid, renttypeid, stateid, cityid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{
                    string fname;
                    string CarImageName = " ";
                    Bal_CarDetails b1 = new Bal_CarDetails();
                    Dal_CarDetails d1 = new Dal_CarDetails();
                    b1.cdid = Convert.ToInt64(Hidcardetailsid.Value);
                    b1.comid = Convert.ToInt64(ddlcompany.SelectedValue);
                    b1.modid = Convert.ToInt64(ddlmodel.SelectedValue);
                    b1.submid = Convert.ToInt64(ddlsubmodel.SelectedValue);
                    b1.cno = txtcarno.Text;
                    b1.cregno = txtcarregno.Text;
                    b1.sid = Convert.ToInt64(ddlcarstate.SelectedValue);
                    b1.cid = Convert.ToInt64(ddlcarcity.SelectedValue);
                    b1.cowner = txtcarowner.Text;
                    b1.comobile = txtownermob.Text;
                    b1.coadd = txtcarowneradd.Text;

                    string oldimagefile = @"H:\ASP\RentSystem\RentSystem\admin\Car_Img\" + hidImageName.Value;
                    if (File.Exists(oldimagefile))
                    {
                        File.Delete(oldimagefile);
                    }


                    b1.price = Convert.ToDecimal(txtcarprice.Text);
                    b1.renttypeid = Convert.ToInt64(ddlrenttype.SelectedValue);
                    fname = Convert.ToString(System.DateTime.Now.ToString("dd-MM-yyyy hh mm ss")).Replace("-", "").Replace(" ", "");
                    if (CarImages.HasFile)
                    {
                        CarImages.SaveAs(Server.MapPath("~/admin/Car_Img/" + fname + ".jpg"));
                        CarImageName = fname + ".jpg";
                    }
                    b1.cimage = CarImageName;
                    d1.FunUpdateData(b1);

                
            }
            else
            {
                //{
                //    long companyid = Convert.ToInt64(ddlcompany.SelectedValue);
                //    long modelid = Convert.ToInt64(ddlmodel.SelectedValue);
                //    long submodelid = Convert.ToInt64(ddlsubmodel.SelectedValue);
                //    long stateid = Convert.ToInt64(ddlcarstate.SelectedValue);
                //    long cityid = Convert.ToInt64(ddlcarcity.SelectedValue);
                //    long renttypeid = Convert.ToInt64(ddlrenttype.SelectedValue);
                //    int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "CarDetails_CheckDuplicate_SP", txtcarowner.Text, txtcarregno.Text, txtownermob.Text, txtcarowneradd.Text, txtcarno.Text, companyid, modelid, submodelid, renttypeid, stateid, cityid));
                //    if (cnt > 0)
                //    {
                //        lblduplicate.Visible = false;
                //        lblduplicate.Visible = true;
                //    }
                //    else
                //    {
                       string fname;
                        string CarImageName = " ";
                        Bal_CarDetails b1 = new Bal_CarDetails();
                        Dal_CarDetails d1 = new Dal_CarDetails();
                        b1.comid = Convert.ToInt64(ddlcompany.SelectedValue);
                        b1.modid = Convert.ToInt64(ddlmodel.SelectedValue);
                        b1.submid = Convert.ToInt64(ddlsubmodel.SelectedValue);
                        b1.cno = txtcarno.Text;
                        b1.cregno = txtcarregno.Text;
                        b1.sid = Convert.ToInt64(ddlcarstate.SelectedValue);
                        b1.cid = Convert.ToInt64(ddlcarcity.SelectedValue);
                        b1.cowner = txtcarowner.Text;
                        b1.comobile = txtownermob.Text;
                        b1.coadd = txtcarowneradd.Text;
                        b1.price = Convert.ToDecimal(txtcarprice.Text);
                        b1.renttypeid = Convert.ToInt64(ddlrenttype.SelectedValue);
                        fname = Convert.ToString(System.DateTime.Now.ToString("dd-MM-yyyy hh mm ss")).Replace("-", "").Replace(" ", "");
                        if (CarImages.HasFile)
                        {
                            CarImages.SaveAs(Server.MapPath("~/admin/Car_Img/" + fname + ".jpg"));
                            CarImageName = fname + ".jpg";
                        }
                        b1.cimage = CarImageName;
                        d1.FunInsertData(b1);
                    }
                
                GetCarDetailsData(1);
                cleardata();
            
        }
        protected void cleardata()
        {
            ddlcompany.SelectedIndex = 0;
            ddlmodel.SelectedIndex = 0;
            ddlsubmodel.SelectedIndex = 0;
            txtcarno.Text = "";
            txtcarregno.Text = "";
            ddlcarstate.SelectedIndex = 0;
            ddlcarcity.SelectedIndex = 0;
            txtcarowner.Text = "";
            txtownermob.Text = "";
            txtcarowneradd.Text = "";
            txtcarprice.Text = "";
            hidImageName.Value = "";
            Hidcardetailsid.Value = "";
            ddlrenttype.SelectedIndex = 0;

        }
        //protected void GetCarDetailsData()
        //{
        //    try
        //    {
        //        Dal_CarDetails d1 = new Dal_CarDetails();
        //        DataSet cardetset = new DataSet();
        //        cardetset = d1.FunUserData();
        //        if (cardetset != null)
        //        {
        //            rptCarDetailsInfo.DataSource = cardetset.Tables[0];
        //            rptCarDetailsInfo.DataBind();
        //        }
        //        else
        //        {
        //            rptCarDetailsInfo.DataSource = null;
        //            rptCarDetailsInfo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        protected void rptCarDetailsInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    Hidcardetailsid.Value = Convert.ToString(e.CommandArgument);
                    CarUpdate(Hidcardetailsid.Value);
                    GetCarDetailsData(1);
                    break;
                case "status":
                    Dal_CarDetails d1 = new Dal_CarDetails();
                    long cdid = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(cdid);
                    GetCarDetailsData(1);
                    break;
            }
        }

        protected void CarUpdate(string cdid1)
        {
            try
            {
                long cdid = Convert.ToInt64(cdid1);
                Dal_CarDetails d1 = new Dal_CarDetails();
                DataSet CarSet = new DataSet();
                CarSet = d1.CarGetRecored(cdid);
                if (CarSet != null)
                {
                    foreach (DataRow Dr in CarSet.Tables[0].Rows)
                    {

                        ddlcompany.SelectedValue = Convert.ToString(Dr["CompanyId"]);
                        ModelBind(Convert.ToInt64(Dr["CompanyId"]));
                        ddlmodel.SelectedValue = Convert.ToString(Dr["ModelId"]);
                        SubModelBind(Convert.ToInt64(Dr["ModelId"]));
                        ddlsubmodel.SelectedValue = Convert.ToString(Dr["SubModelId"]);
                        txtcarno.Text = Convert.ToString(Dr["CarNo"]);
                        txtcarregno.Text = Convert.ToString(Dr["CarRegNo"]);
                        ddlcarstate.SelectedValue = Convert.ToString(Dr["StateId"]);
                        CityBind(Convert.ToInt64(Dr["StateId"]));
                        txtcarowner.Text = Convert.ToString(Dr["CarOwner"]);
                        txtownermob.Text = Convert.ToString(Dr["CarOwnerMobileNo"]);
                        txtcarowneradd.Text = Convert.ToString(Dr["CarownerAddress"]);
                        txtcarprice.Text = Convert.ToString(Dr["CarPrice"]);
                        ddlrenttype.SelectedValue = Convert.ToString(Dr["RentTypeId"]);
                        ddlcarcity.SelectedValue = Convert.ToString(Dr["CityId"]);
                        hidImageName.Value = Convert.ToString(Dr["CarImage"]);
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
            Dal_CarDetails d1 = new Dal_CarDetails();
            DataSet cardetdataset = new DataSet();
            cardetdataset = d1.FunSearchByCarDetailsName(txtSearch.Text);
            if (cardetdataset.Tables[0].Rows.Count > 0)
            {
                rptCarDetailsInfo.DataSource = cardetdataset.Tables[0];
                rptCarDetailsInfo.DataBind();

            }
            else
            {
                GetCarDetailsData(1);
                cleardata();
            }
        }
        #region Pageing
        protected void GetCarDetailsData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet categorydataset = new DataSet();
                categorydataset = SqlHelper.ExecuteDataset(connection, "CarDetails_Select_SP");
                Bal_CarDetails b1 = new Bal_CarDetails();
                Dal_CarDetails d1 = new Dal_CarDetails();
                b1.cid = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet catDataset = d1.CarDetailsMaster_Get_by_PageIndex(b1);
                if (catDataset != null && catDataset.Tables.Count > 0)
                {
                    if (catDataset.Tables[0].Rows.Count > 0)
                    {
                        rptCarDetailsInfo.DataSource = catDataset.Tables[0];
                        rptCarDetailsInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(catDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptCarDetailsInfo.DataSource = null;
                    rptCarDetailsInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptCarDetailsInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        //protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetCarDetailsData(1);
        //}

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetCarDetailsData(pageIndex);
        }

        #endregion

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCarDetailsData(1);
        }
    }
}