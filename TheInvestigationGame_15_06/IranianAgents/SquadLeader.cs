using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestigationGame_15_06.IranianAgents
{
    internal class SquadLeader : IranianAgent
    {
        private Random rand = new Random();
        public override AgentRankLevel RankLevel => AgentRankLevel.SquadLeader;
        public SquadLeader() : base(4) { }
        // Called each turn to check for counterattack
        public string HandleTurn(int turnNumber)
        {
            if (turnNumber % 3 == 0)
            {
                bool removed = RemoveRandomAttachedSensor();
                if (removed)
                    return "\nattack! The Squad Leader removed one of your attached sensors!!!\n";
                else
                    return "\nattack! But the Squad Leader had no sensors to remove...\n";
            }
            return "\n";
        }
        // Remove a random attached sensor from the sensor manager
        private bool RemoveRandomAttachedSensor()
        {
            var attached = sensorManager.attachedSensors;
            if (attached.Count == 0)
            {
                return false;
            }
            int indexToRemove = rand.Next(attached.Count);
            attached.RemoveAt(indexToRemove);
            return true;
        }
    }
}
