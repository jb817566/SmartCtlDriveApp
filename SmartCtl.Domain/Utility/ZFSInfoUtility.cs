using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartCtl.Domain.Entity;
using SmartCtl.Domain.Model;

namespace SmartCtl.Domain.Utility
{
    public class ZFSInfoUtility
    {
        public async Task<Dictionary<ZFSPool, List<ZFSPoolInfo>>> GetZFSInfo()
        {
            Dictionary<ZFSPool, List<ZFSPoolInfo>> _infoMap = new Dictionary<ZFSPool, List<ZFSPoolInfo>>();
            string localDir = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;

            //string _result = (await ProcessAsyncHelperUtility.ExecuteShellCommand(Constants.ZFS_COMMAND,
            //    Constants.ZFS_ARGS, "ZFS_INFO", workingDir: localDir)).ToString();
            string _result = File.ReadAllText(@"C:\Users\Public\zfsinfo.txt");
            List<string> _zfsLines = _result.Split(new char[] { '\n', '\r' }).ToList();
            ZFSPool _poolInfo = new ZFSPool();
            for (int i = 0; i < _zfsLines.Count; i++)
            {
                string zfsLine = _zfsLines[i];
                if (!string.IsNullOrWhiteSpace(zfsLine))
                {
                    try
                    {
                        string[] _spl = zfsLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        string _value = _spl[2];
                        string _poolName = _spl[0];
                        if ((_poolInfo = _infoMap.FirstOrDefault(a => a.Key.PoolName == _poolName).Key) == null)
                        {
                            _poolInfo = new ZFSPool()
                            {
                                PoolName = _poolName,
                                DateCreated = DateTime.UtcNow
                            };
                            _infoMap.Add(_poolInfo, new List<ZFSPoolInfo>());
                        }
                        _poolInfo.FillProperty(_spl[1], _value);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            return _infoMap;
        }

    }
}
