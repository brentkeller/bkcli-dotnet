using System.Text.Json;
using Bkcli.Models;

namespace Bkcli.Services
{
  public class DataService
  {
    static string DataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\.bkcli.data.json";

    private static readonly JsonSerializerOptions _options = new()
    {
      PropertyNameCaseInsensitive = true
    };

    public static AppData GetData()
    {
      using FileStream json = File.OpenRead(DataPath);
      return JsonSerializer.Deserialize<AppData>(json, _options) ?? new AppData();
    }

    public static void SaveData(AppData data)
    {
      var str = JsonSerializer.Serialize(data);
      File.WriteAllText(DataPath, str);
    }
  }
}