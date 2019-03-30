using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;
using Val = BusLib.Validation.Validation;

namespace BusLib.Master
{
    public class TermMast
    {
        private DataSet ds = new DataSet();
        public const string _TableName = "TermMaster";

        #region Properties
        public DataSet Ds
        {
            get { return ds; }
        }
        public string TableName
        {
            get { return _TableName; }
        }

        private int TermID = 0;

        public int TermID1
        {
            get { return TermID; }
            set { TermID = value; }
        }

        private string TermName = "";

        public string TermName1
        {
            get { return TermName; }
            set { TermName = value; }
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
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_TermMaster_Select, Ope.GetParams());


        }
        public int Insert()
        {

            Ope.Clear();
            Ope.AddParams("ID", TermID.ToString());
            Ope.AddParams("Name", TermName);

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_TermMaster_Insert, Ope.GetParams());
        }

        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("ID", TermID.ToString());
            Ope.AddParams("Name", TermName);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_TermMaster_Update, Ope.GetParams());
        }
       
        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("ID", TermID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_TermMaster_Delete, Ope.GetParams());
        }
    }
}
