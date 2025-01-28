using System.Collections.Generic;

namespace MysteryOfTheDottopus
{
    class Inventory
    {
        private List<string> items = new List<string>();

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public bool Contains(string item)
        {
            return items.Contains(item);
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
        }

        public void DisplayItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
