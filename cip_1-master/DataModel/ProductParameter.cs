using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

// ReSharper disable InconsistentNaming
namespace CIP_1.DataModel
{
    [DataContract]
    public class ProductParameter
    {
        [DataMember]
        public string paramCode { get; set; }

        [DataMember]
        public string paramValue { get; set; }
    }
}
