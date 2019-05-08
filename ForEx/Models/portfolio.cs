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
        public string country;

        [DataMember]
        public fxAsset[] fxAssets;

        [DataMember]
        public decimal value;

        [DataMember]
        public decimal intrinsicValue;

        [DataMember]
        public string nativeSymbol;

        [DataMember]
        public string formattedValue
        {
            get { return string.Format("{0}{1:n}", nativeSymbol, Math.Round(value, 2)); }
        }

        [DataMember]
        public string formattedIntrinsicValue
        {
            get { return string.Format("{0:C}",  Math.Round(intrinsicValue, 2)); }
        }
    }

    [DataContract]
    public class portfolioRoot
    {
        [DataMember]
        public portfolio[] portfolios;
    }
}
