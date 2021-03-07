using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Web;
using MyOperations.BAL;
using System.Data.SqlClient;

namespace MyOperations.DAL
{
    public class Dal_Category
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FunInsertData(Bal_Category b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Category_Insert_SP", b1.cname);
        }

        public DataSet FunUserData()
        {
           DataSet mydataset= SqlHelper.ExecuteDataset(connection, "Category_Select_SP");
            return mydataset;
        }
        public void FunUpdateData(Bal_Category b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Category_Update_SP", b1.cid,b1.cname);
        }
        public DataSet CatGetRecored(long cid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "Category_Get_Recored_By_Id_SP",cid );
            return mydataset;
        }
        public void FunStatusUpdate(long cid)
        {
            SqlHelper.ExecuteNonQuery(connection, "Category_Status_Update_SP",cid);
        }
        public DataSet FunSearchByCategoryName(string cname)
        {
            return SqlHelper.ExecuteDataset(connection, "Category_Search_SP", cname);
        }
        public DataSet CategoryMaster_Get_by_PageIndex(Bal_Category b1)
        {
            return SqlHelper.ExecuteDataset(connection, "Category_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }


}
