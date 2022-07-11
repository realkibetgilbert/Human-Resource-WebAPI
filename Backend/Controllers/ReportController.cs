using System;
using System.Collections.Generic;
using Backend.Utilities;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers
{
    public class ReportController : ApiController
    {
        [AllowAnonymous]
        [Route("Reports/CrystalReport")]
        [HttpGet]
        [ClientCacheWithEtag(60)]  //1 min client side caching
        public HttpResponseMessage CrytalReport()
        {
            string reportPath = "~/Reports";
            string reportFileName = "CrystalReport.rpt";
            string exportFilename = "CrystalReport.pdf";

            HttpResponseMessage result = CrystalReport.RenderReport(reportPath, reportFileName, exportFilename);
            return result;
        }
    }
}
