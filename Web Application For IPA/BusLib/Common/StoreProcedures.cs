using System;
using System.Collections.Generic;
using System.Text;

namespace BusLib
{
    public static class StoreProcedures
    {

        #region Admintemp
        public const string ADMIN_RenderAdminMenu = "ADMIN_RenderAdminMenu";
        public const string ADMIN_AdminPageWisePer = "ADMIN_AdminPageWisePer";
        public const string ADMIN_AdminPerUpd = "ADMIN_AdminPerUpd";

        public const string ADMIN_AdminMast_FindAdminLogin = "ADMIN_AdminMast_FindAdminLogin";
        public const string ADMIN_AdminMast_FindSRKNewsLogin = "ADMIN_AdminMast_FindSRKNewsLogin";

        public const string ADMIN_AdminMast_FindAdminInfo = "ADMIN_AdminMast_FindAdminInfo";
        public const string ADMIN_GetClientList = "ADMIN_GetClientList";
        public const string ADMIN_GetAdminList = "ADMIN_GetAdminList";
        public const string ADMIN_IsAdminExists = "ADMIN_IsAdminExists";
        public const string ADMIN_GetPermission = "ADMIN_GetPermission";
        public const string ADMIN_GetLoginName = "ADMIN_GetLoginName";

        public const string ADMIN_AdminAddUserUpd = "ADMIN_AdminAddUserUpd";
        public const string ADMIN_AdminAddUserDeletion = "ADMIN_AdminAddUserDeletion";
        public const string ADMIN_AdminUserDisp = "ADMIN_AdminUserDisp";


        public const string ADMIN_GetGroupList = "ADMIN_GetGroupList";
        public const string ADMIN_InsertGroup = "ADMIN_InsertGroup";
        public const string ADMIN_UpdateGroup = "ADMIN_UpdateGroup";
        public const string ADMIN_DeleteGroup = "ADMIN_DeleteGroup";

        #endregion

        //--IPA START

        #region Common

      
    
        #endregion

        
        #region DeletedTask

        public const string SP_DeletedTask_Select = "SP_DeletedTask_Select";
        public const string SP_DeletedTask_Insert= "SP_DeletedTask_Insert";

    
        #endregion

        #region Notification

        public const string SP_Notification_Admin = "SP_Notification_Admin";
        public const string SP_Notification_Volunteer = "SP_Notification_Volunteer";
        public const string SP_Notification_Hospital = "SP_Notification_Hospital";
        public const string SP_Notification_PharmaCompany = "SP_Notification_PharmaCompany";
        public const string SP_Notification_BloodBank = "SP_Notification_BloodBank";
        public const string SP_Notification_Doctor = "SP_Notification_Doctor";
        
        #endregion

        #region Alert

        public const string SP_Alert_Volunteer = "SP_Alert_Volunteer";

    
        #endregion

        
        #region Dashboard

        public const string SP_DashboardIcons_Admin = "SP_DashboardIcons_Admin";
        public const string SP_DashboardIcons_Volunteer = "SP_DashboardIcons_Volunteer";

        #endregion

        #region SuperAdmin

        public const string SP_SuperAdmin_Select = "SP_SuperAdmin_Select";
        public const string SP_SuperAdmin_GetAdminLoginDetail = "SP_SuperAdmin_GetAdminLoginDetail";
        public const string SP_SuperAdmin_Update = "SP_SuperAdmin_Update";

        public const string SP_SuperAdmin_ResetPassword = "SP_SuperAdmin_ResetPassword";
        public const string SP_SuperAdmin_ForgotPassword = "SP_SuperAdmin_ForgotPassword";
        public const string SP_SuperAdmin_GetAdminResetPwdDetail = "SP_SuperAdmin_GetAdminResetPwdDetail";
        public const string SP_SuperAdmin_SetRandomNo = "SP_SuperAdmin_SetRandomNo";

       
        #endregion

        #region Admin

        public const string SP_Admin_Select = "SP_Admin_Select";
        public const string SP_Admin_Insert = "SP_Admin_Insert";
        public const string SP_Admin_Update = "SP_Admin_Update";
        public const string SP_Admin_Delete = "SP_Admin_Delete";

