namespace MediaManager.Domains.Models
{
    public class MediaDirectory : DataModel
    {
        public string DriveName { get; set; }

        public string Path { get; set; }

        public double Size { get; set; }

        public bool IsFile { get; set; } = false;
    }
}
