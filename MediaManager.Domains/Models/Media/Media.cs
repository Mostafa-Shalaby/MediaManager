using System;
using System.Collections.Generic;

namespace MediaManager.Domains.Models
{
    public class Media : DataModel
    {
        public string Title { get; set; }

        public string AltTitle { get; set; }

        public MediaType Type { get; set; }

        public string Synopsis { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Demographic Demographic { get; set; }

        public Language Language { get; set; }

        public virtual ICollection<MediaGenre> MediaGenres { get; set; }

        public ICollection<MediaDirectory> MediaDirectories { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public double AverageRating { get; set; }

        public byte[] Thumbnail { get; set; }
    }
}
