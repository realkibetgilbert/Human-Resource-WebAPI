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
    public class EmployerDepartmentController : ApiController
    {
        [Route("Api/AddEmployerDepartment"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerDepartment( string Name, string Code, bool Active, bool Delete)
        {
            EmployerDepartment oEmployerDepartment = new EmployerDepartment();
            oEmployerDepartment.isSuccess = false;
            oEmployerDepartment.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerDepartment(0,Name, Code, Active,  Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerDepartment.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oEmployerDepartment.DepartmentId = DbResult.DepartmentId;

              
                    oEmployerDepartment.Name = DbResult.Name;
                    oEmployerDepartment.Code = DbResult.Code;
                    oEmployerDepartment.Active = DbResult.Active;
                    


                    oEmployerDepartment.isSuccess = true;
                    return Ok(oEmployerDepartment);
                }
            }
            catch (Exception ex)
            {
                oEmployerDepartment.errorDescription = ex.Message;
                return Ok(oEmployerDepartment);

            }

        }


        [Route("Api/UpdateEmployerDepartment"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateEmployerDepartment(int? DepartmentId, string Name, string Code, bool Active, bool Delete)
        {
            EmployerDepartment oEmployerDepartment = new EmployerDepartment();
            oEmployerDepartment.isSuccess = false;
            oEmployerDepartment.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerDepartment(DepartmentId,  Name, Code,Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerDepartment.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }

                    oEmployerDepartment.DepartmentId = DbResult.DepartmentId;


                    oEmployerDepartment.Name = DbResult.Name;
                    oEmployerDepartment.Code = DbResult.Code;
                    oEmployerDepartment.Active = DbResult.Active;





                    oEmployerDepartment.isSuccess = true;
                    return Ok(oEmployerDepartment);
                }
            }
            catch (Exception ex)
            {
                oEmployerDepartment.errorDescription = ex.Message;
                return Ok(oEmployerDepartment);

            }
        }

        [Route("Api/DeleteEmployerDepartment"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerDepartment(int? id)
        {

            using (Entities db = new Entities())
            {

               tblEmployerDepartment EmployerDepartment = db.tblEmployerDepartments.SingleOrDefault(x => x.DepartmentId == id);
                db.tblEmployerDepartments.Remove(EmployerDepartment);
                db.SaveChanges();
                return Ok(EmployerDepartment);
            }
        }
        [Route("Api/GetAllEmployerDepartment")]
        public IHttpActionResult GetAllEmployerDepartment()
        {

            EmployerDepartment oemployer = new EmployerDepartment();
            oemployer.isSuccess = false;
            oemployer.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerDepartment().ToList();
                    List<EmployerDepartment> listofEmployerDepartment = new List<EmployerDepartment>();
                    foreach (var items in DbResult)
                    {

                       EmployerDepartment oEmployerDepartment = new EmployerDepartment();

                        oEmployerDepartment.DepartmentId = items.DepartmentId;
                        oEmployerDepartment.Name = items.Name;
                        oEmployerDepartment.Code = items.Code;
                        oEmployerDepartment.Active = items.Active;
                       



                       oEmployerDepartment.errorDescription = "";
                        oEmployerDepartment.isSuccess = true;
                        listofEmployerDepartment.Add(oEmployerDepartment);
                    }
                    IEnumerable<EmployerDepartment> myEmployerDepartment = listofEmployerDepartment;
                    return Ok(myEmployerDepartment);

                }
            }
            catch (Exception ex)
            {
                oemployer.errorDescription = ex.Message;
                return Ok(oemployer);

            }

        }

        [Route("Api/GetEmployerDepartment")]
        public async Task<IHttpActionResult> GetEmployerDepartment(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerDepartment = (from a in db.tblEmployerDepartments
                                   where a.DepartmentId == id
                                   select new
                                   {
                                       a.DepartmentId,
                                       a.Name,
                                       a.Code,
                                       a.Active,
                                       


                                   }).FirstOrDefault();
                return Ok(new { EmployerDepartment });


            }

        }
    }
}
