using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ope = DataLib.SqlServer.OperationSQLServer;
using Val = BusLib.Validation.Validation;

namespace BusLib.Utility
{
   public class Utility
    {
        private int _NewID = 0;
        private int _NewInvNo = 0;
        private int _NewJanNo = 0;

        public int NewID
        {
            get { return _NewID; }
        }
        public int NewInvNo
        {
            get { return _NewInvNo; }
        }
        public int NewJanNo
        {
            get { return _NewJanNo; }
        }

        public void FindNewInvAndJanNo(string LoginName, string JanDate)
        {
            DataSet _NewDS = new DataSet();
            try
            {
                Ope.AddParams("LOGINNAME", LoginName);
                Ope.AddParams("JANDATE", JanDate);
                Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, _NewDS, "SRKUSP_Utility_FindNewInvAndJanNo", Ope.GetParams());

                if (_NewDS.Tables[0].Rows[0]["ID"].ToString() != "0")
                { _NewID = Val.ToInt(_NewDS.Tables[0].Rows[0]["ID"].ToString() + "") + 1; }
                else
                { _NewID = 1; }

                if (_NewDS.Tables[1].Rows[0]["INVNO"].ToString() != "0")
                { _NewInvNo = Val.ToInt(_NewDS.Tables[1].Rows[0]["INVNO"].ToString() + "") + 1; }
                else
                { _NewInvNo = 1; }

                if (_NewDS.Tables[2].Rows[0]["JANNO"].ToString() != "0")
                { _NewJanNo = Val.ToInt(_NewDS.Tables[2].Rows[0]["JANNO"].ToString() + "") + 1; }
                else
                { _NewJanNo = 9001; }

                SaveJanNo(JanDate, _NewJanNo, 0);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void SaveJanNo(string JanDate, int JanNo,int JanPcs)
        {
            try
            {
             
                Ope.AddParams("JANDATE", JanDate);
                Ope.AddParams("JANNO", JanNo.ToString());
                Ope.AddParams("JANPCS", JanPcs.ToString());
                Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, "SRKUSP_JanNo_Save", Ope.GetParams());
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
