using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.IranianAgents

{
    internal class FootSoldier : IranianAgent
    {
        public override AgentRankLevel RankLevel => AgentRankLevel.Foot_Soldier;
        public FootSoldier() : base(2) { }
    }
}
