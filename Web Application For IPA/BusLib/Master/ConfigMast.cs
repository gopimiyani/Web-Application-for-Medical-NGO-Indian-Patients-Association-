using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Master
{
  public static class ConfigMast
    {
        private static DataSet _Ds = new DataSet();
        private const string _TABLENAME = "CONFIGMAST";

        public static DataSet DataSet
        {
            get{ return _Ds; }
        }

        public static string TableName
        {
            get { return _TABLENAME; }
        }

        public static string Stone_In_Jangad_Message
        {
            get { return GetConfigValue("STONE_IN_JANGAD"); }
        }

      
        public static void Fill()
        {

            Ope.Clear();
            Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, _Ds, _TABLENAME, "SRKUSP_ConfigMast_Fill", Ope.GetParams());
        }
        public static string GetConfigValue(string ConfigKey)
        {
            string Str = "";
            if ((string.IsNullOrEmpty(ConfigKey) == true))
                return null;
            DataView DV = _Ds.Tables[_TABLENAME].DefaultView;
            DV.RowFilter = " 1=1 And CONFIG_KEY='" + ConfigKey + "'";
            if (DV.Count != 0)
            {
                Str = DV[0]["CONFIG_VALUE"].ToString();
                DV.RowFilter = "";
                return Str;
            }
            DV.RowFilter = "";
            return null;
        }


    }
}
