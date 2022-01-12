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
    public class EmployerBranchController : ApiController
    {
        [Route("Api/AddEmployerBranch"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerBranch(string Code, string Name, bool Active, bool Delete)
        {
            EmployerBranch oEmployerBranch = new EmployerBranch();
            oEmployerBranch.isSuccess = false;
            oEmployerBranch.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerBranch(0, Code, Name, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerBranch.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oEmployerBranch.BranchId = DbResult.BranchId;


                    oEmployerBranch.Code = DbResult.Code;
                    oEmployerBranch.Name = DbResult.Name;
                    oEmployerBranch.Active = DbResult.Active;



                    oEmployerBranch.isSuccess = true;
                    return Ok(oEmployerBranch);
                }
            }
            catch (Exception ex)
            {
                oEmployerBranch.errorDescription = ex.Message;
                return Ok(oEmployerBranch);

            }

        }
        [Route("Api/UpdateEmployerBranch"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateEmployerBranch(int? BranchId, string Code, string Name, bool Active, bool Delete)
        {
            EmployerBranch oEmployerBranch = new EmployerBranch();
            oEmployerBranch.isSuccess = false;
            oEmployerBranch.errorDescription = "";


            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerBranch(BranchId, Code, Name, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerBranch.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }



                    oEmployerBranch.BranchId = DbResult.BranchId;


                    oEmployerBranch.Code = DbResult.Code;
                    oEmployerBranch.Name = DbResult.Name;
                    oEmployerBranch.Active = DbResult.Active;



                    oEmployerBranch.isSuccess = true;
                    return Ok(oEmployerBranch);
                }
            }
            catch (Exception ex)
            {
               oEmployerBranch.errorDescription = ex.Message;
                return Ok(oEmployerBranch);

            }
        }
        [Route("Api/DeleteEmployerBranch"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerBranch(int? id)
        {

            using (Entities db = new Entities())
            {

               tblEmployerBranch EmployerBranch = db.tblEmployerBranches.SingleOrDefault(x => x.BranchId == id);
                db.tblEmployerBranches.Remove(EmployerBranch);
                db.SaveChanges();
                return Ok(EmployerBranch);
            }
        }
        [Route("Api/GetAllEmployerBranch")]
        public IHttpActionResult GetAllEmployerBranch()
        {

            EmployerBranch oemployer = new EmployerBranch();
            oemployer.isSuccess = false;
            oemployer.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerBranch().ToList();
                    List<EmployerBranch> listofEmployerBranch = new List<EmployerBranch>();
                    foreach (var items in DbResult)
                    {

                        EmployerBranch oEmployerBranch = new EmployerBranch();

                        oEmployerBranch.BranchId = items.BranchId;
                        oEmployerBranch.Code = items.Code;
                        oEmployerBranch.Name = items.Name;
                        oEmployerBranch.Active = items.Active;




                        oEmployerBranch.errorDescription = "";
                        oEmployerBranch.isSuccess = true;
                        listofEmployerBranch.Add(oEmployerBranch);
                    }
                    IEnumerable<EmployerBranch> myEmployerBranch = listofEmployerBranch;
                    return Ok(myEmployerBranch);

                }
            }
            catch (Exception ex)
            {
                oemployer.errorDescription = ex.Message;
                return Ok(oemployer);

            }

        }

        [Route("Api/GetEmployerBranch")]
        public async Task<IHttpActionResult> GetEmployerBranch(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerBranch = (from a in db.tblEmployerBranches
                                          where a.BranchId == id
                                          select new
                                          {
                                              a.BranchId,
                                              a.Code,
                                              a.Name,
                                              a.Active,



                                          }).FirstOrDefault();
                return Ok(new { EmployerBranch });


            }

        }

    }
}
