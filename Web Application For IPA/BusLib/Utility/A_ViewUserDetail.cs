using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Utility
{
   
     public class A_ViewUserDetail
        {
            public const String _TableName = "Registration";
            #region properties


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
            private int User_ID = 0;

            public int User_ID1
            {
                get { return User_ID; }
                set { User_ID = value; }
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
            public void GetDataSet_GetAViewUserDetail()
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
                Ope.AddParams("Password", Pwd);
                Ope.AddParams("StakeHolder", StackHolder);
                Ope.AddParams("Prefix", Prefix);
                Ope.AddParams("Email", Email);
                Ope.AddParams("BirthDate", BirthDate);
                //Ope.AddParams("JoinDate", JoinDate);
                Ope.AddParams("BloodGroup", BloodGroup);
                Ope.AddParams("Website", Website);
                Ope.AddParams("ContactPerson", ContactPerson);
                Ope.AddParams("IdProof", IdProof);
                Ope.AddParams("Degree", Degree);
                Ope.AddParams("Disease", Disease);
                Ope.AddParams("Purpose", Purpose);
                Ope.AddParams("Mission", Mission);
                return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Registration_Update, Ope.GetParams());

            }



        }
    }