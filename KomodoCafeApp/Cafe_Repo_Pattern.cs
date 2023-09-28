public class MenuItemRepository
{
    protected readonly List<MenuItems> itemDirectory = new List<MenuItems>();
    //List
    public MenuItemRepository()
    {
        Seed();
    }
    public List<MenuItems> GetItemList()
    {
        return itemDirectory;
    }

    // Method that Creates new content inside the Menu Items class
    public bool AddItemToDirectory(MenuItems content)
    {
        int startingCount = itemDirectory.Count;
        itemDirectory.Add(content);

        bool wasAdded = itemDirectory.Count > startingCount;
        
        return wasAdded;
    }

    //Read
    public MenuItems GetContentByNumber(string number)
    {
        foreach (MenuItems content in itemDirectory)
        {
            if (content.MealNumber == number)
            {
                return content;
            }
        }

        return default;
    }
    
    //Update
    public bool UpdateExistingContent(string ogNumber, MenuItems newContent)
    {
        MenuItems oldContent = GetContentByNumber(ogNumber);

        if (oldContent != default)
        {
            oldContent.MealNumber = newContent.MealNumber;
            oldContent.MealName = newContent.MealName;
            oldContent.Description = newContent.MealName;
            oldContent.IngredientsList = newContent.IngredientsList;
            oldContent.Price = newContent.Price;

            return true;
        }
        else
        {
            return false;
        }
    }
    
    //Delete
    public bool DeleteExistingContent(string num) 
    {
        MenuItems contentToDelete = GetContentByNumber(num);

        if (contentToDelete != default)
        {
            bool deleteResult = itemDirectory.Remove(contentToDelete);
            return deleteResult;
        }
        else
        {
            return false;
        }
    }

    // Method responsible for creating the initial content within the console. This content will refresh upon restarting the application.
    public void Seed()
    {
    MenuItems itemOne = new MenuItems(
        "#1",
        "Black Coffee",
        "Coffee with nothing added. no cream, no milk, no sweetener",
        "Coffee",
        2.99
        );

    MenuItems itemTwo = new MenuItems(
        "#2",
        "Cafe Latte",
        "Rich, full-bodied espresso in steamed milk",
        "1 1/3 cups hot freshly brewed dark roast espresso coffee, and 2 cups milk",
        3.45
    );

    MenuItems itemThree = new MenuItems(
        "#3",
        "Cappuccino",
        "Perfect balance of espresso, steamed milk and foam",
        "1 1/3 cups hot freshly brewed dark roast espresso coffee, and 2 cups milk",
        4.47
    );

        AddItemToDirectory(itemOne);
        AddItemToDirectory(itemTwo);
        AddItemToDirectory(itemThree);
    }
}