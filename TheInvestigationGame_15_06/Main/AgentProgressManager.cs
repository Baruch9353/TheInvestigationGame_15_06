using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.IranianAgents;
using TheInvestigationGame_15_06.Sensors;

namespace TheInvestigationGame_15_06.Main
{
    internal class AgentProgressManager
    {
        public IranianAgent CurrentAgent { get; private set; }
        public AgentRankLevel HighestRankExposed { get; private set; } = AgentRankLevel.Foot_Soldier;
        public AgentRankLevel CurrentAgentRank => CurrentAgent.RankLevel;
        public AgentProgressManager(IranianAgent startAgent)
        {
            CurrentAgent = startAgent;
        }
        public bool IsAgentRevealed()
        {
            return CurrentAgent.sensorManager.IsRevealed();
        }
        public string ActivateSensor(Sensor sensor)
        {
            return CurrentAgent.sensorManager.ActivateSensor(sensor, CurrentAgent);
        }
        public void SwitchAgent(IranianAgent newAgent)
        {
            Console.WriteLine("\nYou moved on to play against the next agent.\n");
            CurrentAgent = newAgent;
        }
        public void UpdateHighestRank()
        {
            if (CurrentAgent.RankLevel > HighestRankExposed)
            {
                HighestRankExposed = CurrentAgent.RankLevel;
            }
        }
    }
}
