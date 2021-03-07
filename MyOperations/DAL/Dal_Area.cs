using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using MyOperations.BAL;

namespace MyOperations.DAL
{
   public class Dal_Area
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void funInsertArea(Bal_Area b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Area_Insert_SP",b1.AreaName,b1.StateId,b1.CityId);
        }

        public DataSet functionselectarea()
        {
            return SqlHelper.ExecuteDataset(connection, "Area_Select_SP");
        }
        public void funStatusUpdate(long AreaId)
        {
            SqlHelper.ExecuteNonQuery(connection, "Area_Status_Update_SP",AreaId);
        }
        public DataSet getArea(long AreaId)
        {
            DataSet mydataset = new DataSet();
            mydataset = SqlHelper.ExecuteDataset(connection, "Area_Get_Record_By_Id_SP", AreaId);
            return mydataset;
        }
        public void funupdateData(Bal_Area b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Area_Update_SP", b1.AreaId, b1.AreaName,b1.StateId,b1.CityId);
        }
        public  DataSet funsearchData(string AreaName)
        {
            return SqlHelper.ExecuteDataset(connection, "Area_Search_SP", AreaName);
        }
        public DataSet CompanyMaster_Get_by_PageIndex(Bal_Area b1)
        {
            return SqlHelper.ExecuteDataset(connection, "Area_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
