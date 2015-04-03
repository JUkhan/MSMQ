using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [ServiceContract]
    public interface IClient
    {
        [OperationContract(IsOneWay = true)]
        void Reply(int answer);
        [OperationContract(IsOneWay = true)]
        void StatusMesage(string message);
    }
}
