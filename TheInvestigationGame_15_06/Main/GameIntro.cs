using System;
using System.Threading;

namespace TheInvestigationGame_15_06
{
    internal static class GameIntro
    {
        public static void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
██╗████████╗███████╗  ██╗██╗   ██╗███████╗████████╗██╗ ██████╗ ███╗   ██╗
██║╚══██╔══╝██╔════╝  ██║██║   ██║██╔════╝╚══██╔══╝██║██╔═══██╗████╗  ██║
██║   ██║   █████╗    ██║██║   ██║█████╗     ██║   ██║██║   ██║██╔██╗ ██║
██║   ██║   ██╔══╝    ██║╚██╗ ██╔╝██╔══╝     ██║   ██║██║   ██║██║╚██╗██║
██║   ██║   ███████╗  ██║ ╚████╔╝ ███████╗   ██║   ██║╚██████╔╝██║ ╚████║
╚═╝   ╚═╝   ╚══════╝  ╚═╝  ╚═══╝  ╚══════╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝
            ");
            Console.ResetColor();

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n********************Welcome to The Investigation Game********************");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n                  An Iranian agent has infiltrated!!!");
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n  Your mission: uncover their hidden weaknesses using advanced sensors.\n\n\n");
            Thread.Sleep(1500);
            Console.ResetColor();
        }
    }
}