        public const string SP_Admin_Search = "SP_Admin_Search";
        public const string SP_Admin_GetAName = "SP_Admin_GetAName";
        public const string SP_Admin_GetEmail = "SP_Admin_GetEmail";
        public const string SP_Admin_ResetPassword = "SP_Admin_ResetPassword";
        public const string SP_Admin_ForgotPassword = "SP_Admin_ForgotPassword";
        public const string SP_Admin_GetAdminResetPwdDetail = "SP_Admin_GetAdminResetPwdDetail";
        public const string SP_Admin_SetRandomNo = "SP_Admin_SetRandomNo";

        public const string SP_Admin_GetUserName = "SP_Admin_GetUserName";
        public const string SP_Admin_GetAdminDetail = "SP_Admin_GetAdminDetail";
        public const string SP_Admin_GetWorkingPinCode = "SP_Admin_GetWorkingPinCode";
        public const string SP_Admin_SelectCityState = "SP_Admin_SelectCityState";
        public const string SP_Admin_UpdateWorkingPincode = "SP_Admin_UpdateWorkingPincode";
        
        #endregion

        #region Master


        public const string SP_StateMaster_Select = "SP_StateMaster_Select";
        public const string SP_StateMaster_Insert = "SP_StateMaster_Insert";
        public const string SP_StateMaster_Update = "SP_StateMaster_Update";
        public const string SP_StateMaster_Delete = "SP_StateMaster_Delete";
       
        public const string SP_CityMaster_Select = "SP_CityMaster_Select";
        public const string SP_CityMaster_Insert = "SP_CityMaster_Insert";
        public const string SP_CityMaster_Update = "SP_CityMaster_Update";
        public const string SP_CityMaster_Delete = "SP_CityMaster_Delete";
        public const string SP_CityMaster_GetCity = "SP_CityMaster_GetCity";


        public const string SP_SHMaster_Select = "SP_SHMaster_Select";
        public const string SP_SHMaster_Insert = "SP_SHMaster_Insert";
        public const string SP_SHMaster_Update = "SP_SHMaster_Update";
        public const string SP_SHMaster_Delete = "SP_SHMaster_Delete";

        public const string SP_TermMaster_Select = "SP_TermMaster_Select";
        public const string SP_TermMaster_Insert = "SP_TermMaster_Insert";
        public const string SP_TermMaster_Update = "SP_TermMaster_Update";
        public const string SP_TermMaster_Delete = "SP_TermMaster_Delete";

        public const string SP_UserMaster_Select = "SP_UserMaster_Select";
        public const string SP_UserMaster_Insert = "SP_UserMaster_Insert";
        public const string SP_UserMaster_Update = "SP_UserMaster_Update";
        public const string SP_UserMaster_Delete = "SP_UserMaster_Delete";

        public const string SP_ImageMaster_Select = "SP_ImageMaster_Select";
        public const string SP_ImageMaster_Insert = "SP_ImageMaster_Insert";
        public const string SP_ImageMaster_Update = "SP_ImageMaster_Update";
        public const string SP_ImageMaster_Delete = "SP_ImageMaster_Delete";

        public const string SP_AlbumMaster_Select = "SP_AlbumMaster_Select";
        public const string SP_AlbumMaster_Insert = "SP_AlbumMaster_Insert";
        public const string SP_AlbumMaster_Update = "SP_AlbumMaster_Update";
        public const string SP_AlbumMaster_Delete = "SP_AlbumMaster_Delete";

        public const string SP_IpMaster_Select = "SP_IpMaster_Select";
        public const string SP_IpMaster_Insert = "SP_IpMaster_Insert";
        public const string SP_IpMaster_Update = "SP_IpMaster_Update";
        public const string SP_IpMaster_Delete = "SP_IpMaster_Delete";

        public const string SP_PincodeMaster_Insert = "Sp_PincodeMaster_Insert";
        public const string SP_Pincode1_Select = "SP_Pincode1_Select";
        public const string SP_PincodeMaster_Delete = "SP_PincodeMaster_Delete";
        public const string SP_PincodeMaster_Update = "SP_PincodeMaster_Update";
        public const string SP_PincodeMaster_GetWorkingPincode = "SP_PincodeMaster_GetWorkingPincode";
        public const string SP_Pincode_GetPincode = "SP_Pincode_GetPincode";


