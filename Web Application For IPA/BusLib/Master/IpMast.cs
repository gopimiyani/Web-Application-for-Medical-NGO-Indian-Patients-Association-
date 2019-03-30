using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Master
{
    public class IpMast
    {
        public const string _TableName = "IpMaster";

        #region properties
        private int ID = 0;

        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }

        private String Address = "";

        public String Address1
        {
            get { return Address; }
            set { Address = value; }
        }

        private DataSet ds=new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        #endregion

        public void GetDataSet(string Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Address", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_IpMaster_Select, Ope.GetParams());


        }
      

         
         public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("Address", Address);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_IpMaster_Insert, Ope.GetParams());
         
         }
         public int Update()
         {
             Ope.Clear();
             Ope.AddParams("ID", ID.ToString());
             Ope.AddParams("Address", Address);
             return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_IpMaster_Update, Ope.GetParams());
         }
         public int Delete()
         {

             Ope.Clear();
             Ope.AddParams("ID", ID.ToString());
             return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_IpMaster_Delete, Ope.GetParams());  
          }
        
       
    }
}
   
