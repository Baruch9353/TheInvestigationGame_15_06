using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestigationGame_15_06
{
    internal abstract class Sensor
    {
        public abstract string Name { get; }
        public abstract bool Activate();
    }

}