    #endregion

        #region Utility

        public const string SP_PageMaster_Select = "SP_PageMaster_Select";
        public const string SP_PageMaster_Insert = "SP_PageMaster_Insert";
        public const string SP_PageMaster_Update = "SP_PageMaster_Update";
        public const string SP_PageMaster_Delete = "SP_PageMaster_Delete";

        public const string SP_Permission_Select = "SP_Permission_Select";
        public const string SP_Permission_Insert_Update = "SP_Permission_Insert_Update";
        //public const string SP_Admin_Select = "SP_Admin_Select";
    #endregion

        #region Registration
        public const string SP_Registration_Insert = "SP_Registration_Insert";
        public const string SP_Registration_Delete = "SP_Registration_Delete";
        public const string SP_Registration_Update = "SP_Registration_Update";
        public const string SP_Registration_Select = "SP_Registration_Select";

        public const string SP_Registration_Select_StakeHolder = "SP_Registration_Select_StakeHolder";
        public const string SP_Registration_GetUserName = "SP_Registration_GetUserName";
        public const string SP_Registration_GetEmail = "SP_Registration_GetEmail";
        public const string SP_Registration_GetUser="SP_Registration_GetUser";
        public const string SP_Registration_GetUserDetail="SP_Registration_GetUserDetail";
        public const string SP_Registration_GetPendingUser = "SP_Registration_GetPendingUser";


        public const string SP_Registration_GetAdminProfile = "SP_Registration_GetAdminProfile";
        public const string SP_Registration_GetVolunteerProfile = "SP_Registration_GetVolunteerProfile";
        public const string SP_Registration_GetHospitalProfile = "SP_Registration_GetHospitalProfile";
        public const string SP_Registration_GetBloodBankProfile = "SP_Registration_GetBloodBankProfile";
        public const string SP_Registration_GetPharmaCompanyProfile = "SP_Registration_GetPharmaCompanyProfile";
        public const string SP_Registration_GetDoctorProfile = "SP_Registration_GetDoctorProfile";
        public const string SP_Registration_UpdateStatus = "SP_Registration_UpdateStatus";

        public const string SP_Registration_FillSH = "SP_Registration_FillSH";
        public const string SP_Registration_Search = "SP_Registration_Search";
        public const string SP_StakeHolder_Search = "SP_StakeHolder_Search";
        public const string SP_Registration_GetVolunteerDetail = "SP_Registration_GetVolunteerDetail";

        public const string SP_Registration_ForgotPassword = "SP_Registration_ForgotPassword";
        public const string SP_Registration_ResetPassword = "SP_Registration_ResetPassword";
        public const string SP_Registration_GetUserResetPwdDetail = "SP_Registration_GetUserResetPwdDetail";        
        public const string SP_Registration_SetRandomNo = "SP_Registration_SetRandomNo";

        public const string SP_Registration_UpdateNF = "SP_Registration_UpdateNF";
        
       
        public const string SP_Registration_GetProfile = "SP_Registration_GetProfile";
        
        #endregion

        #region Login

        public const string SP_Registration_GetLoginDetail = "SP_Registration_GetLoginDetail";
        public const string SP_Admin_GetAdminLoginDetail = "SP_Admin_GetAdminLoginDetail";
       
        #endregion

        #region Task

        public const string SP_Task_Insert = "SP_Task_Insert";
        public const string SP_Task_AUpdate = "SP_Task_AUpdate";
        public const string SP_Task_VUpdate = "SP_Task_VUpdate";        
        public const string SP_Task_Delete = "SP_Task_Delete";

        public const string SP_Task_GetVName = "SP_Task_GetVName";
        public const string SP_Task_GetVTask = "SP_Task_GetVTask";
        public const string SP_Task_GetATask = "SP_Task_GetATask";
        public const string SP_Task_GetVTaskDetail = "SP_Task_GetVTaskDetail";
        public const string SP_Task_GetVViewTaskDetail = "SP_Task_GetVViewTaskDetail";
        public const string SP_Task_GetAViewTaskDetail = "SP_Task_GetAViewTaskDetail";

