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
    public partial class camera : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCameraData(1);
                CompanyBind();
                RentBind();
                ddlmodel.Items.Insert(0, "-Select Model-");
                ddlsubmodel.Items.Insert(0, "-Select SubModel-");
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
            if (HidCamera.Value != "")
            {

                //long Companyid = Convert.ToInt64(ddlcompany.SelectedValue);
                //long modelid = Convert.ToInt64(ddlmodel.SelectedValue);
                //long Submodelid = Convert.ToInt64(ddlsubmodel.SelectedValue);
                //long RentTypeid = Convert.ToInt64(ddlrenttype.SelectedValue);
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Camera_CheckDuplicate_SP", txtOwner.Text, txtMobile.Text, txtxAddress.Text, Companyid, modelid, Submodelid, RentTypeid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{

                string fname;
                string CameraImage = " ";

                Bal_camera b1 = new Bal_camera();
                Dal_camera d1 = new Dal_camera();

                b1.companyId = Convert.ToInt64(ddlcompany.SelectedValue);
                b1.modelId = Convert.ToInt64(ddlmodel.SelectedValue);
                b1.submodelId = Convert.ToInt64(ddlsubmodel.SelectedValue);
                b1.rentTypeId = Convert.ToInt64(ddlrenttype.SelectedValue);
                b1.owner = txtOwner.Text;
                b1.mobile = txtMobile.Text;
                b1.address = txtxAddress.Text;
                b1.price = Convert.ToDecimal(txtprice.Text);
                b1.cameraId = Convert.ToInt64(HidCamera.Value);
                string oldimagefile = @"H:\ASP\RentSystem\RentSystem\admin\Camera_Img\" + hidImageName.Value;
                if (File.Exists(oldimagefile))
                {
                    File.Delete(oldimagefile);
                }

                fname = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss")).Replace("-", "").Replace(" ", "");
                if (fpCameraImages.HasFile)
                {
                    fpCameraImages.SaveAs(Server.MapPath("~/admin/Camera_Img/" + fname + ".jpg"));
                    CameraImage = fname + ".jpg";
                }
                b1.image = CameraImage;
                d1.CameraUpdateData(b1);
            }


            else
            {

                //long Companyid = Convert.ToInt64(ddlcompany.SelectedValue);
                //long modelid = Convert.ToInt64(ddlmodel.SelectedValue);
                //long Submodelid = Convert.ToInt64(ddlsubmodel.SelectedValue);
                //long RentTypeid = Convert.ToInt64(ddlrenttype.SelectedValue);
                //int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(connection, "Camera_CheckDuplicate_SP", txtOwner.Text, txtMobile.Text, txtxAddress.Text, Companyid, modelid, Submodelid, RentTypeid));
                //if (cnt > 0)
                //{
                //    lblduplicate.Visible = false;
                //    lblduplicate.Visible = true;
                //}
                //else
                //{



                string fname;
                string CameraImage = " ";

                Bal_camera b1 = new Bal_camera();
                Dal_camera d1 = new Dal_camera();
                b1.companyId = Convert.ToInt64(ddlcompany.SelectedValue);
                b1.modelId = Convert.ToInt64(ddlmodel.SelectedValue);
                b1.submodelId = Convert.ToInt64(ddlsubmodel.SelectedValue);
                b1.rentTypeId = Convert.ToInt64(ddlrenttype.SelectedValue);
                b1.owner = txtOwner.Text;
                b1.mobile = txtMobile.Text;
                b1.address = txtxAddress.Text;
                b1.price = Convert.ToDecimal(txtprice.Text);

                fname = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss")).Replace("/", "").Replace(" ", "");
                if (fpCameraImages.HasFile)
                {
                    fpCameraImages.SaveAs(Server.MapPath("~/admin/Camera_Img/" + fname + ".jpg"));
                    CameraImage = fname + ".jpg";
                }

                b1.image = CameraImage;
                d1.FunInsertCamera(b1);
            }

            getCameraData(1);
            cleardata();
        }
        protected void cleardata()
        {
            ddlcompany.SelectedIndex = 0;
            ddlmodel.SelectedIndex = 0;
            ddlsubmodel.SelectedIndex = 0;
            ddlrenttype.SelectedIndex = 0;
            txtOwner.Text = "";
            txtMobile.Text = "";
            txtxAddress.Text = "";
            txtprice.Text = "";
            hidImageName.Value = "";
            HidCamera.Value = "";
        }

        protected void ddlcompany_TextChanged(object sender, EventArgs e)
        {
            long mid = Convert.ToInt64(ddlcompany.SelectedValue);
            ModelBind(mid);

        }

        protected void CameraUpdateData(string cdid1)
        {
            try
            {
                long cameraId = Convert.ToInt64(cdid1);
                Dal_camera d1 = new Dal_camera();
                DataSet CamSet = new DataSet();
                CamSet = d1.CameraGetRecored(cameraId);
                if (CamSet != null)
                {
                    foreach (DataRow Dr in CamSet.Tables[0].Rows)
                    {
                        ddlcompany.SelectedValue = Convert.ToString(Dr["CompanyId"]);
                        ModelBind(Convert.ToInt64(Dr["CompanyId"]));
                        ddlmodel.SelectedValue = Convert.ToString(Dr["ModelId"]);
                        SubModelBind(Convert.ToInt64(Dr["ModelId"]));
                        ddlsubmodel.SelectedValue = Convert.ToString(Dr["SubModelId"]);
                        ddlrenttype.SelectedValue = Convert.ToString(Dr["RentTypeId"]);
                        txtOwner.Text = Convert.ToString(Dr["Owner"]);
                        txtMobile.Text = Convert.ToString(Dr["MobileNo"]);
                        txtxAddress.Text = Convert.ToString(Dr["Address"]);
                        txtprice.Text = Convert.ToString(Dr["price"]);
                        hidImageName.Value = Convert.ToString(Dr["Image"]);
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



        protected void rptcameraInfo_ItemCommand2(object source, RepeaterCommandEventArgs e)
        {
            Dal_camera d1 = new Dal_camera();
            switch (e.CommandName)
            {
                case "edit":
                    HidCamera.Value = Convert.ToString(e.CommandArgument);
                    CameraUpdateData(HidCamera.Value);
                    getCameraData(1);
                    break;
                case "status":
                    long CameraId = Convert.ToInt64(e.CommandArgument);
                    d1.FunStatusUpdate(CameraId);
                    getCameraData(1);
                    break;


            }
        }


        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            Dal_camera d1 = new Dal_camera();
            DataSet comdataset = new DataSet();
            comdataset = d1.FunSearchByCamera(Tsearch.Text);
            if (comdataset.Tables[0].Rows.Count > 0)
            {
                rptcameraInfo.DataSource = comdataset.Tables[0];
                rptcameraInfo.DataBind();

            }
            else
            {
                getCameraData(1);
                cleardata();
            }
        }
        #region pageing
        protected void getCameraData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet cameradataset = new DataSet();
                cameradataset = SqlHelper.ExecuteDataset(connection, "Camera_Select_SP");
                Bal_camera b1 = new Bal_camera();
                Dal_camera d1 = new Dal_camera();
                b1.cameraId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = Tsearch.Text.Trim();
                DataSet comDataset = d1.CameraMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptcameraInfo.DataSource = comDataset.Tables[0];
                        rptcameraInfo.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptcameraInfo.DataSource = null;
                    rptcameraInfo.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptcameraInfo.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCameraData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.getCameraData(pageIndex);
        }
        #endregion

        protected void ddlmodel_TextChanged(object sender, EventArgs e)
        {
            long smid = Convert.ToInt64(ddlmodel.SelectedValue);
            SubModelBind(smid);
        }

    }
}