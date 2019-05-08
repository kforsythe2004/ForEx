using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ForEx.Models
{
    [DataContract]
    public class Rates
    {
        [DataMember]
        public Rate[] rates;

    }

    [DataContract]
    public class Rate
    {
        [DataMember]
        public string name;

        [DataMember]
        public decimal value;
    }

    [DataContract]
    public class Exchange
    {
        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        [DataMember]
        public string disclaimer;

        [DataMember]
        public string license;

        [IgnoreDataMember]
        public DateTime timestamp;

        [DataMember(Name = "timestamp")]
        private int MyDateTimeTicks
        {
            get { return (int)(this.timestamp - unixEpoch).TotalSeconds; }
            set { this.timestamp = unixEpoch.AddSeconds(Convert.ToInt32(value)); }
        }

        [DataMember]
        public string @base;

        [DataMember]
        public Dictionary<string,decimal> rates;

    }


}
