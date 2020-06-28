using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartCtl.Domain;

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

        public async Task<List<DriveInformation>> ListAllAsync()
        {
            using (SmartCtlContext _ctx = new SmartCtlContext())
            {
                return await _ctx.DriveInformation.ToListAsync();
            }
        }
    }
}
