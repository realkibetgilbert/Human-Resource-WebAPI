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
    public class EmployerReligionController : ApiController
    {
        [Route("Api/AddEmployerReligion"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerReligion(string Description, bool Active, bool Delete)
        {
            EmployerReligion oEmployerReligion = new EmployerReligion();
            oEmployerReligion.isSuccess = false;
            oEmployerReligion.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerReligion(0, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerReligion.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oEmployerReligion.ReligionId = DbResult.ReligionId;

                    oEmployerReligion.Description = DbResult.Description;
                    oEmployerReligion.Active = DbResult.Active;



                    oEmployerReligion.isSuccess = true;
                    return Ok(oEmployerReligion);
                }
            }
            catch (Exception ex)
            {
                oEmployerReligion.errorDescription = ex.Message;
                return Ok(oEmployerReligion);

            }

        }
        [Route("Api/UpdateEmployerReligion"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateEmployerReligion(int? ReligionId, string Description, bool Active, bool Delete)
        {
            EmployerReligion oEmployerReligion = new EmployerReligion();
            oEmployerReligion.isSuccess = false;
            oEmployerReligion.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerReligion(ReligionId, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerReligion.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }

                    oEmployerReligion.ReligionId = DbResult.ReligionId;
                    oEmployerReligion.Description = DbResult.Description;
                    oEmployerReligion.Active = DbResult.Active;





                    oEmployerReligion.isSuccess = true;
                    return Ok(oEmployerReligion);
                }
            }
            catch (Exception ex)
            {
                oEmployerReligion.errorDescription = ex.Message;
                return Ok(oEmployerReligion);

            }
        }

        [Route("Api/DeleteEmployerReligion"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerReligion(int? id)
        {

            using (Entities db = new Entities())
            {

                tblEmployerReligion EmployerReligion = db.tblEmployerReligions.SingleOrDefault(x => x.ReligionId == id);
                db.tblEmployerReligions.Remove(EmployerReligion);
                db.SaveChanges();
                return Ok(EmployerReligion);
            }
        }
        [Route("Api/GetAllEmployerReligion")]
        public IHttpActionResult GetAllEmployerReligion()
        {
            EmployerReligion oemployer = new EmployerReligion();
            oemployer.isSuccess = false;
            oemployer.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerReligion().ToList();
                    List<EmployerReligion> listofEmployerReligion = new List<EmployerReligion>();
                    foreach (var items in DbResult)
                    {

                        EmployerReligion oEmployerReligion = new EmployerReligion();

                        oEmployerReligion.ReligionId = items.ReligionId;

                        oEmployerReligion.Description = items.Description;
                        oEmployerReligion.Active = items.Active;
                        oEmployerReligion.errorDescription = "";
                        oEmployerReligion.isSuccess = true;
                        listofEmployerReligion.Add(oEmployerReligion);
                    }
                    IEnumerable<EmployerReligion> myEmployerReligion = listofEmployerReligion;
                    return Ok(myEmployerReligion);

                }
            }
            catch (Exception ex)
            {
                oemployer.errorDescription = ex.Message;
                return Ok(oemployer);

            }

        }

        [Route("Api/GetEmployerReligion")]  
        public async Task<IHttpActionResult> GetEmployerReligion(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerReligion = (from a in db.tblEmployerReligions
                                         where a.ReligionId == id
                                         select new
                                         {
                                             a.ReligionId,
                                             a.Description,
                                             a.Active,



                                         }).FirstOrDefault();
                return Ok(new { EmployerReligion });


            }

        }



    }
}
