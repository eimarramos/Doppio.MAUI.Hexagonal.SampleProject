namespace Infrastructure.Config
{
    public static class Constants
    {
        public const string DatabaseFilename = "Doppio.db3";
        public static string DatabasePath
        {
            get
            {
                string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(appDataDirectory, DatabaseFilename);
            }
        }
    }
}
