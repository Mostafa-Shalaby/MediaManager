using System.Collections.Generic;

namespace MediaManager.Domains.Models
{
    public class Language : DataModel
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public virtual ICollection<Media> MediaEntities { get; set; }
    }
}
