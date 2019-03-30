using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ope = DataLib.SqlServer.OperationSQLServer;
using System.Data;
namespace BusLib.Report
{
    public class Report
    {
        public DataSet GetOrderNo(string Type)
        {
            try
            {
                DataSet _DS = new DataSet();
                _DS.Clear();
                Ope.Clear();
                Ope.AddParams("Type", Type);
                Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, _DS, "OrderNo", "SP_Mast_CmbFill", Ope.GetParams());
                return _DS;
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}