        public const string SP_Task_GetExtendedCDateTask = "SP_Task_GetExtendedCDateTask";

        public const string SP_Task_UpdateNFNew = "SP_Task_UpdateNFNew";
        public const string SP_Task_UpdateNFUpdate = "SP_Task_UpdateNFUpdate";
        public const string SP_Task_UpdateNFComplete = "SP_Task_UpdateNFComplete";
        public const string SP_Task_UpdateNFInProgress = "SP_Task_UpdateNFInProgress";
        public const string SP_Task_UpdateNFNearerTask = "SP_Task_UpdateNFNearerTask";

        #endregion

        #region Request

        public const string SP_Request_Select="SP_Request_Select";
        public const string SP_Request_Insert="SP_Request_Insert";
        public const string SP_Request_Update="SP_Request_Update";
        public const string SP_Request_Delete = "SP_Request_Delete";
        public const string SP_Request_GetViewRequestDetail = "SP_Request_GetViewRequestDetail";
        public const string SP_Request_GetNewRequests = "SP_Request_GetNewRequests";
        public const string SP_Request_GetPatientDetail = "SP_Request_GetPatientDetail";
        public const string SP_Request_UpdateNF = "SP_Request_UpdateNF";
     //   public const string SP_Request_UpdateStatusToHold = "SP_Request_UpdateStatusToHold";
        public const string SP_Request_GetInfoFromTransaction_ID = "SP_Request_GetInfoFromTransaction_ID";
        public const string SP_Request_TUpdate = "SP_Request_TUpdate";

        public const string SP_Request_UpdateIsHold = "SP_Request_UpdateIsHold";
        public const string SP_Request_UpdateIsHold1 = "SP_Request_UpdateIsHold1";
        public const string SP_Request_UpdateIsForward = "SP_Request_UpdateIsForward";

        #endregion

        #region Visitor

        public const string SP_Visitor_Select = "SP_Visitor_Select";
        public const string SP_Visitor_Insert = "SP_Visitor_Insert";
        public const string SP_Visitor_Update = "SP_Visitor_Update";
        public const string SP_Visitor_Delete = "SP_Visitor_Delete";

        #endregion

        #region PatientDetail

        public const string SP_Patient_Select = "SP_Patient_Select";
        public const string SP_Patient_Insert = "SP_Patient_Insert";
        public const string SP_Patient_Update = "SP_Patient_Update";
        public const string SP_Patient_Delete = "SP_Patient_Delete";

        public const string SP_Patient_GetPatientDetail = "SP_Patient_GetPatientDetail";
        public const string SP_Patient_UpdateServiceProviderID = "SP_Patient_UpdateServiceProviderID";
        public const string SP_Patient_GetPatientName = "SP_Patient_GetPatientName";

        public const string SP_Patient_GetNewPatientName = "SP_Patient_GetNewPatientName";
        public const string SP_Patient_GetViewPatientName = "SP_Patient_GetViewPatientName";

        public const string SP_Patient_GetServiceProvider = "SP_Patient_GetServiceProvider";
        #endregion


        #region PharmaComapnyDetail
        public const string SP_PharmaCompanyDetail_Select = "SP_PharmaCompanyDetail_Select";
        public const string SP_PharmaCompanyDetail_Insert = "SP_PharmaCompanyDetail_Insert";
        public const string SP_PharmaCompanyDetail_Update = "SP_PharmaCompanyDetail_Update";
        public const string SP_PharmaCompanyDetail_Delete = "SP_PharmaCompanyDetail_Delete";
     
        public const string SP_PharmaCompanyDetail_GetPharmaCompanyName = "SP_PharmaCompanyDetail_GetPharmaCompanyName";
        public const string SP_PharmaCompanyDetail_GetNextBillNo = "SP_PharmaCompanyDetail_GetNextBillNo";
        public const string SP_PharmaCompanyDetail_SelectMaxID = "SP_PharmaCompanyDetail_SelectMaxID";
        public const string SP_PharmaCompanyDetail_GetPCDetail = "SP_PharmaCompanyDetail_GetPCDetail";

