using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Master
{
    public class SuperAdmin
    {
        public const String _TableName = "SuperAdmin";


        private int SuperAdmin_ID = 0;

        public int SuperAdmin_ID1
        {
            get { return SuperAdmin_ID; }
            set { SuperAdmin_ID = value; }
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

        private String UserName = "";

        public String UserName1
        {
            get { return UserName; }
            set { UserName = value; }
        }

        private String Password = "";

        public String Password1
        {
            get { return Password; }
            set { Password = value; }
        }

        private string Email = "";

        public string Email1
        {
            get { return Email; }
            set { Email = value; }
        }
        private int PinCode;

        public int PinCode1
        {
            get { return PinCode; }
            set { PinCode = value; }
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




        private long MobileNo;

        public long MobileNo1
        {
            get { return MobileNo; }
            set { MobileNo = value; }
        }


        private String Pwd = "";

        public String Pwd1
        {
            get { return Pwd; }
            set { Pwd = value; }
        }

        private String ProfilePic = "";

        public String ProfilePic1
        {
            get { return ProfilePic; }
            set { ProfilePic = value; }
        }

        private String IP = "";

        public String IP1
        {
            get { return IP; }
            set { IP = value; }
        }


        private DataSet ds = new DataSet();
        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }


        public void GetSuperAdminLoginDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("UserName", UserName);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_SuperAdmin_GetAdminLoginDetail, Ope.GetParams());
        }

        public void GetDataset()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("SuperAdmin_ID", SuperAdmin_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_SuperAdmin_Select);

        }

       public void GetDataSet_ForgotPassword()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_SuperAdmin_ForgotPassword, Ope.GetParams());
        }

        public void ResetPassword()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.AddParams("Password", Password);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_SuperAdmin_ResetPassword, Ope.GetParams());
        }

     
        public void GetResetPwdDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_SuperAdmin_GetAdminResetPwdDetail, Ope.GetParams());
        }

        public void SetRandomNo()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Email", Email);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_SuperAdmin_SetRandomNo, Ope.GetParams());
        }


        public int Update()
        {


            Ope.Clear();
            Ope.AddParams("SuperAdmin_ID", SuperAdmin_ID.ToString());
            Ope.AddParams("FirstName", FirstName);
            Ope.AddParams("LastName", LastName);
            Ope.AddParams("Email", Email);
            Ope.AddParams("ProfilePic", ProfilePic);
            Ope.AddParams("Address", Address);
            Ope.AddParams("City", City);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("MobileNo", MobileNo.ToString());
            Ope.AddParams("UserName", UserName);
            Ope.AddParams("Password", Pwd);
            Ope.AddParams("IP", IP);

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_SuperAdmin_Update, Ope.GetParams());

        }


    }
}

