using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.Sensors
{
    internal class SensorManager
    {
        public static Random rand = new Random();
        internal static List<Sensor> allSensors = new List<Sensor>
    {
        new AudioSensor(),
        new ThermalSensor(),
        new PulseSensor()   
    };
        internal List<Sensor> secretSensors = new List<Sensor>(); // a List of real weaknesses (that the player needs to discover)
        internal List<Sensor> attachedSensors = new List<Sensor>(); // a List of Sensors that the player has already discovered
        public SensorManager(int numOfSensors)
        {
            AssignRandomSensors(numOfSensors);
        }
        //Assign Random Sensors to the secret Sensors list
        private void AssignRandomSensors(int numOfSensors)
        {
            for (int i = 0; i < numOfSensors; i++)
            {
                int index = rand.Next(allSensors.Count);
                secretSensors.Add(allSensors[index]);
            }
        }
        //Activates a sensor, reveals new weaknesses if possible, and returns the result.
        public string ActivateSensor(Sensor sensor, IranianAgent agent)
        {
            if (!sensor.IsUsable)
            { 
                return "\nThis sensor is no longer usable.\n";
            }

            string activation = sensor.Activate(agent);

            if (IsInSecretSensors(sensor) && IfCanReveal(sensor))
            {
                attachedSensors.Add(sensor);
                return activation + "\nA new weakness has been revealed! " + GetRevealStatus();
            }
            else
            {
                return activation + "\nThe sensor did not discover any new weaknesses." + GetRevealStatus();
            }
        }

        //checks if there are still undiscovered weaknesses of the sensor’s type that can be revealed.
        public bool IfCanReveal(Sensor sensor)
        {
            int inSecret = secretSensors.Count(s => s.Name == sensor.Name);
            int revealed = attachedSensors.Count(s => s.Name == sensor.Name);
            return revealed < inSecret;
        }
        private string GetRevealStatus()
        {
            return $"\nYou chose: {attachedSensors.Count} correct choices / of {secretSensors.Count} sensors\n";
        }
        public bool IsInSecretSensors(Sensor sensor)
        {
            return secretSensors.Any(s => s.Name == sensor.Name);
        }
        //Checks if all secret sensors have been revealed in attached sensors.
        public bool IsRevealed()
        {
            List<Sensor> tempAttached = new List<Sensor>(attachedSensors);
            foreach (Sensor secretSensor in secretSensors)
            {
                bool foundMatch = false;
                for (int i = 0; i < tempAttached.Count; i++)
                {
                    if (tempAttached[i].Name == secretSensor.Name)
                    {
                        tempAttached.RemoveAt(i);
                        foundMatch = true;
                        break;
                    }
                }
                if (!foundMatch) return false;
            }
            return true;
        }
    }
}
