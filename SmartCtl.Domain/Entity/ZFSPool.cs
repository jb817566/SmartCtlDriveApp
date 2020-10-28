using System;
using System.Linq;
using SmartCtl.Domain.Enum;

namespace SmartCtl.Domain.Entity
{
    public class ZFSPool
    {
        public int ID { get; set; }
        /// <summary>
        /// Name of the pool/dataset
        /// </summary>
        public string PoolName { get; set; }
        /// <summary>
        /// Pool Raid level
        /// </summary>
        public RaidLevel RaidLevel { get; set; }
        /// <summary>
        /// Mount location
        /// </summary>
        public string MountPoint { get; set; }
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The number of drives in the pool
        /// </summary>
        public int MemberCount { get; set; }
        /// <summary>
        /// The capacity of the pool
        /// </summary>
        public double Capacity { get; set; }
        public double Available { get; set; }
        public CompressionType CompressionType { get; set; }

        public void FillProperty(string name, string value)
        {
            switch (name)
            {
                case "type":
                    break;
                case "creation":
                    this.DateCreated = DateTime.ParseExact(value, Constants.SMARTCTL_ARGS, System.Globalization.CultureInfo.InvariantCulture);
                    break;
                case "used":
                    break;
                case "available":
                    this.Available = value.CapacityToGB();
                    break;
                case "referenced":
                    break;
                case "compressratio":
                    break;
                case "mounted":
                    break;
                case "quota":
                    break;
                case "reservation":
                    break;
                case "recordsize":
                    break;
                case "mountpoint":
                    break;
                case "sharenfs":
                    break;
                case "checksum":
                    break;
                case "compression":
                    this.CompressionType =
                        Constants.CompressionTypes.FirstOrDefault(a => a.ToString().ToLower() == value);
                    break;
                case "atime":
                    break;
                case "devices":
                    break;
                case "exec":
                    break;
                case "setuid":
                    break;
                case "readonly":
                    break;
                case "zoned":
                    break;
                case "snapdir":
                    break;
                case "aclinherit":
                    break;
                case "createtxg":
                    break;
                case "canmount":
                    break;
                case "xattr":
                    break;
                case "copies":
                    break;
                case "version":
                    break;
                case "utf8only":
                    break;
                case "normalization":
                    break;
                case "casesensitivity":
                    break;
                case "vscan":
                    break;
                case "nbmand":
                    break;
                case "sharesmb":
                    break;
                case "refquota":
                    break;
                case "refreservation":
                    break;
                case "guid":
                    break;
                case "primarycache":
                    break;
                case "secondarycache":
                    break;
                case "usedbysnapshots":
                    break;
                case "usedbydataset":
                    this.Capacity = value.CapacityToGB();
                    break;
                case "usedbychildren":
                    break;
                case "usedbyrefreservation":
                    break;
                case "logbias":
                    break;
                case "dedup":
                    break;
                case "mlslabel":
                    break;
                case "sync":
                    break;
                case "dnodesize":
                    break;
                case "refcompressratio":
                    break;
                case "written":
                    break;
                case "logicalused":
                    break;
                case "logicalreferenced":
                    break;
                case "volmode":
                    break;
                case "filesystem_limit":
                    break;
                case "snapshot_limit":
                    break;
                case "filesystem_count":
                    break;
                case "snapshot_count":
                    break;
                case "snapdev":
                    break;
                case "acltype":
                    break;
                case "context":
                    break;
                case "fscontext":
                    break;
                case "defcontext":
                    break;
                case "rootcontext":
                    break;
                case "relatime":
                    break;
                case "redundant_metadata":
                    break;
                case "overlay":
                    break;
            }
        }

    }
}
