using System;
using System.Collections.Generic;
using TheInvestigationGame_15_06.IranianAgents;
using TheInvestigationGame_15_06.Main;
using TheInvestigationGame_15_06.Sensors;

namespace TheInvestigationGame_15_06
{
    internal class GameManager
    {
        private AgentProgressManager progressManager;
        private SensorMenu sensorMenu;
        public void StartGame()
        {
            GameIntro.Show();
            // Start with Foot Soldier agent
            progressManager = new AgentProgressManager(new FootSoldier());
            sensorMenu = new SensorMenu();
            PlayAgentInvestigation();
            // Move on to Squad Leader only if Foot Soldier exposed
            progressManager.SwitchAgent(new SquadLeader());
            PlayAgentInvestigation();
            Console.WriteLine($"\nHighest agent exposed so far: {progressManager.HighestRankExposed}\n");
        }
        // Main loop to play the investigation for current agent
        private void PlayAgentInvestigation()
        {
            int turn = 0;
            while (!progressManager.IsAgentRevealed())
            {
                turn++;
                ShowSensorsMenu();
                int choice = GetSensorChoiceFromUser();
                if (choice != -1)
                {
                    ProcessSensorChoice(choice, turn);
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Please try again.\n");
                }
            }
            ShowAgentExposedMessage();
            progressManager.UpdateHighestRank();
        }
        // Shows available sensors on screen
        private void ShowSensorsMenu()
        {
            sensorMenu.ShowAvailableSensors();
        }
        // Reads user's choice, returns -1 if invalid
        private int GetSensorChoiceFromUser()
        {
            bool valid = sensorMenu.GetSensorChoice(out int choice);
            return valid ? choice : -1;
        }
        // Process the chosen sensor and handle counterattack if needed
        private void ProcessSensorChoice(int choice, int turn)
        {
            var sensor = SensorManager.allSensors[choice - 1];
            string result = progressManager.ActivateSensor(sensor);
            Console.WriteLine(result);

            if (progressManager.CurrentAgent is SquadLeader squadLeader)
            {
                string counterAttackResult = squadLeader.HandleTurn(turn);
                if (!string.IsNullOrEmpty(counterAttackResult))
                {
                    Console.WriteLine(counterAttackResult);
                }
            }
        }
        // Prints message when the agent is fully exposed
        private void ShowAgentExposedMessage()
        {
            Console.WriteLine($"\n{progressManager.CurrentAgentRank} has been fully exposed!\n");
        }
    }
}

