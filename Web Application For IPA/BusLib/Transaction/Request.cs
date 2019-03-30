using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;


namespace BusLib.Transaction
{
    public class Request
    {

        public const String _TableName = "Request";
        #region properties

        private int ServiceProviderUser_ID = 0;

        public int ServiceProviderUser_ID1
        {
            get { return ServiceProviderUser_ID; }
            set { ServiceProviderUser_ID = value; }
        }


        private int Request_ID = 0;

        public int Request_ID1
        {
            get { return Request_ID; }
            set { Request_ID = value; }
        }

        private int Request_Patient_ID = 0;

        public int Request_Patient_ID1
        {
            get { return Request_Patient_ID; }
            set { Request_Patient_ID = value; }
        }


        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
        }

        private int Admin_ID = 0;

        public int Admin_ID1
        {
            get { return Admin_ID; }
            set { Admin_ID = value; }
        }

        private DateTime Date;

        public DateTime Date1
        {
            get { return Date; }
            set { Date = value; }
        }

        private string Name = "";

        public string Name1
        {
            get { return Name; }
            set { Name = value; }
        }

        private string Subject = "";

        public string Subject1
        {
            get { return Subject; }
            set { Subject = value; }
        }

        private string Description = "";

        public string Description1
        {
            get { return Description; }
            set { Description = value; }
        }

        private string Address = "";

        public string Address1
        {
            get { return Address; }
            set { Address = value; }
        }


        private int Patient_ID = 0;

        public int Patient_ID1
        {
            get { return Patient_ID; }
            set { Patient_ID = value; }
        }



        private string City = "";

        public string City1
        {
            get { return City; }
            set { City = value; }
        }
        private string State = "";

        public string State1
        {
            get { return State; }
            set { State = value; }
        }
        private int PinCode = 0;

        public int PinCode1
        {
            get { return PinCode; }
            set { PinCode = value; }
        }
        private long MobileNo = 0;

        public long MobileNo1
        {
            get { return MobileNo; }
            set { MobileNo = value; }
        }
        private String Email = "";

        public String Email1
        {
            get { return Email; }
            set { Email = value; }
        }



        private String Response = "";

        public String Response1
        {
            get { return Response; }
            set { Response = value; }
        }

        private String ReasonForRejection = "";

        public String ReasonForRejection1
        {
            get { return ReasonForRejection; }
            set { ReasonForRejection = value; }
        }


        private string Status = "";

        public string Status1
        {
            get { return Status; }
            set { Status = value; }
        }

        private Boolean NotificationFlag = false;

        public Boolean NotificationFlag1
        {
            get { return NotificationFlag; }
            set { NotificationFlag = value; }
        }

        private String IdProof1 = "";

        public String IdProof11
        {
            get { return IdProof1; }
            set { IdProof1 = value; }
        }

        private String IdProof2 = "";

        public String IdProof21
        {
            get { return IdProof2; }
            set { IdProof2 = value; }
        }


        private String IdProof3 = "";

        public String IdProof31
        {
            get { return IdProof3; }
            set { IdProof3 = value; }
        }


        

        private int WorkingAdmin_ID = 0;

        public int WorkingAdmin_ID1
        {
            get { return WorkingAdmin_ID; }
            set { WorkingAdmin_ID = value; }
        }


        private Boolean IsHold = false;

        public Boolean IsHold1
        {
            get { return IsHold; }
            set { IsHold = value; }
        }


        private Boolean IsForward = false;

