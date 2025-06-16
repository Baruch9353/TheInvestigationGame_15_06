using System;
using System.Collections.Generic;
using System.Linq;
using TheInvestigationGame_15_06.Sensors;

namespace TheInvestigationGame_15_06.IranianAgents
{
    internal abstract class IranianAgent
    {
        public abstract string AgentRank { get; }
        public SensorManager sensorManager { get; }

        //A constructor that takes an argument of several sensors
        protected IranianAgent(int numOfSensors)
        {
            sensorManager = new SensorManager(numOfSensors);
        }
    }
}
