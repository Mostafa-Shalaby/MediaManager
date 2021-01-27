namespace MediaManager.Domains.Models
{
    public class Rating : DataModel
    {
        public RatingSource Source { get; set; }

        public double Value { get; set; }
    }
}
