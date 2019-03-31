using System;
using System.Runtime.Serialization;

namespace CIP_1.DataModel
{
    [Serializable]
    [DataContract]
    public class AdditionalValue
    {
        [DataMember(EmitDefaultValue = false)]
        public long id { get; set; }

        [DataMember]
        public string key { get; set; }

        [DataMember]
        public string value { get; set; }
    }
}
