using System.Data.SqlClient;
using System.Data;
using Utilities;

namespace Restaurant_API.Models
{
    public class ReservationManagement
    {
        //Get all reservation for a restaurant
        public DataSet GetReservation(Reservation Reservation)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservation";

            SqlParameter inputParameter = new SqlParameter("@RestaurantID", Reservation.RestaurantID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        //Gets reservation that is being modified.
        public DataSet GetReservationModify(Reservation Reservation)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservationModify";

            SqlParameter inputParameter = new SqlParameter("@ReservationID", Reservation.ReservationID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        /*Restaurant has not been made yet. Uncomment after it has been made
        //Get's the email of the restaurant/represenative which will be used as the sender for email event.
        public DataSet GetRepresenativeEmail(Restaurant Restaurant)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRepresenativeEmail";

            SqlParameter inputParameter = new SqlParameter("@RepresentativeID", Restaurant.RepresentativeID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }*/

        //Execute the procedure that deletes the selected row.
        public int DeleteReservation(Reservation Reservation)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReservation";

            SqlParameter inputParameter = new SqlParameter("@ReservationID", Reservation.ReservationID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }


        //Update the selected reservation with the changes.
        public int ModifyReservation(Reservation Reservation)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ModifyReservation";

            SqlParameter inputParameter = new SqlParameter("@ReservationID", Reservation.ReservationID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@FirstName", Reservation.FirstName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Reservation.FirstName.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@LastName", Reservation.LastName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Reservation.LastName.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@PhoneNumber", Reservation.PhoneNumber);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Reservation.PhoneNumber.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Email", Reservation.Email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Reservation.Email.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Date", Reservation.Date);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Date;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Time", Reservation.Time);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Time;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@PartySize", Reservation.PartySize);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Reservation.PartySize.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@SpecialRequest", Reservation.SpecialRequest);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Reservation.SpecialRequest.Length;
            objCommand.Parameters.Add(inputParameter);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
}
