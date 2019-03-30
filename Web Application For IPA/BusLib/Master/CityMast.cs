using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Master
{
    public class CityMast
    {
        public const String _TableName="CityMaster";

        #region properties

        private int CityID = 0;

        public int CityID1
        {
            get { return CityID; }
            set { CityID = value; }
        }

        private int StateID = 0;

        public int StateID1
        {
            get { return StateID; }
            set { StateID = value; }
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

        #endregion

        public void GetDataSet(string Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Name", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_CityMaster_Select, Ope.GetParams());


        }

        public void GetCity()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("State_ID", StateID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_CityMaster_GetCity,Ope.GetParams());
        }
       

        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("State_ID", StateID.ToString());
            Ope.AddParams("Name", Name);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_CityMaster_Insert, Ope.GetParams());
         }
        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("ID", CityID.ToString());
            Ope.AddParams("Name", Name);
            Ope.AddParams("State_ID", StateID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_CityMaster_Update, Ope.GetParams());
        }
        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("ID", CityID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_CityMaster_Delete, Ope.GetParams());
        }
      
        
    }
 }
