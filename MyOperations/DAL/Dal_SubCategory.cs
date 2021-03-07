using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MyOperations.BAL;
using System.Data.SqlClient;

namespace MyOperations.DAL
{
    public class Dal_SubCategory
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void FunInsertData(Bal_SubCategory b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Subcategory_Insert_SP", b1.scname,b1.cid);
        }

        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "SubCategory_Select_SP");
            return mydataset;
        }
        public void FunUpdateData(Bal_SubCategory b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "SubCategory_Update_SP", b1.scid, b1.cid,b1.scname);
        }
        public DataSet SubCatGetRecored(long scid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "SubCategory_Get_Recored_By_Id_SP", scid);
            return mydataset;
        }
        public void FunStatusUpdate(long scid)
        {
            SqlHelper.ExecuteNonQuery(connection, "SubCategory_Status_Update_SP", scid);
        }
        public DataSet FunSearchBySubCategoryName(string scname)
        {
            return SqlHelper.ExecuteDataset(connection,"SubCategory_Search_SP", scname);
        }
        public DataSet SubCategoryMaster_Get_by_PageIndex(Bal_SubCategory b1)
        {
            return SqlHelper.ExecuteDataset(connection, "SubCategory_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }
}
