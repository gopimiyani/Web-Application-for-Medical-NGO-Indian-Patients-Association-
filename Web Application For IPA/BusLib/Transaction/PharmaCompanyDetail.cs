using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class PharmaCompanyDetail
    {
        public const string _TableName = "PharmaCompanyDetail";

        public string TableName
        {
            get { return _TableName; }
        }

        private int PharmaCompanyDetail_ID = 0;

        public int PharmaCompanyDetail_ID1
        {
            get { return PharmaCompanyDetail_ID; }
            set { PharmaCompanyDetail_ID = value; }
        }

        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
        }


        
        private int Patient_ID = 0;

        public int Patient_ID1
        {
            get { return Patient_ID; }
            set { Patient_ID = value; }
        }


        private int BillNo = 0;

        public int BillNo1
        {
            get { return BillNo; }
            set { BillNo = value; }
        }



        private Decimal TotalAmount;

        public Decimal TotalAmount1
        {
            get { return TotalAmount; }
            set { TotalAmount = value; }
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



        private Decimal FinalAmount;

        public Decimal FinalAmount1
        {
            get { return FinalAmount; }
            set { FinalAmount = value; }
        }

        private Boolean PaymentStatus = false;

        public Boolean PaymentStatus1
        {
            get { return PaymentStatus; }
            set { PaymentStatus = value; }
        }

      
        //end
    


        

     

        
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
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PharmaCompanyDetail_Select,Ope.GetParams());


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
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PharmaCompanyDetail_GetPCDetail, Ope.GetParams());


        }


        public void GetMaxID()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
         //   Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PharmaCompanyDetail_SelectMaxID, Ope.GetParams());


        }

        public void GetNextBillNo()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            //  Ope.AddParams("PharmaCompanyDetail_ID", PharmaCompanyDetail_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PharmaCompanyDetail_GetNextBillNo, Ope.GetParams());


        }
        public int Insert()
        {

            Ope.Clear();
    //        Ope.AddParams("BillNo", BillNo.ToString());            
            Ope.AddParams("User_ID", User_ID.ToString());            
            Ope.AddParams("Patient_ID", Patient_ID.ToString());
            Ope.AddParams("BillNo", BillNo1.ToString());
            Ope.AddParams("TotalAmount", TotalAmount.ToString());
            Ope.AddParams("Discount", Discount.ToString());
            Ope.AddParams("DiscountAmount", DiscountAmount.ToString());
            Ope.AddParams("FinalAmount", FinalAmount.ToString());
            Ope.AddParams("PaymentStatus", PaymentStatus.ToString());
          
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_PharmaCompanyDetail_Insert, Ope.GetParams());
        }

        


        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("PharmaCompanyDetail_ID", PharmaCompanyDetail_ID.ToString());
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Patient_ID", Patient_ID.ToString());
            Ope.AddParams("BillNo", BillNo1.ToString());
            Ope.AddParams("TotalAmount", TotalAmount.ToString());
            Ope.AddParams("Discount", Discount.ToString());
            Ope.AddParams("DiscountAmount", DiscountAmount.ToString());
            Ope.AddParams("FinalAmount", FinalAmount.ToString());
            Ope.AddParams("PaymentStatus", PaymentStatus.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_PharmaCompanyDetail_Update, Ope.GetParams());
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

        //public void GetDataSet_GetBillNo()
        //{
        //    if (ds != null)
        //    {
        //        ds.Clear();
        //    }
        //    Ope.Clear();
        //    Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PharmaCompanyDetail_GetBillNo, Ope.GetParams());
        //}

        public void GetDataSet_GetPharmaCompanyName()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PharmaCompanyDetail_GetPharmaCompanyName, Ope.GetParams());
        }

        public void GetDataSet_GetPharmaCompanyServiceDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("PharmaCompanyDetail_ID", PharmaCompanyDetail_ID.ToString());


//            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PharmaCompany_GetAPharmaCompanyServiceDetail, Ope.GetParams());
        }
    }
}
