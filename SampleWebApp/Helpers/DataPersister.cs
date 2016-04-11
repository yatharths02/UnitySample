using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Helpers
{
    [Serializable]
    public class DataPersister
    {
        #region Static Properties
        public static bool HasValues
        {
            get
            {
                if (HttpContext.Current.Session != null)
                    return HttpContext.Current.Session["DataPersister"] != null;
                return false;
            }
        }
        public static DataPersister Current
        {
            get
            {
                return DataPersister.HasValues ? (DataPersister)HttpContext.Current.Session["DataPersister"] : DataPersister.LoadDefault();
            }
            set
            {
                if (HttpContext.Current.Session != null)
                    HttpContext.Current.Session["DataPersister"] = value;
            }
        }

        public static string ServerPath { get; set; }
        #endregion

        #region Global Values
        public UserInfo userModel { get; set; }

        #endregion

        #region Config Values


        #endregion


        #region Constructor and Methods

        private DataPersister()
        {

        }

        private static DataPersister LoadDefault()
        {
            DataPersister _dataPersister = new DataPersister();
            DataPersister.Current = _dataPersister;
            return _dataPersister;
        }
        #endregion
    }
}