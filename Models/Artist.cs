namespace artists_MC.Models
{
    public class Artist
    {
        public Artist() { }

        public Artist(string name, string description, int birthyear)
        {
            Name = name;
            Description = description;
            BirthYear = birthyear;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? BirthYear { get; set; }
        public int Id { get; set; }

    }
}