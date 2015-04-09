using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;
using WebAce.Models;

namespace MyClientService
{
    public class Service2:HubHelper<MyHub>, IService2
    {
        private void WriteLog(string msg)
        {
            string path = @"C:\Jasim Khan\test_project\log.txt";
            System.IO.File.AppendAllText(path, DateTime.Now.ToShortDateString() + " : " + msg + Environment.NewLine + "-------------------" + Environment.NewLine);
        }
        public void Status(string value)
        {
           
            //WriteLog(value+"->");
            HUB.Clients.All.sendStatus(value);
        }
    }
    [ServiceContract]
    public interface IService2
    {

        [OperationContract(IsOneWay = true)]
        void Status(string value);

        // TODO: Add your service operations here
    }
}