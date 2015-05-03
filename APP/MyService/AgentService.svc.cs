using Agent.Servive;
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
    public class AgentService : IAgent
    {
        private void WriteLog(string msg)
        {
            string path = @"C:\log.txt";
            System.IO.File.AppendAllText(path, DateTime.Now.ToShortDateString() + " : " + msg + Environment.NewLine + "-------------------" + Environment.NewLine);
        }
        public void TestMethod(ExecuteInfo executeInfo)
        {
            //new Task(() => { processing(); }).Start();           
            processing(executeInfo);
        }
        private void processing(ExecuteInfo info)
        {
            StatusClient client = new StatusClient();
            info.Message = string.Format("start with agent={0} state={1}", info.AgentId, info.Message);
            client.Status(info);
           
            for (int i = 0; i < 99000000; i++)
            {
                if (i % 10000000 == 0)
                {
                    System.Threading.Thread.Sleep(100);
                    //info.Message = i.ToString() ;
                    //client.Status(info);


                }

            }
            //info.Message = string.Format("end with agent={0} state={1}", info.AgentId, info.Message);
            //client.Status(info);

            info.Message = "Done";
            client.Status(info);
           
            client.Close();
        }
    }

   
}