        #endregion

        #region PharmaCompanyServiceDetail
        public const string SP_PharmaCompanyServiceDetail_Select = "SP_PharmaCompanyServiceDetail_Select";
        public const string SP_PharmaCompanyServiceDetail_Insert = "SP_PharmaCompanyServiceDetail_Insert";
        public const string SP_PharmaCompanyServiceDetail_Update = "SP_PharmaCompanyServiceDetail_Update";
        public const string SP_PharmaCompanyServiceDetail_Delete = "SP_PharmaCompanyServiceDetail_Delete";
   
        #endregion


        #region HospitalDetail

        public const string SP_HospitalDetail_Select = "SP_HospitalDetail_Select";
        public const string SP_HospitalDetail_Insert = "SP_HospitalDetail_Insert";
        public const string SP_HospitalDetail_Update = "SP_HospitalDetail_Update";
        public const string SP_HospitalDetail_Delete = "SP_HospitalDetail_Delete";

        public const string SP_HospitalDetail_GetHospitalName = "SP_HospitalDetail_GetHospitalName";
        public const string SP_HospitalDetail_GetNextBillNo = "SP_HospitalDetail_GetNextBillNo";
        public const string SP_HospitalDetail_SelectMaxID = "SP_HospitalDetail_SelectMaxID";
        public const string SP_HospitalDetail_GetPCDetail = "SP_HospitalDetail_GetPCDetail";

        public const string SP_HospitalDetail_GetHospitalDetail = "SP_HospitalDetail_GetHospitalDetail";

        #endregion

        #region HospitalServiceDetail

        public const string SP_HospitalServiceDetail_Select = "SP_HospitalServiceDetail_Select";
        public const string SP_HospitalServiceDetail_Insert = "SP_HospitalServiceDetail_Insert";
        public const string SP_HospitalServiceDetail_Update = "SP_HospitalServiceDetail_Update";
        public const string SP_HospitalServiceDetail_Delete = "SP_HospitalServiceDetail_Delete";

        public const string SP_Hospital_GetAHospitalServiceDetail = "SP_Hospital_GetAHospitalServiceDetail";

        #endregion

        #region BloodBankDetail
        public const string SP_BloodBankDetail_Select = "SP_BloodBankDetail_Select";
        public const string SP_BloodBankDetail_Insert = "SP_BloodBankDetail_Insert";
        public const string SP_BloodBankDetail_Update = "SP_BloodBankDetail_Update";
        public const string SP_BloodBankDetail_GetPatientName = "SP_BloodBankDetail_GetPatientName";
        public const string SP_BloodBankDetail_GetBloodBankName = "SP_BloodBankDetail_GetBloodBankName";
        public const string SP_BloodBankDetail_GetNextBillNo = "SP_BloodBankDetail_GetNextBillNo";
        public const string SP_BloodBankDetail_GetBloodBankServiceDetail = "SP_BloodBankDetail_GetBloodBankServiceDetail";

        #endregion

        #region DoctorDetail

        public const string SP_DoctorDetail_Insert = "SP_DoctorDetail_Insert";
        public const string SP_DoctorDetail_Select = "SP_DoctorDetail_Select";
        public const string SP_DoctorDetail_Update = "SP_DoctorDetail_Update";
        public const string SP_DoctorDetail_GetPatientName = "SP_DoctorDetail_GetPatientName";
        public const string SP_DoctorDetail_GetDoctorName = "SP_DoctorDetail_GetDoctorName";
        public const string SP_DoctorDetail_GetNextBillNo = "SP_DoctorDetail_GetNextBillNo";
        public const string SP_DoctorDetail_GetDoctorServiceDetail = "SP_DoctorDetail_GetDoctorServiceDetail";

        #endregion

        #region DoctorServiceDetail

