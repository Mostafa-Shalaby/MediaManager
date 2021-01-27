namespace MediaManager.Domains.Models
{
    public class MediaGenre
    {
        public int MediaID { get; set; }

        public Media Media { get; set; }

        public int GenreID { get; set; }

        public Genre Genre { get; set; }
    }
}
