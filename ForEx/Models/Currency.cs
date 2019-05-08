using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ForEx.Models
{
    [DataContract]
    public class Currency
    {

        [DataMember]
        public string isoCode;

        [DataMember]
        public string name;

        [DataMember]
        public string symbol;
    }


}
