using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ForEx.Models
{
    [DataContract]
    public class fxAsset
    {
        [DataMember]
        public string currencyCode;

        [DataMember]
        public decimal amount;

        [IgnoreDataMember]
        public decimal nativeAmount;
    }
}
