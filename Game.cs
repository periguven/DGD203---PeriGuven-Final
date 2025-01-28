using System;
using System.Collections.Generic;
using System.IO;

namespace MysteryOfTheDottopus
{
    class Game
    {
        private string currentLocation = "";
        private List<string> inventory = new List<string>();
        private bool hasDottopus = false;

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mystery of the Dottopus!");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    LoadGame();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    MainMenu();
                    break;
            }
        }

        private void StartGame()
        {
            currentLocation = "Security Point";
            inventory.Clear();
            hasDottopus = false;
            Console.WriteLine("Your adventure begins at the Security Point...");
            Console.ReadKey();
            GameLoop();
        }

        private void GameLoop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You are at: {currentLocation}");

                switch (currentLocation)
                {
                    case "Security Point":
                        SecurityPoint();
                        break;
                    case "Game Design Studio":
                        GameDesignStudio();
                        break;
                    case "Library":
                        Library();
                        break;
                    case "Social Area":
                        SocialArea();
                        break;
                    default:
                        Console.WriteLine("Invalid location. Returning to the main menu.");
                        MainMenu();
                        break;
                }
            }
        }

        private void SecurityPoint()
        {
            Console.WriteLine("You stand at the entrance of the school, blocked by a security officer.");
            Console.WriteLine("1. Show your student ID.");
            Console.WriteLine("2. Try to talk your way in.");
            Console.WriteLine("3. Move to Game Design Studio.");
            Console.WriteLine("4. Save the game.");
            Console.WriteLine("5. Exit to Main Menu.");

            switch (Console.ReadLine())
            {
                case "1":
                    if (inventory.Contains("Student ID"))
                    {
                        Console.WriteLine("The officer lets you through!");
                        currentLocation = "Game Design Studio";
                    }
                    else
                    {
                        Console.WriteLine("You need a student ID to enter.");
                    }
                    break;
                case "2":
                    Console.WriteLine("The officer remains unconvinced.");
                    break;
                case "3":
                    currentLocation = "Game Design Studio";
                    break;
                case "4":
                    SaveGame();
                    break;
                case "5":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        // Other locations and methods (GameDesignStudio, Library, SocialArea) follow the same pattern.

        private void SaveGame()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("savefile.txt"))
                {
                    writer.WriteLine(currentLocation);
                    writer.WriteLine(hasDottopus);
                    writer.WriteLine(string.Join(",", inventory));
                }
                Console.WriteLine("Game saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving game: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void LoadGame()
        {
            if (File.Exists("savefile.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader("savefile.txt"))
                    {
                        currentLocation = reader.ReadLine();
                        hasDottopus = bool.Parse(reader.ReadLine());
                        inventory = new List<string>(reader.ReadLine().Split(','));
                    }
                    Console.WriteLine("Game loaded successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading game: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No save file found. Starting a new game.");
                StartGame();
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
