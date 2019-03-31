using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CIP_1.DataModel
{
    [DataContract]
    public class ProductRelations
    {
        [DataMember]
        public List<AddOnProduct> addOnProducts { get; set; }
    }
}
