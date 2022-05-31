using EmpBL;
using EmpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpAPI.Controllers
{
    public class EmpController : ApiController
    {
        private IEmpBL iBlObj;
        public EmpController() : this(new BL())
        {

        }
        public EmpController(IEmpBL iNewBlObj)
        {
            iBlObj = iNewBlObj;
        }
        [HttpGet]
        public HttpResponseMessage FetchEmployees()
        {
            try
            {
                List<EmpDetailsDto> lstEmp = iBlObj.FetchEmpDetails();
                if (lstEmp.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstEmp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "no reviews found");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public HttpResponseMessage Save(EmpDetailsDto newEmp)
        {
            try
            {
                int res = iBlObj.SaveAllEmp(newEmp);
                if (res == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Details added sucessfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Something went wrong");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage UpdateEmpRec(EmpDetailsDto newEmp)
        {
            try
            {
                int res = iBlObj.Edit(newEmp);
                if (res == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Details updated sucessfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Something went wrong");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage SearchEmployees(string input)
        {
            try
            {
                List<EmpDetailsDto> lstEmp = iBlObj.GetTraineeBySearch(input);
                if (lstEmp.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstEmp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No trainee details found");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public HttpResponseMessage EmpLogin(LoginDTO loginUser)
        {
            try
            {
                List<LoginDTO> res = iBlObj.Login(loginUser);
                if (res.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Invalid UserId and Password");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage EmpSignUp(SignUpDTO newLogin)
        {
            try
            {
                int res = iBlObj.Signup(newLogin);
                if (res == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, 0);
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
    }
}
