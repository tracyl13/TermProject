using System.Data.SqlClient;
using System.Data;
using Utilities;

namespace TermProject.Models
{
    public class MainManagement
    {
            /*Used to get the average rating along with account summery information. Does this using the SQL average calculator, and returning a extra column which is the average of all the
             * averages. Value return are grouped by RestaurantID and connected to that restauran's summery information by using a left join.
             */
        public DataSet GetRestaurantSummery()
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAverageTry";

                return objDB.GetDataSetUsingCmdObj(objCommand);
            }

        //Goes through the Restaurant and return all cusiens without duplicates. Used to populate the checkbox list in the main menu.
        public DataSet GetCuisine()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCuisine";

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetCity()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCity";

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

    }
}
