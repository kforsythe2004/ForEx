using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ForEx.Models
{
    [DataContract]
    public class Country
    {

        [DataMember]
        public string code;

        [DataMember]
        public string name;

        [DataMember]
        public string currencyCode;
    }


}
