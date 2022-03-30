using EmpDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDAL
{
    public class DAL
    {
        SqlConnection conObj;
        SqlCommand cmdObj;
        StepUpContext stepUpContext;
        public DAL()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["StepUPstr"].ConnectionString);
            stepUpContext = new StepUpContext();
        }
        public List<DTO> GetEmpDetails()
        {
            try
            {
                var res = stepUpContext.Employees.ToList();
                List<DTO> lstEmp = new List<DTO>();
                foreach (var emp in res)
                {
                    lstEmp.Add(new DTO
                    {
                        Psno = emp.Psno,
                        Employee_Name = emp.employee_name,
                        Email = emp.email_id,
                        Current_skill = emp.current_skills,
                        Expected_Training = emp.excepted_training,
                        Expected_Training1 = emp.excepted_1,
                        Expected_Training2 = emp.excepted_2,
                        Expected_Training3 = emp.excepted_3,



                    });

                }
                return lstEmp;
            }
            catch (Exception)
            {

                throw;
            }

        }

        

        public int SaveEmp(DTO newEmp)
        {
            try
            {
                cmdObj = new SqlCommand();
                cmdObj.CommandText = @"uspAddEmployee";
                cmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                cmdObj.Connection = conObj;
                cmdObj.Parameters.AddWithValue(@"Psno", newEmp.Psno);
                cmdObj.Parameters.AddWithValue(@"employee_name", newEmp.Employee_Name);
                cmdObj.Parameters.AddWithValue(@"email_id", newEmp.Email);
                cmdObj.Parameters.AddWithValue(@"current_skill", newEmp.Current_skill);
                cmdObj.Parameters.AddWithValue(@"expected_training", newEmp.Expected_Training);
                cmdObj.Parameters.AddWithValue(@"expected_1", newEmp.Expected_Training1);
                cmdObj.Parameters.AddWithValue(@"expected_2", newEmp.Expected_Training2);
                cmdObj.Parameters.AddWithValue(@"expected_3", newEmp.Expected_Training3);
                SqlParameter retObj = new SqlParameter();
               
                retObj.Direction = ParameterDirection.ReturnValue;
                retObj.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(retObj);
                conObj.Open();
                cmdObj.ExecuteNonQuery();
                return Convert.ToInt32(retObj.Value);

            }
            catch (Exception)
            {

                throw;
            }

        }
        public int EditEmp(DTO newEdit)
        {
            try
            {
                cmdObj = new SqlCommand();
                cmdObj.CommandText = @"uspUpdateEmp";
                cmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                cmdObj.Connection = conObj;
                cmdObj.Parameters.AddWithValue(@"Psno", newEdit.Psno);
                cmdObj.Parameters.AddWithValue(@"employee_name", newEdit.Employee_Name);
                cmdObj.Parameters.AddWithValue(@"email_id", newEdit.Email);
                cmdObj.Parameters.AddWithValue(@"current_skill", newEdit.Current_skill);
                cmdObj.Parameters.AddWithValue(@"expected_training", newEdit.Expected_Training);
                cmdObj.Parameters.AddWithValue(@"expected_1", newEdit.Expected_Training1);
                cmdObj.Parameters.AddWithValue(@"expected_2", newEdit.Expected_Training2);
                cmdObj.Parameters.AddWithValue(@"expected_3", newEdit.Expected_Training3);
                SqlParameter retObj = new SqlParameter();
                retObj.Direction = ParameterDirection.ReturnValue;
                retObj.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(retObj);
                conObj.Open();
                cmdObj.ExecuteNonQuery();
                return Convert.ToInt32(retObj.Value);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteData(String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["StepUPstr"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"Psno", ID);
                cmd.Parameters.AddWithValue(@"employee_name","");
                cmd.Parameters.AddWithValue(@"email_id", "");
                cmd.Parameters.AddWithValue(@"current_skills", "");
                cmd.Parameters.AddWithValue(@"excepted_training", "");
                cmd.Parameters.AddWithValue(@"excepted_1", "");
                cmd.Parameters.AddWithValue(@"excepted_2", "");
                cmd.Parameters.AddWithValue(@"excepted_3", "");
                cmd.Parameters.AddWithValue(@"Query", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }

           
        }
            public List<LoginDTO> LoginValidation(LoginDTO loginUser)
            {
            try
            {

                var result = stepUpContext.LoginUsers.Where(x => x.Username == loginUser.Username && x.Password == loginUser.Password).ToList();
                List<LoginDTO> loginCredentails = new List<LoginDTO>();
                foreach (var log in result)
                {
                    loginCredentails.Add(new LoginDTO()
                    {
                        Username = log.Username,
                        Password = log.Password,
                    });
                }
                return loginCredentails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SignupPage(SignUpDTO newLogin)
        {
            try
            {
                cmdObj = new SqlCommand();
                cmdObj.CommandText = @"uspLogin";
                cmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                cmdObj.Connection = conObj;
                cmdObj.Parameters.AddWithValue(@"Username", newLogin.Username);
                cmdObj.Parameters.AddWithValue(@"password", newLogin.Password);
                SqlParameter retObj = new SqlParameter();
                retObj.Direction = ParameterDirection.ReturnValue;
                retObj.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(retObj);
                conObj.Open();
                cmdObj.ExecuteNonQuery();
                return Convert.ToInt32(retObj.Value);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveExcelEmp(DTO model)
        {
            try
            {
                cmdObj = new SqlCommand();
                cmdObj.CommandText = @"uspAddEmployee";
                cmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                cmdObj.Connection = conObj;
                cmdObj.Parameters.AddWithValue(@"Psno", model.Psno);
                cmdObj.Parameters.AddWithValue(@"employee_name", model.Employee_Name);
                cmdObj.Parameters.AddWithValue(@"email_id", model.Email);
                cmdObj.Parameters.AddWithValue(@"current_skill", model.Current_skill);
                cmdObj.Parameters.AddWithValue(@"expected_training", model.Expected_Training);
                cmdObj.Parameters.AddWithValue(@"expected_1", model.Expected_Training1);
                cmdObj.Parameters.AddWithValue(@"expected_2", model.Expected_Training2);
                cmdObj.Parameters.AddWithValue(@"expected_3", model.Expected_Training3);
                SqlParameter retObj = new SqlParameter();

                retObj.Direction = ParameterDirection.ReturnValue;
                retObj.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(retObj);
                conObj.Open();
                cmdObj.ExecuteNonQuery();

                return Convert.ToInt32(retObj.Value);



            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<DTO> Search(string PSnumber)
        {
            var result = stepUpContext.Employees.Where(w => (w.Psno+w.employee_name + w.email_id + w.current_skills + w.excepted_training + w.excepted_1  ).ToString().Contains(PSnumber)).ToList();
            List<DTO> lstOftrainee = new List<DTO>();
            foreach (var Trainee in result)
            {
                lstOftrainee.Add(new DTO()
                {

                    Psno = Trainee.Psno,
                    Employee_Name = Trainee.employee_name,
                    Email = Trainee.email_id,
                    Current_skill = Trainee.current_skills,
                    Expected_Training = Trainee.excepted_training,
                    Expected_Training1 = Trainee.excepted_1,
                    Expected_Training2 = Trainee.excepted_2,
                    Expected_Training3 = Trainee.excepted_3,
                });

            }
            return lstOftrainee;
        }
    }
}

