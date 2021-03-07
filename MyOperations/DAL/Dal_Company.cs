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
   public  class Dal_Company
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void FunInsertData(Bal_Company b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Company_Insert_SP", b1.cname, b1.catid);
        }
        public DataSet FunUserData()
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "Company_Select_SP");
            return mydataset;
        }
        public void FunUpdateData(Bal_Company b1)
        {
            SqlHelper.ExecuteNonQuery(connection, "Company_Update_SP", b1.comid, b1.catid, b1.cname);
        }
        public DataSet CompanyGetRecored(long comid)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "Company_Get_Recored_By_Id_SP", comid);
            return mydataset;
        }
        public void FunStatusUpdate(long comid)
        {
            SqlHelper.ExecuteNonQuery(connection, "Company_Status_Update_SP", comid);
        }
        public DataSet FunSearchByCompanyName(string comname)
        {
            return SqlHelper.ExecuteDataset(connection, "Company_Search_SP", comname);
        }
        public DataSet CompanyMaster_Get_by_PageIndex(Bal_Company b1)
        {
            return SqlHelper.ExecuteDataset(connection, "Company_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }
}
