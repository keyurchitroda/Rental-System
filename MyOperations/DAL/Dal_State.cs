using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MyOperations.BAL;
using MyOperations.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyOperations.DAL
{
   public class Dal_State
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FunInsertData(Bal_State b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "State_Insert_SP", b1.StateName);
        }
        public void FunUpdateData(Bal_State b1)
        {
            SqlHelper.ExecuteDataset(connection, "State_Update_SP",b1.StateId,b1.StateName);
        }
        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "State_Select_SP");
            return mydataset;
        }
        public DataSet SubCatGetRecored(long scid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "State_Get_Recored_By_Id_SP", scid);
            return mydataset;
        }
        public void FunStatusUpdate(long scid)
        {
            SqlHelper.ExecuteNonQuery(connection, "State_Status_Update_SP", scid);
        }
        public DataSet FunSearchByStateName(string sname)
        {
            return SqlHelper.ExecuteDataset(connection, "State_Search_SP", sname);
        }
        public DataSet StateMaster_Get_by_PageIndex(Bal_State b1)
        {
            return SqlHelper.ExecuteDataset(connection, "State_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }
}
