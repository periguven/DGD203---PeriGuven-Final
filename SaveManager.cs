using System;
using System.IO;

namespace MysteryOfTheDottopus
{
    class SaveManager
    {
        public static void SaveGame(string currentLocation, bool hasDottopus, List<string> inventory)
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
        }

        public static void LoadGame(out string currentLocation, out bool hasDottopus, out List<string> inventory)
        {
            currentLocation = "";
            hasDottopus = false;
            inventory = new List<string>();

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
                Console.WriteLine("No save file found.");
            }
        }
    }
}
