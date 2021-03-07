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
    public class Dal_camera
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void FunInsertCamera(Bal_camera b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Camera_insert_SP", b1.companyId,b1.modelId,b1.submodelId,b1.rentTypeId,b1.owner,b1.mobile,b1.address,b1.price,b1.image);
        }
        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "Camera_Select_SP");
            return mydataset;
        }
        public void CameraUpdateData(Bal_camera b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Camera_UpDate_Sp", b1.cameraId,b1.companyId,b1.modelId,b1.submodelId,b1.rentTypeId,b1.owner,b1.mobile,b1.address,b1.price,b1.image);
        }

        public DataSet CameraGetRecored(long cameraId)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "Camera_Get_Record_By_Id_SP", cameraId);
            return mydataset;
        }
        public DataSet FunSearchByCamera(string owner)
        {
            return SqlHelper.ExecuteDataset(connection, "Camera_Search_SP", owner);
        }
        public void FunStatusUpdate(long CameraId)
        {
            SqlHelper.ExecuteNonQuery(connection, "Camera_Status_Update_SP", CameraId);
        }

        public DataSet CameraMaster_Get_by_PageIndex(Bal_camera b1)
        {
            return SqlHelper.ExecuteDataset(connection, "Camera_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }
}
