namespace artists_MC.Models
{
    public class Song
    {
        public Song()
        { }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int? Year { get; set; }
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}