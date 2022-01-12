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
    public class EmployerBankController : ApiController
    {
        [Route("Api/AddEmployerBank"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddNewEmployee(string Code, string Name, bool Active, string BankAccount, string Address1, string Address2, string City, string PostalCode, string State, string Country, string Telephone, string Fax, bool Delete)
        {
            EmployerBank oEmployerBank = new EmployerBank();
            oEmployerBank.isSuccess = false;
            oEmployerBank.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerBank(0, Code, Name, Active, BankAccount, Address1, Address2, City, PostalCode, State, Country, Telephone, Fax, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerBank.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    // oNew
                    oEmployerBank.BankId = DbResult.BankId;

                    oEmployerBank.Code = DbResult.Code;
                    oEmployerBank.Name = DbResult.Name;
                    oEmployerBank.Active = DbResult.Active;
                    oEmployerBank.BankAccount = DbResult.BankAccount;
                    oEmployerBank.Address1 = DbResult.Address1;
                    oEmployerBank.Address2 = DbResult.Address2;
                    oEmployerBank.City = DbResult.City;
                    oEmployerBank.PostalCode = DbResult.PostalCode;
                    oEmployerBank.State = DbResult.State;
                    oEmployerBank.Country = DbResult.State;
                    oEmployerBank.Telephone = DbResult.Telephone;
                    oEmployerBank.Fax = DbResult.Fax;

                    oEmployerBank.isSuccess = true;
                    return Ok(oEmployerBank);
                }
            }
            catch (Exception ex)
            {
                oEmployerBank.errorDescription = ex.Message;
                return Ok(oEmployerBank);

            }

        }
        [Route("Api/UpdateEmployerBank"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateEmployerBank(int? BankId, string Code, string Name, bool Active, string BankAccount, string Address1, string Address2, string City, string PostalCode, string State, string Country, string Telephone, string Fax, bool Delete)
        {
            EmployerBank oEmployerBank = new EmployerBank();
            oEmployerBank.isSuccess = false;
            oEmployerBank.errorDescription = "";
            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_AddEditEmployerBanks(BankId, Code, Name, Active, BankAccount, Address1, Address2, City, PostalCode, State, Country, Telephone, Fax, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oEmployerBank.errorDescription = "Process failed";
                        return Ok(DbResult);
                    }
                    oEmployerBank.BankId = DbResult.BankId;

                    oEmployerBank.Code = DbResult.Code;
                    oEmployerBank.Name = DbResult.Name;
                    oEmployerBank.Active = DbResult.Active;
                    oEmployerBank.BankAccount = DbResult.BankAccount;
                    oEmployerBank.Address1 = DbResult.Address1;
                    oEmployerBank.Address2 = DbResult.Address2;
                    oEmployerBank.City = DbResult.City;
                    oEmployerBank.PostalCode = DbResult.PostalCode;
                    oEmployerBank.State = DbResult.State;
                    oEmployerBank.Country = DbResult.Country;
                    oEmployerBank.Telephone = DbResult.Telephone;
                    oEmployerBank.Fax = DbResult.Fax;





                    oEmployerBank.isSuccess = true;
                    return Ok(oEmployerBank);
                }
            }
            catch (Exception ex)
            {
                oEmployerBank.errorDescription = ex.Message;
                return Ok(oEmployerBank);

            }
        }

        [Route("Api/GetAllEmployerBank")]
        public IHttpActionResult GetAllEmployerInfo()
        {

            EmployerBank employerBank = new EmployerBank();
            employerBank.isSuccess = false;
            employerBank.errorDescription = "";

            try
            {
                using (Entities db = new Entities())
                {
                    var DbResult = db.proc_GetAllEmployerBanks().ToList();
                    List<EmployerBank> listofEmployerBank = new List<EmployerBank>();
                    foreach (var items in DbResult)
                    {

                        EmployerBank oEmployerBank = new EmployerBank();

                        oEmployerBank.BankId = items.BankId;
                        oEmployerBank.Code= items.Code;
                        oEmployerBank.Name = items.Name;
                        oEmployerBank.Active = items.Active;
                        oEmployerBank.BankAccount = items.BankAccount;
                        oEmployerBank.Address1 = items.Address1;
                        oEmployerBank.Address2= items.Address2;
                        oEmployerBank.City= items.City;
                        oEmployerBank.PostalCode = items.PostalCode;
                        oEmployerBank.State = items.State;
                        oEmployerBank.Country = items.Country;
                        oEmployerBank.Telephone = items.Telephone;
                        oEmployerBank.Fax = items.Fax;


                        oEmployerBank.errorDescription = "";
                        oEmployerBank.isSuccess = true;
                        listofEmployerBank.Add(oEmployerBank);
                    }
                    IEnumerable<EmployerBank> myEmployerBank = listofEmployerBank;
                    return Ok(myEmployerBank);

                }
            }
            catch (Exception ex)
            {
                employerBank.errorDescription = ex.Message;
                return Ok(employerBank);

            }

        }

        [Route("Api/GetEmployerBank")]
        public async Task<IHttpActionResult> GetEmployerBank(int? id)
        {
            using (Entities db = new Entities())
            {
                var EmployerBank = (from a in db.tblEmployerBanks
                                   where a.BankId== id
                                   select new
                                   {
                                       a.BankId,
                                       a.Code,
                                       a.Name,
                                       a.Active,
                                       a.BankAccount,
                                       a.Address1,
                                       a.Address2,
                                       a.City,
                                       a.PostalCode,
                                       a.State,
                                       a.Country,
                                       a.Telephone,
                                       a.Fax


                                   }).FirstOrDefault();
                return Ok(new { EmployerBank });


            }

        }
        [Route("Api/DeleteEmployerBank"), HttpGet, HttpDelete]
        public IHttpActionResult DeleteEmployerBank(int? id)
        {

            using (Entities db = new Entities())
            {

                tblEmployerBank EmployerBank = db.tblEmployerBanks.SingleOrDefault(x => x.BankId == id);
                db.tblEmployerBanks.Remove(EmployerBank);
                db.SaveChanges();
                return Ok(EmployerBank);
            }
        }


    }
}
