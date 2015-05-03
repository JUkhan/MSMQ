using Agent.Servive;
using Status.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;
using WebAce.Models;
using WebAce.Models.Agent;

namespace Prod
{
    public class StatusService : HubHelper<MyHub>, IStatus
    {
        private void WriteLog(string msg)
        {
            string path = @"C:\Jasim Khan\test_project\log.txt";
            System.IO.File.AppendAllText(path, DateTime.Now.ToShortDateString() + " : " + msg + Environment.NewLine + "-------------------" + Environment.NewLine);
        }
        public void Status(ExecuteInfo info)
        {
            if (info.Message == "Done")
            {
                StateManager.Next(info);
               
            }
           
            HUB.Clients.All.sendStatus(info.Message+" - "+info.StateName);
        }
    }
    
}