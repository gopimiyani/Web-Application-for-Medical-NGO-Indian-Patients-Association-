using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class Task
    {
        private const string _TableName = "Task";

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
        private String CompletionDate="";

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

        private string ExtendedDays = "";

        public string ExtendedDays1
        {
            get { return ExtendedDays; }
            set { ExtendedDays = value; }
        }
        private String ActualComplitionDate="";

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

        private Boolean NFNew = false;

        public Boolean NFNew1
        {
            get { return NFNew; }
            set { NFNew = value; }
        }

        private Boolean NFUpdate = false;

        public Boolean NFUpdate1
        {
            get { return NFUpdate; }
            set { NFUpdate = value; }
        }

        private Boolean NFDelete = false;

        public Boolean NFDelete1
        {
            get { return NFDelete; }
            set { NFDelete = value; }
        }

        private Boolean NFComplete = false;

        public Boolean NFComplete1
        {
            get { return NFComplete; }
            set { NFComplete = value; }
        }

        private Boolean NFInProgress = false;

        public Boolean NFInProgress1
        {
            get { return NFInProgress; }
            set { NFInProgress = value; }
        }


        private Boolean NFNearerTask = false;

        public Boolean NFNearerTask1
        {
            get { return NFNearerTask; }
            set { NFNearerTask = value; }
        }

        private int Request_ID = 0;

        public int Request_ID1
        {
            get { return Request_ID; }
            set { Request_ID = value; }
        }

        private DataSet ds=new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        #endregion

        public void GetDataSet_GetVName()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Task_GetVName);
        }

        public void GetDataSet_GetVTask()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.AddParams("Status", Status);
        
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Task_GetVTask,Ope.GetParams());
        }

        public void GetDataSet_GetATask(string Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Keyword", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Task_GetATask, Ope.GetParams());
        }

        public void GetDataSet_GetVTaskDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("User_ID", User_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Task_GetVTaskDetail, Ope.GetParams());
        }

        public void GetDataSet_GetVViewTaskDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Task_ID", Task_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Task_GetVViewTaskDetail, Ope.GetParams());
        }

        public void GetDataSet_GetAViewTaskDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Task_ID", Task_ID.ToString());
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Task_GetAViewTaskDetail,Ope.GetParams());
        }

        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("User_ID",User_ID.ToString());
            Ope.AddParams("Admin_ID",Admin_ID.ToString());
            Ope.AddParams("Subject",Subject);
            Ope.AddParams("Detail",Detail);
            Ope.AddParams("Priority",Priority);
            Ope.AddParams("Status",Status);
            Ope.AddParams("WCP", WCP.ToString());
          
            Ope.AddParams("EntryDateTime",EntryDateTime.ToString());
            Ope.AddParams("CompletionDate",CompletionDate);
            Ope.AddParams("CompletionTime", CompletionTime);
            Ope.AddParams("NFNew", NFNew.ToString());
            Ope.AddParams("Request_ID", Request_ID.ToString());
         
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_Insert, Ope.GetParams());
        
        }
        public int AUpdate()
        {
            Ope.Clear();
            Ope.AddParams("Task_ID",Task_ID.ToString());
            Ope.AddParams("User_ID",User_ID.ToString());
            Ope.AddParams("Subject",Subject);
            Ope.AddParams("Detail",Detail);
            Ope.AddParams("Priority",Priority);
            Ope.AddParams("Status",Status);
            Ope.AddParams("EntryDateTime",EntryDateTime.ToString());
            Ope.AddParams("CompletionDate",CompletionDate.ToString());
            Ope.AddParams("CompletionTime", CompletionTime);
            Ope.AddParams("ExtendedDays", ExtendedDays);
       //     Ope.AddParams("WCP", WCP.ToString());
      //      Ope.AddParams("Remarks", Remarks);
      //      Ope.AddParams("ActualCompletionDate", ActualComplitionDate.ToString());
      //      Ope.AddParams("ActualCompletionTime", ActualComplitionTime);

      //      Ope.AddParams("NFUpdate", NFUpdate.ToString());
         
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_AUpdate, Ope.GetParams());
        }
        public int VUpdate()
        {
            Ope.Clear();
            Ope.AddParams("Task_ID",Task_ID.ToString());
            Ope.AddParams("WCP",WCP.ToString());
            Ope.AddParams("Status", Status);
            Ope.AddParams("Remarks",Remarks);
            Ope.AddParams("ActualCompletionDate",ActualComplitionDate);
            Ope.AddParams("ActualCompletionTime", ActualComplitionTime);
         
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_VUpdate, Ope.GetParams());
        }
        
        public int Delete()
        {

            Ope.Clear();
            Ope.AddParams("Task_ID", Task_ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_Delete, Ope.GetParams());
        }
        

        public void GetDataSet_GetExtendedCDateTask(string Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("Keyword", Value);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Task_GetExtendedCDateTask, Ope.GetParams());
        }

        public int UpdateNFNew()
        {
            Ope.Clear();
            Ope.AddParams("Task_ID", Task_ID.ToString());
            Ope.AddParams("NFNew", NFNew.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_UpdateNFNew, Ope.GetParams());
        }

        
        public int UpdateNFUpdate()
        {
            Ope.Clear();
            Ope.AddParams("Task_ID", Task_ID.ToString());
            Ope.AddParams("NFUpdate", NFUpdate.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_UpdateNFUpdate, Ope.GetParams());
        }
        public int UpdateNFComplete()
        {
            Ope.Clear();
            Ope.AddParams("Task_ID", Task_ID.ToString());
            Ope.AddParams("NFComplete", NFComplete.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_UpdateNFComplete, Ope.GetParams());
        }
        public int UpdateNFInProgress()
        {
            Ope.Clear();
            Ope.AddParams("Task_ID", Task_ID.ToString());
            Ope.AddParams("NFInProgress", NFInProgress.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_UpdateNFInProgress, Ope.GetParams());
        }

        public int UpdateNFNearerTask()
        {
            Ope.Clear();
            Ope.AddParams("Task_ID", Task_ID.ToString());
            Ope.AddParams("NFNearerTask", NFNearerTask.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Task_UpdateNFNearerTask, Ope.GetParams());
        }

    }
}

