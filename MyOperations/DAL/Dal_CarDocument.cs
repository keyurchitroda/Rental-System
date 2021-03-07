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
    public class Dal_CarDocument
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FunInsertData(Bal_CarDocument b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "CarDocument_Insert_SP", b1.doctype, b1.cdid,b1.image);
        }

        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "CarDocument_Select_SP");
            return mydataset;
        }
        public void FunUpdateData(Bal_CarDocument b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "CarDocument_Update_SP", b1.docid, b1.cdid, b1.doctype,b1.image);
        }
        public DataSet CarDocGetRecored(long docid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "CarDocument_Get_Recored_By_Id_SP", docid);
            return mydataset;
        }
        public void FunStatusUpdate(long docid)
        {
            SqlHelper.ExecuteNonQuery(connection, "CarDocument_Status_Update_SP", docid);
        }
        public DataSet FunSearchByCarDocumentName(string search)
        {
            return SqlHelper.ExecuteDataset(connection, "CarDocument_Search_SP", search);
        }
        public DataSet CarDocument_Get_by_PageIndex(Bal_CarDocument b1)
        {
            return SqlHelper.ExecuteDataset(connection, "CarDocument_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}

