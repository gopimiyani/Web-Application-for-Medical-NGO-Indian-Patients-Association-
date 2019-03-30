using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;
using Val = BusLib.Validation.Validation;

namespace BusLib.Utility
{
    public class PageMast
    {
       
        public const string _TableName = "PageMaster";

        #region Properties

        private DataSet ds = new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }
        public string TableName
        {
            get { return _TableName; }
        }

        private int Page_ID = 0;

        public int Page_ID1
        {
            get { return Page_ID; }
            set { Page_ID = value; }
        }
        private string PageName = "";

        public string PageName1
        {
            get { return PageName; }
            set { PageName = value; }
        }
        private string Description = "";

        public string Description1
        {
            get { return Description; }
            set { Description = value; }
        }
        private string Menu = "";

        public string Menu1
        {
            get { return Menu; }
            set { Menu = value; }
        }
        
        #endregion


        public void GetDataset()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_PageMaster_Select);
        }


        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("PageName", PageName);
            Ope.AddParams("Description", Description);
            Ope.AddParams("Menu", Menu);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_PageMaster_Insert, Ope.GetParams());
        }
        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("PageID", Page_ID.ToString());
            Ope.AddParams("PageName", PageName);
            Ope.AddParams("Description", Description);
            Ope.AddParams("Menu", Menu);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_PageMaster_Update, Ope.GetParams());
        }
        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("PageID", Page_ID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_PageMaster_Delete, Ope.GetParams());
        }
    //    public int Save(string PageID,string PageName,string Descr,string Menu)
    //    {
    //        Ope.Clear();
    //        Ope.AddParams("PAGEID", PageID);
    //        Ope.AddParams("PAGENAME", PageName);
    //        Ope.AddParams("PAGEDESCR", Descr);
    //        Ope.AddParams("MENU", Menu);
            
    //       return  Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.USP_InsertPage, Ope.GetParams());
    //    }

    //    public int Delete(string PageID)
    //    {
    //        Ope.Clear();
    //        Ope.AddParams("PAGEID", PageID);
    //        return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.USP_DeletePage, Ope.GetParams());
    //    }
    }
}
