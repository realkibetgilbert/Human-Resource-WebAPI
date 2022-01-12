using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class ModelClass
    {
        public  class NewEmployee
        {
            public int? NewEmployeeId { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Position { get; set; }
            public string Department { get; set; }
            public DateTime? DateJoined { get; set; }
            public string Status { get; set; }
            public DateTime? Modified { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }


        }

        public class EmployerInfo
        {
            public int? EmployerId { get; set; }
            public string ImageName { get; set; }
            public string Name { get; set; }
            public string RegistrationNumber { get; set; }
            public string Industry { get; set; }
            public string HomeCountry { get; set; }
            public string PortalUrl { get; set; }
            public string Email { get; set; }
            public string WebSite { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Telephone { get; set; }
            public string Fax { get; set; }
            public bool? IsSuccess { get; set; }
            public string ErrorDescription { get; set; }
        }
        public class JobPosition
        {
            public int? JobPositionId { get; set; }
            public string Code { get; set; }
            public string Title { get; set; }
            public bool? Active { get; set; }
            public string Responsibility { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }
        }
        public class EmployerBank
        {
            public int? BankId { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public bool? Active { get; set; }
            public string BankAccount { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Telephone { get; set; }
            public string Fax { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription{ get; set; }
     

        }
        public  class EmployerDepartment
        {
            public int? DepartmentId { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public bool? Active { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }

        }
        public class EmployerBranch
        {
            public int? BranchId { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public bool? Active { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }

        }
        public  class EmployerLevel
        {
            public int? LevelId { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public bool? Active { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }
        }
        public  class EmployerCourse
        {
            public int? CourseId { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public bool? Active { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }
        }
        public class EmployerTrainer
        {
            public int? TrainerId { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public bool? Active { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }


        }
        public class EmployerEthnicity
        {
            public int? EthnicityId { get; set; }
            public string Description { get; set; }
            public bool? Active { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }
        }
        public  class EmployerReligion
        {
            public int? ReligionId { get; set; }
            public string Description { get; set; }
            public bool? Active { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }
        }
        public  class EmployerDocumentCategory
        {
            public int? CategoryId { get; set; }
            public string Description { get; set; }
            public bool? Active { get; set; }
            public bool? isSuccess { get; set; }
            public string errorDescription { get; set; }
        }
    }
}