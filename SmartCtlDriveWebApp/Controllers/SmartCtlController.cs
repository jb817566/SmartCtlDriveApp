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
        [HttpGet("ingest")]
        public async Task<bool> IngestData([FromQuery] string drives)
        {
            await GetFromDrives(drives);
            return true;
        }

        private static async Task GetFromDrives( string drives)
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
                await PooledInvokeAsync(_tasksToRun, 6);
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
            await new DriveInformationUtility().AddMany(_objs);
        }
        public static async Task PooledInvokeAsync(IEnumerable<Func<Task>> taskFactories, int maxDegreeOfParallelism)
        {
            if (taskFactories == null) throw new ArgumentNullException(nameof(taskFactories));
            if (maxDegreeOfParallelism <= 0) throw new ArgumentException(nameof(maxDegreeOfParallelism));

            Func<Task>[] queue = taskFactories.ToArray();

            if (queue.Length == 0)
            {
                return;
            }

            List<Task> tasksInFlight = new List<Task>(maxDegreeOfParallelism);
            int index = 0;

            do
            {
                while (tasksInFlight.Count < maxDegreeOfParallelism && index < queue.Length)
                {
                    Func<Task> taskFactory = queue[index++];

                    tasksInFlight.Add(Task.Run(() => taskFactory()));
                }

                Task completedTask = await Task.WhenAny(tasksInFlight).ConfigureAwait(false);
                await completedTask.ConfigureAwait(false);
                tasksInFlight.Remove(completedTask);
            }
            while (index < queue.Length || tasksInFlight.Count != 0);
        }

    }
}
