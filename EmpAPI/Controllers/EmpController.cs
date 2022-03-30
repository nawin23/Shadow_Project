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
        BL blObj;
        public EmpController()
        {
            blObj = new BL();

        }
        [HttpGet]
        public HttpResponseMessage Fetch()
        {
            try
            {
                List<DTO> lstEmp = blObj.FetchEmpDetails();
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
        public HttpResponseMessage Save(DTO newEmp)
        {
            try
            {
                int res = blObj.SaveAllEmp(newEmp);
                if (res == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Reviews enter sucessfully");
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

        


    }
}
