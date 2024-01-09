namespace BitzArt.Console;

internal class MenuMap
{
    private readonly List<MenuMapItem> _menus = [];

    public void Add(Type menuType)
    {
        var attribute = menuType.GetAppMenuAttribute();

        var item = new MenuMapItem(attribute.IsMain, attribute.GetTitle(), menuType);
        _menus.Add(item);
    }

    public IEnumerable<MenuMapItem> GetItems()
    {
        return _menus;
    }

    public IEnumerable<MenuMapItem> GetMainMenuItems()
    {
        return _menus.Where(x => x.IsMainMenu == true);
    }

    public MenuMapItem GetMainMenuItem()
    {
        var items = GetMainMenuItems().ToList();
        if (items.Count == 0) throw new InvalidOperationException("There is no main menu registered.");
        if (items.Count > 1) throw new InvalidOperationException("There are more than one main menu registered.");
        return items.First();
    }
}
