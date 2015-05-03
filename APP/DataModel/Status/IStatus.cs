using Agent.Servive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Status.Service
{
    [ServiceContract]
    public interface IStatus
    {

        [OperationContract(IsOneWay = true)]
        void Status(ExecuteInfo info);

        // TODO: Add your service operations here
    }
}
