
using System;
using System.Collections.Generic;
using InheritanceMinigame.Classes;

namespace InheritanceMinigame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("    WELCOME TO THE INHERITANCE ARENA");
            Console.WriteLine("====================================");

            Console.Write("Enter your hero's name: ");
            string heroName = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(heroName))
            {
                heroName = "Unknown Hero";
            }

            Console.WriteLine("\nChoose your class:");
            Console.WriteLine("1. Warrior (High Health, Blocks Damage)");
            Console.WriteLine("2. Mage (Low Health, Powerful Fireballs)");
            Console.Write("Selection (1 or 2): ");

            string choice = Console.ReadLine() ?? "";

            Character player;

            if (choice == "2")
            {
                player = new Mage(heroName);
            }
            else
            {
                player = new Warrior(heroName);
            }

            Queue<Character> dungeonEnemies = new Queue<Character>();

            dungeonEnemies.Enqueue(new Goblin("Gorg the Sneaky"));
            dungeonEnemies.Enqueue(new Goblin("Zib the Vile"));
            dungeonEnemies.Enqueue(new Dragon("Ignis the Flame-Bringer"));

            Console.WriteLine($"\n{player.Name} enters the dungeon!");

            Console.WriteLine(
                $"Your health: {player.Health}/{player.MaxHealth}");

            Console.WriteLine(
                $"Your attack power: {player.AttackPower}");

            while (player.IsAlive && dungeonEnemies.Count > 0)
            {
                Character currentEnemy = dungeonEnemies.Peek();

                Console.WriteLine("\n====================================");
                Console.WriteLine(
                    $"A wild {currentEnemy.GetType().Name} appears!");

                Console.WriteLine($"Enemy: {currentEnemy.Name}");

                Console.WriteLine(
                    $"Enemy health: {currentEnemy.Health}/{currentEnemy.MaxHealth}");

                Console.WriteLine("====================================");

                while (player.IsAlive && currentEnemy.IsAlive)
                {
                    Console.WriteLine("\nPress ENTER to attack...");
                    Console.ReadLine();

                    player.PerformAttack(currentEnemy);

                    if (!currentEnemy.IsAlive)
                    {
                        Console.WriteLine(
                            $"\nYou defeated {currentEnemy.Name}!");

                        dungeonEnemies.Dequeue();
                        break;
                    }

                    currentEnemy.PerformAttack(player);

                    Console.WriteLine(
                        $"Your remaining HP: {player.Health}/{player.MaxHealth}");
                }
            }

            Console.WriteLine("\n====================================");
            Console.WriteLine("             END OF GAME");
            Console.WriteLine("====================================");

            if (player.IsAlive)
            {
                Console.WriteLine(
                    "CONGRATULATIONS! You cleared the dungeon and won!");
            }
            else
            {
                Console.WriteLine("YOU DID NOT SURVIVE! GAME OVER.");
            }

            Console.WriteLine("====================================");
        }
    }
}
