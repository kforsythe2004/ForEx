using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ForEx.Models
{
    [DataContract]
    public class portfolio
    {
        [DataMember]
        public string name;

        [DataMember]
        public string countryCode;

        [DataMember]
        public fxAsset[] fxAssets;
    }

    [DataContract]
    public class portfolioRoot
    {
        [DataMember]
        public portfolio[] portfolios;
    }
}
