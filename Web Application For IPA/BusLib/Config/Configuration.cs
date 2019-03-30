using System;
using System.Configuration; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusLib.Config
{
   public class Configuration
    {
        #region InterNet Server Details...

        public static string InterNetServerConnStr
        {
            get { return ConfigurationSettings.AppSettings["ServerConnectionString"].ToString(); }
        }
    
        public static string PartnetEmailID
        {
            get { return ConfigurationSettings.AppSettings["PartnerEMailID"].ToString(); }
        }

        public static string AdminEmailID
        {
            get { return ConfigurationSettings.AppSettings["mailfrom"].ToString(); }
        }

        public static string SMTPUser
        {
            get { return ConfigurationSettings.AppSettings["SMTPUser"].ToString(); }
        }
        public static string SMTPPassword
        {
            get { return ConfigurationSettings.AppSettings["SMTPPassword"].ToString(); }
        }
        public static string SMTPAddress
        {
            get { return ConfigurationSettings.AppSettings["SMTPAddress"].ToString(); }
        }
        public static int SMTPPort
        {
            get { return Validation.Validation.ToInt(ConfigurationSettings.AppSettings["SMTPPORT"].ToString()); }
        }
        public static string CertificateServerPath
        {
            get { return ConfigurationSettings.AppSettings["CertificateServerPath"].ToString(); }
        }

        public static string CertificateServer
        {
            get { return ConfigurationSettings.AppSettings["_ServerFTP"].ToString(); }
        }

        public static string CertificateServerUserName
        {
            get { return ConfigurationSettings.AppSettings["_ServFTPDBUser"].ToString(); }
        }
        public static string CertificateServerPassWord
        {
            get { return ConfigurationSettings.AppSettings["_ServFTPDBPass"].ToString(); }
        }

        public static string ClientIP
        {
            get { return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();  }
        }
        private static string _DesignCode = "";

        public static string DesignCode
        {
            get { return Configuration._DesignCode; }
            set { Configuration._DesignCode = value; }
        }

        private static string _ClientLoginName = "";
        public static string ClientLoginName
        {
            get { return _ClientLoginName; }
            set { _ClientLoginName = value; }
        }

        private static string _PageName = "";

        public static string PageName
        {
            get { return Configuration._PageName; }
            set { Configuration._PageName = value; }
        }
        private static bool _IsView = false;

        public static bool IsView
        {
            get { return Configuration._IsView; }
            set { Configuration._IsView = value; }
        }
        private static bool _IsInsert = false;

        public static bool IsInsert
        {
            get { return Configuration._IsInsert; }
            set { Configuration._IsInsert = value; }
        }
        private static bool _IsUpdate = false;

        public static bool IsUpdate
        {
            get { return Configuration._IsUpdate; }
            set { Configuration._IsUpdate = value; }
        }
        private static bool _IsDelete = false;

        public static bool IsDelete
        {
            get { return Configuration._IsDelete; }
            set { Configuration._IsDelete = value; }
        }

        private static string _AdminLoginName = "";
        public static string AdminLoginName
        {
            get { return _AdminLoginName; }
            set { _AdminLoginName = value; }
        }
      
        private static int _ShowHeader = 0;
        public static int ShowHeader
        {
            get { return _ShowHeader; }
            set { _ShowHeader = value; }
        }

        private static int _PanelUnitHeight = 450;
        public static int PanelUnitHeight
        {
            get { return _PanelUnitHeight; }
            set { _PanelUnitHeight = value; }
        }

        private static int _ClientHeight = 768;
        public static int ClientHeightResolution
        {
            get { return _ClientHeight; }
            set { _ClientHeight = value; }
        }
        private static int _ClientWidth = 1024;
        public static int ClientWidthResolution
        {
            get { return _ClientWidth; }
            set { _ClientWidth = value; }
        }
        #endregion

    

        public static string InterNet { get; set; }
    }
}
