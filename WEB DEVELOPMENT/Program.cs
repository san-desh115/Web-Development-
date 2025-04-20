using System;
using System.Collections.Generic;
using Internal;

namespace TigerSoccerClub
{
    public class Player
    {
        public string Name { get; set; }
        public string RegistrationType { get; set; }
        public string Jersey { get; set; }
        public double TotalPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_PLAYERS = 4;
            const double JERSEY_COST = 100;
            const double KIDS_FEE = 150;
            const double ADULT_FEE = 230;
            List<Player> playerList = new List<Player>();

            string header = "***** Welcome to Tiger Soccer Club *****";
            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(header);

            Console.Write("Enter the number of players (1 to 4): ");
            int numPlayers = Convert.ToInt32(Console.ReadLine());

            if (numPlayers < 1 || numPlayers > MAX_PLAYERS)
            {
                Console.WriteLine("Invalid number, please enter between 1 and 4.");
                return;
            }

            bool applyDiscount = numPlayers > 1;

            for (int i = 0; i < numPlayers; i++)
            {
                Console.WriteLine($"\n--- Player {i + 1} ---");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter registration type (Kids/Adult): ");
                string registrationType = Console.ReadLine();

                Console.Write("Do you want a jersey? (Yes/No): ");
                string jersey = Console.ReadLine();

                double totalPrice = CalculateTotal(registrationType, jersey, applyDiscount);
                Console.WriteLine($"Total price for {name}: ${totalPrice}");

                playerList.Add(new Player
                {
                    Name = name,
                    RegistrationType = registrationType,
                    Jersey = jersey,
                    TotalPrice = totalPrice
                });
            }

            // Summary
            Console.WriteLine("\n\nSummary of Registrations");
            Console.WriteLine("********************************************");
            Console.WriteLine("Name\t\tType\tJersey\tTotal");

            foreach (var player in playerList)
            {
                Console.WriteLine($"{player.Name}\t\t{player.RegistrationType}\t{player.Jersey}\t${player.TotalPrice}");
            }
        }

        static double CalculateTotal(string registration, string jersey, bool applyDiscount)
        {
            double basePrice = registration.Equals("Kids", StringComparison.OrdinalIgnoreCase) ? 150 : 230;
            if (jersey.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                basePrice += 100;

            if (applyDiscount)
                basePrice *= 0.95;

            return basePrice;
        }
    }
}