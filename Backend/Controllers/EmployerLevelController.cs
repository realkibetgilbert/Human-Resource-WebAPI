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
    public class EmployerLevelController : ApiController
    {
        [Route("Api/AddEmployerLevel"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerLevel(string Code, string Description, bool Active, bool Delete)
        {
            EmployerLevel oEmployerLevel = new EmployerLevel();
            oEmployerLevel.isSuccess = false;
            oEmployerLevel.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddUpdateEmployerLevel(0, Code,Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerLevel.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oEmployerLevel.LevelId = DbResult.LevelId;
                    oEmployerLevel.Code = DbResult.Code;
                    oEmployerLevel.Description = DbResult.Description;
                    oEmployerLevel.Active = DbResult.Active;



                    oEmployerLevel.isSuccess = true;
                    return Ok(oEmployerLevel);
                }
            }
            catch (Exception ex)
            {
                oEmployerLevel.errorDescription = ex.Message;
                return Ok(oEmployerLevel);

            }

        }

        [Route("Api/UpdateEmployerLevel"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateEmployerLevel(int? LevelId, string Code, string Description, bool Active, bool Delete)
        {
            EmployerLevel oEmployerLevel = new EmployerLevel();
            oEmployerLevel.isSuccess = false;
            oEmployerLevel.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddUpdateEmployerLevel(LevelId, Code,Description ,Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerLevel.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }

                    oEmployerLevel.LevelId = DbResult.LevelId;
                    oEmployerLevel.Code = DbResult.Code;
                    oEmployerLevel.Description = DbResult.Description;
                    oEmployerLevel.Active = DbResult.Active;





                    oEmployerLevel.isSuccess = true;
                    return Ok(oEmployerLevel);
                }
            }
            catch (Exception ex)
            {
                oEmployerLevel.errorDescription = ex.Message;
                return Ok(oEmployerLevel);

            }
        }
        [Route("Api/DeleteEmployerLevel"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerLevel(int? id)
        {

            using (Entities db = new Entities())
            {

                tblEmployerLevel EmployerLevel = db.tblEmployerLevels.SingleOrDefault(x => x.LevelId == id);
                db.tblEmployerLevels.Remove(EmployerLevel);
                db.SaveChanges();
                return Ok(EmployerLevel);
            }
        }

        [Route("Api/GetAllEmployerLevel")]
        public IHttpActionResult GetAllEmployerLevel()
        {
            EmployerLevel oemployer = new EmployerLevel();
            oemployer.isSuccess = false;
            oemployer.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerLevel().ToList();
                    List<EmployerLevel> listofEmployerLevel = new List<EmployerLevel>();
                    foreach (var items in DbResult)
                    {

                        EmployerLevel oEmployerLevel = new EmployerLevel();

                        oEmployerLevel.LevelId = items.LevelId;
                        oEmployerLevel.Code = items.Code;
                        oEmployerLevel.Description = items.Description;
                        oEmployerLevel.Active = items.Active;
                        oEmployerLevel.errorDescription = "";
                        oEmployerLevel.isSuccess = true;
                        listofEmployerLevel.Add(oEmployerLevel);
                    }
                    IEnumerable<EmployerLevel> myEmployerLevel = listofEmployerLevel;
                    return Ok(myEmployerLevel);

                }
            }
            catch (Exception ex)
            {
                oemployer.errorDescription = ex.Message;
                return Ok(oemployer);

            }

        }

        [Route("Api/GetEmployerLevel")]
        public async Task<IHttpActionResult> GetEmployerLevel(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerLevel = (from a in db.tblEmployerLevels
                                          where a.LevelId == id
                                          select new
                                          {
                                              a.LevelId,
                                              a.Code,
                                              a.Description,
                                              a.Active,



                                          }).FirstOrDefault();
                return Ok(new { EmployerLevel });


            }

        }

    }
}
