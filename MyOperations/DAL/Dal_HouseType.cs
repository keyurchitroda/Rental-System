using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MyOperations.BAL;
using MyOperations;
using System.Web;

namespace MyOperations.DAL
{
   public class Dal_HouseType
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void funInsertHouse(Bal_HouseType b1)
        {
           
            SqlHelper.ExecuteNonQuery(connection, "HouseType_Insert_SP", b1.HouseType,b1.rentTypeId, b1.Price);
        }

        public DataSet HotelTypeGetUser()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "HouseType_Select_SP");
            return mydataset;
        }
        public DataSet getrecord(long hid)
        {
            DataSet mydataset = new DataSet();
            mydataset = SqlHelper.ExecuteDataset(connection, "HouseType_Get_Id_SP", hid);
            return mydataset;
        }
        public void HouseUpdateData(Bal_HouseType b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "HouseType_Update_SP", b1.HouseTypeId,b1.HouseType,b1.rentTypeId ,b1.Price);
        }
        public void funStatusUpdate(long hid)
        {
            SqlHelper.ExecuteNonQuery(connection, "HouseType_Status_Update_SP", hid);
        }
        public DataSet FunSearchByHouseTypeName(string hname)
        {
            return SqlHelper.ExecuteDataset(connection, "HouseType_Search_SP", hname);
        }
        public DataSet CompanyMaster_Get_by_PageIndex(Bal_HouseType b1)
        {
            return SqlHelper.ExecuteDataset(connection, "HouseType_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
