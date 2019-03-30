using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class Notification
    {
        public const string _TableName = "";

        #region properties

        private int Notification_ID = 0;

        public int Notification_ID1
        {
            get { return Notification_ID; }
            set { Notification_ID = value; }
        }

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

    //    private String Notification = "";

        //public String Notification1
        //{
        //    get { return Notification; }
        //    set { Notification = value; }
        //}

        private String Entrydate = "";

        public String Entrydate1
        {
            get { return Entrydate; }
            set { Entrydate = value; }
        }

        private String EntryTime = "";

        public String EntryTime1
        {
            get { return EntryTime; }
            set { EntryTime = value; }
        }

        private String IP = "";

        public String IP1
        {
            get { return IP; }
            set { IP = value; }
        }

        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }


        #endregion

        public void GetNotification_Admin()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Notification_Admin, Ope.GetParams());
        }

        public void GetNotification_Volunteer()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Notification_Volunteer, Ope.GetParams());
        }

    }
}
