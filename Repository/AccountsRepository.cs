using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        List<SqlParameter> lstParameters;
        public LoginStatus Login(string username, string password)
        {
            LoginStatus loginStatus;
            lstParameters = new List<SqlParameter>();

            DataAccess.AddInParameter<string>(ref lstParameters, "@Username", username, SqlDbType.VarChar);
            DataAccess.AddInParameter<string>(ref lstParameters, "@Password", password, SqlDbType.VarChar);
            //Output Parameters
            DataAccess.AddOutParameter(ref lstParameters, "@Message", SqlDbType.VarChar);
            DataAccess.AddOutParameter(ref lstParameters, "@Error", SqlDbType.VarChar);
            DataAccess.AddOutParameter(ref lstParameters, "@Result", SqlDbType.Int);

            DataSet ds = DataAccess.ExecuteDataSet("USPCheckLogin", ref lstParameters);

            loginStatus.Result = (int)lstParameters[4].Value;
            loginStatus.ErrorMessage = (string)lstParameters[3].Value.ToString();
            loginStatus.Message = (string)lstParameters[2].Value.ToString();

            DataAccess.ClearListParameters(ref lstParameters);
            return loginStatus;
        }


    }
}
