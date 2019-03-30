using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
   public class HospitalServiceDetail
    {
        public const String _TableName = "HospitalServiceDetail";

            #region properties

        private int HospitalServiceDetail_ID = 0;

        public int HospitalServiceDetail_ID1
        {
            get { return HospitalServiceDetail_ID; }
            set { HospitalServiceDetail_ID = value; }
        }

        private int HospitalDetail_ID = 0;

        public int HospitalDetail_ID1
        {
            get { return HospitalDetail_ID; }
            set { HospitalDetail_ID = value; }
        }


        private String ServiceDescription = "";

        public String ServiceDescription1
        {
            get { return ServiceDescription; }
            set { ServiceDescription = value; }
        }

        private Decimal ServiceCharges;

        public Decimal ServiceCharges1
        {
            get { return ServiceCharges; }
            set { ServiceCharges = value; }
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


        public void GetDataSet()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("HospitalDetail_ID", HospitalDetail_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_HospitalServiceDetail_Select, Ope.GetParams());


        }



        public int Insert()
        {
            Ope.Clear();
            // Ope.AddParams("PharmaCompanyDetail_ID", PharmaCompanyDetail_ID.ToString());
            Ope.AddParams("ServiceDescription", ServiceDescription);
            Ope.AddParams("ServiceCharges", ServiceCharges.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_HospitalServiceDetail_Insert, Ope.GetParams());
        }

        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("HospitalServiceDetail_ID", HospitalServiceDetail_ID.ToString());
            Ope.AddParams("HospitalDetail_ID", HospitalDetail_ID.ToString());
            Ope.AddParams("ServiceDescription", ServiceDescription);
            Ope.AddParams("ServiceCharges", ServiceCharges.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_HospitalServiceDetail_Update, Ope.GetParams());
        }

        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("HospitalServiceDetail_ID", HospitalServiceDetail_ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_HospitalServiceDetail_Delete, Ope.GetParams());
        }
    }
}
