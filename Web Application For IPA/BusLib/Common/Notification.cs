using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Common
{
    public class Notification
    {
        public const String _TableName = "Notification";
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


        public void GetNotification_Admin()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Notification_Admin, Ope.GetParams());
        }

        public void GetNotification_Volunteer()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString()); 
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Notification_Volunteer, Ope.GetParams());
        }




    }
}
