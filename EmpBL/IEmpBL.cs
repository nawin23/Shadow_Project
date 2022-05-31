using EmpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBL
{
    public interface IEmpBL
    {
        List<EmpDetailsDto> FetchEmpDetails();
        int SaveAllEmp(EmpDetailsDto newEmp);
        int Edit(EmpDetailsDto newEdit);
        List<EmpDetailsDto> GetTraineeBySearch(string traineePSNum);
        List<LoginDTO> Login(LoginDTO loginUser);
        int Signup(SignUpDTO newLogin);
    }
}
