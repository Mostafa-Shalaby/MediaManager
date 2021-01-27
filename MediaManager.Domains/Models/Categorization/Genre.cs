using System.Collections.Generic;

namespace MediaManager.Domains.Models
{
    public class Genre : DataModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Media> MediaEntities { get; set; }
    }
}
