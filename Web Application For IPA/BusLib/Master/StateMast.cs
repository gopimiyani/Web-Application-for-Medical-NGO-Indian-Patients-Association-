using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Master
{
    public class StateMast
    {
       // private DataSet _DS = new DataSet();
        public const string _TableName = "StateMaster";

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

        private DataSet ds=new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

      
        public void GetDataSet(string Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Name", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_StateMaster_Select,Ope.GetParams());


        }

         
         public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("Name", Name);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_StateMaster_Insert, Ope.GetParams());
         
         }
         public int Update()
         {
             Ope.Clear();
             Ope.AddParams("ID", ID.ToString());
             Ope.AddParams("Name", Name);
             return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_StateMaster_Update, Ope.GetParams());
         }
         public int Delete()
         {

             Ope.Clear();
             Ope.AddParams("ID", ID.ToString());
             return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_StateMaster_Delete, Ope.GetParams());  
          }
        
       
    }
}