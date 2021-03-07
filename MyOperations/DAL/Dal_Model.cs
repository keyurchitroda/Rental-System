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
    public class Dal_Model
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void FunInsertData(Bal_Model b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Model_Insert_SP", b1.mname, b1.comid);
        }
        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "Model_Select_SP");
            return mydataset;
        }
        public void FunUpdateData(Bal_Model b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Model_Update_SP", b1.modid, b1.comid, b1.mname);
        }
        public DataSet ModelGetRecored(long modid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "Model_Get_Recored_By_Id_SP", modid);
            return mydataset;
        }
        public void FunStatusUpdate(long modid)
        {
            SqlHelper.ExecuteNonQuery(connection, "Model_Status_Update_SP", modid);
        }
        public DataSet FunSearchByModelName(string modname)
        {
            return SqlHelper.ExecuteDataset(connection, "Model_Search_SP", modname);
        }
        public DataSet CompanyMaster_Get_by_PageIndex(Bal_Model b1)
        {
            return SqlHelper.ExecuteDataset(connection, "Model_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }
}

