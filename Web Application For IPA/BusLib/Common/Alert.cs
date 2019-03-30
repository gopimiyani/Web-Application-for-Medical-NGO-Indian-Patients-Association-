using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;


namespace BusLib.Common
{
    public class Alert
    {
        public const String _TableName = "Alert";
        #region properties

        private int Admin_ID = 0;

        public int Admin_ID1
        {
            get { return Admin_ID; }
            set { Admin_ID = value; }
        }

        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
        }
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


        public void GetAlert_Volunteer()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Alert_Volunteer, Ope.GetParams());
        }
    }
}
