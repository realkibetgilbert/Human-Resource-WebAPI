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
    public class NewEmployeeController : ApiController
    {
        [Route("Api/AddNewEmployee"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddNewEmployee(int Id, string Name, string Gender, string Position, string Department, DateTime? DateJoined, string Status, DateTime? Modified, bool Delete)
        {
            NewEmployee oNewEmployee = new NewEmployee();
            oNewEmployee.isSuccess = false;
            oNewEmployee.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditNewEmployee(0, Id, Name, Gender, Position, Department, DateJoined, Status, Modified, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewEmployee.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNewJobPosit.JobPositionId = DbResult.JobPositionId;
                    oNewEmployee.NewEmployeeId = DbResult.NewEmployeeId;

                    oNewEmployee.Id = DbResult.Id;
                    oNewEmployee.Name = DbResult.Name;
                    oNewEmployee.Gender = DbResult.Gender;
                    oNewEmployee.Position = DbResult.Position;
                    oNewEmployee.Department = DbResult.Department;
                    oNewEmployee.DateJoined = DbResult.DateJoined;
                    oNewEmployee.Status = DbResult.Status;
                    oNewEmployee.Modified = DbResult.Modified;


                    oNewEmployee.isSuccess = true;
                    return Ok(oNewEmployee);
                }
            }
            catch (Exception ex)
            {
                oNewEmployee.errorDescription = ex.Message;
                return Ok(oNewEmployee);

            }

        }


        [Route("Api/UpdateNewEmployee"), HttpGet, HttpPost]

        public async Task<IHttpActionResult> UpdateNewEmployee(int? NewEmployeeId, int Id, string Name, string Gender, string Position, string Department, DateTime DateJoined, string Status, DateTime Modified, bool Delete)
        {
            NewEmployee oNewEmployee = new NewEmployee();
            oNewEmployee.isSuccess = false;
            oNewEmployee.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditNewEmployee(NewEmployeeId, Id, Name, Gender, Position, Department, DateJoined, Status, Modified, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewEmployee.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    oNewEmployee.NewEmployeeId = DbResult.NewEmployeeId;
                    oNewEmployee.Id = DbResult.Id;
                    oNewEmployee.Name = DbResult.Name;
                    oNewEmployee.Gender = DbResult.Gender;
                    oNewEmployee.Position = DbResult.Position;
                    oNewEmployee.Department = DbResult.Department;
                    oNewEmployee.DateJoined = DbResult.DateJoined;
                    oNewEmployee.Status = DbResult.Status;
                    oNewEmployee.Modified = DbResult.Modified;






                    oNewEmployee.isSuccess = true;
                    return Ok(oNewEmployee);
                }
            }
            catch (Exception ex)
            {
                oNewEmployee.errorDescription = ex.Message;
                return Ok(oNewEmployee);

            }
        }
        [Route("Api/DeleteNewEmployee"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteNewEmployee(int? id)
        {

            using (Entities db = new Entities())
            {

                tblNewEmployee NewEmployee = db.tblNewEmployees.SingleOrDefault(x => x.NewEmployeeId == id);
                db.tblNewEmployees.Remove(NewEmployee);
                db.SaveChanges();
                return Ok(NewEmployee);
            }
        }
        [Route("Api/GetAllNewEmployee")]
        public IHttpActionResult GetAllNewEmployee()
        {

            NewEmployee oNewNewEmployee = new NewEmployee();
            oNewNewEmployee.isSuccess = false;
            oNewNewEmployee.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllNewEmployee().ToList();
                    List<NewEmployee> listofNewEmployee = new List<NewEmployee>();
                    foreach (var items in DbResult)
                    {

                        NewEmployee oNewEmployee = new NewEmployee();

                        oNewEmployee.NewEmployeeId = items.NewEmployeeId;
                        oNewEmployee.Id = items.Id;
                        oNewEmployee.Name = items.Name;
                        oNewEmployee.Gender = items.Gender;
                        oNewEmployee.Position = items.Position;
                        oNewEmployee.Department = items.Department;
                        oNewEmployee.DateJoined = items.DateJoined;
                        oNewEmployee.Status = items.Status;
                        oNewEmployee.Modified = items.Modified;



                        oNewEmployee.errorDescription = "";
                        oNewEmployee.isSuccess = true;
                        listofNewEmployee.Add(oNewEmployee);
                    }
                    IEnumerable<NewEmployee> myNewEmployee = listofNewEmployee;
                    return Ok(myNewEmployee);

                }
            }
            catch (Exception ex)
            {
                oNewNewEmployee.errorDescription = ex.Message;
                return Ok(oNewNewEmployee);

            }

        }
        [Route("Api/GetNewEmployee")]
        public async Task<IHttpActionResult> GetNewEmployee(int? id)
        {
            using (Entities db = new Entities())
            {
                var NewEmployee = (from a in db.tblNewEmployees
                                   where a.NewEmployeeId == id
                                   select new
                                   {
                                       a.NewEmployeeId,
                                       a.Id,
                                       a.Name,
                                       a.Gender,
                                       a.Position,
                                       a.Department,
                                       a.DateJoined,
                                       a.Status,
                                       a.Modified


                                   }).FirstOrDefault();
                return Ok(new { NewEmployee });


            }

        }

    }
}

 
    