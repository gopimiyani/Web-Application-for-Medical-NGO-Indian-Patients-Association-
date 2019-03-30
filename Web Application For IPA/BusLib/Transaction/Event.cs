using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;


namespace BusLib.Transaction
{
    public class Event
    {
        public const string _TableName = "Event";

            #region properties

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
        private string StartTime = "";

        public string StartTime1
        {
            get { return StartTime; }
            set { StartTime = value; }
        }

        private string EndTime = "";

        public string EndTime1
        {
            get { return EndTime; }
            set { EndTime = value; }
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


        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }


            #endregion

        public void GetDataset(String Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
          
            Ope.AddParams("Event_ID", Event_ID.ToString());
          
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Event_Select, Ope.GetParams());
        }

        public int Insert()
        {
            Ope.Clear();
        
            Ope.AddParams("Admin_ID",Admin_ID.ToString());
            Ope.AddParams("EventName",EventName);
            Ope.AddParams("EventDescription",EventDescription);
            Ope.AddParams("EventDate",EventDate);
            Ope.AddParams("StartTime", StartTime);
            Ope.AddParams("EndTime", EndTime);
            Ope.AddParams("Location", Location);
            Ope.AddParams("EntryDate", EntryDate);

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Event_Insert, Ope.GetParams());
        }


        public int Update()
        {
            Ope.Clear();

            Ope.AddParams("Event_ID", Event_ID.ToString());
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("EventName", EventName);
            Ope.AddParams("EventDescription", EventDescription);
            Ope.AddParams("EventDate", EventDate);
            Ope.AddParams("StartTime", StartTime);
            Ope.AddParams("EndTime", EndTime);
            Ope.AddParams("Location", Location);
            Ope.AddParams("EntryDate", EntryDate);

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Event_Update, Ope.GetParams());
        }

        public int Delete()
        {

            Ope.Clear();

            Ope.AddParams("Event_ID", Event_ID.ToString());
        
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_Event_Delete, Ope.GetParams());
       
        }
    }
}
