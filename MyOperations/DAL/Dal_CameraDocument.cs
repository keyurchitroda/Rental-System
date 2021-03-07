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
    public class Dal_CameraDocument
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void FunInsertCameraDocument(Bal_CameraDocument b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "CameraDocument_insert_SP",b1.companyId,b1.DocumentName,b1.Image);
        }
        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "CameraDocument_Select_SP");
            return mydataset;
        }
        public void FunUpdateData(Bal_CameraDocument b1)
        {
            SqlHelper.ExecuteDataset(connection, "CameraDocument_Update_SP", b1.DocumentId, b1.companyId, b1.DocumentName, b1.Image);
        }

        public DataSet CameraDocGetRecored(long cdid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "CameraDocument_Get_Recored_By_Id_SP", cdid);
            return mydataset;
        }

        public void FunStatusUpdate(long cdid)
        {
            SqlHelper.ExecuteNonQuery(connection, "CameraDocument_Status_Update_SP", cdid);
        }

        public DataSet FunSearchByDocName(string docname)
        {
            return SqlHelper.ExecuteDataset(connection, "CameraDocument_Search_SP", docname);
        }
        public DataSet CompanyDocumentMaster_Get_by_PageIndex(Bal_CameraDocument b1)
        {
            return SqlHelper.ExecuteDataset(connection, "CameraDocument_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }
}
