using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SmartCtl.Db;
using SmartCtl.Db.Utility;
using SmartCtl.Domain;
using SmartCtl.Domain.Model;

namespace SmartTest
{
    [TestClass]
    public class SmartUnitTest
    {
        [TestMethod]
        public async Task IngestData()
        {
            string _json = await File.ReadAllTextAsync("C:\\Users\\Public\\driveinfo.json");
            List<SmartOutput> _list = JsonConvert.DeserializeObject<List<SmartOutput>>(_json);
            List<DriveInformation> _objs = new List<DriveInformation>();
            foreach (IGrouping<string, SmartOutput> a1 in _list.GroupBy(a => a.serial_number))
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
            string _dedupe = JsonConvert.SerializeObject(_objs);
            await File.WriteAllTextAsync("C:\\Users\\Public\\driveinfo_entity.json", _dedupe);
        }

        [TestMethod]
        public async Task AddTest()
        {
            string _json = await File.ReadAllTextAsync("C:\\Users\\Public\\driveinfo.json");
            List<SmartOutput> _list = JsonConvert.DeserializeObject<List<SmartOutput>>(_json);
            List<DriveInformation> _objs = new List<DriveInformation>();
            foreach (IGrouping<string, SmartOutput> a1 in _list.GroupBy(a => a.serial_number))
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

        [TestMethod]
        public async Task TestMethod1()
        {
            string _json = await File.ReadAllTextAsync("C:\\Users\\Public\\driveinfo.json");
            List<SmartOutput> _list = JsonConvert.DeserializeObject<List<SmartOutput>>(_json);

            Dictionary<string, SmartOutput> dictionary = new Dictionary<string, SmartOutput>();
            foreach (IGrouping<string, SmartOutput> a1 in _list.GroupBy(a => a.serial_number))
            {
                try
                {
                    SmartOutput output = a1.First();
                    if (output.serial_number == null)
                    {
                        continue;

                    }
                    dictionary.Add(output.serial_number, output);
                }
                catch (Exception e)
                {

                }
            }

            string _dedupe = JsonConvert.SerializeObject(dictionary);
            await File.WriteAllTextAsync("C:\\Users\\Public\\driveinfo_dict.json", _dedupe);
        }
    }
}