        public const string SP_DoctorServiceDetail_Select = "SP_DoctorServiceDetail_Select";
        public const string SP_DoctorServiceDetail_Insert = "SP_DoctorServiceDetail_Insert";
        public const string SP_DoctorServiceDetail_Update = "SP_DoctorServiceDetail_Update";
        public const string SP_DoctorServiceDetail_Delete = "SP_DoctorServiceDetail_Delete";
        public const string SP_DoctorDetail_GetDoctorDetail = "SP_DoctorDetail_GetDoctorDetail";

        #endregion

        #region Payment

        public const string SP_Payment_Insert = "SP_Payment_Insert";
        public const string SP_Payment_Select = "SP_Payment_Select";
        public const string SP_Payment_Update = "SP_Payment_Update";
        public const string SP_Payment_UpdatePaymentStatus = "SP_Payment_UpdatePaymentStatus";
        public const string SP_Payment_GetBillNo = "SP_Payment_GetBillNo";
        public const string SP_Payment_GetNextPID = "SP_Payment_GetNextPID";
        public const string SP_Payment_GetAmount = "SP_Payment_GetAmount";
        public const string SP_Payment_GetPaymentDetail = "SP_Payment_GetPaymentDetail";
       
        #endregion

        #region Donation
        public const string SP_Donation_Insert = "SP_Donation_Insert";
        public const string SP_Donation_Select = "SP_Donation_Select";
        public const string SP_Donation_Update = "SP_Donation_Update";
        #endregion

        #region Event

        public const string SP_Event_Select = "SP_Event_Select"; 
        public const string SP_Event_Insert = "SP_Event_Insert";
        public const string SP_Event_Update = "SP_Event_Update";
        public const string SP_Event_Delete = "SP_Event_Delete";


        #endregion

        #region News

        public const string SP_News_Select = "SP_News_Select";
        public const string SP_News_Insert = "SP_News_Insert";
        public const string SP_News_Update = "SP_News_Update";
        public const string SP_News_Delete = "SP_News_Delete";
        public const string SP_News_GetRecentNews = "SP_News_GetRecentNews";


        #endregion

        #region Inquiry
        public const string SP_Inquiry_Insert = "SP_Inquiry_Insert";
        public const string SP_Inquiry_Select = "SP_Inquiry_Select";
        public const string SP_Inquiry_Update = "SP_Inquiry_Update";
        #endregion

        #region Report
        public const string SP_Report_RegistrationGetUserDetail = "SP_Report_RegistrationGetUserDetail";
        public const string SP_Report_SPGetServiceDetail = "SP_Report_SPGetServiceDetail";
        public const string SP_Report_FillSHName = "SP_Report_FillSHName";
        public const string SP_Report_GetTaskDetail = "SP_Report_GetTaskDetail";
        public const string SP_Report_GetEventDetail = "SP_Report_GetEventDetail";
        public const string SP_Report_GetRequestDetail = "SP_Report_GetRequestDetail";
        #endregion

        #region

        public const string SP_Rating_Volunteer = "SP_Rating_Volunteer";
        public const string SP_Rating_BloodBank = "SP_Rating_BloodBank";
        public const string SP_Rating_PharmaCompany = "SP_Rating_PharmaCompany";
        public const string SP_Rating_Hospital = "SP_Rating_Hospital";
        public const string SP_Rating_Donor = "SP_Rating_Volunteer";

        #endregion

        //--IPA END

        public const string USP_InsertDesign = "USP_InsertDesign";
        public const string USP_DeleteDesign = "USP_DeleteDesign";
        public const string USP_GetDesign = "USP_GetDesign";

        public const string USP_InsertBank = "USP_InsertBank";
        public const string USP_DeleteBank = "USP_DeleteBank";
        public const string USP_GetBank = "USP_GetBank";

        public const string USP_InsertTerm = "USP_InsertTerm";
        public const string USP_DeleteTerm = "USP_DeleteTerm";
        public const string USP_GetTerm = "USP_GetTerm";

        public const string USP_InsertPMTerm = "USP_InsertPMTerm";
        public const string USP_DeletePMTerm = "USP_DeletePMTerm";
        public const string USP_GetPMTerm = "USP_GetPMTerm";

