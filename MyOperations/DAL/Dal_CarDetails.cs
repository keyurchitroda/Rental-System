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
    public class Dal_CarDetails
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void FunInsertData(Bal_CarDetails b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "CarDetails_Insert_SP", b1.comid,b1.modid,b1.submid,b1.cno, b1.cregno,b1.cid,b1.sid ,b1.cowner, b1.coadd, b1.comobile, b1.price, b1.cimage,b1.renttypeid);
        }
        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "CarDetails_Select_SP");
            return mydataset;
        }


        public void FunUpdateData(Bal_CarDetails b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "CarDetails_Update_SP",b1.cdid,b1.comid,b1.modid,b1.submid,
                b1.cno,b1.cregno,b1.sid,b1.cid, b1.cowner, b1.comobile,b1.coadd,b1.price,b1.cimage,b1.renttypeid);
        }

        public DataSet CarGetRecored(long cdid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "CarDetails_Get_Record_By_Id_SP", cdid);
            return mydataset;
        }
        public void FunStatusUpdate(long cdid)
        {
            SqlHelper.ExecuteNonQuery(connection, "CarDetails_Status_Update_SP", cdid);
        }
        public DataSet FunSearchByCarDetailsName(string search)
        {
            return SqlHelper.ExecuteDataset(connection, "CarDetails_Search_SP", search);
        }
        public DataSet CarDetailsMaster_Get_by_PageIndex(Bal_CarDetails b1)
        {
            return SqlHelper.ExecuteDataset(connection, "CarDetails_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }
}
