using ClosedXML.Excel;
using EmpBL;
using EmpDAL;
using EmpDTO;
using EmpMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Protocols.WSTrust;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using PagedList;
using PagedList.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace EmpMVC.Controllers
{
    [Authorize]
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
    public class EmpController : Controller
    {
        BL blObj;
        StepUpContext stepUpContext;
        SqlConnection conObj;

        public EmpController()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["StepUPstr"].ConnectionString);

            blObj = new BL();
            stepUpContext = new StepUpContext();
        }
        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fetch(int? page)
        {
            try
            {
                bool Status;
                string message;
                List<DTO> lstEmp = blObj.FetchEmpDetails();
                List<EmpFetchMVC> empMvc = new List<EmpFetchMVC>();
                foreach (var emp in lstEmp)
                {
                    EmpFetchMVC lstMvc = new EmpFetchMVC();
                    lstMvc.Psno = emp.Psno;
                    lstMvc.Employee_Name = emp.Employee_Name;
                    lstMvc.Email = emp.Email;
                    lstMvc.Current_skill = emp.Current_skill;
                    lstMvc.Expected_Training = emp.Expected_Training;
                    lstMvc.Expected_Training1 = emp.Expected_Training1;
                    lstMvc.Expected_Training2 = emp.Expected_Training2;
                    lstMvc.Expected_Training3 = emp.Expected_Training3;
                    empMvc.Add(lstMvc);
                }

                return View(empMvc.ToPagedList(page ?? 1, 5));
            }
            catch (Exception)
            {

                return View("Error");
            }


        }
        [HttpGet]
        public ActionResult SaveEmp()
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
        public ActionResult SaveEmp(EmpFetchMVC saveObj)
        {
            try
            {
                bool Status;
                string message;
                DTO dtoObj = new DTO();
                dtoObj.Psno = saveObj.Psno;
                dtoObj.Employee_Name = saveObj.Employee_Name;
                dtoObj.Email = saveObj.Email;
                dtoObj.Current_skill = saveObj.Current_skill;
                dtoObj.Expected_Training = saveObj.Expected_Training;
                dtoObj.Expected_Training1 = saveObj.Expected_Training1;
                dtoObj.Expected_Training2 = saveObj.Expected_Training2;
                dtoObj.Expected_Training3 = saveObj.Expected_Training3;
                TempData["Trainee"] = dtoObj.Expected_Training.ToString();
                TempData["ps"]=dtoObj.Psno.ToString();
                TempData["name"]=dtoObj.Employee_Name;
                TempData["exp"] = dtoObj.Expected_Training.ToString();
               
                int res = blObj.SaveAllEmp(dtoObj);
              
                if (res == 1)
                {
                    SendEmail(saveObj);
                    message = "Registration Successfully";
                    Status = true;
                    return RedirectToAction("Drop");
                }
                else
                {
                    ViewBag.Message = "PS Number is Already Exist";

                    return View("SaveEmp");
                }

            }
            catch (Exception)
            {
                return View("SaveEmp");
                throw;
            }

        }



        [HttpGet]
        public ActionResult EditMvc()
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
        public ActionResult EditMvc(EmpEditModel saveObj)
        {
            try
            {
                DTO dtoObj = new DTO();
                dtoObj.Psno = saveObj.Psno;
                dtoObj.Employee_Name = saveObj.Employee_Name;
                dtoObj.Email = saveObj.Email;
                dtoObj.Current_skill = saveObj.Current_skill;
                dtoObj.Expected_Training = saveObj.Expected_Training;
                dtoObj.Expected_Training1 = saveObj.Expected_Training1;
                dtoObj.Expected_Training2 = saveObj.Expected_Training2;
                dtoObj.Expected_Training3 = saveObj.Expected_Training3;

                int res = blObj.Edit(dtoObj);
                if (res == 1)
                {
                    return RedirectToAction("Succes");
                }
                else
                {
                    ViewBag.Message = "PS Number Entered is not Exist!";
                    return View("Error");

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult DeleteMvc()
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
        

        [NonAction]
        public void SendEmail(EmpFetchMVC saveObj)
        {

            var fromEmail = new MailAddress("gtpolo110@gmail.com", "GEA Portal");
            var toEmail = new MailAddress(saveObj.Email);
            var fromEmailPassword = "oleeolee45";
            string subject = "New Employee added";

            string body = "<h2>New Employee Details Added<h2> <br></br>" +
                "<strong>Username</strong>:" + saveObj.Psno + "<br></br>" +
                "Employee Name:" + saveObj.Employee_Name +
                "<br></br>" + "Email ID:  " + saveObj.Email + "<br></br>" +
                "Employee Name: " + saveObj.Employee_Name + "<br></br>" +
                "Current Skills: " + saveObj.Current_skill + "<br></br>" +
                "Expected Training: " + saveObj.Expected_Training + "<br></br>" +
                "Expected Training 1: " + saveObj.Expected_Training1 + "<br></br>" +
                "Expected Training 2: " + saveObj.Expected_Training2 + "<br></br>" +
                "Expected Training 3: " + saveObj.Expected_Training3 + "<br></br>";



            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        public ActionResult Succes()
        {
            return View();

        }

        public ActionResult dropsucces()
        {
            return View();

        }
        public ActionResult UploadExcel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadExcel(HttpPostedFileBase file)
        {
            DataTable dt = new DataTable();
            
            //Checking file content length and Extension must be .xlsx  
            if (file != null && file.ContentLength > 0 && System.IO.Path.GetExtension(file.FileName).ToLower() == ".xlsx")
            {
                string path = Path.Combine(Server.MapPath("~/UploadFile"), Path.GetFileName(file.FileName));
                //Saving the file  
                file.SaveAs(path);
                //Started reading the Excel file.  
                using (XLWorkbook workbook = new XLWorkbook(path))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    bool FirstRow = true;
                    //Range for reading the cells based on the last cell used.  
                    string readRange = "1:1";
                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        //If Reading the First Row (used) then add them as column name  
                        if (FirstRow)
                        {
                            //Checking the Last cellused for column generation in datatable  
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Columns.Add(cell.Value.ToString());

                            }
                            FirstRow = false;
                        }
                        else
                        {
                            //Adding a Row in datatable  
                            dt.Rows.Add();
                            int cellIndex = 0;
                            //Updating the values of datatable  
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                cellIndex++;
                            }
                        }
                    }
                    //If no data in Excel file  
                    if (FirstRow)
                    {
                        ViewBag.Message = "Empty Excel File!";
                    }
                }
            }
            else
            {
                //If file extension of the uploaded file is different then .xlsx  
                ViewBag.Message = "Please select file with .xlsx extension!";

            }
            string conString = string.Empty;

            conString = ConfigurationManager.ConnectionStrings["StepUPstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conString))
            {

                using (SqlBulkCopy bulk = new SqlBulkCopy(con))
                {
                    bulk.DestinationTableName = "[StepUp].[dbo].[Employee]";

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        bulk.ColumnMappings.Add(i, i);
                    }

                    con.Open();
                    bulk.WriteToServer(dt);
                    con.Close();
                }






                return View("UploadExcel");



            }


        }
        [HttpGet]
        public ActionResult Search(string PSnumber)
        {
            try
            {
                List<DTO> trainee = blObj.GetTraineeByPSNum(PSnumber);
                List<EmpFetchMVC> searchmvc = new List<EmpFetchMVC>();
                foreach (var emp in trainee)
                {
                    EmpFetchMVC lstMvc = new EmpFetchMVC();
                    lstMvc.Psno = emp.Psno;
                    lstMvc.Employee_Name = emp.Employee_Name;
                    lstMvc.Email = emp.Email;
                    lstMvc.Current_skill = emp.Current_skill;
                    lstMvc.Expected_Training = emp.Expected_Training;
                    lstMvc.Expected_Training1 = emp.Expected_Training1;
                    lstMvc.Expected_Training2 = emp.Expected_Training2;
                    lstMvc.Expected_Training3 = emp.Expected_Training3;
                    searchmvc.Add(lstMvc);
                }
                return View(searchmvc);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }

        public ActionResult Drop()
        {
            List<SelectListItem> customerList = GetCustomers();
            return View(customerList);
        }

        [HttpPost]
        public ActionResult Drop(string ddlCustomers)
        {
            List<SelectListItem> customerList = GetCustomers();
            if (!string.IsNullOrEmpty(ddlCustomers))
            {


                string emls = ddlCustomers.ToString();
                SendEmail(emls);



            }

            return RedirectToAction("Succes");
        }

        public List<SelectListItem> GetCustomers()
        {
            string track = (string)TempData["Trainee"];

           StepUpContext entities = new StepUpContext();

            List<SelectListItem> customerList = (from p in entities.Faculties.AsEnumerable()
                                                 where p.Track == track
                                                 select new SelectListItem
                                                 {

                                                     Text = p.Name,
                                                     Value = p.Email,




                                                 }).ToList();


            customerList.Insert(0, new SelectListItem { Text = "--Select faculty--", Value = "" });
            return customerList;
        }

        [NonAction]
        public void SendEmail(string eml)
        {
            string ps = TempData["ps"].ToString();
            string name = TempData["name"].ToString();
            string skill = TempData["exp"].ToString();

            var fromEmail = new MailAddress("gtpolo110@gmail.com", "GEA Portal");
            var toEmail = new MailAddress(eml);
            var fromEmailPassword = "oleeolee45";
            string subject = "New Trainee Enrolled for " +skill ;

            string body = "A new Trainee "+name+ " ("+ps+") " +"has been enrolled for Training : "+skill ;



            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        [HttpGet]
        public ActionResult Delete(String ID)
        {
            BL objDB = new BL();
            int result = objDB.Delete(ID);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
                                //return View();
            ViewBag.Message = TempData["result3"].ToString();
            return RedirectToAction("Fetch");
        }

        public JsonResult CheckPSAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(100);
            var SeachData = stepUpContext.Employees.Where(x => x.Psno.ToString() == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }

        public JsonResult CheckUpdatePSAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(100);
            var SeachData = stepUpContext.Employees.Where(x => x.Psno.ToString() == userdata).SingleOrDefault();
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
