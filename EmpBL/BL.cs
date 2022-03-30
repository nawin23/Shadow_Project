using EmpDAL;
using EmpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBL
{
    public class BL
    {
        DAL dalObj;
        public BL()
        {
            dalObj = new DAL();
        }
        public List<DTO> FetchEmpDetails()
        {
            List<DTO> lstFetch = dalObj.GetEmpDetails();
            return lstFetch;
        }
        public int SaveAllEmp(DTO newEmp)
        {
            return dalObj.SaveEmp(newEmp);

        }
        public List<LoginDTO> Login(LoginDTO loginUser)
        {

            return dalObj.LoginValidation(loginUser);
        }
        public int Signup(SignUpDTO newLogin)
        {
            return dalObj.SignupPage(newLogin);
        }
        public int Edit(DTO newEdit)
        {
            return dalObj.EditEmp(newEdit);
        }

        public int Delete(string ID)
        {
            return dalObj.DeleteData(ID);
        }

        public int Excel(DTO model)
        {
            return dalObj.SaveExcelEmp(model);
        }

        public List<DTO> GetTraineeByPSNum(string traineePSNum)
        { 
           return dalObj.Search(traineePSNum);   
        }

    }
}

