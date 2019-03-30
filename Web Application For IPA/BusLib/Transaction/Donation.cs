using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class Donation
    {
        public const String _TableName = "Donation";
        #region properties

        public string TableName
        {
            get { return _TableName; }
        }
        private int Admin_ID = 0;

        public int Admin_ID1
        {
            get { return Admin_ID; }
            set { Admin_ID = value; }
        }

        private int Donation_ID = 0;

        public int Donation_ID1
        {
            get { return Donation_ID; }
            set { Donation_ID = value; }
        }
        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
        }

        private string Date = "";

        public string Date1
        {
            get { return Date; }
            set { Date = value; }
        }


        private Decimal Amount;

        public Decimal Amount1
        {
            get { return Amount; }
            set { Amount = value; }
        }

        private int ChequeNo;

        public int ChequeNo1
        {
            get { return ChequeNo; }
            set { ChequeNo = value; }
        }

        private String ChequeDate = "";

        public String ChequeDate1
        {
            get { return ChequeDate; }
            set { ChequeDate = value; }
        }

        private String BankName = "";

        public String BankName1
        {
            get { return BankName; }
            set { BankName = value; }
        }


        private String Type = "";

        public String Type1
        {
            get { return Type; }
            set { Type = value; }
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

        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("Date", Date);
            Ope.AddParams("Amount", Amount.ToString());
            Ope.AddParams("Type", Type);
            Ope.AddParams("ChequeNo", ChequeNo.ToString());
            Ope.AddParams("ChequeDate", ChequeDate);
            Ope.AddParams("BankName", BankName);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Donation_Insert, Ope.GetParams());

        }

        public void GetDataSet()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();


            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Donation_Select, Ope.GetParams());


        }

        public void GetDataSet_GetDonationDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Donation_ID", Donation_ID.ToString());

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Donation_Select, Ope.GetParams());


        }





    }
}
       

