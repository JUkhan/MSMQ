using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi
{
    public class Client:IClient
    {
        public void Reply(int answer)
        {
            Console.WriteLine(answer);
        }

        public void StatusMesage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
