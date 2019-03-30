using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class Patient
    {
        public const String _TableName = "Patient";
        #region properties

        private int ServiceProviderUser_ID = 0;

        public int ServiceProviderUser_ID1
        {
            get { return ServiceProviderUser_ID; }
            set { ServiceProviderUser_ID = value; }
        }

        private int User_ID = 0;

        public int User_ID1
        {
            get { return User_ID; }
            set { User_ID = value; }
        }

        private int Request_ID = 0;

        public int Request_ID1
        {
            get { return Request_ID; }
            set { Request_ID = value; }
        }

        private int Patient_ID = 0;

        public int Patient_ID1
        {
            get { return Patient_ID; }
            set { Patient_ID = value; }
        }


        private string Address = "";

        public string Address1
        {
            get { return Address; }
            set { Address = value; }
        }

        private string Name = "";

        public string Name1
        {
            get { return Name; }
            set { Name = value; }
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

        private Boolean IsSelect = false;

        public Boolean IsSelect1
        {
            get { return IsSelect; }
            set { IsSelect = value; }
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



        public void GetDataSet()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

           
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Patient_Select, Ope.GetParams());


        }

        public void GetDataSet_GetPatientDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.AddParams("Patient_ID", Patient_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Patient_GetPatientDetail, Ope.GetParams());


        }


       


        public int Insert()
        {

            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());
            Ope.AddParams("Name", Name);

            Ope.AddParams("ServiceProviderUser_ID", ServiceProviderUser_ID.ToString());
            Ope.AddParams("Address", Address);
            Ope.AddParams("Email", Email);
            Ope.AddParams("City", City);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("MobileNo", MobileNo.ToString());

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Patient_Insert, Ope.GetParams());

        }

        public int Update()
        {

            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());
            Ope.AddParams("Name", Name);
            Ope.AddParams("ServiceProviderUser_ID", ServiceProviderUser_ID.ToString());
            Ope.AddParams("Patient_ID", Patient_ID.ToString());
            Ope.AddParams("Address", Address);
            Ope.AddParams("City", City);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("MobileNo", MobileNo.ToString());
            Ope.AddParams("Email", Email);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Patient_Update, Ope.GetParams());

        }

        public int UpdateServiceProviderID()
        {

            Ope.Clear();
            
            Ope.AddParams("ServiceProviderUser_ID", ServiceProviderUser_ID.ToString());
            Ope.AddParams("Patient_ID", Patient_ID.ToString());
           
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Patient_UpdateServiceProviderID, Ope.GetParams());

        }


        public void GetNewPatientName()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("ServiceProviderUser_ID", ServiceProviderUser_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Patient_GetNewPatientName, Ope.GetParams());
        }

        public void GetViewPatientName()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
           
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Patient_GetViewPatientName, Ope.GetParams());
        }


        public void GetServiceProvider()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Request_ID", Request_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Patient_GetServiceProvider, Ope.GetParams());
        
        }


    }
}
