namespace MysteryOfTheDottopus
{
    class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Location(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
