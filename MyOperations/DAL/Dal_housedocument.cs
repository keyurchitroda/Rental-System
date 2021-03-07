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
   public class Dal_housedocument
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void funInsertHouseDocument(Bal_Housedocument b1)
        {

            SqlHelper.ExecuteNonQuery(connection, "HouseDocument_Insert_SP", b1.Hid,b1.houseid,b1.DocumentType,b1.HImage);
        }
        public DataSet  funSelectHouseDocument()
        {
            return SqlHelper.ExecuteDataset(connection, "HouseDocument_Select_SP");
        }
        public void FunUpdateData(Bal_Housedocument b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "HouseDocument_Update_SP",b1.Did, b1.Hid,b1.houseid,b1.DocumentType, b1.HImage);
        }
        public DataSet HouseDocGetRecored(long hdid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "HouseDocument_Get_Recored_By_Id_SP", hdid);
            return mydataset;
        }
        public void FunStatusUpdate(long hdid)
        {
            SqlHelper.ExecuteNonQuery(connection, "HouseDocument_Status_Update_SP", hdid);
        }
        public DataSet FunSearchByHouseDocumentName(string search)
        {
            return SqlHelper.ExecuteDataset(connection, "HouseDocument_Search_SP", search);
        }
        public DataSet HouseDocumentMaster_Get_by_PageIndex(Bal_Housedocument b1)
        {
            return SqlHelper.ExecuteDataset(connection, "HouseDocument_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
