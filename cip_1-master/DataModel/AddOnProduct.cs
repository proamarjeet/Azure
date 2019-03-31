using System.Collections.Generic;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming
namespace CIP_1.DataModel
{
    [DataContract]
    public class AddOnProduct
    {
        [DataMember]
        public Product addOnProduct { get; set; }
    }
}
