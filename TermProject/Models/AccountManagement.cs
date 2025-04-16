using System.Data.SqlClient;
using System.Data;
using Utilities;

namespace TermProject.Models
{
    public class AccountManagement
    {
        public int CreateAccount(Account Account)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CreateAccount";

            SqlParameter inputParameter = new SqlParameter("@Email", Account.Email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.Email.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Password", Account.Password);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.Password.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@AccountType", Account.AccountType);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.AccountType.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@SecurityQuestionOne", Account.SecurityQuestionOne);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.SecurityQuestionOne.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@SecurityQuestionOne", Account.SecurityQuestionTwo);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.SecurityQuestionTwo.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@SecurityQuestionThree", Account.SecurityQuestionThree);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.SecurityQuestionThree.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@VerificationCode", Account.VerificationCode);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.VerificationCode.Length;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@VerificationStatus", Account.VerificationStatus);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.VerificationStatus.Length;
            objCommand.Parameters.Add(inputParameter);

            int status = objDB.DoUpdateUsingCmdObj(objCommand);
            return status;
        }
    }
}

