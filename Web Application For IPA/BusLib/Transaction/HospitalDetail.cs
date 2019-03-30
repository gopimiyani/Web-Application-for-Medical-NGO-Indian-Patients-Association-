using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class HospitalDetail
    {
        public const String _TableName = "HospitalDetail";

        #region properties
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



        private int HospitalDetail_ID = 0;

        public int HospitalDetail_ID1
        {
            get { return HospitalDetail_ID; }
            set { HospitalDetail_ID = value; }
        }


        private String DoctorName = "";

        public String DoctorName1
        {
            get { return DoctorName; }
            set { DoctorName = value; }
        }

        private String ServiceDetail = "";

        public String ServiceDetail1
        {
            get { return ServiceDetail; }
            set { ServiceDetail = value; }
        }



        private String AdmitDate = "";

        public String AdmitDate1
        {
            get { return AdmitDate; }
            set { AdmitDate = value; }
        }

        
        private String AdmitTime = "";

        public String AdmitTime1
        {
            get { return AdmitTime; }
            set { AdmitTime = value; }
        }

        
        private String DischargeDate = "";

        public String DischargeDate1
        {
            get { return DischargeDate; }
            set { DischargeDate = value; }
        }


        private String DischargeTime = "";

        public String DischargeTime1
        {
            get { return DischargeTime; }
            set { DischargeTime = value; }
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

        private int HospitalServiceDetail_ID = 0;

        public int HospitalServiceDetail_ID1
        {
            get { return HospitalServiceDetail_ID; }
            set { HospitalServiceDetail_ID = value; }
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


        private bool PaymentStatus = false;

        public bool PaymentStatus1
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

        #endregion

        public void GetDataSet()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("HospitalDetail_ID", HospitalDetail_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_HospitalDetail_Select, Ope.GetParams());


        }

        public void GetDataSet(String User_ID,string Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Keyword", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_HospitalDetail_GetHospitalDetail, Ope.GetParams());


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

        public void GetDataSet_GetHospitalName()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_HospitalDetail_GetHospitalName, Ope.GetParams());
        }

        public void GetMaxID()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            //   Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_HospitalDetail_SelectMaxID, Ope.GetParams());


        }

        public void GetDataSet_GetHospitalServiceDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("HospitalDetail_ID", HospitalDetail_ID.ToString());


            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Hospital_GetAHospitalServiceDetail, Ope.GetParams());
        }
        public void GetNextBillNo()
        {
            if (ds != null)
            {
                ds.Clear();
            }

            Ope.Clear();
            //  Ope.AddParams("PharmaCompanyDetail_ID", PharmaCompanyDetail_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_HospitalDetail_GetNextBillNo, Ope.GetParams());


        }
        public int Insert()
        {

            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Patient_ID", Patient_ID.ToString());
            Ope.AddParams("BillNo", BillNo1.ToString());

            Ope.AddParams("DoctorName", DoctorName);
            Ope.AddParams("AdmitDate", AdmitDate);
            Ope.AddParams("AdmitTime", AdmitTime);
        
            Ope.AddParams("DischargeDate", DischargeDate);
            Ope.AddParams("DischargeTime", DischargeTime);
        
            Ope.AddParams("TotalAmount", TotalAmount.ToString());
            Ope.AddParams("Discount", Discount.ToString());
            Ope.AddParams("DiscountAmount", DiscountAmount.ToString());
            Ope.AddParams("FinalAmount", FinalAmount.ToString());
            Ope.AddParams("PaymentStatus", PaymentStatus.ToString());

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_HospitalDetail_Insert, Ope.GetParams());
        }
        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("HospitalDetail_ID", HospitalDetail_ID.ToString());
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Patient_ID", Patient_ID.ToString());
            Ope.AddParams("BillNo", BillNo1.ToString());

            Ope.AddParams("DoctorName", DoctorName);
            Ope.AddParams("AdmitDate", AdmitDate);
            Ope.AddParams("DischargeDate", DischargeDate);
            Ope.AddParams("AdmitTime", AdmitTime);
            Ope.AddParams("DischargeTime", DischargeTime);

            Ope.AddParams("TotalAmount", TotalAmount.ToString());
            Ope.AddParams("Discount", Discount.ToString());
            Ope.AddParams("DiscountAmount", DiscountAmount.ToString());
            Ope.AddParams("FinalAmount", FinalAmount.ToString());
            Ope.AddParams("PaymentStatus", PaymentStatus.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_HospitalDetail_Update, Ope.GetParams());
        }

        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("HospitalServiceDetail_ID", HospitalServiceDetail_ID.ToString());
            //  Ope.AddParams("Patient_ID", Patient_ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_HospitalServiceDetail_Delete, Ope.GetParams());
        }


    }
}
