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
    public class EmployerDocumentCategoryController : ApiController
    {
        [Route("Api/AddEmployerDocumentCategory"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddEmployerDocumentCategory(string Description, bool Active, bool Delete)
        {
            EmployerDocumentCategory oEmployerDocumentCategory = new EmployerDocumentCategory();
            oEmployerDocumentCategory.isSuccess = false;
            oEmployerDocumentCategory.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerDocumentCategory(0, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerDocumentCategory.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oEmployerDocumentCategory.CategoryId = DbResult.CategoryId;

                    oEmployerDocumentCategory.Description = DbResult.Description;
                    oEmployerDocumentCategory.Active = DbResult.Active;



                    oEmployerDocumentCategory.isSuccess = true;
                    return Ok(oEmployerDocumentCategory);
                }
            }
            catch (Exception ex)
            {
                oEmployerDocumentCategory.errorDescription = ex.Message;
                return Ok(oEmployerDocumentCategory);

            }

        }
        [Route("Api/UpdateEmployerDocumentCategory"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateEmployerDocumentCategory(int? CategoryId, string Description, bool Active, bool Delete)
        {
            EmployerDocumentCategory oEmployerDocumentCategory = new EmployerDocumentCategory();
            oEmployerDocumentCategory.isSuccess = false;
            oEmployerDocumentCategory.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerDocumentCategory(CategoryId, Description, Active, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerDocumentCategory.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }

                    oEmployerDocumentCategory.CategoryId = DbResult.CategoryId;
                    oEmployerDocumentCategory.Description = DbResult.Description;
                    oEmployerDocumentCategory.Active = DbResult.Active;





                    oEmployerDocumentCategory.isSuccess = true;
                    return Ok(oEmployerDocumentCategory);
                }
            }
            catch (Exception ex)
            {
                oEmployerDocumentCategory.errorDescription = ex.Message;
                return Ok(oEmployerDocumentCategory);

            }
        }

        [Route("Api/DeleteEmployerDocumentCategory"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerDocumentCategory(int? id)
        {

            using (Entities db = new Entities())
            {

                tblEmployerDocumentCategory EmployerDocumentCategory = db.tblEmployerDocumentCategories.SingleOrDefault(x => x.CategoryId == id);
                db.tblEmployerDocumentCategories.Remove(EmployerDocumentCategory);
                db.SaveChanges();
                return Ok(EmployerDocumentCategory);
            }
        }
        [Route("Api/GetAllEmployerDocumentCategory")]
        public IHttpActionResult GetAllEmployerDocumentCategory()
        {
            EmployerDocumentCategory oemployer = new EmployerDocumentCategory();
            oemployer.isSuccess = false;
            oemployer.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerDocumentCategory().ToList();
                    List<EmployerDocumentCategory> listofEmployerDocumentCategory = new List<EmployerDocumentCategory>();
                    foreach (var items in DbResult)
                    {

                        EmployerDocumentCategory oEmployerDocumentCategory = new EmployerDocumentCategory();

                        oEmployerDocumentCategory.CategoryId = items.CategoryId;

                        oEmployerDocumentCategory.Description = items.Description;
                        oEmployerDocumentCategory.Active = items.Active;
                        oEmployerDocumentCategory.errorDescription = "";
                        oEmployerDocumentCategory.isSuccess = true;
                        listofEmployerDocumentCategory.Add(oEmployerDocumentCategory);
                    }
                    IEnumerable<EmployerDocumentCategory> myEmployerDocumentCategory = listofEmployerDocumentCategory;
                    return Ok(myEmployerDocumentCategory);

                }
            }
            catch (Exception ex)
            {
                oemployer.errorDescription = ex.Message;
                return Ok(oemployer);

            }

        }

        [Route("Api/GetEmployerDocumentCategory")]
        public async Task<IHttpActionResult> GetEmployerDocumentCategory(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerDocumentCategory = (from a in db.tblEmployerDocumentCategories
                                        where a.CategoryId == id
                                        select new
                                        {
                                            a.CategoryId,
                                            a.Description,
                                            a.Active,



                                        }).FirstOrDefault();
                return Ok(new { EmployerDocumentCategory });


            }

        }



    }
}
    