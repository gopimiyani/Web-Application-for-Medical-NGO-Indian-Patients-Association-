using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class PharmaCompanyServiceDetail
    {
        public const string _TableName = "PharmaCompanyServiceDetail";

        public string TableName
        {
            get { return _TableName; }
        }

        private int PharmaCompanyService_ID = 0;

        public int PharmaCompanyService_ID1
        {
            get { return PharmaCompanyService_ID; }
            set { PharmaCompanyService_ID = value; }
        }


        private int PharmaCompanyDetail_ID = 0;

        public int PharmaCompanyDetail_ID1
        {
            get { return PharmaCompanyDetail_ID; }
            set { PharmaCompanyDetail_ID = value; }
        }

        private String ItemName = "";

        public String ItemName1
        {
            get { return ItemName; }
            set { ItemName = value; }
        }

        private Decimal Quantity;

        public Decimal Quantity1
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        private Decimal Rate;

        public Decimal Rate1
        {
            get { return Rate; }
            set { Rate = value; }
        }


        private Decimal Amount;

        public Decimal Amount1
        {
            get { return Amount; }
            set { Amount = value; }
        }

        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        public void GetDataSet()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("PharmaCompanyDetail_ID", PharmaCompanyDetail_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PharmaCompanyServiceDetail_Select, Ope.GetParams());


        }


       
        public int Insert()
        {
            Ope.Clear();
           // Ope.AddParams("PharmaCompanyDetail_ID", PharmaCompanyDetail_ID.ToString());
            Ope.AddParams("ItemName", ItemName);
            Ope.AddParams("Rate", Rate.ToString());
            Ope.AddParams("Quantity", Quantity.ToString());
            Ope.AddParams("Amount", Amount.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_PharmaCompanyServiceDetail_Insert, Ope.GetParams());
        }

        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("PharmaCompanyService_ID", PharmaCompanyService_ID.ToString());
            Ope.AddParams("PharmaCompanyDetail_ID ", PharmaCompanyDetail_ID.ToString());            
            Ope.AddParams("ItemName", ItemName);
            Ope.AddParams("Rate", Rate.ToString());
            Ope.AddParams("Quantity", Quantity.ToString());
            Ope.AddParams("Amount", Amount.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_PharmaCompanyServiceDetail_Update, Ope.GetParams());
        }

        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("PharmaCompanyService_ID", PharmaCompanyService_ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_PharmaCompanyServiceDetail_Delete, Ope.GetParams());
        }
    }
}
