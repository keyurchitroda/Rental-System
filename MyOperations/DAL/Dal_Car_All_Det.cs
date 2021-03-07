using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using MyOperations.BAL;

namespace MyOperations.DAL
{
   public class Dal_Car_All_Det
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataSet FunUserData(long id)
        {
            DataSet mydataset = SqlHelper.ExecuteDataset(connection, "Car_all_Details_Select_SP",id);
            return mydataset;
        }
    }
}
