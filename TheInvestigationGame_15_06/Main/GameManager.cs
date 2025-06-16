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
            // פה יכנסו סוכנים
            currentAgent = new FootSoldier();
            while (!currentAgent.IsRevealed())
            {
                ShowAvailableSensors();
                HandleSensorChoice();
            }
            Console.WriteLine("The agent has been fully exposed!");
        }
        private void ShowAvailableSensors()
        {
            Console.WriteLine("Available Sensors:");
            for (int i = 0; i < IranianAgent.allSensors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {IranianAgent.allSensors[i].Name}");
            }
        }
        private void HandleSensorChoice()
        {
            Console.Write("Choose a sensor by number: ");
            string input = Console.ReadLine();

            int choice;
            if (ValidChoice(input, out choice))
            {
                Sensor selectedSensor = IranianAgent.allSensors[choice - 1];
                string result = currentAgent.ActivateSensor(selectedSensor);
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
            if (choice < 1 || choice > IranianAgent.allSensors.Count)
            {
                return false;
            }
            return true;
        }
    }
}

