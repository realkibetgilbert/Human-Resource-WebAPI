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
    public class EmployerTrainerController : ApiController
    {
        [Route("Api/AddEmployerTrainer"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerTrainer(string Code, string Description, bool Active, bool Delete)
        {
            EmployerTrainer oEmployerTrainer = new EmployerTrainer();
            oEmployerTrainer.isSuccess = false;
            oEmployerTrainer.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerTrainer(0, Code, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerTrainer.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oEmployerTrainer.TrainerId = DbResult.TrainerId;
                    oEmployerTrainer.Code = DbResult.Code;
                    oEmployerTrainer.Description = DbResult.Description;
                    oEmployerTrainer.Active = DbResult.Active;



                    oEmployerTrainer.isSuccess = true;
                    return Ok(oEmployerTrainer);
                }
            }
            catch (Exception ex)
            {
                oEmployerTrainer.errorDescription = ex.Message;
                return Ok(oEmployerTrainer);

            }

        }

        [Route("Api/UpdateEmployerTrainer"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateEmployerTrainer(int? TrainerId, string Code, string Description, bool Active, bool Delete)
        {
            EmployerTrainer oEmployerTrainer = new EmployerTrainer();
            oEmployerTrainer.isSuccess = false;
            oEmployerTrainer.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerTrainer(TrainerId, Code, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerTrainer.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }

                    oEmployerTrainer.TrainerId = DbResult.TrainerId;
                    oEmployerTrainer.Code = DbResult.Code;
                    oEmployerTrainer.Description = DbResult.Description;
                    oEmployerTrainer.Active = DbResult.Active;





                    oEmployerTrainer.isSuccess = true;
                    return Ok(oEmployerTrainer);
                }
            }
            catch (Exception ex)
            {
                oEmployerTrainer.errorDescription = ex.Message;
                return Ok(oEmployerTrainer);

            }
        }

        [Route("Api/DeleteEmployerTrainer"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerTrainer(int? id)
        {

            using (Entities db = new Entities())
            {

                tblEmployerTrainer EmployerTrainer = db.tblEmployerTrainers.SingleOrDefault(x => x.TrainerId == id);
                db.tblEmployerTrainers.Remove(EmployerTrainer);
                db.SaveChanges();
                return Ok(EmployerTrainer);
            }
        }

        [Route("Api/GetAllEmployerTrainer")]
        public IHttpActionResult GetAllEmployerTrainer()
        {
            EmployerTrainer oemployer = new EmployerTrainer();
            oemployer.isSuccess = false;
            oemployer.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerTrainer().ToList();
                    List<EmployerTrainer> listofEmployerTrainer = new List<EmployerTrainer>();
                    foreach (var items in DbResult)
                    {

                        EmployerTrainer oEmployerTrainer = new EmployerTrainer();

                        oEmployerTrainer.TrainerId = items.TrainerId;
                        oEmployerTrainer.Code = items.Code;
                        oEmployerTrainer.Description = items.Description;
                        oEmployerTrainer.Active = items.Active;
                        oEmployerTrainer.errorDescription = "";
                        oEmployerTrainer.isSuccess = true;
                        listofEmployerTrainer.Add(oEmployerTrainer);
                    }
                    IEnumerable<EmployerTrainer> myEmployerTrainer = listofEmployerTrainer;
                    return Ok(myEmployerTrainer);

                }
            }
            catch (Exception ex)
            {
                oemployer.errorDescription = ex.Message;
                return Ok(oemployer);

            }

        }
        [Route("Api/GetEmployerTrainer")]
        public async Task<IHttpActionResult> GetEmployerTrainer(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerTrainer = (from a in db.tblEmployerTrainers
                                     where a.TrainerId == id
                                     select new
                                     {
                                         a.TrainerId,
                                         a.Code,
                                         a.Description,
                                         a.Active,



                                     }).FirstOrDefault();
                return Ok(new { EmployerTrainer });


            }

        }
    }
}
