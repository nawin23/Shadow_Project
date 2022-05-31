using EmpAPI.Controllers;
using EmpBL;
using EmpDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace EmpAPI.Controllers.Tests
{
    [TestClass()]
    public class EmpControllerTests
    {
        [TestMethod()]
        public void FetchTest()
        {
            EmpDetailsDto expectedResult = new EmpDetailsDto();
            List<EmpDetailsDto> lstEmp = new List<EmpDetailsDto>();
            expectedResult.Psno = 40020490;
            expectedResult.Employee_Name = "Sample Employee Name";
            expectedResult.Email = "Sample Employee EmailID";
            expectedResult.Current_skill = "Sample Employee Current Skills";
            expectedResult.Expected_Training = "Sample Employee Expected Training";
            lstEmp.Add(expectedResult); ;

            Mock<IEmpBL> mockobj = new Mock<IEmpBL>();
            mockobj.Setup(x => x.FetchEmpDetails()).Returns(lstEmp);

            EmpController controlObj = new EmpController(mockobj.Object);
            controlObj.Request = new HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration()
                    }
                }
            };

            HttpResponseMessage actualResult = controlObj.FetchEmployees();
            List<EmpDetailsDto> lstActualResult = actualResult.Content.ReadAsAsync<List<EmpDetailsDto>>().Result;
            Assert.AreEqual(lstEmp, lstActualResult);
        }

        [TestMethod()]
        public void SaveTest()
        {
            EmpDetailsDto expectedResult = new EmpDetailsDto();
            List<EmpDetailsDto> lstEmp = new List<EmpDetailsDto>();
            expectedResult.Psno = 40020490;
            expectedResult.Employee_Name = "Sample Employee Name";
            expectedResult.Email = "Sample Employee EmailID";
            expectedResult.Current_skill = "Sample Employee Current Skills";
            expectedResult.Expected_Training = "Sample Employee Expected Training";
            lstEmp.Add(expectedResult);
            int expRetVal = 1;
            string expMsg = "Details added sucessfully";

            Mock<IEmpBL> mockobj = new Mock<IEmpBL>();
            mockobj.Setup(x => x.SaveAllEmp(expectedResult)).Returns(expRetVal);

            EmpController controlObj = new EmpController(mockobj.Object);
            controlObj.Request = new HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration()
                    }
                }
            };

            HttpResponseMessage actualResult = controlObj.Save(expectedResult);
            string actualRes = actualResult.Content.ReadAsAsync<string>().Result;
            Assert.AreEqual(expMsg, actualRes);
        }

        [TestMethod()]
        public void UpdateEmpRecTest()
        {
            EmpDetailsDto expectedResult = new EmpDetailsDto();
            List<EmpDetailsDto> lstEmp = new List<EmpDetailsDto>();
            expectedResult.Psno = 40020490;
            expectedResult.Employee_Name = "Sample Employee Name";
            expectedResult.Email = "Sample Employee EmailID";
            expectedResult.Current_skill = "Sample Employee Current Skills";
            expectedResult.Expected_Training = "Sample Employee Expected Training";
            lstEmp.Add(expectedResult);
            int expRetVal = 1;
            string expMsg = "Details updated sucessfully";

            Mock<IEmpBL> mockobj = new Mock<IEmpBL>();
            mockobj.Setup(x => x.Edit(expectedResult)).Returns(expRetVal);

            EmpController controlObj = new EmpController(mockobj.Object);
            controlObj.Request = new HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration()
                    }
                }
            };

            HttpResponseMessage actualResult = controlObj.UpdateEmpRec(expectedResult);
            string actualRes = actualResult.Content.ReadAsAsync<string>().Result;
            Assert.AreEqual(expMsg, actualRes);
        }

        [TestMethod()]
        public void SearchEmployeesTest()
        {
            EmpDetailsDto expectedResult = new EmpDetailsDto();
            List<EmpDetailsDto> lstEmp = new List<EmpDetailsDto>();
            expectedResult.Psno = 40020490;
            expectedResult.Employee_Name = "Sample Employee Name";
            expectedResult.Email = "Sample Employee EmailID";
            expectedResult.Current_skill = "Sample Employee Current Skills";
            expectedResult.Expected_Training = "Sample Employee Expected Training";
            string input = "Sample input data";
            lstEmp.Add(expectedResult);

            Mock<IEmpBL> mockobj = new Mock<IEmpBL>();
            mockobj.Setup(x => x.GetTraineeBySearch(input)).Returns(lstEmp);

            EmpController controlObj = new EmpController(mockobj.Object);
            controlObj.Request = new HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration()
                    }
                }
            };

            HttpResponseMessage actualResult = controlObj.SearchEmployees(input);
            List<EmpDetailsDto> lstActualResult = actualResult.Content.ReadAsAsync<List<EmpDetailsDto>>().Result;
            Assert.AreEqual(lstEmp, lstActualResult);

        }

        [TestMethod()]
        public void EmpLoginTest()

        {
            LoginDTO expectedCreds = new LoginDTO();
            List<LoginDTO> empCred = new List<LoginDTO>();
            expectedCreds.Username = "Sample UserName";
            expectedCreds.Password = "Sample Password";
            empCred.Add(expectedCreds);

            Mock<IEmpBL> mockobj = new Mock<IEmpBL>();
            mockobj.Setup(x => x.Login(expectedCreds)).Returns(empCred);

            EmpController controlObj = new EmpController(mockobj.Object);
            controlObj.Request = new HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration()
                    }
                }
            };

            HttpResponseMessage actualResult = controlObj.EmpLogin(expectedCreds);
            List<LoginDTO> actualCreds = actualResult.Content.ReadAsAsync<List<LoginDTO>>().Result;
            Assert.AreEqual(empCred, actualCreds);

        }

        [TestMethod()]
        public void EmpSignUpTest()
        {
            SignUpDTO expectedCreds = new SignUpDTO();
            List<SignUpDTO> empCred = new List<SignUpDTO>();
            expectedCreds.Username = "Sample UserName";
            expectedCreds.Password = "Sample Password";
            empCred.Add(expectedCreds);
            int expRetVal = 1;

            Mock<IEmpBL> mockobj = new Mock<IEmpBL>();
            mockobj.Setup(x => x.Signup(expectedCreds)).Returns(expRetVal);

            EmpController controlObj = new EmpController(mockobj.Object);
            controlObj.Request = new HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration()
                    }
                }
            };

            HttpResponseMessage actualResult = controlObj.EmpSignUp(expectedCreds);
            int actualRetVal = actualResult.Content.ReadAsAsync<int>().Result;
            Assert.AreEqual(expRetVal, actualRetVal);
        }
    }
}