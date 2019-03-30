using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class BloodBankDetail
    {
        public const String _TableName = "BloodBankDetail";
        #region properties

        private Decimal Rate;

        public Decimal Rate1
        {
            get { return Rate; }
            set { Rate = value; }
        }
        private int BloodBankDetail_ID = 0;

        public int BloodBankDetail_ID1
        {
            get { return BloodBankDetail_ID; }
            set { BloodBankDetail_ID = value; }
        }

        private int BloodBankServiceDetail_ID = 0;

        public int BloodBankServiceDetail_ID1
        {
            get { return BloodBankServiceDetail_ID; }
            set { BloodBankServiceDetail_ID = value; }
        }




        private int Patient_ID = 0;

        public int Patient_ID1
        {
            get { return Patient_ID; }
            set { Patient_ID = value; }
        }
        private String BloodGroup = "";

        public String BloodGroup1
        {
            get { return BloodGroup; }
            set { BloodGroup = value; }
        }

        private String Name = "";

        public String Name1
        {
            get { return Name; }
            set { Name = value; }
        }

        private Decimal Charges;

        public Decimal Charges1
        {
            get { return Charges; }
            set { Charges = value; }
        }

       


        private Decimal TotalAmount;

        public Decimal TotalAmount1
        {
            get { return TotalAmount; }
            set { TotalAmount = value; }
        }

        private int NoOfBottle = 0;

        public int NoOfBottle1
        {
            get { return NoOfBottle; }
            set { NoOfBottle = value; }
        }



        private Decimal Discount;

        public Decimal Discount1
        {
            get { return Discount; }
            set { Discount = value; }
        }

        private Decimal DiscountAmount;

        public Decimal DiscountAmount1
        {
            get { return DiscountAmount; }
            set { DiscountAmount = value; }
        }


        private Decimal BillNo;

        public Decimal BillNo1
        {
            get { return BillNo; }
            set { BillNo = value; }
        }

      


        private Decimal FinalAmount;

        public Decimal FinalAmount1
        {
            get { return FinalAmount; }
            set { FinalAmount = value; }
        }

        private int Admin_ID = 0;

        public int Admin_ID1
        {
            get { return Admin_ID; }
            set { Admin_ID = value; }
        }

        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
        }

        private Boolean PaymentStatus = false;

        public Boolean PaymentStatus1
        {
            get { return PaymentStatus; }
            set { PaymentStatus = value; }
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
            Ope.AddParams("BloodBankDetail_ID", BloodBankDetail_ID.ToString());
            Ope.AddParams("Patient_ID", Patient_ID.ToString());
            Ope.AddParams("BillNo", BillNo1.ToString());

            Ope.AddParams("TotalAmount", TotalAmount.ToString());
            Ope.AddParams("Discount", Discount.ToString());
            Ope.AddParams("DiscountAmount", DiscountAmount.ToString());
            Ope.AddParams("FinalAmount", FinalAmount.ToString());
            Ope.AddParams("PaymentStatus", PaymentStatus.ToString());
            
            Ope.AddParams("NoOfBottle", NoOfBottle1.ToString());
            Ope.AddParams("BloodGroup", BloodGroup);
            Ope.AddParams("Charges", Charges.ToString());
           
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_BloodBankDetail_Insert, Ope.GetParams());
        }


        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("BloodBankDetail_ID", BloodBankDetail_ID.ToString());
            Ope.AddParams("Patient_ID", Patient_ID.ToString());
            Ope.AddParams("BillNo", BillNo1.ToString());
           
            Ope.AddParams("TotalAmount", TotalAmount.ToString());
            Ope.AddParams("Discount", Discount.ToString());
            Ope.AddParams("DiscountAmount", DiscountAmount.ToString());
            Ope.AddParams("FinalAmount", FinalAmount.ToString());
            Ope.AddParams("PaymentStatus", PaymentStatus.ToString());
            
            Ope.AddParams("NoOfBottle", NoOfBottle1.ToString());
            Ope.AddParams("BloodGroup", BloodGroup);
            Ope.AddParams("Charges", Charges.ToString());
            
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_BloodBankDetail_Update, Ope.GetParams());
        }


        public void GetDataSet(String User_ID,String Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Keyword", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_BloodBankDetail_Select,Ope.GetParams());
        }
        public void GetDataSet_GetPatientName()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_BloodBankDetail_GetPatientName, Ope.GetParams());
        }

        public void GetNextBillNo()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            //  Ope.AddParams("PharmaCompanyDetail_ID", PharmaCompanyDetail_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_BloodBankDetail_GetNextBillNo,Ope.GetParams());


        }

        public void GetDataSet_GetBloodBankName()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_BloodBankDetail_GetBloodBankName, Ope.GetParams());
        }

        public void GetDataSet_GetBloodBankServiceDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("BloodBankDetail_ID", BloodBankDetail_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_BloodBankDetail_GetBloodBankServiceDetail, Ope.GetParams());
        }
    }
}
