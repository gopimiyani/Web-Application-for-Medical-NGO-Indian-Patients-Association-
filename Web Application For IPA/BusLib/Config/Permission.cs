using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Config
{
    public class Permission
    {
        private const string _TableName = "Permission";

        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
        }

        private int Page_ID = 0;

        public int Page_ID1
        {
            get { return Page_ID; }
            set { Page_ID = value; }
        }

        private bool IsInsert = false;

        public bool IsInsert1
        {
            get { return IsInsert; }
            set { IsInsert = value; }
        }

        private bool IsUpdate = false;

        public bool IsUpdate1
        {
            get { return IsUpdate; }
            set { IsUpdate = value; }
        }

        private bool IsDelete = false;

        public bool IsDelete1
        {
            get { return IsDelete; }
            set { IsDelete = value; }
        }

        private bool IsView = false;

        public bool IsView1
        {
            get { return IsView; }
            set { IsView = value; }
        }

        public void GetDataset()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Permission_Select,Ope.GetParams());
        }

        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Page_ID", Page_ID.ToString());
            Ope.AddParams("IsView", IsView.ToString());
            Ope.AddParams("IsInsert", IsInsert.ToString());
            Ope.AddParams("IsUpdate", IsUpdate.ToString());
            Ope.AddParams("IsDelete", IsDelete.ToString());
            
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Permission_Insert_Update, Ope.GetParams());
        }
        
    }
}
