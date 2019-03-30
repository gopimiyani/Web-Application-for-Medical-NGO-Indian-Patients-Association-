using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Transaction
{
    public class Login
    {
        public const string _TableName = "Registration";

        //private string TableName = "";

        //public string TableName1
        //{
        //    get { return TableName; }
        //    set { TableName = value; }
        //}
        
        private DataSet ds = new DataSet();
        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        private String UserName = "";

        public String UserName1
        {
            get { return UserName; }
            set { UserName = value; }
        }

        //private String Password = "";

        //public String Password1
        //{
        //    get { return Password; }
        //    set { Password = value; }
        //}

        private String UserType = "";

        public String UserType1
        {
            get { return UserType; }
            set { UserType = value; }
        }

        private string Status = "";

        public string Status1
        {
            get { return Status; }
            set { Status = value; }
        }

        public void GetLoginDetail()
        {
            if (ds != null)
            {
                ds.Clear();
            }
            Ope.Clear();
            Ope.AddParams("UserName", UserName);
            Ope.AddParams("UserType", UserType);
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_Registration_GetLoginDetail, Ope.GetParams());
        }   

           public  string ENCODE_DECODE(string pStr, string pStrToEncodeOrDecode)
        {
            int IntPos=0;
            string StrPass;
            string StrECode;
            string StrDCode;
            char ChrSingle;

            StrECode = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StrDCode = ")(*~^%$#@!";

            for (int IntLen = 1; IntLen <= 52; IntLen++)
            {
                StrDCode = StrDCode + (Char)(IntLen + 160);
            }

            StrPass = "";
            for (int IntCnt = 0; IntCnt <= pStr.Trim().Length - 1; IntCnt++)
            {
                ChrSingle = char.Parse(pStr.Substring(IntCnt, 1));
                if (pStrToEncodeOrDecode == "E")
                {
                    IntPos = StrECode.IndexOf(ChrSingle, 0);
                }
                else
                {
                    IntPos = StrDCode.IndexOf(ChrSingle, 0);
                }
                if (pStrToEncodeOrDecode == "E")
                {
                    StrPass = StrPass + StrDCode.Substring(IntPos, 1);
                }
                else
                {
                    StrPass = StrPass + StrECode.Substring(IntPos, 1);
                }
            }
            return StrPass;
        }
    

        //public void GetAdminLoginDetail()
        //{
        //    if (ds != null)
        //    {
        //        ds.Clear();
        //    }
        //    Ope.Clear();
        //    Ope.AddParams("UserName", UserName);
        //    Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, "Admin", StoreProcedures.SP_Admin_GetAdminLoginDetail, Ope.GetParams());
        //}
   


    }
   }

