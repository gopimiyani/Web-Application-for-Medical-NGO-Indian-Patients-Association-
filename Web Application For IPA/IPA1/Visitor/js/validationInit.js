function formValidation() {
    var ruleSet1 = {
        required: true,
        lettersonly: true
     };
    var ruleSet2 = {
        notEqual: "Select"
    };
    var ruleSet3 = {
        required: true,
        mob: true
    };
    var ruleSet4 = {
        required: true,
        email: true
    };
    var ruleSet5 = {
        required: true
    };
   
    
    "use strict";
    /*----------- BEGIN validationEngine CODE -------------------------*/
    $('#popup-validation').validationEngine();
    
    /*----------- END validationEngine CODE -------------------------*/

    /*----------- BEGIN validate CODE -------------------------*/




    /*------------------------------------validation for home and student login-------------------------------------------------*/
    $('#inlinevalidate').validate({
        rules: {
            required: "required",
            
            
            /* --------------student_signup------------------- */
            ctl00$ContentPlaceHolder1$fileupload1: {
                required: true,
                accept: "jpeg|png|gif",
                filesize: 30720
            },
            ctl00$ContentPlaceHolder1$txt_enno: {
                required: true,
                enno: true
            },
            ctl00$ContentPlaceHolder1$txt_lname: ruleSet1,
            ctl00$ContentPlaceHolder1$txt_mname: ruleSet1,
            ctl00$ContentPlaceHolder1$txt_fname: ruleSet1,
            ctl00$ContentPlaceHolder1$txt_address: ruleSet5,
            ctl00$ContentPlaceHolder1$ddl_city: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_area: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_course: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_branch: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_sem: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_shift: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_staff: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_designation: ruleSet2,
            ctl00$ContentPlaceHolder1$txt_stu_mob: ruleSet3,
            ctl00$ContentPlaceHolder1$txt_mobno: ruleSet3,
            ctl00$ContentPlaceHolder1$txt_father_mob: ruleSet3,
            ctl00$ContentPlaceHolder1$txt_email: ruleSet4,
            ctl00$ContentPlaceHolder1$txt_femail: ruleSet4,
            ctl00$ContentPlaceHolder1$txt_qualification: ruleSet5,
            ctl00$ContentPlaceHolder1$txt_areaofinterest: ruleSet5,
            ctl00$ContentPlaceHolder1$txt_doj: ruleSet5,
            ctl00$ContentPlaceHolder1$txt_psswd: {
                required: true,
                pass: true
            },
            ctl00$ContentPlaceHolder1$txt_cpsswd: {
                required: true,
                pass: true,
                equalTo: "#ContentPlaceHolder1_txt_psswd"
            },
            
            /* ------------------------student view attendance------------------------ */
            ctl00$ContentPlaceHolder1$ddl_sub: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_month: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_year: ruleSet2,

            /* ------------------------leave application------------------------ */
            ctl00$ContentPlaceHolder1$ddl_typeofleave: ruleSet2,
            ctl00$ContentPlaceHolder1$fileupload_medicatcerti:{
                required: true,
                accept: "jpeg|jpg|png|gif",
                filesize: 51200
            },
            ctl00$ContentPlaceHolder1$txt_fromd: ruleSet5,
            ctl00$ContentPlaceHolder1$txt_tod: ruleSet5,
            ctl00$ContentPlaceHolder1$txt_reason: ruleSet5,

            /* -------------------------faculty_signup------------------ */
            ctl00$ContentPlaceHolder1$txt_identificationno: {
                required: true,
                identification_no: true
            },
            ctl00$ContentPlaceHolder1$txt_fname: ruleSet1,
            ctl00$ContentPlaceHolder1$txt_mname: ruleSet1,
            ctl00$ContentPlaceHolder1$txt_lname: ruleSet1,
            ctl00$ContentPlaceHolder1$txt_address: ruleSet5,
            ctl00$ContentPlaceHolder1$ddl_city: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_area: ruleSet2,
            ctl00$ContentPlaceHolder1$txt_mobno: ruleSet3,
            ctl00$ContentPlaceHolder1$ddl_branch: ruleSet2,
            ctl00$ContentPlaceHolder1$txt_doj: ruleSet5,
            ctl00$ContentPlaceHolder1$txt_qualification: ruleSet5,
            ctl00$ContentPlaceHolder1$ddl_staff: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_designation: ruleSet2,
            ctl00$ContentPlaceHolder1$txt_areaofinterest: ruleSet5,
            ctl00$ContentPlaceHolder1$txt_email: ruleSet4,
            ctl00$ContentPlaceHolder1$txt_pass: {
                required: true,
                pass: true
            },
            ctl00$ContentPlaceHolder1$txt_repass: {
                required: true,
                pass: true,
                equalTo: "#ContentPlaceHolder1_txt_pass"
            },
            ctl00$ContentPlaceHolder1$fileupload1: {
                required: true,
                accept: "jpeg|png|gif",
                filesize: 30720
            },

            date: {
                required: true,
                date: true
            },
            url: {
                required: true,
                url: true
            },
            agree: "required",
            minsize: {
                required: true,
                minlength: 3
            },
            maxsize: {
                required: true,
                maxlength: 6
            },
            minNum: {
                required: true,
                min: 3
            },
            maxNum: {
                required: true,
                max: 16
            }
        },
        messages: {
          /* --------------student_signup------------------- */
          ctl00$ContentPlaceHolder1$fileupload1: "File must be JPEG, PNG or GIF, less than 30KB",
          ctl00$ContentPlaceHolder1$ddl_city: "Please select city",
          ctl00$ContentPlaceHolder1$ddl_area: "Please select area",
          ctl00$ContentPlaceHolder1$ddl_course: "Please select course",
          ctl00$ContentPlaceHolder1$ddl_branch: "Please select branch",
          ctl00$ContentPlaceHolder1$ddl_sem: "Please select sem",
          ctl00$ContentPlaceHolder1$ddl_shift: "Please select shift",
          
          /* ------------------------view attendance------------------------ */
          ctl00$ContentPlaceHolder1$ddl_sub: "Please select subject",
          ctl00$ContentPlaceHolder1$ddl_month: "Please select month",
          ctl00$ContentPlaceHolder1$ddl_year: "Please select year",
         
          /* -------------------------faculty_signup------------------ */
          ctl00$ContentPlaceHolder1$ddl_city: "Please select city",
          ctl00$ContentPlaceHolder1$ddl_area: "Please select area",
          ctl00$ContentPlaceHolder1$ddl_branch: "Please select branch",
          ctl00$ContentPlaceHolder1$ddl_staff: "Please select Staff Type",
          ctl00$ContentPlaceHolder1$ddl_designation: "Please select designation",
        
          /* ------------------------leave application------------------------ */
          ctl00$ContentPlaceHolder1$ddl_typeofleave: "Please select type of leave",
          ctl00$ContentPlaceHolder1$fileupload_medicatcerti: "File must be JPEG, PNG or GIF, less than 50KB"
        },
            
        errorClass: 'help-block col-lg-6',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });






    /*-------------------------------------------Validation for faculty login---------------------------------------------------*/
    $('#inlinevalidate1').validate({
        rules: {
            required: "required",
            /* --------------assign_class_teacher------------------- */
            ctl00$ContentPlaceHolder1$ddl_course: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_sem: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_shift: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_facultyname: ruleSet2,

            /* --------------stu_attendance------------------- */
            ctl00$ContentPlaceHolder1$txt_dat: ruleSet5,
            ctl00$ContentPlaceHolder1$ddl_branch: ruleSet2,
            ctl00$ContentPlaceHolder1$ddl_sub: ruleSet2,

            /* --------------stu_midmark------------------- */
            ctl00$ContentPlaceHolder1$txt_start: ruleSet5,
            ctl00$ContentPlaceHolder1$txt_end: ruleSet5,

            /* --------------timetable------------------- */
            ctl00$ContentPlaceHolder1$FileUpload1: {
                required: true,
                extension: "xls|xlsx|xls|xlsm"
            }        
        },
        messages: {
            /* --------------assign_class_teacher------------------- */
            ctl00$ContentPlaceHolder1$ddl_course: "Please select course",
            ctl00$ContentPlaceHolder1$ddl_sem: "Please select sem",
            ctl00$ContentPlaceHolder1$ddl_shift: "Please select shift",
            ctl00$ContentPlaceHolder1$ddl_facultyname: "Please select faculty name",

            /* --------------stu_attendance------------------- */
            ctl00$ContentPlaceHolder1$ddl_branch: "Please select branch",
            ctl00$ContentPlaceHolder1$ddl_sub: "Please select subject",

            /* --------------timetable------------------- */
            ctl00$ContentPlaceHolder1$FileUpload1: "Please upload valid file formats .xls,.xlsx, .xlsm, .xls only"
        },

        errorClass: 'help-block col-lg-6',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });

    $('#block-validate').validate({
        rules: {
            required2: "required",
            email2: {
                required: true,
                email: true
            },
            date2: {
                required: true,
                date: true
            },
            url2: {
                required: true,
                url: true
            },
            password2: {
                required: true,
                minlength: 5
            },
            confirm_password2: {
                required: true,
                minlength: 5,
                equalTo: "#password2"
            },
            agree2: "required",
            digits: {
                required: true,
                digits: true
            },
            range: {
                required: true,
                range: [5, 16]
            }
        },
        errorClass: 'help-block',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });
    /*----------- END validate CODE -------------------------*/
}