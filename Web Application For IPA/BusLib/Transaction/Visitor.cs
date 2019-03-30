using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public  class Visitor
    {
        public const String _TableName = "Visitor";

        #region properties

        private int NoOfVisitors = 0;

        public int NoOfVisitors1
        {
            get { return NoOfVisitors; }
            set { NoOfVisitors = value; }
        }

        private DataSet ds = new DataSet();
        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        #endregion

        public void GetDataSet()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, "Count", StoreProcedures.SP_Visitor_Select, Ope.GetParams());
        }

        public int Insert()
        {
            Ope.Clear();

            Ope.AddParams("NoOfVisitors", NoOfVisitors.ToString());

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Visitor_Insert, Ope.GetParams());

        }

        public int Update()
        {
            Ope.Clear();

            Ope.AddParams("NoOfVisitors", NoOfVisitors.ToString());

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Visitor_Update, Ope.GetParams());

        }
    }
}
