using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static Backend.Models.ModelClass;


namespace Backend.Controllers
{
    public class EmployerEthnicityController : ApiController
    {
        [Route("Api/AddEmployerEthnicity"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerEthnicity( string Description, bool Active, bool Delete)
        {
            EmployerEthnicity oEmployerEthnicity = new EmployerEthnicity();
            oEmployerEthnicity.isSuccess = false;
            oEmployerEthnicity.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerEthnicity( 0,Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerEthnicity.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oEmployerEthnicity.EthnicityId = DbResult.EthnicityId;
                   
                    oEmployerEthnicity.Description = DbResult.Description;
                    oEmployerEthnicity.Active = DbResult.Active;



                    oEmployerEthnicity.isSuccess = true;
                    return Ok(oEmployerEthnicity);
                }
            }
            catch (Exception ex)
            {
                oEmployerEthnicity.errorDescription = ex.Message;
                return Ok(oEmployerEthnicity);

            }

        }
        [Route("Api/UpdateEmployerEthnicity"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateEmployerEthnicity(int? EthnicityId,  string Description, bool Active, bool Delete)
        {
            EmployerEthnicity oEmployerEthnicity = new EmployerEthnicity();
            oEmployerEthnicity.isSuccess = false;
            oEmployerEthnicity.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerEthnicity(EthnicityId, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerEthnicity.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }

                    oEmployerEthnicity.EthnicityId = DbResult.EthnicityId;
                    oEmployerEthnicity.Description = DbResult.Description;
                    oEmployerEthnicity.Active = DbResult.Active;





                    oEmployerEthnicity.isSuccess = true;
                    return Ok(oEmployerEthnicity);
                }
            }
            catch (Exception ex)
            {
                oEmployerEthnicity.errorDescription = ex.Message;
                return Ok(oEmployerEthnicity);

            }
        }

        [Route("Api/DeleteEmployerEthnicity"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerEthnicity(int? id)
        {

            using (Entities db = new Entities())
            {

                tblEmployerEthnicity EmployerEthnicity = db.tblEmployerEthnicities.SingleOrDefault(x => x.EthnicityId == id);
                db.tblEmployerEthnicities.Remove(EmployerEthnicity);
                db.SaveChanges();
                return Ok(EmployerEthnicity);
            }
        }
        [Route("Api/GetAllEmployerEthnicity")]
        public IHttpActionResult GetAllEmployerLevel()
        {
            EmployerEthnicity oemployer = new EmployerEthnicity();
            oemployer.isSuccess = false;
            oemployer.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerEthnicity().ToList();
                    List<EmployerEthnicity> listofEmployerEthnicity = new List<EmployerEthnicity>();
                    foreach (var items in DbResult)
                    {

                        EmployerEthnicity oEmployerEthnicity = new EmployerEthnicity();

                        oEmployerEthnicity.EthnicityId = items.EthnicityId;

                        oEmployerEthnicity.Description = items.Description;
                        oEmployerEthnicity.Active = items.Active;
                        oEmployerEthnicity.errorDescription = "";
                        oEmployerEthnicity.isSuccess = true;
                        listofEmployerEthnicity.Add(oEmployerEthnicity);
                    }
                    IEnumerable<EmployerEthnicity> myEmployerEthnicity = listofEmployerEthnicity;
                    return Ok(myEmployerEthnicity);

                }
            }
            catch (Exception ex)
            {
                oemployer.errorDescription = ex.Message;
                return Ok(oemployer);

            }

        }
        [Route("Api/GetEmployerEthnicity")]
        public async Task<IHttpActionResult> GetEmployerEthnicity(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerEthnicity = (from a in db.tblEmployerEthnicities
                                     where a.EthnicityId == id
                                     select new
                                     {
                                         a.EthnicityId,
                                         
                                         a.Description,
                                         a.Active,



                                     }).FirstOrDefault();
                return Ok(new { EmployerEthnicity });


            }

        }

    }
}
