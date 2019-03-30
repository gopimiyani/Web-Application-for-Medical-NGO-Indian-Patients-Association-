using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ope = DataLib.SqlServer.OperationSQLServer;
using System.Data;
namespace BusLib.Report
{
    public class ExcelSheetReport
    {
        public DataSet GetExcelReport(string ExcelPage,DateTime FromDate,DateTime ToDate )
        {
            try
            {
                DataSet _DS = new DataSet();
                Ope.AddParams("ExcelPage", ExcelPage);
                Ope.AddParams("FromDate", FromDate.ToString("MM/dd/yyyy"));
                Ope.AddParams("ToDate", ToDate.ToString("MM/dd/yyyy"));
 //               Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, _DS, BusLib.Tables.ExcelReportList , StoreProcedures.ADMIN_GetExcelReport,Ope.GetParams());
                return _DS;
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetExcelPageReport()
        {
            try
            {
                DataSet _DS = new DataSet();
   //             Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, _DS, BusLib.Tables.ExcelReportPageList, StoreProcedures.ADMIN_GetExcelPageReport);
                return _DS;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
