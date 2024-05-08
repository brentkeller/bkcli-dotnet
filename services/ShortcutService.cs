namespace Bkcli.Services
{
  public class ShortcutService
  {
    public IDictionary<string, string> Shortcuts;

    public ShortcutService()
    {
      Shortcuts = DataService.GetData()?.Shortcuts ?? new Dictionary<string, string>();
    }
  }
}