        public const string USP_InsertPTerm = "USP_InsertPTerm";
        public const string USP_DeletePTerm = "USP_DeletePTerm";
        public const string USP_GetPTerm = "USP_GetPTerm";

        public const string USP_InsertItemGroup = "USP_InsertItemGroup";
        public const string USP_DeleteItemGroup = "USP_DeleteItemGroup";
        public const string USP_GetItemGroup = "USP_GetItemGroup";


        public const string USP_InsertGRP = "USP_InsertGRP";
        public const string USP_DeleteGRP = "USP_DeleteGRP";
        public const string USP_GetGRP = "USP_GetGRP";


        public const string USP_InsertHEADGRP = "USP_InsertHEADGRP";
        public const string USP_DeleteHEADGRP = "USP_DeleteHEADGRP";
        public const string USP_GetHEADGRP = "USP_GetHEADGRP";


        public const string USP_InsertHEAD = "USP_InsertHEAD";
        public const string USP_DeleteHEAD = "USP_DeleteHEAD";
        public const string USP_GetHEAD = "USP_GetHEAD";


        public const string USP_InsertITEM = "USP_InsertITEM";
        public const string USP_DeleteITEM = "USP_DeleteITEM";
        public const string USP_GetITEM = "USP_GetITEM";



        public const string USP_InsertEMP = "USP_InsertEMP";
        public const string USP_DeleteEMP = "USP_DeleteEMP";
        public const string USP_GetEMP = "USP_GetEMP";

        public const string USP_InsertParty = "USP_InsertParty";
        public const string USP_DeleteParty = "USP_DeleteParty";
        public const string USP_GetParty = "USP_GetParty";

        public const string USP_InsertSup = "USP_InsertSUP";
        public const string USP_DeleteSup = "USP_DeleteSUP";
        public const string USP_GetSup = "USP_GetSUP";

        public const string USP_InsertUSER = "USP_InsertUSER";
        public const string USP_DeleteUSER = "USP_DeleteUSER";
        public const string USP_GetUSER = "USP_GetUSER";


        public const string USP_InsertPage = "USP_InsertPage";
        public const string USP_DeletePage = "USP_DeletePage";
        public const string USP_GetPage = "USP_GetPage";



        #region Transaction

        public const string USP_InsertPayment = "USP_InsertPayment";
        public const string USP_DeletePayment = "USP_DeletePayment";
        public const string USP_GetPayment = "USP_GetPayment";


        public const string USP_InsertInsurance = "USP_InsertInsurance";
        public const string USP_DeleteInsurance = "USP_DeleteInsurance";
        public const string USP_GetInsurance = "USP_GetInsurance";

        public const string USP_InsertRECEIVED = "USP_InsertRECEIVED";
        public const string USP_DeleteRECEIVED = "USP_DeleteRECEIVED";
        public const string USP_GetRECEIVED = "USP_GetRECEIVED";



        public const string USP_InsertRojmel = "USP_InsertRojmel";
        public const string USP_DeleteRojmel = "USP_DeleteRojmel";
        public const string USP_GetRojmel = "USP_GetRojmel";


        public const string USP_InsertWorkSheet = "USP_InsertWorkSheet";
        public const string USP_DeleteWorkSheet = "USP_DeleteWorkSheet";
        public const string USP_GetWorkSheet = "USP_GetWorkSheet";




        public const string USP_InsertIntTran = "USP_InsertIntTran";
        public const string USP_GetInternalTransfr = "USP_GetInternalTransfr";
        public const string USP_DeleteInternalTransfr = "USP_DeleteInternalTransfr";

        public const string USP_InsertPaymentReceived = "USP_InsertPaymentReceived";
        public const string USP_GetPaymentReceived = "USP_GetPaymentReceived";
        public const string USP_DeletePaymentReceived = "USP_DeletePaymentReceived";

       

        public const string USP_InsertPaymentRequest = "USP_InsertPaymentRequest";
        public const string USP_GetPaymentRequest = "USP_GetPaymentRequest";
        public const string USP_DeletePaymentRequest = "USP_DeletePaymentRequest";

       #endregion

        public const string USP_RP_GetEMP = "USP_RP_GetEMP";







    }
}