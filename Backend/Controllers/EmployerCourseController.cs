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
    public class EmployerCourseController : ApiController
    {
        [Route("Api/AddEmployerCourse"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerCourse(string Code, string Description, bool Active, bool Delete)
        {
            EmployerCourse oEmployerCourse = new EmployerCourse();
            oEmployerCourse.isSuccess = false;
            oEmployerCourse.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerCourse(0, Code, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerCourse.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oEmployerCourse.CourseId = DbResult.CourseId;
                    oEmployerCourse.Code = DbResult.Code;
                    oEmployerCourse.Description = DbResult.Description;
                    oEmployerCourse.Active = DbResult.Active;



                    oEmployerCourse.isSuccess = true;
                    return Ok(oEmployerCourse);
                }
            }
            catch (Exception ex)
            {
                oEmployerCourse.errorDescription = ex.Message;
                return Ok(oEmployerCourse);

            }

        }
        [Route("Api/UpdateEmployerCourse"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateEmployerCourse(int? CourseId, string Code, string Description, bool Active, bool Delete)
        {
            EmployerCourse oEmployerCourse = new EmployerCourse();
            oEmployerCourse.isSuccess = false;
            oEmployerCourse.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerCourse(CourseId, Code, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerCourse.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }

                    oEmployerCourse.CourseId = DbResult.CourseId;
                    oEmployerCourse.Code = DbResult.Code;
                    oEmployerCourse.Description = DbResult.Description;
                    oEmployerCourse.Active = DbResult.Active;





                    oEmployerCourse.isSuccess = true;
                    return Ok(oEmployerCourse);
                }
            }
            catch (Exception ex)
            {
                oEmployerCourse.errorDescription = ex.Message;
                return Ok(oEmployerCourse);

            }
        }

        [Route("Api/DeleteEmployerCourse"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerCourse(int? id)
        {

            using (Entities db = new Entities())
            {

                tblEmployerCourse EmployerCourse = db.tblEmployerCourses.SingleOrDefault(x => x.CourseId == id);
                db.tblEmployerCourses.Remove(EmployerCourse);
                db.SaveChanges();
                return Ok(EmployerCourse);
            }
        }
        [Route("Api/GetAllEmployerCourse")]
        public IHttpActionResult GetAllEmployerCourse()
        {

            EmployerCourse oemployer = new EmployerCourse();
            oemployer.isSuccess = false;
            oemployer.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerCourse().ToList();
                    List<EmployerCourse> listofEmployerCourse = new List<EmployerCourse>();
                    foreach (var items in DbResult)
                    {

                        EmployerCourse oEmployerCourse = new EmployerCourse();

                        oEmployerCourse.CourseId = items.CourseId;
                        oEmployerCourse.Code = items.Code;
                        oEmployerCourse.Description = items.Description;
                        oEmployerCourse.Active = items.Active;




                        oEmployerCourse.errorDescription = "";
                        oEmployerCourse.isSuccess = true;
                        listofEmployerCourse.Add(oEmployerCourse);
                    }
                    IEnumerable<EmployerCourse> myEmployerCourse = listofEmployerCourse;
                    return Ok(myEmployerCourse);

                }
            }
            catch (Exception ex)
            {
                oemployer.errorDescription = ex.Message;
                return Ok(oemployer);

            }

        }
        [Route("Api/GetEmployerCourse")]
        public async Task<IHttpActionResult> GetEmployerCourse(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerCourse = (from a in db.tblEmployerCourses
                                     where a.CourseId == id
                                     select new
                                     {
                                         a.CourseId,
                                         a.Code,
                                         a.Description,
                                         a.Active,



                                     }).FirstOrDefault();
                return Ok(new { EmployerCourse });


            }

        }

    }
}
