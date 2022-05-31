using EmpDAL;
using EmpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBL
{
    public class BL : IEmpBL
    {
        DAL dalObj;
        public BL()
        {
            dalObj = new DAL();
        }
        public List<EmpDetailsDto> FetchEmpDetails()
        {
            List<EmpDetailsDto> lstFetch = dalObj.GetEmpDetails();
            return lstFetch;
        }
        public int SaveAllEmp(EmpDetailsDto newEmp)
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
        public int Edit(EmpDetailsDto newEdit)
        {
            return dalObj.EditEmp(newEdit);
        }

        public int Delete(string ID)
        {
            return dalObj.DeleteData(ID);
        }

        public int Excel(EmpDetailsDto model)
        {
            return dalObj.SaveExcelEmp(model);
        }

        public List<EmpDetailsDto> GetTraineeBySearch(string traineePSNum)
        {
            return dalObj.Search(traineePSNum);
        }
        public List<string> GetExpTrainingDetails()
        {
            return dalObj.GetExpTrainingDetails();
        }
    }
}

