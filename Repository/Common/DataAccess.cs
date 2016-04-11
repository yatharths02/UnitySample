using Entities.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class DataAccess
    {
        public static string CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        public static void ExecuteNonQuery(string spname, ref List<SqlParameter> parameters)
        {
            try
            {
                if (!string.IsNullOrEmpty(spname))
                {
                    using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
                    {
                        using (SqlCommand sql = new SqlCommand(spname, con))
                        {
                            sql.CommandType = CommandType.StoredProcedure;
                            if (parameters != null && parameters.Count > 0)
                                sql.Parameters.AddRange(parameters.ToArray());

                            con.Open();
                            sql.ExecuteNonQuery();
                        }
                    }
               
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static T ExecuteScalar<T>(string spname, ref List<SqlParameter> parameters)
        {
            try
            {
                if (!string.IsNullOrEmpty(spname))
                {
                    using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
                    {
                        using (SqlCommand sql = new SqlCommand(spname, con))
                        {
                            sql.CommandType = CommandType.StoredProcedure;
                            if (parameters != null && parameters.Count > 0)
                                sql.Parameters.AddRange(parameters.ToArray());

                            con.Open();
                            return (T)sql.ExecuteScalar();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return default(T);
        }

        public static DataSet ExecuteDataSet(string spname, ref List<SqlParameter> parameters)
        {
            try
            {
                if (!string.IsNullOrEmpty(spname))
                {
                    using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
                    {
                        using (SqlCommand sql = new SqlCommand(spname, con))
                        {
                            sql.CommandType = CommandType.StoredProcedure;
                            if (parameters != null && parameters.Count > 0)
                                sql.Parameters.AddRange(parameters.ToArray());

                            con.Open();
                            DataSet ds = new DataSet();
                            using (SqlDataAdapter da = new SqlDataAdapter(sql))
                            {
                                da.Fill(ds);
                            }
                            return  ds ;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }

        public static void AddInParameter<T>(ref List<SqlParameter> lstParameters, string name, T value, SqlDbType dbType, int size = 100)
        {
            if (dbType == SqlDbType.VarChar || dbType == SqlDbType.NVarChar)
                lstParameters.Add(new SqlParameter(name, value) { Direction = ParameterDirection.Input, Size = size });
            else
                lstParameters.Add(new SqlParameter(name, value) { Direction = ParameterDirection.Input});
        }

        public static void AddOutParameter(ref List<SqlParameter> lstParameters, string name, SqlDbType dbType, int size = 100)
        {
            if (dbType == SqlDbType.VarChar || dbType == SqlDbType.NVarChar)
                 lstParameters.Add(new SqlParameter(name, dbType) { Direction = ParameterDirection.Output, Size = size });
            else
                 lstParameters.Add(new SqlParameter(name, dbType) { Direction = ParameterDirection.Output });

        }

        public static void ClearListParameters(ref List<SqlParameter> lstParameters)
        {
            lstParameters.Clear();
            lstParameters = null;
        }
    }
}
