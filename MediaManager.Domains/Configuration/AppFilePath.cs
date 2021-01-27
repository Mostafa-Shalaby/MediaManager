using System;
using System.IO;

namespace MediaManager.Domains.Configuration
{
    /// <summary>
    /// Static class holding some permanent file paths for use in app.
    /// </summary>
    public static class AppFilePath
    {
        public static string LocalAppData { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); } }

        public static string ProgramAppData { get { return Path.Combine(LocalAppData, "MediaManager/"); } }

        public static string LocalDbFile { get { return Path.Combine(ProgramAppData, "MM_Data.db"); } }

        public static string LocalSettingsFile { get { return Path.Combine(ProgramAppData, "MM_Settings.config"); } }

        // TO DO: Most likely I will be moving this into proper AppConfig later on.
    }
}
