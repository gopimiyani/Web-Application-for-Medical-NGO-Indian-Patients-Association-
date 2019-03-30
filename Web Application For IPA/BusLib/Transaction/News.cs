using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class News
    {
        public const string _TableName = "News";

            #region properties

        private int News_ID = 0;

        public int News_ID1
        {
            get { return News_ID; }
            set { News_ID = value; }
        }
        private int Admin_ID = 0;

        public int Admin_ID1
        {
            get { return Admin_ID; }
            set { Admin_ID = value; }
        }

        private string NewsTitle = "";

        public string NewsTitle1
        {
            get { return NewsTitle; }
            set { NewsTitle = value; }
        }
        private string NewsDescription = "";

        public string NewsDescription1
        {
            get { return NewsDescription; }
            set { NewsDescription = value; }
        }
        private string EntryDate = "";

        public string EntryDate1
        {
            get { return EntryDate; }
            set { EntryDate = value; }
        }
        private string EntryTime = "";

        public string EntryTime1
        {
            get { return EntryTime; }
            set { EntryTime = value; }
        }
        private string StartDate = "";

        public string StartDate1
        {
            get { return StartDate; }
            set { StartDate = value; }
        }
        private string CloseDate = "";

        public string CloseDate1
        {
            get { return CloseDate; }
            set { CloseDate = value; }
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
            Ope.AddParams("News_ID", News_ID.ToString());

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_News_Select, Ope.GetParams());
        }

        public void GetRecentNews()
        {

            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();

            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_News_GetRecentNews, Ope.GetParams());
        }

        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("Admin_ID",Admin_ID.ToString());
            Ope.AddParams("NewsTitle",NewsTitle);
            Ope.AddParams("NewsDescription",NewsDescription);
            Ope.AddParams("EntryDate",EntryDate);
            Ope.AddParams("EntryTime",EntryTime);
            Ope.AddParams("StartDate",StartDate);
            Ope.AddParams("CloseDate",CloseDate);

            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_News_Insert, Ope.GetParams());
        }


        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("News_ID", News_ID.ToString());
            Ope.AddParams("Admin_ID", Admin_ID.ToString());
            Ope.AddParams("NewsTitle", NewsTitle);
            Ope.AddParams("NewsDescription", NewsDescription);
            Ope.AddParams("EntryDate", EntryDate);
            Ope.AddParams("EntryTime", EntryTime);
            Ope.AddParams("StartDate", StartDate);
            Ope.AddParams("CloseDate", CloseDate);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_News_Update, Ope.GetParams());
        }

        
        public int Delete()
        {

            Ope.Clear();

            Ope.AddParams("News_ID", News_ID.ToString());
        
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_News_Delete, Ope.GetParams());
       
        }


    }
}
