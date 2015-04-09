using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private void WriteLog(string msg)
        {
            string path = @"C:\Jasim Khan\test_project\log.txt";
            System.IO.File.AppendAllText(path, DateTime.Now.ToShortDateString() + " : " + msg + Environment.NewLine + "-------------------" + Environment.NewLine);
        }
        public void GetData(int value)
        {
            WriteLog(value.ToString());
            ServiceRef.Service2Client client = new ServiceRef.Service2Client();
            System.Threading.Thread.Sleep(2000);
            client.Status("10%");
            System.Threading.Thread.Sleep(2000);
            client.Status("20%");
            System.Threading.Thread.Sleep(2000);
            client.Status("30%");
            System.Threading.Thread.Sleep(2000);
            client.Status("40%");
            System.Threading.Thread.Sleep(2000);
            client.Status("60%");
            System.Threading.Thread.Sleep(2000);
            client.Status("80%");
            System.Threading.Thread.Sleep(2000);
            client.Status("90%");
            client.Status("100% done");
            client.Close();
        }       
    }
}
