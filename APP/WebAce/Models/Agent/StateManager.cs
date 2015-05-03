using Agent.Servive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAce.Models.Agent
{
    public class StateManager
    {
        private static Dictionary<int, Queue<State>> PRODS = new Dictionary<int, Queue<State>>();
        public static void SetStates(int prodId, Queue<State> states)
        {
            if (!PRODS.ContainsKey(prodId))
            {
                PRODS.Add(prodId, states);
            }
        }
        public static void SetStates(int prodId)
        {
            if (!PRODS.ContainsKey(prodId))
            {
                Queue<State> states = new Queue<State>();

                states.Enqueue(new State() { StateInfo = prodId, StateName = "one" });
                State state = new State { StateInfo = prodId, StateName = "two" };
                state.PreStates = new List<State>
               {
                   new State{ StateInfo=prodId, StateName="pre-one"},
                    new State{ StateInfo=prodId, StateName="pre-two", 
                        PreStates=new List<State>{
                            new State{ StateInfo=prodId, StateName="pre-two-pre-one"},
                            new State{ StateInfo=prodId, StateName="pre-two-pre-two"},
                            new State{ StateInfo=prodId, StateName="pre-two-pre-three"},
                            new State{ StateInfo=prodId, StateName="pre-two-pre-four"},
                            new State{ StateInfo=prodId, StateName="pre-two-pre-five",
                               PreStates=new List<State>{
                                    new State{ StateInfo=prodId, StateName="pre-two-pre-five-pre-one"},
                                }
                            },
                        }
                    },
                     new State{ StateInfo=prodId, StateName="pre-three"},
                      new State{ StateInfo=prodId, StateName="pre-four"}
               };
                states.Enqueue(state);
                states.Enqueue(new State() { StateInfo = prodId, StateName = "three" });
                PRODS.Add(prodId, states);
            }
        }
        public static void Run(int prodId)
        {
            Next(prodId);

        }
        private static void RunState(State state)
        {
            if (state != null)
            {
                AgentClientManager.Execute(state);
                state.Status = StateStatus.RUNNING;
            }
        }
        public static void SetStatusDone(int prodId, string stateId)
        {
            if (PRODS.ContainsKey(prodId))
            {
                State state = null;
                foreach (var item in PRODS[prodId])
                {
                    if (item.StateId == stateId)
                    {
                        state = item;
                        break;
                    }
                    if (item.PreStates != null && item.PreStates.Count > 0)
                    {
                        state = FindState(stateId, item.PreStates);
                        if (state != null) break;
                    }
                }
                if (state != null)
                {
                    state.Status = StateStatus.DONE;
                }
            }
        }
        private static State FindState(string stateId, List<State> preList)
        {
            State state = null;
            foreach (var item in preList)
            {
                if (item.StateId == stateId)
                {
                    state = item;
                    break;
                }
                if (item.PreStates != null && item.PreStates.Count > 0)
                {
                    state = FindState(stateId, item.PreStates);
                    if (state != null) break;
                }
            }
            return state;
        }
        public static void Next(ExecuteInfo info)
        {
            AgentClientManager.UpdateAgentPriority(info.AgentId);
            SetStatusDone(info.ProdId, info.StateId);
            Next(info.ProdId);
        }
        private static void Next(int prodId)
        {

            if (PRODS.ContainsKey(prodId))
            {
                State state = PRODS[prodId].Peek();
                ProcessState(prodId, state);
                if (PRODS.ContainsKey(prodId) && PRODS[prodId].Count == 0)
                {
                    PRODS.Remove(prodId);
                }

            }

        }

        private static void ProcessState(int prodId, State state)
        {

            if (state.PreStates != null && state.PreStates.Count > 0)
            {
                int count = 1;
                bool allPreStateDone = true;
                foreach (var preState in state.PreStates)
                {
                    allPreStateDone &= preState.Status == StateStatus.DONE;
                    if (preState.Status == StateStatus.STOP && count <= AgentClientManager.COUNT)
                    {
                        ProcessPreState(prodId, preState);
                        count++;
                    }
                }
                if (count == 1 && allPreStateDone)
                {
                    RunState(PRODS[prodId].Dequeue());
                }
            }
            else
            {
                RunState(PRODS[prodId].Dequeue());
            }
        }
        private static void ProcessPreState(int prodId, State state)
        {

            if (state.PreStates != null && state.PreStates.Count > 0)
            {
                int count = 1;
                bool allPreStateDone = true;
                foreach (var preState in state.PreStates)
                {
                    allPreStateDone &= preState.Status == StateStatus.DONE;
                    if (preState.Status == StateStatus.STOP && count <= AgentClientManager.COUNT)
                    {
                        ProcessPreState(prodId, preState);
                        count++;
                    }
                }
                if (count == 1 && allPreStateDone)
                {
                    RunState(state);
                }
            }
            else
            {
                RunState(state);
            }
        }
    }
    public class State
    {
        public State()
        {
            Status = StateStatus.STOP;
            StateId = Guid.NewGuid().ToString();
        }
        public string StateName { get; set; }
        public string StateId { get; set; }
        public StateStatus Status { get; set; }
        public List<State> PreStates { get; set; }
        public dynamic StateInfo { get; set; }
    }
    public enum StateStatus
    {
        RUNNING, DONE, STOP
    }
}