using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ope = DataLib.SqlServer.OperationSQLServer;

namespace BusLib.Master
{
    public class ImageMast
    {
        public const String _TableName="ImageMaster";

        #region properties

        private int ImageID = 0;

        public int ImageID1
        {
            get { return ImageID; }
            set { ImageID = value; }
        }



        private int AlbumID = 0;

        public int AlbumID1
        {
            get { return AlbumID; }
            set { AlbumID = value; }
        }





        private String ImageName = "";

        public String ImageName1
        {
            get { return ImageName; }
            set { ImageName = value; }
        }

        
        private DataSet ds=new DataSet();

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        private SqlDataReader dr;

        public SqlDataReader Dr
        {
            get { return dr; }
            set { dr = value; }
        }

        #endregion

        public void GetDataSet(string Value)
        {
            if (ds != null)
            {
                ds.Clear();
            }
         Ope.Clear();
         Ope.AddParams("Name", Value);
      
         Ope.FillDataSet(BusLib.Config.Configuration.InterNetServerConnStr, ds, _TableName, StoreProcedures.SP_ImageMaster_Select);
        }
        
        public int Insert()
        {
            Ope.Clear();
            Ope.AddParams("Album_ID", AlbumID.ToString());
            Ope.AddParams("ImageName", ImageName);
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_ImageMaster_Insert, Ope.GetParams());
         }
        public int Update()
        {
            Ope.Clear();
            Ope.AddParams("ID", ImageID.ToString());
            Ope.AddParams("ImageName", ImageName);
            Ope.AddParams("Album_ID", AlbumID.ToString());
          
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_ImageMaster_Update, Ope.GetParams());
        }
        public int Delete()
        {
            Ope.Clear();
            Ope.AddParams("ID", ImageID.ToString());
            return Ope.ExNonQuery(BusLib.Config.Configuration.InterNetServerConnStr, StoreProcedures.SP_ImageMaster_Delete, Ope.GetParams());
        }
      
        
    }
 }
   
