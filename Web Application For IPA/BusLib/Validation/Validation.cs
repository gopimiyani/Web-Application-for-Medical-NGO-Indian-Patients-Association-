using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;



namespace BusLib.Validation
{
    /// <summary>
    /// Class For PerForm Validation In Application
    /// </summary>
    public class Validation 
    {
       
        /// <summary>
        /// Method For Checking Valid Date
        /// </summary>
        /// <param name="anyString">Date String </param>
        /// <returns>True Or False</returns>
        public static bool IsDate(string anyString)
        {
            if (anyString == null)
            {
                anyString = "";
            }
            if (anyString.Length > 0)
            {
                System.DateTime dummyDate;
                try
                {
                    dummyDate = DateTime.Parse(anyString);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
      
        /// <summary>
        /// Method For Display Date In [DD/MM/YYYY] Format
        /// </summary>
        /// <param name="pStrDate">Date String</param>
        /// <returns>True Or False</returns>

        public static string DispDate(string pStrDate)
        {
            if (pStrDate == "")
            {
                return "";
            }
            else
            {
                return Convert.ToDateTime(pStrDate).ToString("dd/MM/yyyy");
            }
        }
        public static string DispDate(DateTime? pDateTime)
        {
            if (pDateTime.HasValue == false)
            {
                return "";
            }
            else
            {
                return pDateTime.Value.ToString("dd/MM/yyyy");
            }
        }

        /// <summary>
        /// Method For Display Date In [HH:MM AM/PM] Format
        /// </summary>
        /// <param name="pStrTime">Time String</param>
        /// <returns>String</returns>
        public static string DispTime(string pStrTime)
        {
            if (pStrTime == "")
            {
                return "";
            }
            else
            {
                return Convert.ToDateTime(pStrTime).ToString("hh:mm tt");
            }
        }
        /// <summary>
        /// Display Time In (HH:MM AM/PM) format
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static string DispTime(DateTime? pDateTime)
        {
            if (pDateTime.HasValue == false)
            {
                return "";
            }
            else
            {
                return pDateTime.Value.ToString("hh:mm tt");
            }
        }
        /// <summary>
        /// Convert Date In (dd/MM/yyyy) format
        /// </summary>
        /// <param name="pStrDateTime"></param>
        /// <returns></returns>
        public static DateTime? DTDBDate(String pStrDateTime)
        {
            if (pStrDateTime == null || pStrDateTime == "")
            {
                DateTime? DT = null;
                return DT;
            }
            else
            {
                return DateTime.Parse(pStrDateTime);
            }
        }
        /// <summary>
        /// Convert Date In (dd/MM/yyyy) format
        /// </summary>
        /// <param name="pObjDateTime"></param>
        /// <returns></returns>
        public static DateTime? DTDBDate(Object pObjDateTime)
        {
            if (pObjDateTime == null || pObjDateTime.ToString() == "")
            {
                DateTime? DT = null;
                return DT;
            }
            else
            {
                return DateTime.Parse(pObjDateTime.ToString());
            }
        }
        /// <summary>
        /// Date Checking
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static DateTime? DTDBDate(DateTime? pDateTime)
        {
            if (pDateTime == null || pDateTime.ToString() == "")
            {
                DateTime? DT = null;
                return DT;
            }
            else
            {
                return pDateTime;
            }
        }
        /// <summary>
        /// Time Checking
        /// </summary>
        /// <param name="pStrDateTime"></param>
        /// <returns></returns>
        public static DateTime? DTDBTime(String pStrDateTime)
        {
            if (pStrDateTime == null || pStrDateTime == "")
            {
                DateTime? DT = null;
                return DT;
            }
            else
            {
                DateTime? DT = DateTime.Parse(pStrDateTime);
                DateTime? DTRet = new DateTime(1, 1, 1, DT.Value.Hour, DT.Value.Minute, DT.Value.Second);
                return DTRet;
            }
        }
        /// <summary>
        /// Data Access To Business Layer For Time
        /// </summary>
        /// <param name="pObjDateTime"></param>
        /// <returns></returns>
        public static DateTime? DTDBTime(Object pObjDateTime)
        {
            if (pObjDateTime == null || pObjDateTime.ToString() == "")
            {
                DateTime? DT = null;
                return DT;
            }
            else
            {
                DateTime? DT = DateTime.Parse(pObjDateTime.ToString());
                DateTime? DTRet = new DateTime(1, 1, 1, DT.Value.Hour, DT.Value.Minute, DT.Value.Second);
                return DTRet;
            }
        }
        /// <summary>
        /// Data Access To Business Layer For Time
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static DateTime? DTDBTime(DateTime? pDateTime)
        {
            if (pDateTime == null || pDateTime.ToString() == "")
            {
                DateTime? DT = null; // new DateTime(1, 1, 1); 
                return DT;
            }
            else
            {
                DateTime? DTRet = new DateTime(1, 1, 1, pDateTime.Value.Hour, pDateTime.Value.Minute, pDateTime.Value.Second);
                return DTRet;
                //return DateTime.Parse(pDateTime.ToString("hh:mm tt"));
            }
        }

        /// <summary>
        /// Method For Display Date In Sql [MM/DD/YYYY] Format
        /// </summary>
        /// <param name="pStrDate">Date String</param>
        /// <returns>String</returns>
        public static string SqlDate(string pStrDate)
        {
            if (pStrDate.Length == 0)
            {
                return "";
            }
            else
            {
                //return "'" + DateTime.Parse(pStrDate).ToString(new System.Globalization.CultureInfo("en-US", false)).ToString() + "'";
                return "" + DateTime.Parse(pStrDate).ToString("MM/dd/yy") + "";
            }
        }
        /// <summary>
        /// Method For Display Time In Sql [HH:MM AM/PM] Format
        /// </summary>
        /// <param name="pStrTime">Time String</param>
        /// <returns>String</returns>
        public static string SqlTime(string pStrTime)
        {
            if (pStrTime.Length == 0)
            {
                return "";
            }
            else
            {
                return Convert.ToDateTime(pStrTime).ToString("hh:mm tt");
            }
        }
        /// <summary>
        /// Method For Display Date In Sql Short [MM/DD/YY] Format
        /// </summary>
        /// <param name="pStrDate">Date String</param>
        /// <returns>String</returns>
        public static string SqlShortDate(string pStrDate)
        {
            if (pStrDate.Length == 0)
            {
                return "";
            }
            else
            {
                return DateTime.Parse(pStrDate).ToString("MM/dd/yy");
            }
        }
        /// <summary>
        /// Method For Display Time In Sql Short [HH:MM AM/PM] Format
        /// </summary>
        /// <param name="pStrTime">Time String</param>
        /// <returns>String</returns>
        public static string SqlShortTime(string pStrTime)
        {
            if (pStrTime.Length == 0)
            {
                return "";
            }
            else
            {
                return DateTime.Parse(pStrTime).ToString("hh:mm tt");
            }
        }

        /// <summary>
        /// Method For Display Date In Short [DD/MM/YY] Format
        /// </summary>
        /// <param name="pStrDate">Date String</param>
        /// <returns>String</returns>
        public static string DispShortDate(string pStrDate)
        {
            if (pStrDate.Length == 0)
            {
                return "";
            }
            else
            {
                return DateTime.Parse(pStrDate).ToString("dd/MM/yy");
            }
        }
        /// <summary>
        /// Method For Display Time In Short [HH:MM AM/PM] Format
        /// </summary>
        /// <param name="pStrTime"></param>
        /// <returns></returns>
        public static string DispShortTime(string pStrTime)
        {
            if (pStrTime.Length == 0)
            {
                return "";
            }
            else
            {
                return DateTime.Parse(pStrTime).ToString("hh:mm tt");
            }
        }
     
      
        /// <summary>
        /// Method for Validating String Value
        /// </summary>
        /// <param name="Str">String Value</param>
        /// <returns>Double</returns>
        public static double Val(String Str)
        {
            return Convert.ToDouble( Microsoft.VisualBasic.Conversion.Val(Str));
        }
        /// <summary>
        /// Method for Validating Object Value
        /// </summary>
        /// <param name="Str">Object Str</param>
        /// <returns>Double </returns>
        public static double Val(Object Str)
        {
            return Convert.ToDouble(Microsoft.VisualBasic.Conversion.Val(Str));
        }
        /// <summary>
        /// Method For Remove Leading & Trailing Blank Space From String
        /// </summary>
        /// <param name="Str">String Str</param>
        /// <returns>String</returns>
        public static string Trim(String Str)
        {
            return Microsoft.VisualBasic.Strings.Trim((Str));
        }

        public static Decimal ToDecimal(String pStr)
        {
            return Convert.ToDecimal("0" + pStr);
        }

        public static int ToInt(String pStr)
        {
            return Convert.ToInt32(Microsoft.VisualBasic.Conversion.Val(pStr));
        }

        public static Int64 ToInt64(String pStr)
        {
            return Convert.ToInt64(Microsoft.VisualBasic.Conversion.Val(pStr));
        }

        public static double ToDouble(String pStr)
        {
            return Convert.ToDouble("0" + pStr);
        }

        public static Decimal ToDecimal(Object pObj)
        {
            return Convert.ToDecimal(Microsoft.VisualBasic.Conversion.Val(pObj) + "");
        }

        public static int ToInt(Object pObj)
        {
            return Convert.ToInt32(Microsoft.VisualBasic.Conversion.Val(pObj));
        }

        public static double ToDouble(Object pObj)
        {
            return Convert.ToDouble(Microsoft.VisualBasic.Conversion.Val(pObj) + "");
        }

        public static string ToString(Object pObj)
        {
            return string.IsNullOrEmpty(pObj.ToString()) ? "" : pObj.ToString();
        }

        public static Int16 ToInt16(Object pObj)
        {
            return Convert.ToInt16(Microsoft.VisualBasic.Conversion.Val(pObj));
        }

        public static Int16 ToInt16(String pStr)
        {
            return Convert.ToInt16(Microsoft.VisualBasic.Conversion.Val(pStr));
        }

        /// <summary>Method For Extracting Left Side Part Of String
        /// Get Left Side String Of A Given Length
        /// </summary>
        /// <param name="pStr">Original String</param>
        /// <param name="pLength">Number Of Characters To Extract</param>
        /// <returns>String</returns>
        public static string Left(String pStr, int pLength)
        {
            return Microsoft.VisualBasic.Strings.Left(pStr, pLength);
        }
        /// <summary>Method For Extracting Right Side Part Of String
        /// Get Right Side String Of A Given Length
        /// </summary>
        /// <param name="pStr">Original String</param>
        /// <param name="pLength">Number Of Characters To Extract</param>
        /// <returns>String</returns>

        public static string Right(String pStr, int pLength)
        {
            return Microsoft.VisualBasic.Strings.Right(pStr, pLength);
        }

        public static char Chr(int pIntChar)
        {
            return Microsoft.VisualBasic.Strings.Chr(pIntChar);
        }
        /// <summary>
        /// To Format String With Object Expression
        /// </summary>
        /// <param name="Expression"></param>
        /// <param name="Style"></param>
        /// <returns></returns>
        public static string Format(object Expression, string Style)
        {
            if (Style.IndexOf('#') != -1)
            {
                if (Style.IndexOf('.') != -1)
                {
                    double douval = ToDouble(Expression);
                    return Microsoft.VisualBasic.Strings.Format(douval, Style);
                }
                else
                {
                    Int64 int64val = ToInt64(Convert.ToString(Expression));
                    return Microsoft.VisualBasic.Strings.Format(int64val, Style);
                }
            }
            else
            {
                return Microsoft.VisualBasic.Strings.Format(Expression, Style);
            }

        }


        //Added Later
        public static int ToBoolToInt(Object pObj)
        {
            if (pObj == null) return 0;
            if (pObj.ToString().Length == 0) return 0;
            if (((Boolean)pObj) == true) return 1;
            else return 0;
        }

        public static int ToBoolToInt(String pStr)
        {
            if (pStr == null) return 0;
            if ((Convert.ToBoolean(pStr) == true)) return 1;
            else return 0;
        }
    }
}
