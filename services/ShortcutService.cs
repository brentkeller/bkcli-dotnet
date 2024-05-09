namespace Bkcli.Services
{
  public class ShortcutService
  {
    public IDictionary<string, string> Shortcuts;

    public ShortcutService()
    {
      Shortcuts = DataService.GetData()?.Shortcuts ?? new Dictionary<string, string>();
    }

    private void SaveShortcuts()
    {
      var data = DataService.GetData();
      data.Shortcuts = Shortcuts;
      DataService.SaveData(data);
    }

    public string AddShortcut(string name, string path = "")
    {
      if (Shortcuts.TryGetValue(name, out string? existingPath))
      {
        return $"Shortcut '{name}' already exists: {existingPath}";
      }
      else
      {
        Shortcuts.Add(name, path);
        SaveShortcuts();
        return $"Shortcut '{name}' added successfully!";
      }
    }
  }
}