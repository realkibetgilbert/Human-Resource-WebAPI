using Backend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Backend.Models.ModelClass;

namespace Backend.Controllers
{
    public class EmployerInfoController : ApiController
    {

        [Route("Api/AddEmployerInfo"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerInfo()
        {
            EmployerInfo oEmployerInfo = new EmployerInfo();
            oEmployerInfo.IsSuccess = false;
            oEmployerInfo.ErrorDescription = "";
            try
            {



                string imageName = null;
                string Name = "";
                string RegistrationNumber = "";
                string Industry = "";
                string HomeCountry = "";
                string PortalUrl = "";
                string Email = "";
                string WebSite = "";
                string Address1 = "";
                string Address2 = "";
                string City = "";
                string PostalCode = "";
                string State = "";
                string Country = "";
                string Telephone = "";
                string Fax = "";


                var httpRequest = HttpContext.Current.Request;


                Name = httpRequest["Name"];
                RegistrationNumber = httpRequest["RegistrationNumber"];
                Industry = httpRequest["Industry"];
                HomeCountry = httpRequest["HomeCountry"];
                PortalUrl = httpRequest["PortalUrl"];
                Email = httpRequest["Email"];
                WebSite = httpRequest["WebSite"];
                Address1 = httpRequest["Address1"];
                Address2 = httpRequest["Address2"];
                City = httpRequest["City"];
                PostalCode = httpRequest["PostalCode"];
                State = httpRequest["State"];
                Country = httpRequest["Country"];
                Telephone = httpRequest["Telephone"];
                Fax = httpRequest["Fax"];
                //UPLOAD IMAGE
                var postedFile = httpRequest.Files["Image"];
                //create custom fileName
                imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
                postedFile.SaveAs(filePath);
                //save DB
                using (Entities db = new Entities())
                {

                    var dbResult = db.proc_AddEmployerInfo(0, imageName, Name, RegistrationNumber, Industry, HomeCountry, PortalUrl, Email, WebSite, Address1, Address2, City, PostalCode, State, Country, Telephone, Fax).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oEmployerInfo.ErrorDescription = "Employer is not added";
                        return Ok(oEmployerInfo);
                    }
                    oEmployerInfo.IsSuccess = true;
                    oEmployerInfo.ErrorDescription = "";
                    return Ok(oEmployerInfo);
                }

            }
            catch (Exception ex)
            {
                oEmployerInfo.ErrorDescription = ex.Message;
                oEmployerInfo.IsSuccess = false;
                return Ok(oEmployerInfo);
            }
        }



        [Route("Api/UpdateEmployerInfo"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateEmployerInfo(int? EmployerId, string ImageName, string Name, string RegistrationNumber, string Industry, string HomeCountry, string PortalUrl, string Email, string WebSite, string Address1, string Address2, string City, string PostalCode, string State, string Country, string Telephone, string Fax)
        {
            EmployerInfo oEmployerInfo = new EmployerInfo();
            oEmployerInfo.IsSuccess = false;
            oEmployerInfo.ErrorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_EditEmployerInformations(EmployerId, Name, RegistrationNumber, Industry, HomeCountry, PortalUrl, Email, WebSite, Address1, Address2, City, PostalCode, State, Country, Telephone, Fax).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerInfo.ErrorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    oEmployerInfo.EmployerId = DbResult.EmployerId;

                    oEmployerInfo.Name = DbResult.Name;

                    oEmployerInfo.RegistrationNumber = DbResult.RegistrationNumber;
                    oEmployerInfo.Industry = DbResult.Industry;
                    oEmployerInfo.HomeCountry = DbResult.HomeCountry;
                    oEmployerInfo.PortalUrl = DbResult.PortalUrl;
                    oEmployerInfo.Email = DbResult.Email;
                    oEmployerInfo.Address1 = DbResult.Address1;
                    oEmployerInfo.Address2 = DbResult.Address2;
                    oEmployerInfo.City = DbResult.City;
                    oEmployerInfo.PostalCode = DbResult.PostalCode;
                    oEmployerInfo.State = DbResult.State;
                    oEmployerInfo.Country = DbResult.Country;
                    oEmployerInfo.Telephone = DbResult.Telephone;
                    oEmployerInfo.Fax = DbResult.Fax;






                    oEmployerInfo.IsSuccess = true;
                    return Ok(oEmployerInfo);
                }
            }
            catch (Exception ex)
            {
                oEmployerInfo.ErrorDescription = ex.Message;
                return Ok(oEmployerInfo);

            }
        }








        //updating image only

        [Route("Api/UpdateEmployerImage"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateEmployerImage()
        {
            EmployerInfo oEmployerInfo = new EmployerInfo();
            oEmployerInfo.IsSuccess = false;
            oEmployerInfo.ErrorDescription = "";
         
            try
            {
                string imageName = null;
                int EmployerId = 0;

                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files["Image"];
                EmployerId =int.Parse (httpRequest["EmployerId"]);
                //create custom fileName
                imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
                postedFile.SaveAs(filePath);
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_UpdateEmployerImage(EmployerId, imageName).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerInfo.ErrorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    oEmployerInfo.EmployerId = DbResult.EmployerId;
                    oEmployerInfo.ImageName = DbResult.ImageName;

                    oEmployerInfo.IsSuccess = true;
                    return Ok(oEmployerInfo);
                }
            }
            catch (Exception ex)
            {
                oEmployerInfo.ErrorDescription = ex.Message;
                return Ok(oEmployerInfo);

            }
        }






        [Route("Api/DeleteEmployerInfo"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerInfo(int? id)
        {

            using (Entities db = new Entities())
            {

                tblEmployerInfo employerInfo = db.tblEmployerInfoes.SingleOrDefault(x => x.EmployerId == id);
                db.tblEmployerInfoes.Remove(employerInfo);
                db.SaveChanges();
                return Ok(employerInfo);
            }
        }
        [Route("Api/GetAllEmployerInfo")]
        public IHttpActionResult GetAllEmployerInfo()
        {

            EmployerInfo oEmployerInfo = new EmployerInfo();
            oEmployerInfo.IsSuccess = false;
            oEmployerInfo.ErrorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerInfo().ToList();
                    List<EmployerInfo> listofEmployerInfo = new List<EmployerInfo>();
                    foreach (var items in DbResult)
                    {

                        EmployerInfo oEmployerinfo = new EmployerInfo();

                        oEmployerinfo.EmployerId = items.EmployerId;
                        oEmployerinfo.ImageName = items.ImageName;
                        oEmployerinfo.Name = items.Name;
                        oEmployerinfo.RegistrationNumber = items.RegistrationNumber;
                        oEmployerinfo.Industry = items.Industry;
                        oEmployerinfo.HomeCountry = items.HomeCountry;
                        oEmployerinfo.PortalUrl = items.PortalUrl;
                        oEmployerinfo.Email = items.Email;
                        oEmployerinfo.WebSite = items.WebSite;
                        oEmployerinfo.Address1 = items.Address1;
                        oEmployerinfo.Address2 = items.Address2;
                        oEmployerinfo.City = items.City;
                        oEmployerinfo.PostalCode = items.PostalCode;
                        oEmployerinfo.State = items.State;
                        oEmployerinfo.Country = items.Country;
                        oEmployerinfo.Telephone = items.Telephone;
                        oEmployerinfo.Fax = items.Fax;

                        oEmployerinfo.ErrorDescription = "";
                        oEmployerinfo.IsSuccess = true;
                        listofEmployerInfo.Add(oEmployerinfo);
                    }
                    IEnumerable<EmployerInfo> myEmployerInfo = listofEmployerInfo;
                    return Ok(myEmployerInfo);

                }
            }
            catch (Exception ex)
            {
                oEmployerInfo.ErrorDescription = ex.Message;
                return Ok(oEmployerInfo);

            }

        }

        [Route("Api/GetEmployerInfo")]
        public async Task<IHttpActionResult> GetEmployerInfo(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerInfo = (from a in db.tblEmployerInfoes
                                    where a.EmployerId == id
                                    select new
                                    {
                                        a.EmployerId,
                                        a.ImageName,
                                        a.Name,
                                        a.RegistrationNumber,
                                        a.Industry,
                                        a.HomeCountry,
                                        a.PortalUrl,
                                        a.Email,
                                        a.WebSite,
                                        a.Address1,
                                        a.Address2,
                                        a.City,
                                        a.PostalCode,
                                        a.State,
                                        a.Country,
                                        a.Telephone,
                                        a.Fax


                                    }).FirstOrDefault();
                return Ok(new { EmployerInfo });


            }

        }

    }
}


