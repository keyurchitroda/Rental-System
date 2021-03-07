using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MyOperations.BAL;
using System.Configuration;
using System.Web;

namespace MyOperations.DAL
{
    public class Dal_City
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FunInsertCity(Bal_City b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "City_Insert_SP", b1.CityName,b1.StateId);
        }
        public void FunUpdateData(Bal_City b1)
        {
            SqlHelper.ExecuteDataset(connection, "City_Update_SP", b1.CityId, b1.CityName,b1.StateId);
        }
        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "City_Select_SP");
            return mydataset;
        }
        public DataSet SubCatGetRecored(long cid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "City_Get_Recored_By_Id_SP", cid);
            return mydataset;
        }
        public void FunStatusUpdate(long cid)
        {
            SqlHelper.ExecuteNonQuery(connection, "City_Status_Update_SP", cid);
        }
        public DataSet FunSearchByCityName(string cname)
        {
            return SqlHelper.ExecuteDataset(connection, "City_Search_SP", cname);
        }
        public DataSet CityMaster_Get_by_PageIndex(Bal_City b1)
        {
            return SqlHelper.ExecuteDataset(connection, "City_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
