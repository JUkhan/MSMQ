using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [DataContract]
    public class MessageHeader
    {
        [DataMember]
        public string CorrelationId { get; set; }

        [DataMember]
        public string ResponseQueue { get; set; }

        public MessageHeader(string id, string respq)
        {
            CorrelationId = id;
            ResponseQueue = respq;
        }
    }
}
