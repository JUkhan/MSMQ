using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

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
            //new Task(() => { processing(); }).Start();           
            processing();
        }
        private void processing()
        {
            ServiceRef.Service2Client client = new ServiceRef.Service2Client();            
           
            for (int i = 0; i < 99000000; i++)
            {
                if (i % 10000000 == 0)
                {
                    System.Threading.Thread.Sleep(10);
                     client.Status(i.ToString());
                    

                }

            }
            client.Status("100% done");
            client.Close();
        }
    }
}
