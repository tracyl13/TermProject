using System.Data.SqlClient;
using System.Data;
using Utilities;

namespace Restaurant_API.Models
{
    public class ReviewsManagement
    {
        //Create the review. Take in a review object, and uses it's data and a sql insert statment to add a review to the database.
        public int CreateReview(Reviews Reviews)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateReview";

            SqlParameter inputParameter = new SqlParameter("@ReviewerID", Reviews.ReviewerID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@RestaurantID", Reviews.RestaurantID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Date", Reviews.Date);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Date;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Time", Reviews.Time);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Time;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@FoodQuality", Reviews.FoodQuality);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 1;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Service", Reviews.Service);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 1;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Atmosphere", Reviews.Atmosphere);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 1;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Price", Reviews.Price);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 1;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Comment", Reviews.Comment);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Reviews.Comment.Length;
            objCommand.Parameters.Add(inputParameter);


            int status = objDB.DoUpdateUsingCmdObj(objCommand);
            return status;
        }


        //Shows all reviews made by the reviewer.
        public DataSet GetReviews(Reviews Reviews)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetReviewByReviewer";

            SqlParameter inputParameter = new SqlParameter("@ReviewerID", Reviews.ReviewerID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        //Gets review that is being modified. 
        public DataSet GetReviewModify(Reviews Reviews)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetReviewModify";

            SqlParameter inputParameter = new SqlParameter("@ReviewID", Reviews.ReviewID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        //Delete reviews
        public int DeleteReview(Reviews Reviews)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteReview";

            SqlParameter inputParameter = new SqlParameter("@ReviewID", Reviews.ReviewID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }


        //Modify the selected review
        public int ModifyReview(Reviews Reviews)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ModifyReview";

            SqlParameter inputParameter = new SqlParameter("@ReviewID", Reviews.ReviewID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Date", Reviews.Date);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Date;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Time", Reviews.Time);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Time;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@FoodQuality", Reviews.FoodQuality);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 1;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Service", Reviews.Service);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 1;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Atmosphere", Reviews.Atmosphere);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 1;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Price", Reviews.Price);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 1;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Comment", Reviews.Comment);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Reviews.Comment.Length;
            objCommand.Parameters.Add(inputParameter);


            return objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
}
