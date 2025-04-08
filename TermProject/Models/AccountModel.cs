using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Utilities;
using System.Data.SqlClient;

namespace TermProject.Models
{
    public class AccountModel
    {
        private string email;
        private string password;
        private string accountType;
        private string securityQuestionOne;
        private string securityQuestionTwo;
        private string securityQuestionThree;
        private string verificationCode;
        private string verificationStatus;

        [Required(ErrorMessage = "Please enter a email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [Required(ErrorMessage = "Please enter a password")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [Required(ErrorMessage = "Please select a account type")]
        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        [Required(ErrorMessage = "Please answer all security questions")]
        public string SecurityQuestionOne
        {
            get { return securityQuestionOne; }
            set { securityQuestionOne = value; }
        }

        [Required(ErrorMessage = "Please answer all security questions")]
        public string SecurityQuestionTwo
        {
            get { return securityQuestionTwo; }
            set { securityQuestionTwo = value; }
        }

        [Required(ErrorMessage = "Please answer all security questions")]
        public string SecurityQuestionThree
        {
            get { return securityQuestionThree; }
            set { securityQuestionThree = value; }
        }

        public string VerificationCode
        {
            get { return verificationCode; }
            set { verificationCode = value; }
        }

        public string VerificationStatus
        {
            get { return verificationStatus; }
            set { verificationStatus = value; }
        }

        public int CreateAccount(AccountModel Account)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CreateAccount";

            SqlParameter inputParameter = new SqlParameter("@Username", Account.email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = Account.email.Length;
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

            int status = objDB.DoUpdateUsingCmdObj(objCommand);
            return status;
        }

    }
}
