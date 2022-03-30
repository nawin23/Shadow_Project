using EmpBL;
using EmpDAL;
using EmpDTO;
using EmpMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmpMVC.Controllers
{
    public class AccountController : Controller
    {
        BL blObj;
        StepUpContext stepUpContext;
        public AccountController()
        {
            blObj = new BL();
            stepUpContext = new StepUpContext();
        }

        [HttpGet]
        public ActionResult LoginDetails()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult LoginDetails(EmpFetchModel loginDetails)
        {
            try
            {
                int result = 0;

                LoginDTO loginCreds = new LoginDTO();
                loginCreds.Username = loginDetails.Username;
                loginCreds.Password = loginDetails.Password;
                List<LoginDTO> validation = blObj.Login(loginCreds);
                foreach (var validationItem in validation)
                {
                    if (loginDetails.Username == validationItem.Username && loginDetails.Password == validationItem.Password)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = 0;
                    }
                }
                if (result == 1)
                {
                    FormsAuthentication.SetAuthCookie(loginDetails.Username, false);
                    return RedirectToAction("Fetch", "Emp");                   
                    

                }
                else
                {
                    return RedirectToAction("Invaild");
                }

            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }



        [HttpGet]
        public ActionResult Signup()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Signup(EmpsignupModel saveObj)
        {


            try
            {
                SignUpDTO dtoObj = new SignUpDTO();
                dtoObj.Username = saveObj.Username;
                dtoObj.Password = saveObj.Password;

                int res = blObj.Signup(dtoObj);
                if (res == 1)
                {
                    return RedirectToAction("LoginDetails");
                }
                else
                {
                    return View("Error");

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Invaild()
        {
            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            FormsAuthentication.SignOut();


            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();

            return RedirectToAction("LoginDetails");
        }

        public JsonResult CheckUsernameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(100);
            var SeachData = stepUpContext.LoginUsers.Where(x => x.Username.ToString() == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
    }



}

