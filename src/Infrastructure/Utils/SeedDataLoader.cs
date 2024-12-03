using Infrastructure.Persistance;
using System.Text.Json;

namespace Infrastructure.Utils
{
    public static class SeedDataLoader
    {
        public static List<T> LoadSeedData<T>(string resourceName)
        {
            var assembly = typeof(DatabaseContextInitializer).Assembly;

            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException($"Resource '{resourceName}' not found.");
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                }
            }
        }
    }
}
