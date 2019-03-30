using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class DeletedTask
    {
        private const string _TableName = "DeletedTask";

        #region properties

        public string TableName
        {
            get { return _TableName; }
        }


        private int Task_ID = 0;

        public int Task_ID1
        {
            get { return Task_ID; }
            set { Task_ID = value; }
        }

        private int PageSize = 0;

        public int PageSize1
        {
            get { return PageSize; }
            set { PageSize = value; }
        }

        private int PageIndex = 0;

        public int PageIndex1
        {
            get { return PageIndex; }
            set { PageIndex = value; }
        }

        private int RecordCount = 0;

        public int RecordCount1
        {
            get { return RecordCount; }
            set { RecordCount = value; }
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

        private String VName = "";

        public String VName1
        {
            get { return VName; }
            set { VName = value; }
        }
        private String Subject = "";

        public String Subject1
        {
            get { return Subject; }
            set { Subject = value; }
        }

        private String Detail = "";

        public String Detail1
        {
            get { return Detail; }
            set { Detail = value; }
        }

        private String Priority = "";

        public String Priority1
        {
            get { return Priority; }
            set { Priority = value; }
        }

        private String Status = "";

        public String Status1
        {
            get { return Status; }
            set { Status = value; }
        }

        private DateTime EntryDateTime;

        public DateTime EntryDateTime1
        {
            get { return EntryDateTime; }
            set { EntryDateTime = value; }
        }
        private String CompletionDate = "";

        public String CompletionDate1
        {
            get { return CompletionDate; }
            set { CompletionDate = value; }
        }

        private String CompletionTime = "";

        public String CompletionTime1
        {
            get { return CompletionTime; }
            set { CompletionTime = value; }
        }

        private String ActualComplitionDate = "";

        public String ActualComplitionDate1
        {
            get { return ActualComplitionDate; }
            set { ActualComplitionDate = value; }
        }


        private String ActualComplitionTime = "";

        public String ActualComplitionTime1
        {
            get { return ActualComplitionTime; }
            set { ActualComplitionTime = value; }
        }

        private decimal WCP;

        public decimal WCP1
        {
            get { return WCP; }
            set { WCP = value; }
        }
        private String Remarks = "";

        public String Remarks1
        {
            get { return Remarks; }
            set { Remarks = value; }
        }

        private Boolean NotificationFlag = false;

        public Boolean NotificationFlag1
        {
            get { return NotificationFlag; }
            set { NotificationFlag = value; }
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
       //     Ope.AddParams("DeletedTask_ID", Task_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_DeletedTask_Select, Ope.GetParams());
        }

        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("Subject", Subject);
            Ope.AddParams("Detail", Detail);
            Ope.AddParams("Priority", Priority);
            Ope.AddParams("Status", Status);
            Ope.AddParams("WCP", WCP.ToString());

            Ope.AddParams("EntryDateTime", EntryDateTime.ToString());
            Ope.AddParams("CompletionDate", CompletionDate);
            Ope.AddParams("CompletionTime", CompletionTime);
            Ope.AddParams("NotificationFlag", NotificationFlag.ToString());

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_Insert, Ope.GetParams());

        }
       
    }
}
