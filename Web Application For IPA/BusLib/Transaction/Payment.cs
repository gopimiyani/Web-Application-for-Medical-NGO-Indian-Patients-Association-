using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Utility
{
    public class Payment
    {

        public const string _TableName = "Payment";

        public string TableName
        {
            get { return _TableName; }
        }

        #region properties
        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
        }

        private int Payment_ID = 0;

        public int Payment_ID1
        {
            get { return Payment_ID; }
            set { Payment_ID = value; }
        }

        private string PaymentDate = "";

        public string PaymentDate1
        {
            get { return PaymentDate; }
            set { PaymentDate = value; }
        }

        private int Admin_ID = 0;

        public int Admin_ID1
        {
            get { return Admin_ID; }
            set { Admin_ID = value; }
        }


        private int BillNo = 0;

        public int BillNo1
        {
            get { return BillNo; }
            set { BillNo = value; }
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

        private String Name = "";

        public String Name1
        {
            get { return Name; }
            set { Name = value; }
        }

        private String StackHolder = "";

        public String StackHolder1
        {
            get { return StackHolder; }
            set { StackHolder = value; }
        }

        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }
        #endregion

        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("PaymentDate", PaymentDate);
            Ope.AddParams("BillNo", BillNo.ToString());
            Ope.AddParams("Amount", Amount.ToString());
            Ope.AddParams("ChequeNo", ChequeNo.ToString());
            Ope.AddParams("ChequeDate",ChequeDate);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Payment_Insert, Ope.GetParams());

        }

        public void GetBillNo()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID1.ToString());
            Ope.AddParams("StackHolder", StackHolder1);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Payment_GetBillNo, Ope.GetParams());
        }

        public void GetAmount()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID1.ToString());
            Ope.AddParams("StackHolder", StackHolder1);
            Ope.AddParams("BillNo", BillNo.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Payment_GetAmount, Ope.GetParams());
        }

        public void GetNextPID()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Payment_GetNextPID, Ope.GetParams());


        }


        public void GetDataSet()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.AddParams("StackHolder", StackHolder1);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Payment_Select, Ope.GetParams());


        }

        public void GetDataSet_GetPaymentDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.AddParams("Payment_ID", Payment_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Payment_GetPaymentDetail, Ope.GetParams());


        }

        public void UpdatePaymentStatus()
        {
             if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("BillNo", BillNo.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Payment_UpdatePaymentStatus, Ope.GetParams());

            
        }
    }

}
