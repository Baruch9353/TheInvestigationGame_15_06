using System;
using System.Collections.Generic;
using TheInvestigationGame_15_06.IranianAgents;
using TheInvestigationGame_15_06.Sensors;

namespace TheInvestigationGame_15_06
{
    internal class GameManager
    {
        private IranianAgent currentAgent;

        public void StartGame()
        {
            Console.WriteLine("Welcome to The Investigation Game!");
            Console.WriteLine("Starting investigation...\n");

            // Create agent
            currentAgent = new FootSoldier();

            // Loop until all weaknesses are revealed
            while (!currentAgent.sensorManager.IsRevealed())
            {
                ShowAvailableSensors();
                HandleSensorChoice();
            }

            Console.WriteLine("The agent has been fully exposed!");
        }

        private void ShowAvailableSensors()
        {
            Console.WriteLine("Available Sensors:");
            for (int i = 0; i < SensorManager.allSensors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SensorManager.allSensors[i].Name}");
            }
        }

        private void HandleSensorChoice()
        {
            Console.Write("Choose a sensor by number: ");
            string input = Console.ReadLine();

            int choice;
            if (ValidChoice(input, out choice))
            {
                Sensor selectedSensor = SensorManager.allSensors[choice - 1];
                string result = currentAgent.sensorManager.ActivateSensor(selectedSensor, currentAgent);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Unvalid choice. Please try again.");
            }
        }

        private bool ValidChoice(string input, out int choice)
        {
            bool isNumber = int.TryParse(input, out choice);
            if (!isNumber)
            {
                return false;
            }
            if (choice < 1 || choice > SensorManager.allSensors.Count)
            {
                return false;
            }
            return true;
        }

    }
}

