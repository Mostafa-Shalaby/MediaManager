using System.Collections.Generic;

namespace MediaManager.Domains.Models
{
    public class Demographic : DataModel
    {
        public string Name { get; set; }

        public int AllowedAge { get; set; } = 0;

        public virtual ICollection<Media> MediaEntities { get; set; }
    }
}
