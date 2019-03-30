using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Common
{
    public class Common
    {
        public const String _TableName = "Common";
     
        #region properties

        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        private SqlDataReader dr;

        public SqlDataReader Dr
        {
            get { return dr; }
            set { dr = value; }
        }

        #endregion

        //public void GetNewID()
        //{
        //    if (ds != null)
        //    {
        //        ds.Clear();
        //    }
        //    Ope.Clear();
        //    Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_GetNewID, Ope.GetParams());
        //}

    }
}
