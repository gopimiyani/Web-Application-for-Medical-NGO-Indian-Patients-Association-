using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Master
{
   public class UserMast
    {
        public const string _TableName = "Registration";

        private int ID = 0;

        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }

        private String Name = "";

        public String Name1
        {
            get { return Name; }
            set { Name = value; }
        }

        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }


        public void GetDataSet(string Type)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Type", Type);
        //    Ope.AddParams("Keyword", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_UserMaster_Select,Ope.GetParams());


        }
        public void GetDataSet_GetAdmin()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_UserMaster_Select, Ope.GetParams());


        }

        //public int Insert()
        //{
        //    Ope.Clear();
        //    Ope.AddParams("Name", Name);
        //    return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_UserMaster_Insert, Ope.GetParams());

        //}
        //public int Update()
        //{
        //    Ope.Clear();
        //    Ope.AddParams("ID", ID.ToString());
        //    Ope.AddParams("Name", Name);
        //  //  return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_UserMaster_Update, Ope.GetParams());
        //}
        //public int Delete()
        //{

        //    Ope.Clear();
        //    Ope.AddParams("ID", ID.ToString());
        //    //return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_UserMaster_Delete, Ope.GetParams());
        //}
        
    }
}
