using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;


namespace BusLib.Common
{
    public class Registration
    {
        public const String _TableName = "Registration";
        
        #region properties
        private String Status = "";
        public String Status1
        {
            get { return Status; }
            set { Status = value; }
        }
        
        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
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

        private String Name = "";

        public String Name1
        {
            get { return Name; }
            set { Name = value; }
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
        private String BirthDate="";

        public String BirthDate1
        {
            get { return BirthDate; }
            set { BirthDate = value; }
        }
        private String FromDate="";

        public String FromDate1
        {
            get { return FromDate; }
            set { FromDate = value; }
        }

        private String ToDate="";

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

        private String BloodGroup = "";

        public String BloodGroup1
        {
            get { return BloodGroup; }
            set { BloodGroup = value; }
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
        private String ReasonForRejection = "";

        public String ReasonForRejection1
        {
            get { return ReasonForRejection; }
            set { ReasonForRejection = value; }
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
            Ope.AddParams("Name", Name);
            Ope.AddParams("LastName", LastName);
            Ope.AddParams("Address", Address);
            Ope.AddParams("City", City);
            Ope.AddParams("Email", Email);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("MobileNo", MobileNo.ToString());
            Ope.AddParams("UserName", UserName);
            Ope.AddParams("Password", Pwd);
            Ope.AddParams("StakeHolder", StackHolder);
            Ope.AddParams("Prefix", Prefix);
            Ope.AddParams("BirthDate", BirthDate);
            Ope.AddParams("JoinDate", JoinDate);
            Ope.AddParams("BloodGroup", BloodGroup);
            Ope.AddParams("Website", Website);
            Ope.AddParams("ContactPerson", ContactPerson);
            Ope.AddParams("IdProof", IdProof);
            Ope.AddParams("Degree", Degree);
            Ope.AddParams("Disease", Disease);
            Ope.AddParams("Purpose", Purpose);
            Ope.AddParams("Mission", Mission);
            Ope.AddParams("Status", Status);
            Ope.AddParams("ProfilePic", ProfilePic);
            Ope.AddParams("NotificationFlag", NotificationFlag.ToString());
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Registration_Insert, Ope.GetParams());

        }


        public void GetDataSet_GetAdminProfile()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetProfile, Ope.GetParams());
        }


        public void GetDataSet_GetVolunteerProfile()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetProfile, Ope.GetParams());
        }

        public void GetDataSet_GetHospitalProfile()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetProfile, Ope.GetParams());
        }

        public void GetDataSet_GetBloodBankProfile()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetProfile, Ope.GetParams());
        }

        public void GetDataSet_GetDonorProfile()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetProfile, Ope.GetParams());
        }

        public void GetDataSet_GetPharmaCompanyProfile()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetProfile, Ope.GetParams());
        }

        public void GetDataSet_GetDoctorProfile()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetProfile, Ope.GetParams());
        }
        
               
        public int Registration_UpdateStatus()
        {

            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("ReasonForRejection", ReasonForRejection1);
            Ope.AddParams("Status", Status);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Registration_UpdateStatus, Ope.GetParams());

        }

        public int Registration_UpdateNF()
        {

            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("StakeHolder", StackHolder);
            Ope.AddParams("NotificationFlag", NotificationFlag.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Registration_UpdateNF, Ope.GetParams());

        }

        public void GetDataSet_GetPendingUser(string UserType, String Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Type", UserType);
            Ope.AddParams("Keyword", Value);
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID.ToString());

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetPendingUser, Ope.GetParams());
        }

        public void GetDataSet_Select()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_Select, Ope.GetParams());
        }

        public void GetDataSet_GetUserName()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("UserName", UserName);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetUserName, Ope.GetParams());
        }

        public void GetDataSet_GetEmail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetEmail, Ope.GetParams());
        }

        public void GetDataSet_GetUserDetail()
        {
            if (ds != null)
            {       
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());


            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetUserDetail, Ope.GetParams());
        }
        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Registration_Delete, Ope.GetParams());
        }
        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("FirstName", FirstName);
            Ope.AddParams("Address", Address);
            Ope.AddParams("City", City);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("MobileNo", MobileNo.ToString());
            Ope.AddParams("UserName", UserName);
            Ope.AddParams("ProfilePic", ProfilePic);
            Ope.AddParams("StakeHolder", StackHolder);
            Ope.AddParams("Prefix", Prefix);
            Ope.AddParams("Email", Email);
            Ope.AddParams("BirthDate", BirthDate);
            //Ope.AddParams("JoinDate", JoinDate);
            Ope.AddParams("BloodGroup", BloodGroup);
            Ope.AddParams("Website", Website);
            Ope.AddParams("ContactPerson", ContactPerson);
            // Ope.AddParams("IdProof", IdProof);
            Ope.AddParams("Degree", Degree);
            Ope.AddParams("Disease", Disease);
            Ope.AddParams("Purpose", Purpose);
            Ope.AddParams("Mission", Mission);
            //Ope.AddParams("ProfilePic", ProfilePic);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Registration_Update, Ope.GetParams());
        }
       
        private int ID = 0;

        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }

        public void GetUser(string Type, string Value, Boolean NF)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID.ToString());
            Ope.AddParams("Type", Type);
            Ope.AddParams("Keyword", Value);
            Ope.AddParams("NF", NF.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetUser, Ope.GetParams());
        }

        public void GetDataSet_GetAdmin()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_UserMaster_Select, Ope.GetParams());


        }

        public void GetDataSet_Search()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("StackHolder", StackHolder);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_Search, Ope.GetParams());
        }

        

        public void GetDataSet_Search_Volunteer()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_StakeHolder_Search, Ope.GetParams());
        }

        public void GetDataset_GetVolnteerDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.AddParams("User_ID",User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetVolunteerDetail, Ope.GetParams());
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

        // -- start -- Forgot and reset password 
        public void GetDataSet_ForgotPassword()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_ForgotPassword, Ope.GetParams());
        }


        public void ResetPassword()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.AddParams("Password", Pwd);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_ResetPassword, Ope.GetParams());
        }

        public void GetResetPwdDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetUserResetPwdDetail, Ope.GetParams());
        }

        public void SetRandomNo()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_SetRandomNo, Ope.GetParams());
        }

        // -- end -- Forgot and reset password 

        // -- start -- Alert 
       

        // -- end -- Alert 

        //Report

        public void Regisrtation_GetUserDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("StackHolder", StackHolder1);
            Ope.AddParams("City", City1);
            Ope.AddParams("State", State1);
            Ope.AddParams("PinCode", PinCode1.ToString());
            Ope.AddParams("FromDate", FromDate1);
            Ope.AddParams("ToDate", ToDate1);
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Report_RegistrationGetUserDetail, Ope.GetParams());
        }

        public void GetVolunteer_Rating()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Rating_Volunteer, Ope.GetParams());
        }

        public void GetHospital_Rating()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Rating_Hospital, Ope.GetParams());
        }
        public void GetBloodBank_Rating()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Rating_BloodBank, Ope.GetParams());
        }

        public void GetPharmaCompany_Rating()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Rating_PharmaCompany, Ope.GetParams());
        }

        public void GetDonor_Rating()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Rating_Donor, Ope.GetParams());
        }
    }
}

