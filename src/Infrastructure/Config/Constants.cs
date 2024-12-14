namespace Infrastructure.Config
{
    public static class Constants
    {
        public const string DatabaseFilename = "TestDGT.db3";
        public const string CategoriesResourceName = "Infrastructure.Persistence.Data.CategoriesSeedData.json";
        public const string ShopsResourceName = "Infrastructure.Persistence.Data.ShopsSeedData.json";

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
