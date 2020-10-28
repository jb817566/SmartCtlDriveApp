using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartCtl.Domain;
using SmartCtl.Domain.Entity;

namespace SmartCtl.Db.Utility
{
    public class DriveInformationUtility
    {
        public async Task<List<DriveInformation>> AddMany(IEnumerable<DriveInformation> _objs)
        {
            using (SmartCtlContext _ctx = new SmartCtlContext())
            {
                await _ctx.DriveInformation.AddRangeAsync(_objs);
                await _ctx.SaveChangesAsync();
            }

            return _objs.ToList();
        }
        public async Task<List<DriveInformation>> AddUpdateMany(IEnumerable<DriveInformation> _objs)
        {
            using (SmartCtlContext _ctx = new SmartCtlContext())
            {
                if (_objs.Any())
                    foreach (DriveInformation driveInformation in _objs)
                    {
                        DriveInformation _dr =
                            await _ctx.DriveInformation.FirstOrDefaultAsync(a =>
                                a.SerialNumber == driveInformation.SerialNumber);
                        if (_dr != default)
                        {
                            _dr.PowerOnHours = driveInformation.PowerOnHours;
                            _dr.Temperature = driveInformation.Temperature;
                            _dr.PowerCycleCount = driveInformation.PowerCycleCount;
                            _dr.SmartOK = driveInformation.SmartOK;

                            _ctx.DriveInformation.Update(_dr);
                        }
                        else
                        {
                            await _ctx.DriveInformation.AddAsync(driveInformation);
                        }
                    }
                await _ctx.SaveChangesAsync();
            }

            return _objs.ToList();
        }


        public async Task<List<DriveInformation>> ListAllAsync()
        {
            using (SmartCtlContext _ctx = new SmartCtlContext())
            {
                return await _ctx.DriveInformation.ToListAsync();
            }
        }
    }
}
