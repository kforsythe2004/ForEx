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

        [DataMember]
        public decimal nativeAmount;

        [DataMember]
        public string symbol;

        [DataMember]
        public string nativeSymbol;

        [DataMember]
        public string formattedAmount
        {
            get { return string.Format("{0}{1:n}", symbol, Math.Round(amount, 2)); }
        }

        [DataMember]
        public string formattedNativeAmount
        {
            get { return string.Format("{0}{1:n}", nativeSymbol, Math.Round(nativeAmount, 2)); }
        }
    }
}
