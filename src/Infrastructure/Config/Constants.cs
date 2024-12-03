using Infrastructure.Persistance;
using System.Text.Json;

namespace Infrastructure.Config
{
    public static class Constants
    {
        public const string DatabaseFilename = "TestDGT.db3";
        public const string CategoriesResourceName = "Infrastructure.Persistance.Data.CategoriesSeedData.json";
        public const string ShopsResourceName = "Infrastructure.Persistance.Data.ShopsSeedData.json";

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
