using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpMVC.Models
{
    public class EmpFetchMVC
    {
        [Key]
        [DisplayName("PS Number")]
        [Required(ErrorMessage = "PS Number should not be empty.")]
        //[RegularExpression(@"^[A-Z\sa-z]+$,^[0-9]+$", ErrorMessage = "Username  must have only Character")]
        public int Psno { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee name should not be empty.")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Employee name must have only Character")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Employee  should be between 5 and 20 characters")]
        public string Employee_Name { get; set; }

        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email name should not be empty.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Enter a valid Email ID ")]
        //[StringLength(50, MinimumLength = 25, ErrorMessage = "Email should be between 10 and 20 characters")]
        public string Email { get; set; }

        [DisplayName("Current Skills")]
        [Required(ErrorMessage = "Current Skills should not be empty.")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Current Skills must have only Character")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Current Skills should not be more than 50 characters")]
        public string Current_skill { get; set; }


        [DisplayName("Expected Training")]
        [Required(ErrorMessage = "Expected Training should not be empty.")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Execpted Training must have only Character")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Expected Training should be between 10 and 20 characters")]
        public string Expected_Training { get; set; }

    }
    public class EmpEditMVC
    {
        [Key]
        [DisplayName("PS Number")]
        [Required(ErrorMessage = "PS Number should not be empty.")]
        //[RegularExpression(@"^[A-Z\sa-z]+$,^[0-9]+$", ErrorMessage = "Username  must have only Character")]
        public int Psno { get; set; }

        [DisplayName("Employee Name")]
        public string Employee_Name { get; set; }

        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email name should not be empty.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Enter a valid Email ID ")]
        //[StringLength(50, MinimumLength = 25, ErrorMessage = "Email should be between 10 and 20 characters")]
        public string Email { get; set; }

        [DisplayName("Current Skills")]
        [Required(ErrorMessage = "Current Skills should not be empty.")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Current Skills must have only Character")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Current Skills should not be more than 50 characters")]
        public string Current_skill { get; set; }


        [DisplayName("Expected Training")]
        [Required(ErrorMessage = "Expected Training should not be empty.")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Execpted Training must have only Character")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Expected Training should be between 10 and 20 characters")]
        public string Expected_Training { get; set; }

    }
    public class EmpFetchModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username  should not be empty.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Username must have only Character")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    
    public class EmpsignupModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username should not be empty.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Username must have only Character")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [RegularExpression(@"^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$", ErrorMessage = "Password doesn't meet the requirements ")]
        [Required(ErrorMessage = "Password  should not be empty.")]
        [Compare("Password",ErrorMessage = "Password doesn't match")]
        [DataType(DataType.Password)]
        public string Repassword { get; set; } 
    }
    
    public class EmpEditModel
    {
        [Key]
        [DisplayName("PS Number")]
        [Required(ErrorMessage = "Email name should not be empty.")]
        public int Psno { get; set; }

        [DisplayName("Employee Name")]
        //[Required(ErrorMessage = "Email name should not be empty.")]
        public string Employee_Name { get; set; }

        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email name should not be empty.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Enter a valid Email ID ")]
        public string Email { get; set; }

        [DisplayName("Current Skills")]
        [Required(ErrorMessage = "Current Skills should not be empty.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Current Skills should not be more than 50 characters")]
        public string Current_skill { get; set; }

        [DisplayName("Expected Training")]
        [Required(ErrorMessage = "Expected Training is required.")]
        [RegularExpression(@"^[A-Z\sa-z]+$", ErrorMessage = "Execpted Training must have only Character")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Expected Training should be between 10 and 20 characters")]
        public string Expected_Training { get; set; }

    }
    public class EmpExpTraModel
    {
        public string Expected_Training { get; set; }

    }
    public class EmpDeleteModel
    {
        public int Psno { get; set; }
        public string Employee_Name { get; set; }
        public string Email { get; set; }
        public string Current_skill { get; set; }
        public string Expected_Training { get; set; }
        public string Expected_Training1 { get; set; }
        public string Expected_Training2 { get; set; }
        public string Expected_Training3 { get; set; }
    }


}