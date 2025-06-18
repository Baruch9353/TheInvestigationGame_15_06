using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.Sensors;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.Sensors
{
    internal abstract class Sensor
    {
        public abstract string Name { get; }
        public virtual bool IsUsable => true;

        public abstract string Activate(IranianAgent agent);
    }
}
