using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDTO
{
    public class DTO
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
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
       
    }

    public class SignUpDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }


    }

    public class EmpDeletetModel
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
