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
        internal static List<Sensor> allSensors = new List<Sensor>
    {
        new AudioSensor(),
        new ThermalSensor()
    };
        internal List<Sensor> secretSensors = new List<Sensor>(); // a List of real weaknesses (that the player needs to discover)
        internal List<Sensor> revealedSensors = new List<Sensor>(); // a List of Sensors that the player has already discovered
        public SensorManager(int numOfSensors)
        {
            AssignRandomSensors(numOfSensors);
        }
        //Assign Random Sensors to the secret Sensors list
        private void AssignRandomSensors(int numOfSensors)
        {
            Random rand = new Random();
            for (int i = 0; i < numOfSensors; i++)
            {
                int index = rand.Next(allSensors.Count);
                secretSensors.Add(allSensors[index]);
            }
        }
        // Triggers a specific sensor, and returns the result as a string
        public string ActivateSensor(Sensor sensor, IranianAgent agent)
        {
            string activationResult = sensor.Activate(agent);
            if (IsInSecretSensors(sensor) && IfCanReveal(sensor))
            {
                RevealSensor(sensor);
                return activationResult + "\nA new weakness has been revealed! " + GetRevealStatus();
            }
            else
            {
                return "The sensor did not discover any new weaknesses." + GetRevealStatus();
            }
        }
        //Checks the quantity of a specific sensor in the lists, Checking if possible to Reveal.
        public bool IfCanReveal(Sensor sensor)
        {
            //(s =>) foreach-קיצור ל
            int inSecret = secretSensors.Count(s => s.Name == sensor.Name);
            int revealed = revealedSensors.Count(s => s.Name == sensor.Name);
            return revealed < inSecret;
        }
        private string GetRevealStatus()
        {
            return $"{revealedSensors.Count}/{secretSensors.Count}";
        }
        public bool IsInSecretSensors(Sensor sensor)
        {
            foreach (Sensor secretSensor in secretSensors)
            {
                if (secretSensor.Name == sensor.Name)
                {
                    return true;
                }
            }
            return false;
        }
        // Checks if a particular sensor has been exposed before
        public bool IsSensorRevealed(Sensor sensor)
        {
            return revealedSensors.Any(s => s.Name == sensor.Name);
        }
        // Adds a sensor to the revealed Sensors list
        public void RevealSensor(Sensor sensor)
        {
            revealedSensors.Add(sensor);
        }
        // Returns true if all secret sensors have been revealed, 
        // + taking into account how many times each sensor appears.
        public bool IsRevealed()
        {
            var groupedSecret = secretSensors.GroupBy(s => s.Name); // Group secret sensors by name
            foreach (var group in groupedSecret)
            {
                string sensorName = group.Key; // Get the sensor name (group key)
                int requiredCount = group.Count(); // How many times it appears in secretSensors
                int revealedCount = revealedSensors.Count(s => s.Name == sensorName); // How many times it was revealed
                if (revealedCount < requiredCount) // If not all instances revealed
                    return false;
            }
            return true; // All sensors revealed with correct count
        }
    }
}
