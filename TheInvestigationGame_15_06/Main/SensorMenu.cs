using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.Sensors;

namespace TheInvestigationGame_15_06.Main
{
    internal class SensorMenu
    {
        public void ShowAvailableSensors()
        {
            Console.WriteLine("\nPossible sensors to choose from:\n");
            for (int i = 0; i < SensorManager.allSensors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SensorManager.allSensors[i].Name}");
            }
        }
        public bool GetSensorChoice(out int choice)
        {
            Console.Write("\nChoose a sensor by number: \n");
            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out choice);
            if (!isValid) return false;
            if (choice < 1 || choice > SensorManager.allSensors.Count)
            { 
               return false;
            }
            return true;
        }
    }
}