        public Boolean IsForward1
        {
            get { return IsForward; }
            set { IsForward = value; }
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

        public void GetDataSet(string Value) 
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
           
            Ope.AddParams("Status", Status);
            Ope.AddParams("Keyword", Value);
            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Request_Select, Ope.GetParams());
        }

        public void GetDataSet_GetViewRequestDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());


            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Request_GetViewRequestDetail, Ope.GetParams());
        }

        public void GetNewReuests()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Request_GetNewRequests, Ope.GetParams());
        }
        public int Insert()
        {
            Ope.Clear();

            Ope.AddParams("User_ID", User_ID.ToString());

            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("Date", Date);

            Ope.AddParams("Name", Name);
            Ope.AddParams("Subject", Subject);
            Ope.AddParams("Description", Description);
            Ope.AddParams("Address", Address);
            Ope.AddParams("Email", Email);

            Ope.AddParams("City", City);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("MobileNo", MobileNo.ToString());
            Ope.AddParams("Status", Status);
           
            Ope.AddParams("NotificationFlag", NotificationFlag.ToString());
            Ope.AddParams("IdProof1", IdProof1);
            Ope.AddParams("IdProof2", IdProof2);
            Ope.AddParams("IdProof3", IdProof3);

            Ope.AddParams("WorkingAdmin_ID", WorkingAdmin_ID.ToString());

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Request_Insert, Ope.GetParams());

        }

        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Request_Delete, Ope.GetParams());
        }
        public int Update()
        {

            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
           // Ope.AddParams("Request_Patient_ID", Request_Patient_ID1.ToString());
            //   Ope.AddParams("Date", Date.ToString());


            Ope.AddParams("Name", Name);
            Ope.AddParams("Subject", Subject);

            Ope.AddParams("Description", Description);

            Ope.AddParams("Address", Address);
            Ope.AddParams("City", City);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("MobileNo", MobileNo.ToString());
            Ope.AddParams("Email", Email);
            Ope.AddParams("Response", Response);
            Ope.AddParams("Status", Status);
            Ope.AddParams("ReasonForRejection", ReasonForRejection);
           // Ope.AddParams("IdProof1", IdProof1);
           // Ope.AddParams("IdProof2", IdProof2);
           // Ope.AddParams("IdProof3", IdProof3);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Request_Update, Ope.GetParams());

        }


        public int TUpdate()
        {

            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("Request_Patient_ID", Request_Patient_ID1.ToString());
            //   Ope.AddParams("Date", Date.ToString());


            Ope.AddParams("Name", Name);
            Ope.AddParams("Subject", Subject);

            Ope.AddParams("Description", Description);

            Ope.AddParams("Address", Address);
            Ope.AddParams("City", City);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("MobileNo", MobileNo.ToString());
            Ope.AddParams("Email", Email);
            Ope.AddParams("Response", Response);
            Ope.AddParams("Status", Status);
            Ope.AddParams("ReasonForRejection", ReasonForRejection);
             Ope.AddParams("IdProof1", IdProof1);
             Ope.AddParams("IdProof2", IdProof2);
             Ope.AddParams("IdProof3", IdProof3);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Request_TUpdate, Ope.GetParams());

        }


        public int UpdateNF()
        {

            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());
           
            Ope.AddParams("NotificationFlag", NotificationFlag.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Request_UpdateNF, Ope.GetParams());

        }

        public void GetDataSet_GetPatientDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.AddParams("Request_ID", Request_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Request_GetPatientDetail, Ope.GetParams());


        }

        public int UpdateIsHold()
        {

            Ope.Clear();
            Ope.AddParams("Request_ID", Request_Patient_ID1.ToString());
            Ope.AddParams("IsHold", IsHold.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Request_UpdateIsHold, Ope.GetParams());

        }

        public int UpdateIsHold1()
        {

            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID1.ToString());
            Ope.AddParams("IsHold", IsHold.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Request_UpdateIsHold1, Ope.GetParams());

        }

        public int UpdateIsForward()
        {

            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());
            Ope.AddParams("IsForward", IsForward.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Request_UpdateIsForward, Ope.GetParams());

        }
        //public void UpdateStatusToHold()
        //{
        //    if (ds != null)
        //    {
        //        ds.Clear();
        //    }
        //    Ope.Clear();

        //    Ope.AddParams("Request_ID", Request_ID.ToString());
        //    Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Request_UpdateStatusToHold, Ope.GetParams());


        //}




        public void GetDataSet_GetInfoFromTransaction_ID()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.AddParams("Request_Patient_ID", Request_Patient_ID1.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Request_GetInfoFromTransaction_ID, Ope.GetParams());


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


        public int UpdateServiceProviderID()
        {

            Ope.Clear();
          //  Ope.AddParams("Request_ID", Request_ID.ToString());
            Ope.AddParams("ServiceProviderUser_ID", ServiceProviderUser_ID.ToString());
            Ope.AddParams("Patient_ID", Patient_ID.ToString());

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Patient_UpdateServiceProviderID, Ope.GetParams());

        }



    }


}
