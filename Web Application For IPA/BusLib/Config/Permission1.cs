using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ope = DataLib.SqlServer.OperationSQLServer;
using Val = BusLib.Validation.Validation;
using System.Data;

namespace BusLib.Config
{
   public class Permission1
    {
        private DataSet _DS = new DataSet();
        private const string _TableName = "Permission";

        public string TableName
        {
            get { return _TableName; }
        } 



        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }

        private string _UserID = "";

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private string _Design_Code = "";

        public string Design_Code
        {
            get { return _Design_Code; }
            set { _Design_Code = value; }
        }
        private int _PageID = 0;

        public int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        private bool _IsView = false;

        public bool IsView
        {
            get { return _IsView; }
            set { _IsView = value; }
        }

        private bool _IsInsert = false;

        public bool IsInsert
        {
            get { return _IsInsert; }
            set { _IsInsert = value; }
        }

        private bool _IsUpdate = false;

        public bool IsUpdate
        {
            get { return _IsUpdate; }
            set { _IsUpdate = value; }
        }

        private bool _IsDelete = false;

        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; }
        }

        public void CheckPermission(string PageName, string UserID, string Design_Code)
        {
            _DS.Clear();
            Ope.Clear();
            Ope.AddParams("PageName", PageName);
            Ope.AddParams("UserID", UserID);
            Ope.AddParams("Design_Code", Design_Code);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, _DS, _TableName, "USP_GetPermission", Ope.GetParams());

            if (_DS.Tables[_TableName].Rows.Count > 0)
            {
                Configuration.IsView = Convert.ToBoolean(_DS.Tables[_TableName].Rows[0]["ISVIEW"].ToString());
                Configuration.IsUpdate = Convert.ToBoolean(_DS.Tables[_TableName].Rows[0]["ISUPDATE"].ToString());
                Configuration.IsDelete = Convert.ToBoolean(_DS.Tables[_TableName].Rows[0]["ISDELETE"].ToString());
                Configuration.IsInsert = Convert.ToBoolean(_DS.Tables[_TableName].Rows[0]["ISINSERT"].ToString());
            }
            else
            {
                Configuration.IsView = false;
                Configuration.IsUpdate = false;
                Configuration.IsDelete = false;
                Configuration.IsInsert = false;
            }
        }
        public void Disp(string UserID, string Design_Code)
        {
            _DS.Clear();
            Ope.Clear();
            Ope.AddParams("UserID", UserID);
            Ope.AddParams("Design_Code", Design_Code);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, _DS, _TableName, "USP_DispPermission", Ope.GetParams());


        }
        public void Save(Permission1 pc1)
        {
            Ope.Clear();
            Ope.AddParams("Design_Code", pc1.Design_Code);
            Ope.AddParams("UserID", pc1.UserID);
            Ope.AddParams("PageID", pc1.PageID.ToString());
            Ope.AddParams("IsView", pc1.IsView.ToString());
            Ope.AddParams("IsInsert", pc1.IsInsert.ToString());
            Ope.AddParams("IsUpdate", pc1.IsUpdate.ToString());
            Ope.AddParams("IsDelete", pc1.IsDelete.ToString());
            int intre = Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, "USP_InsertPermission", Ope.GetParams());

        }
    }
}
