using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyOperations.BAL;
using MyOperations.DAL;
using MyOperations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RentSystem
{
    public partial class visitor : System.Web.UI.MasterPage
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
     
            if (!IsPostBack)
            {
                try
                {
                    CompanyBind();
                    ddlModel.Items.Insert(0,new ListItem("-Select Model-","0"));
                    ddlSubModel.Items.Insert(0,new ListItem("-Select SubModel-","0"));
                    CompanyBind1();
                    ddlModel1.Items.Insert(0, new ListItem("-Select Model-","0"));
                    ddlSubModel1.Items.Insert(0, new ListItem("-Select SubModel-", "0"));
                    StateBind();
                    ddlCity.Items.Insert(0, new ListItem("-Select City-", "0"));
                    ddlArea.Items.Insert(0, new ListItem("-Select Area-", "0"));
                    HouseTypeBind();
                }catch(Exception ex)
                { }
                getCategory();

            }
        }

        protected void getCategory()
        {
            DataSet DSCategory = SqlHelper.ExecuteDataset(connection, "Category_Select_SP");
            if (DSCategory.Tables[0].Rows.Count > 0)
            {
                rptCategory.DataSource = DSCategory.Tables[0];
                rptCategory.DataBind();
            }
            else
            {
                rptCategory.DataSource = null;
                rptCategory.DataBind();
            }
        }
        protected void CompanyBind()
        {
            DataSet comdataset = new DataSet();
            comdataset = SqlHelper.ExecuteDataset(connection, "Company_Get_SP_By_CategoryId",1);
            if (comdataset.Tables[0].Rows.Count > 0)
            {
                ddlCompany.DataSource = comdataset.Tables[0];
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0,new ListItem("-Select Company-","0"));
            }
        }
        protected void ModelBind(long mid)
        {
            DataSet moddataset = new DataSet();
            moddataset = SqlHelper.ExecuteDataset(connection, "Model_Get_By_CompanyId_SP", mid);
            if (moddataset.Tables[0].Rows.Count > 0)
            {
                ddlModel.DataSource = moddataset.Tables[0];
                ddlModel.DataTextField = "ModelName";
                ddlModel.DataValueField = "ModelId";
                ddlModel.DataBind();
                ddlModel.Items.Insert(0,new ListItem("-Select Model-","0"));
            }
        }
        protected void SubModelBind(long smid)
        {
            DataSet submoddataset = new DataSet();
            submoddataset = SqlHelper.ExecuteDataset(connection, "SubModel_Get_By_ModelId_SP", smid);
            if (submoddataset.Tables[0].Rows.Count > 0)
            {
                ddlSubModel.DataSource = submoddataset.Tables[0];
                ddlSubModel.DataTextField = "SubModelName";
                ddlSubModel.DataValueField = "SubModelId";
                ddlSubModel.DataBind();
                ddlSubModel.Items.Insert(0, new ListItem("-Select SubModel-","0"));
            }
        }
        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            long mid = Convert.ToInt64(ddlCompany.SelectedValue);
            ModelBind(mid);
        }

        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            long smid = Convert.ToInt64(ddlModel.SelectedValue);
            SubModelBind(smid);
        }

        protected void CompanyBind1()
        {
            DataSet comdataset = new DataSet();
            comdataset = SqlHelper.ExecuteDataset(connection, "Company_Get_SP_By_CategoryId",3);
            if (comdataset.Tables[0].Rows.Count > 0)
            {
                ddlCompany1.DataSource = comdataset.Tables[0];
                ddlCompany1.DataTextField = "CompanyName";
                ddlCompany1.DataValueField = "CompanyId";
                ddlCompany1.DataBind();
                ddlCompany1.Items.Insert(0, new ListItem("-Select Company-","0"));
            }
        }
        protected void ModelBind1(long mid)
        {
            DataSet moddataset = new DataSet();
            moddataset = SqlHelper.ExecuteDataset(connection, "Model_Get_By_CompanyId_SP", mid);
            if (moddataset.Tables[0].Rows.Count > 0)
            {
                ddlModel1.DataSource = moddataset.Tables[0];
                ddlModel1.DataTextField = "ModelName";
                ddlModel1.DataValueField = "ModelId";
                ddlModel1.DataBind();
                ddlModel1.Items.Insert(0, new ListItem("-Select Model-","0"));
            }
        }
        protected void SubModelBind1(long smid)
        {
            DataSet submoddataset = new DataSet();
            submoddataset = SqlHelper.ExecuteDataset(connection, "SubModel_Get_By_ModelId_SP", smid);
            if (submoddataset.Tables[0].Rows.Count > 0)
            {
                ddlSubModel1.DataSource = submoddataset.Tables[0];
                ddlSubModel1.DataTextField = "SubModelName";
                ddlSubModel1.DataValueField = "SubModelId";
                ddlSubModel1.DataBind();
                ddlSubModel1.Items.Insert(0, new ListItem("-Select SubModel-", "0"));
            }
        }

        protected void ddlCompany1_SelectedIndexChanged(object sender, EventArgs e)
        {
            long mid = Convert.ToInt64(ddlCompany1.SelectedValue);
            ModelBind1(mid);
        }

        protected void ddlModel1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            long smid = Convert.ToInt64(ddlModel1.SelectedValue);
            SubModelBind1(smid);
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
                ddlhousetype.Items.Insert(0, new ListItem("-Select HouseType-","0"));
            }
        }

       

        protected void btnsearchCar_Click(object sender, EventArgs e)
        {
            long CarCompany = Convert.ToInt64(ddlCompany.SelectedValue.ToString());
            long CarModel = Convert.ToInt64(ddlModel.SelectedValue.ToString());
            long CarSubmodel = Convert.ToInt64(ddlSubModel.SelectedValue.ToString());
            Response.Redirect("search.aspx?&Company="+CarCompany+"&Model="+CarModel+"&CarSubModel="+CarSubmodel+"&CType=car");
        }

        protected void btnsearchCamera_Click(object sender, EventArgs e)
        {
            long CameraCompany = Convert.ToInt64(ddlCompany1.SelectedValue.ToString());
            long CameraModel = Convert.ToInt64(ddlModel1.SelectedValue.ToString());
            long CameraSubmodel = Convert.ToInt64(ddlSubModel1.SelectedValue.ToString());
            Response.Redirect("search.aspx?&Company=" + CameraCompany + "&Model=" + CameraModel + "&SubModel=" +CameraSubmodel + "&CType=camera");
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
                ddlState.Items.Insert(0, new ListItem("-Select State-","0"));
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
                ddlCity.Items.Insert(0, new ListItem("-Select city-","0"));
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
            ddlArea.Items.Insert(0, new ListItem("-Select Area-","0"));
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            long cid = Convert.ToInt64(ddlState.SelectedValue);
            CityBind(cid);

        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            long aid = Convert.ToInt64(ddlCity.SelectedValue);
            AreaBind(aid);

        }

        protected void btnsearchHouse_Click(object sender, EventArgs e)
        {
            long State = Convert.ToInt64(ddlState.SelectedValue.ToString());
            long City= Convert.ToInt64(ddlCity.SelectedValue.ToString());
            long Area = Convert.ToInt64(ddlArea.SelectedValue.ToString());
            long HouseType= Convert.ToInt64(ddlhousetype.SelectedValue.ToString());
            Response.Redirect("search.aspx?&State=" + State + "&City=" + City + "&Area=" + Area + "&HouseType=" + HouseType + "&CType=house");
        }

       
    }
}