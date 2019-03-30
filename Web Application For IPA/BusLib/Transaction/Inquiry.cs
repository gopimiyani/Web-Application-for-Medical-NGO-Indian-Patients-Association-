using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class Inquiry
    {
        public const String _TableName = "Inquiry";
        #region properties

        public string TableName
        {
            get { return _TableName; }
        }

        private int Inquiry_ID = 0;

        public int Inquiry_ID1
        {
            get { return Inquiry_ID; }
            set { Inquiry_ID = value; }
        }

       


        private int Admin_ID=0;

        public int Admin_ID1
        {
             get { return Admin_ID; }
             set { Admin_ID = value; }
        }



        private string Name = "";

        public string Name1
        {
            get { return Name; }
            set { Name = value; }
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

        private bool Status = false;

        public bool Status1
        {
            get { return Status; }
            set { Status = value; }
        }
        
        private String Subject = "";

        public String Subject1
        {
            get { return Subject; }
            set { Subject = value; }
        }

        private String Email = "";

        public String Email1
        {
            get { return Email; }
            set { Email = value; }
        }

        private String Question= "";

        public String Question1
        {
            get { return Question; }
            set { Question = value; }
        }

        private String Answer = "";

        public String Answer1
        {
            get { return Answer; }
            set { Answer = value; }
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

           
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Inquiry_Select, Ope.GetParams());


        }

        public void GetDataSet_GetInquiryDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Inquiry_ID", Inquiry_ID.ToString());

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Inquiry_Select, Ope.GetParams());


        }
        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("Name", Name);
            Ope.AddParams("Address", Address);
            Ope.AddParams("City", City);
            Ope.AddParams("Email", Email);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("Subject", Subject);
            Ope.AddParams("Question", Question);
            Ope.AddParams("Answer", Answer);
            Ope.AddParams("Status", Status.ToString());


          
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Inquiry_Insert, Ope.GetParams());

        }


        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("Inquiry_ID",Inquiry_ID.ToString());
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("Name", Name);
            Ope.AddParams("Address", Address);
            Ope.AddParams("City", City);
            Ope.AddParams("Email", Email);
            Ope.AddParams("State", State);
            Ope.AddParams("PinCode", PinCode.ToString());
            Ope.AddParams("Subject", Subject);
            Ope.AddParams("Question", Question);
            Ope.AddParams("Answer", Answer);
            Ope.AddParams("Status", Status.ToString());



            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Inquiry_Update, Ope.GetParams());

        }



    }
}
