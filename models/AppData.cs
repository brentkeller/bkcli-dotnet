using System.Text.Json.Serialization;

namespace Bkcli.Models
{
  public class AppData
  {
    [JsonPropertyName("shortcuts")]
    public IDictionary<string, string> Shortcuts { get; set; } = new Dictionary<string, string>();
  }
}
