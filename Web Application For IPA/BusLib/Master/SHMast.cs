using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Master
{
    public class SHMast
    {
        public const String _TableName="StateMaster";
      
        private int SHID = 0;

        public int SHID1
        {
            get { return SHID; }
            set { SHID = value; }
        }

        private String Name = "";

        public String Name1
        {
            get { return Name; }
            set { Name = value; }
        }
        
        private DataSet ds=new DataSet();

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

        public void GetDataSet(string Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Name", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_SHMaster_Select, Ope.GetParams());


        }


       
        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("ID", SHID.ToString());
            Ope.AddParams("Name", Name);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_SHMaster_Insert, Ope.GetParams());
        }
        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("ID", SHID.ToString());
            Ope.AddParams("Name", Name);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_SHMaster_Update, Ope.GetParams());
        }
        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("ID", SHID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_SHMaster_Delete, Ope.GetParams());
        }
    }
    
}