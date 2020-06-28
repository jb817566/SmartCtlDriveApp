using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartCtl.Db.Utility;
using SmartCtl.Domain;

namespace SmartCtlDriveWebApp.Controllers
{
    [ApiController]
    [Route("api/smartctl")]
    public class SmartCtlController : ControllerBase
    {
        private readonly DriveInformationUtility DBUtility;
        public SmartCtlController(DriveInformationUtility utility)
        {
            this.DBUtility = utility;
        }

        [HttpGet("listall")]
        public async Task<List<DriveInformation>> Get()
        {
            return await DBUtility.ListAllAsync();
        }
    }
}
