using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.Sensors;

namespace TheInvestigationGame_15_06.IranianAgents
{
    internal class SquadLeader : IranianAgent
    {
        private static Random rand = new Random();
        public override AgentRankLevel RankLevel => AgentRankLevel.Squad_Leader;
        public SquadLeader() : base(4) { }
        // Checks each turn. If it's turn 3, triggers an attack
        public string HandleTurn(int turnNumber)
        {
            if (turnNumber % 3 == 0)
            {
                bool removed = RemoveOneOfAttachedSensor();
                if (removed)
                    return "\nattack! The Squad Leader removed one of your attached sensors!!!\n";
                else
                    return "\nattack! But the Squad Leader had no sensors to remove...\n";
            }
            return "\n";
        }
        // Remove a random attached sensor from the Attached Sensor list
        private bool RemoveOneOfAttachedSensor()
        {
            List<Sensor> attached = sensorManager.attachedSensors;
            if (attached.Count == 0)
            {
                return false;
            }
            int index = rand.Next(attached.Count);
            attached.RemoveAt(index);
            return true;
        }
    }
}
