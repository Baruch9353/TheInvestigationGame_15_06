using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.Sensors;

namespace TheInvestigationGame_15_06.IranianAgents
{

    internal abstract class IranianAgent
    {
        Random rand = new Random();

        public abstract string AgentRank { get; }
        protected IranianAgent(int numOfSensors)
        {
            AssignRandomSensors(numOfSensors);
        }

        internal static List<Sensor> allSensors = new List<Sensor>
        {
        new AudioSensor(),
        new ThermalSensor()
        };

        internal List<Sensor> selecteSensors = new List<Sensor>();

        private void AssignRandomSensors(int numOfSensors)
        {
            

            for (int i = 0; i < numOfSensors; i++)
            {
                int index = rand.Next(allSensors.Count);
                selecteSensors.Add(allSensors[index]);
                allSensors[index].Activate();
            }
        }

        



        // test
        //public void PrintMySensors()
        //{
        //    Console.WriteLine("This agent has:");
        //    foreach (var sensor in selectedSensors)
        //    {
        //        Console.WriteLine(sensor.Name + ". ");
        //    }
        //}
    }

}
