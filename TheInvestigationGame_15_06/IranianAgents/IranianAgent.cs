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
        protected IranianAgent(int numOfSensors)
        {
            AssignRandomSensors(numOfSensors);
        }

        protected static List<Sensor> allSensors = new List<Sensor>
        {
        new AudioSensor(),
        new ThermalSensor()
        };

        protected List<Sensor> selecteSensors = new List<Sensor>();

        private void AssignRandomSensors(int numOfSensors)
        {
            Random rand = new Random();

            for (int i = 0; i < numOfSensors; i++)
            {
                int index = rand.Next(allSensors.Count);
                selecteSensors.Add(allSensors[index]);
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
