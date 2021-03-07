using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOperations.BAL;
using System.Web;

namespace MyOperations.DAL
{
    public class Dal_RentType
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FunInsertData(Bal_RentType b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "RentType_Insert_SP", b1.RentTypeName,b1.Categoryid);
        }
       
        public void FunUpdateData(Bal_RentType b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "RentType_Update_SP", b1.RentTypeid, b1.RentTypeName,b1.Categoryid);
        }
        public DataSet RentTypeGetRecored(long rid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "RentType_Get_Recored_By_Id_SP", rid);
            return mydataset;
        }
        public void FunStatusUpdate(long scid)
        {
            SqlHelper.ExecuteNonQuery(connection, "RentType_Status_Update_SP", scid);
        }

        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "RentType_Select_SP");
            return mydataset;

        }

        public DataSet FunSearchByRentTypeName(string rtname)
        {
            return SqlHelper.ExecuteDataset(connection, "RentType_Search_SP", rtname);
        }
        public DataSet RentTypeMaster_Get_by_PageIndex(Bal_RentType b1)
        {
            return SqlHelper.ExecuteDataset(connection, "RentType_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
