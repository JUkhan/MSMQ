using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;

namespace Agent.Servive
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAgent
    {

        [OperationContract(IsOneWay = true)]
        void TestMethod(ExecuteInfo info);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class ExecuteInfo
    {
        [DataMember]
        public int AgentId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int ProdId { get; set; }
        [DataMember]
        public string StateId { get; set; }
        [DataMember]
        public string StateName { get; set; }
    }
}
