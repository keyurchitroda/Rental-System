using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyOperations.BAL;

namespace MyOperations.DAL
{
    public class Dal_SubModel
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void FunInsertData(Bal_SubModel b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "SubModel_Insert_SP",b1.submname,b1.comid,b1.mid );
        }
        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "SubModel_Select_SP");
            return mydataset;
        }

        public void FunUpdateData(Bal_SubModel b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "SubModel_Update_SP", b1.submid, b1.comid,b1.mid,b1.submname);
        }

        public DataSet SubModGetRecored(long smid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "SubModel_Get_Recored_By_Id_SP", smid);
            return mydataset;
        }
        public void FunStatusUpdate(long smid)
        {
            SqlHelper.ExecuteNonQuery(connection, "SubModel_Status_Update_SP", smid);
        }
        public DataSet FunSearchBySubModelName(string search)
        {
            return SqlHelper.ExecuteDataset(connection, "SubModel_Search_SP", search);
        }
        public DataSet SubModelMaster_Get_by_PageIndex(Bal_SubModel b1)
        {
            return SqlHelper.ExecuteDataset(connection, "SubModel_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
