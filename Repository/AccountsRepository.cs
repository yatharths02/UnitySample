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
        public UserInfo Login(string username, string password)
        {
            UserInfo userInfo = new UserInfo();
            lstParameters = new List<SqlParameter>();

            DataAccess.AddInParameter<string>(ref lstParameters, "@Username", username, SqlDbType.VarChar);
            DataAccess.AddInParameter<string>(ref lstParameters, "@Password", password, SqlDbType.VarChar);
            //Output Parameters
            DataAccess.AddOutParameter(ref lstParameters, "@Message", SqlDbType.VarChar);
            DataAccess.AddOutParameter(ref lstParameters, "@Error", SqlDbType.VarChar);
            DataAccess.AddOutParameter(ref lstParameters, "@Result", SqlDbType.Int);

            DataSet ds = DataAccess.ExecuteDataSet("USPCheckLogin", ref lstParameters);

            userInfo.Result = (int)lstParameters[4].Value;
            userInfo.ErrorMessage = (string)lstParameters[3].Value.ToString();
            userInfo.Message = (string)lstParameters[2].Value.ToString();

            if (userInfo.Result == 1)
            {
                if (ds !=null && ds.Tables.Count > 0)
                {
                    userInfo.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                    userInfo.isActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"]);
                }
            }

            DataAccess.ClearListParameters(ref lstParameters);
            return userInfo;
        }


    }
}
