using System;
using Backend.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using static Backend.Models.ModelClass;
using System.Collections.Generic;

namespace Backend.Controllers
{
    public class JobPositionController : ApiController
    {
        [Route("Api/AddJobPosition"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddJobPosition(string Code, string Title, bool? Active, string Responsibility, bool Delete)
        {
            JobPosition oJobPosition = new JobPosition();
            oJobPosition.isSuccess = false;
            oJobPosition.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditJobPosition(0, Code, Title, Active, Responsibility, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oJobPosition.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosition.JobPositionId = DbResult.JobPositionId;
                    oJobPosition.JobPositionId = DbResult.JobPositionId;
                    oJobPosition.Title = DbResult.Title;
                    oJobPosition.Active = DbResult.Active;
                    oJobPosition.Responsibility = DbResult.Responsibility;



                    oJobPosition.isSuccess = true;
                    return Ok(oJobPosition);
                }
            }
            catch (Exception ex)
            {
                oJobPosition.errorDescription = ex.Message;
                return Ok(oJobPosition);

            }

        }
        [Route("Api/UpdateJobPosition"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateJobPosition(int? JobPositionId,  string Code, string Title, bool Active, string Responsibility,bool Delete)
        {
            JobPosition oJobPosition = new JobPosition();
            oJobPosition.isSuccess = false;
            oJobPosition.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditJobPosition(JobPositionId, Code, Title, Active, Responsibility, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oJobPosition.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    oJobPosition.JobPositionId = DbResult.JobPositionId;
                    oJobPosition.Code = DbResult.Code;
                    oJobPosition.Title = DbResult.Title;
                    oJobPosition.Active = DbResult.Active;
                    oJobPosition. Responsibility= DbResult.Responsibility;
                    





                    oJobPosition.isSuccess = true;
                    return Ok(oJobPosition);
                }
            }
            catch (Exception ex)
            {
                oJobPosition.errorDescription = ex.Message;
                return Ok(oJobPosition);

            }
        }
        [Route("Api/DeleteJobPosition"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteJobPosition(int? id)
        {

            using (Entities db = new Entities())
            {

                tblJobPosition JobPosition = db.tblJobPositions.SingleOrDefault(x => x.JobPositionId == id);
                db.tblJobPositions.Remove(JobPosition);
                db.SaveChanges();
                return Ok(JobPosition);
            }
        }
        [Route("Api/GetAllJobPosition")]
        public IHttpActionResult GetAllJobPosition()
        {

            JobPosition oJobPosition = new JobPosition();
            oJobPosition.isSuccess = false;
            oJobPosition.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllJobPosition().ToList();
                    List<JobPosition> listofJobPosition = new List<JobPosition>();
                    foreach (var items in DbResult)
                    {

                        JobPosition ojobPosition = new JobPosition();

                        ojobPosition.JobPositionId = items.JobPositionId;
                        ojobPosition.Code = items.Code;
                        ojobPosition.Title = items.Title;
                        ojobPosition.Active = items.Active;
                        ojobPosition.Responsibility = items.Responsibility;
                       



                        ojobPosition.errorDescription = "";
                        ojobPosition.isSuccess = true;
                        listofJobPosition.Add(ojobPosition);
                    }
                    IEnumerable<JobPosition> myJobPosition = listofJobPosition;
                    return Ok(myJobPosition);

                }
            }
            catch (Exception ex)
            {
                oJobPosition.errorDescription = ex.Message;
                return Ok(oJobPosition);

            }

        }
        [Route("Api/GetJobPosition")]
        public async Task<IHttpActionResult> GetJobPosition(int? id)
        {
            using (Entities db = new Entities())
            {
                var JobPosition = (from a in db.tblJobPositions
                                   where a.JobPositionId == id
                                   select new
                                   {
                                       a.JobPositionId,
                                       a.Code,
                                       a.Title,
                                       a.Active,
                                       a.Responsibility
                                       


                                   }).FirstOrDefault();
                return Ok(new { JobPosition });


            }

        }
    }
}

