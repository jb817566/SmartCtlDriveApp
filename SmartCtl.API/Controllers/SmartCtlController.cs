using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartCtl.Db.Utility;
using SmartCtl.Domain;
using SmartCtl.Domain.Entity;
using SmartCtl.Domain.Model;
using SmartCtl.Domain.Utility;

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
        [HttpGet("drives/ingest")]
        public async Task<bool> IngestDriveData([FromQuery] string drives)
        {
            List<DriveInformation> _infos = await GetFromDrives(drives);
            await new DriveInformationUtility().AddUpdateMany(_infos);
            return true;
        }

        [HttpGet("zfs/ingest")]
        public async Task<bool> IngestZFSData()
        {
            var _infos = await new ZFSInfoUtility().GetZFSInfo();
            //await new DriveInformationUtility().AddUpdateMany(_infos);
            return true;
        }

        private static async Task<List<DriveInformation>> GetFromDrives( string drives)
        {
            string localDir = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;

            ConcurrentBag<SmartOutput> _so = new ConcurrentBag<SmartOutput>();
            if (drives.Contains(","))
            {
                IEnumerable<string> eachDrives =
                    drives.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim());
                IEnumerable<Func<Task>> _tasksToRun = eachDrives.Select(_eachDrive => new Func<Task>(async () =>
                {
                    StringBuilder _o = await ProcessAsyncHelperUtility.ExecuteShellCommand("/usr/bin/smartctl",
                        $" --info --all --json=c --nocheck standby {_eachDrive}", _eachDrive, workingDir: localDir);
                    //System.Console.WriteLine(_o.ToString());
                    _so.Add(JsonConvert.DeserializeObject<SmartOutput>(_o.ToString()));
                }));
                await _tasksToRun.PooledInvokeAsync(6);
            }
            else
            {
                StringBuilder _o = await ProcessAsyncHelperUtility.ExecuteShellCommand("/usr/bin/smartctl",
                    $" --info --all --json=c --nocheck standby {drives}", drives, workingDir: localDir);
                //System.Console.WriteLine(_o.ToString());
                _so.Add(JsonConvert.DeserializeObject<SmartOutput>(_o.ToString()));
            }

            List<DriveInformation> _objs = new List<DriveInformation>();
            foreach (IGrouping<string, SmartOutput> a1 in _so.GroupBy(a => a.serial_number))
            {
                try
                {
                    SmartOutput _smartObj = a1.First();
                    if (_smartObj.serial_number == null)
                    {
                        continue;
                    }
                    _objs.Add(_smartObj.Out());
                }
                catch (Exception e)
                {

                }
            }

            return _objs;
        }
     

    }
}
