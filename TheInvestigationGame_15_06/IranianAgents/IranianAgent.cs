using System;
using System.Collections.Generic;
using System.Linq;
using TheInvestigationGame_15_06.Sensors;

namespace TheInvestigationGame_15_06.IranianAgents
{
    internal abstract class IranianAgent
    {
        public abstract string AgentRank { get; }
        // a List of all existing sensors
        internal static List<Sensor> allSensors = new List<Sensor>
        {
            new AudioSensor(),
            new ThermalSensor()
        };
        // a List of real weaknesses (that the player needs to discover)
        internal List<Sensor> secretSensors = new List<Sensor>();

        // a List of Sensors that the player has already discovered
        internal List<Sensor> revealedSensors = new List<Sensor>();

        //A constructor that takes an argument of several sensors
        protected IranianAgent(int numOfSensors)
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
        public string ActivateSensor(Sensor sensor)
        {
            string activationResult = sensor.Activate(this);

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
        // Have all the weaknesses been exposed?
        public bool IsRevealed()
        {
            return secretSensors.All(s => revealedSensors.Any(r => r.Name == s.Name)) &&
                   revealedSensors.All(r => secretSensors.Any(s => s.Name == r.Name));
        }
    }
}
