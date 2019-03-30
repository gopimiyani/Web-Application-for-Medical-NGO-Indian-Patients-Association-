using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;
namespace BusLib.Master
{
    public class AlbumMast
    {

        public const string _TableName = "AlbumMaster";

        private int ID = 0;

        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }

        private String _Name = "";

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private DataSet ds = new DataSet();

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
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_AlbumMaster_Select, Ope.GetParams());


        }
    

        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("Name", _Name);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_AlbumMaster_Insert, Ope.GetParams());

        }
        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("ID", ID.ToString());
            Ope.AddParams("Name", _Name);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_AlbumMaster_Update, Ope.GetParams());
        }
        public int Delete()
        {

            Ope.Clear();
            Ope.AddParams("ID", ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_AlbumMaster_Delete, Ope.GetParams());
        }


    }
}
