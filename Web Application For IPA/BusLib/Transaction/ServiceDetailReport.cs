using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class ServiceDetailReport
    {
        public const String _TableName = "HospitalServiceDetail";

        #region properties
        //Registration

        private String Status = "";
        public String Status1
        {
            get { return Status; }
            set { Status = value; }
        }

        

        private int State_ID = 0;

        public int State_ID1
        {
            get { return State_ID; }
            set { State_ID = value; }
        }
        private String FirstName = "";

        public String FirstName1
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        
        private String LastName = "";

        public String LastName1
        {
            get { return LastName; }
            set { LastName = value; }
        }


        private String Address = "";

        public String Address1
        {
            get { return Address; }
            set { Address = value; }
        }
        private String City = "";

        public String City1
        {
            get { return City; }
            set { City = value; }
        }
        private String State = "";

        public String State1
        {
            get { return State; }
            set { State = value; }
        }

        private int PinCode;

        public int PinCode1
        {
            get { return PinCode; }
            set { PinCode = value; }
        }
        private long MobileNo;

        public long MobileNo1
        {
            get { return MobileNo; }
            set { MobileNo = value; }
        }
        private String UserName = "";

        public String UserName1
        {
            get { return UserName; }
            set { UserName = value; }
        }

        private String Pwd = "";

        public String Pwd1
        {
            get { return Pwd; }
            set { Pwd = value; }
        }
        private String StackHolder = "";

        public String StackHolder1
        {
            get { return StackHolder; }
            set { StackHolder = value; }
        }
        private String Prefix = "";

        public String Prefix1
        {
            get { return Prefix; }
            set { Prefix = value; }
        }
        private String BirthDate = "";

        public String BirthDate1
        {
            get { return BirthDate; }
            set { BirthDate = value; }
        }
        private String FromDate = "";

        public String FromDate1
        {
            get { return FromDate; }
            set { FromDate = value; }
        }

        private String ToDate = "";

        public String ToDate1
        {
            get { return ToDate; }
            set { ToDate = value; }
        }
        private DateTime JoinDate;

        public DateTime JoinDate1
        {
            get { return JoinDate; }
            set { JoinDate = value; }
        }

      
        private DateTime DOB;

        public DateTime DOB1
        {
            get { return DOB; }
            set { DOB = value; }
        }

        private String Website = "";

        public String Website1
        {
            get { return Website; }
            set { Website = value; }
        }

        private String Purpose = "";

        private String Email = "";

        public String Email1
        {
            get { return Email; }
            set { Email = value; }
        }

        public String Purpose1
        {
            get { return Purpose; }
            set { Purpose = value; }
        }

        private String Mission = "";

        public String Mission1
        {
            get { return Mission; }
            set { Mission = value; }
        }

        private String IdProof = "";

        public String IdProof1
        {
            get { return IdProof; }
            set { IdProof = value; }
        }

        private String ProfilePic = "";

        public String ProfilePic1
        {
            get { return ProfilePic; }
            set { ProfilePic = value; }
        }

        private String ContactPerson = "";

        public String ContactPerson1
        {
            get { return ContactPerson; }
            set { ContactPerson = value; }
        }

        private String Disease = "";

        public String Disease1
        {
            get { return Disease; }
            set { Disease = value; }
        }

        private String Degree = "";

        public String Degree1
        {
            get { return Degree; }
            set { Degree = value; }
        }

        private Boolean NotificationFlag = false;

        public Boolean NotificationFlag1
        {
            get { return NotificationFlag; }
            set { NotificationFlag = value; }
        }

        private int WorkingAdmin_ID = 0;

        public int WorkingAdmin_ID1
        {
            get { return WorkingAdmin_ID; }
            set { WorkingAdmin_ID = value; }
        }


        //HospitalDetail
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

        private int HospitalServiceDetail_ID = 0;

        public int HospitalServiceDetail_ID1
        {
            get { return HospitalServiceDetail_ID; }
            set { HospitalServiceDetail_ID = value; }
        }

        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        //PharmaCompany
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

       


        private Decimal Amount;

        public Decimal Amount1
        {
            get { return Amount; }
            set { Amount = value; }
        }

       //BloodBank

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
        
        private int NoOfBottle = 0;

        public int NoOfBottle1
        {
            get { return NoOfBottle; }
            set { NoOfBottle = value; }
        }

        private SqlDataReader dr;

        public SqlDataReader Dr
        {
            get { return dr; }
            set { dr = value; }
        }

        //Event

        private int Event_ID = 0;

        public int Event_ID1
        {
            get { return Event_ID; }
            set { Event_ID = value; }
        }
        private int Admin_ID = 0;

        public int Admin_ID1
        {
            get { return Admin_ID; }
            set { Admin_ID = value; }
        }

        private string EventName = "";

        public string EventName1
        {
            get { return EventName; }
            set { EventName = value; }
        }
        private string EventDescription = "";

        public string EventDescription1
        {
            get { return EventDescription; }
            set { EventDescription = value; }
        }
        private string EventDate = "";

        public string EventDate1
        {
            get { return EventDate; }
            set { EventDate = value; }
        }
        private string TimeDuration = "";

        public string TimeDuration1
        {
            get { return TimeDuration; }
            set { TimeDuration = value; }
        }
        private string Location = "";

        public string Location1
        {
            get { return Location; }
            set { Location = value; }
        }
        private string EntryDate = "";

        public string EntryDate1
        {
            get { return EntryDate; }
            set { EntryDate = value; }
        }





        //Doctor

        private int DoctorServiceDetail_ID = 0;

        public int DoctorServiceDetail_ID1
        {
            get { return DoctorServiceDetail_ID; }
            set { DoctorServiceDetail_ID = value; }
        }

        #endregion


        public void SP_GetServiceDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("StackHolder", StackHolder1);
            Ope.AddParams("PaymentStatus", PaymentStatus1.ToString());
            Ope.AddParams("User_ID", User_ID1.ToString());
            Ope.AddParams("City", City1);
            Ope.AddParams("State", State1);
            Ope.AddParams("PinCode", PinCode1.ToString());
            Ope.AddParams("FromDate", FromDate1);
            Ope.AddParams("ToDate", ToDate1);
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID1.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Report_SPGetServiceDetail, Ope.GetParams());
        }

        public void Task_GetTaskDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            //            Ope.AddParams("Name", );
            Ope.AddParams("Status", Status1.ToString());
            Ope.AddParams("User_ID", User_ID1.ToString());
            Ope.AddParams("City", City1);
            Ope.AddParams("State", State1);
            Ope.AddParams("PinCode", PinCode1.ToString());
            Ope.AddParams("FromDate", FromDate1);
            Ope.AddParams("ToDate", ToDate1);
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID1.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Report_GetTaskDetail, Ope.GetParams());
        }

        public void Request_GetRequestDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
//            Ope.AddParams("Name", );
            Ope.AddParams("Status",Status1.ToString());
        //    Ope.AddParams("User_ID", User_ID1.ToString());
            Ope.AddParams("City", City1);
            Ope.AddParams("State", State1);
            Ope.AddParams("PinCode", PinCode1.ToString());
            Ope.AddParams("FromDate", FromDate1);
            Ope.AddParams("ToDate", ToDate1);
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Report_GetRequestDetail, Ope.GetParams());
        }


        public void GetDataSet_FillSHName(String value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("StackHolder", value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Report_FillSHName, Ope.GetParams());
        }


        public void Event_GetEventDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            //            Ope.AddParams("Name", );
            Ope.AddParams("Location", Location1);
            Ope.AddParams("FromDate", FromDate1);
            Ope.AddParams("ToDate", ToDate1);
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID1.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Report_GetEventDetail, Ope.GetParams());
        }

    }
}
