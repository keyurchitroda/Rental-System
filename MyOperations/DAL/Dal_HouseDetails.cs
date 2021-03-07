using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOperations.BAL;
using MyOperations;

namespace MyOperations.DAL
{
    public class Dal_HouseDetails
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FunInsertHouse(Bal_HouseDetails b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "HouseDetails_Insert_SP",b1.HouseNo, b1.HouseOwner, b1.HouseAddress,b1.MobileNo,b1.StateId,b1.CityId,b1.AreaId,b1.HouseTypeId,b1.HImage);
        }

        public DataSet fungethouse()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection,"HouseDetail_Select_SP");
            return mydataset;
        }
        public void funStatusUpdate(long hid)
        {
            SqlHelper.ExecuteNonQuery(connection, "HouseDetail_Status_Update", hid);
        }

        public void HouseUpdate(Bal_HouseDetails b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "HouseDetails_Update_SP", b1.HouseId,b1.HouseNo, b1.HouseOwner, b1.HouseAddress,b1.MobileNo, b1.StateId, b1.CityId, b1.AreaId, b1.HouseTypeId, b1.HImage);
        }
        public DataSet HouseGetRecord(long hid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "HouseDetail_Get_Id_SP", hid);
            return mydataset;
        }
        public DataSet FunSearchByHouseDetails(string Search)
        {
            return SqlHelper.ExecuteDataset(connection, "HouseDetails_Search_SP", Search);
        }
        public DataSet CompanyMaster_Get_by_PageIndex(Bal_HouseDetails b1)
        {
            return SqlHelper.ExecuteDataset(connection, "HouseDetails_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
