using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.Sensors
{
    internal class FootSoldier : IranianAgent 
    {
        public override string AgentRank => "junior";
        public FootSoldier() : base(2)
        {
        }
    }
}
