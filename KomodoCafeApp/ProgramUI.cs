using System.Collections;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class ProgramUI
{
    // Object used to access Menu Items repository methods
    protected readonly MenuItemRepository repo = new MenuItemRepository();

    // Method used to call RunMenu() method
    public void Run()
    {
        RunMenu();
    }

    // Method created to display options for user to interact with
    public void RunMenu()
    {
        bool menuLoop = true;
        Console.Clear();
        do
        {
            // Lists options for user to interact with
            Console.WriteLine(
                "Menu:\n" +
                "1. List Menu Items\n" +
                "2. Create New Menu items\n" +
                "3. Update Menu Items\n" +
                "4. Delete Menu Items\n" +
                "5. Exit Console"
            );
            // Collects user input and assigns it to a variable 'selection' to be passed through a switch statement. This will run the apporopriate method.
            string selection = Console.ReadLine() ?? "";

            switch (selection)
            {
            case "1":
                Console.Clear();
                ListMenuItems();
                break;
            case "2":
                CreateNewMenuItems();
                break;
            case "3":
                UpdateMenuItems();
                break;
            case "4":
                DeleteMenuItems();
                break;
            case "5":
                menuLoop = false;
                break;
            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid selection...");
                break;
            }
        }
        // Do-while loop that loops until 'menuLoop' variable is false, which is when the user wishes to exit the console.
        while(menuLoop);
    }

    // Method that grabs all of the items from the item directory and displays each to the console.
    private void ListMenuItems()
    {
        List<MenuItems> allItems = repo.GetItemList();
        foreach (MenuItems item in allItems)
        {
            DisplayMenuItems(item);
        }

        WaitForKeyPress();
        Console.Clear();
    }

    // Method that creates new meal item and adds it to the current directory.
    private void CreateNewMenuItems()
    {
        Console.Clear();
        Console.Write("Enter item number (#num): ");
        string mealNum = Console.ReadLine() ?? "";

        Console.Clear();
        Console.Write("Enter in a meal name: ");
        string mealName = Console.ReadLine() ?? "";

        Console.Clear();
        Console.Write("Enter in a meal description: ");
        string description = Console.ReadLine() ?? "";

        Console.Clear();
        Console.Write("Enter in the meal's list of ingredients: ");
        string ingredientsList = Console.ReadLine() ?? "";

        Console.Clear();
        Console.Write("Enter in a price for the meal: ");
        double price = Convert.ToDouble(Console.ReadLine());
        
        MenuItems newContent = new MenuItems(mealNum, mealName, description, ingredientsList, price);
        repo.AddItemToDirectory(newContent);
    }

    // Method that Updates each meals property in order
    private void UpdateMenuItems()
    {
        Console.Clear();
        bool selectionLoop = true;
        do
        {
            Console.Write("Enter in meal number you would like to update (#num): ");
            string mealNum = Console.ReadLine() ?? "";

            Console.Clear();

            MenuItems item = repo.GetContentByNumber(mealNum);
            if (item == default)
            {
                Console.WriteLine("Meal not found...");
            }
            else 
            {
                DisplayMenuItems(item);
                selectionLoop = false;

                // Update meal number sequence
                Console.Write("Enter a new meal number (#num): ");
                string newNum = Console.ReadLine() ?? "";
                item.MealNumber = newNum;

                // Update meal name sequence
                Console.Write("Enter in a new meal name: ");
                string newName = Console.ReadLine() ?? "";
                item.MealName = newName;

                // Update meal description sequence
                Console.Write("Enter in a new meal description: ");
                string newDescription = Console.ReadLine() ?? "";
                item.Description = newDescription;

                // Update meal ingredients list sequence
                Console.Write("Enter in a new ingredients list: ");
                string newIngredientsList = Console.ReadLine() ?? "";
                item.IngredientsList = newIngredientsList;

                // Update meal price sequence
                Console.Write("Enter in a new meal price: ");
                double newPrice = Convert.ToDouble(Console.ReadLine());
                item.Price = newPrice;
            }
        }
        while(selectionLoop);

        WaitForKeyPress();
        Console.Clear();
    }

    // Method that deletes a meal by its number.
    private void DeleteMenuItems()
    {
        Console.Clear();

        // Loop created that if the meal number is null will repeat until user inputs a valid meal number
        bool selectionLoop = true;
        do
        {
            Console.Write("Enter in meal number that you want to delete (#num): ");
            string num = Console.ReadLine() ?? "";

            Console.Clear();

            MenuItems item = repo.GetContentByNumber(num);

            if (item == default)
            {
                Console.WriteLine("Meal not found...");
            }
            else 
            {
                DisplayMenuItems(item);
                selectionLoop = false;

                Console.Write($"Are you sure you want to delete {num}? (y/n): ");
                string selection = Console.ReadLine() ?? "";

                if (selection == "y" || selection == "yes")
                {
                    repo.DeleteExistingContent(num);
                    Console.WriteLine($"{num} successfully deleted.");
                    WaitForKeyPress();
                }
                else{
                    
                }
                Console.Clear();
            }
        }
        while(selectionLoop);
    }

    // ! Helper Methods

    // This helper method is used to display the menu item's fields. Meal number, Meal name, Description, and the Ingredients list.
    public void DisplayMenuItems(MenuItems item)
    {
        Console.WriteLine(
            $"{item.MealNumber}\n" +
            $"{item.MealName}\n" +
            $"{item.Description}\n" +
            $"{item.IngredientsList}\n" +
            $"${item.Price}" +
            "\n"
        );
    }

    // Method that waits for keypress from user and returns the menu
    public void WaitForKeyPress()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}