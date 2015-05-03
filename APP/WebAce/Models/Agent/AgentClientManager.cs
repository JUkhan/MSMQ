using Agent.Servive;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WebAce.Models.Agent
{
    public class AgentClientManager
    {
        private static Dictionary<int, Stack<int>> PRIORITIES = new Dictionary<int, Stack<int>>();
        private static Dictionary<int, string> ADDRESS = new Dictionary<int, string>();
        public static int COUNT = 0;
        private static int ACTIVE_AGENT_ID = 0;
        public static void RegisterAgent()
        {
            COUNT = Convert.ToInt32(ConfigurationManager.AppSettings["AVAILABLE_AGENTES"]);
            for (int i = 1; i <= COUNT; i++)
            {
                if (ADDRESS.ContainsKey(i))
                {
                    if (ADDRESS[i] != ConfigurationManager.AppSettings["AGENT_" + i])
                    {
                        ADDRESS[i]= ConfigurationManager.AppSettings["AGENT_" + i];
                        PRIORITIES[i].Clear();
                    }
                }
                if (!ADDRESS.ContainsKey(i))
                {
                    ADDRESS.Add(i, ConfigurationManager.AppSettings["AGENT_" + i]);
                    PRIORITIES.Add(i, new Stack<int>());
                }
            }

        }
        public static void UpdateAgentPriority(int agentId)
        {
            if (PRIORITIES.ContainsKey(agentId))
                PRIORITIES[agentId].Pop();
        }
        public static void Execute(State state)
        {
            AgentClient agent = new AgentClient(GetAddress());
            PRIORITIES[ACTIVE_AGENT_ID].Push(ACTIVE_AGENT_ID);
            agent.TestMethod(new ExecuteInfo { AgentId = ACTIVE_AGENT_ID, ProdId = state.StateInfo, StateId = state.StateId, Message = state.StateName, StateName = state.StateName });
            agent.Close();
        }

        private static string GetAddress()
        {
            int min = int.MaxValue;
            string address = "";
            for (int i = 1; i <= COUNT; i++)
            {
                int val = PRIORITIES[i].Count;
                if (val < min)
                {
                    ACTIVE_AGENT_ID = i;
                    address = ADDRESS[i];
                    min = val;
                }
            }
            return address;
        }
    }
}