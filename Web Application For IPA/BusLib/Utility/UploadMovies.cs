using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ope = DataLib.SqlServer.OperationSQLServer;
using System.Data;
namespace BusLib.Utility
{
   public class UploadMovies
    {
       public bool UpdateMovie(string STONEID)
       {
           bool Result = false;
           Ope.AddParams("STONEID", STONEID);
      
           //Ope.AddParams("@return",);
          // Result = Convert.ToBoolean(Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.ADMIN_UpdateMovieFile, Ope.GetParams()));

           return Result;
       }

    }
}
