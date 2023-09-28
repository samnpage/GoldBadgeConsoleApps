//  Menu Items Class
public class MenuItems
{
    // Properties
    public string MealNumber { get; set; }
    public string MealName { get; set; }
    public string Description { get; set; }
    public string IngredientsList { get; set; }
    public double Price { get; set; }

    // Menu Items constructor
    public MenuItems(string mealNumber, string mealName, string description, string ingredientsList, double price)
    {
        MealNumber = mealNumber;
        MealName = mealName;
        Description = description;
        IngredientsList = ingredientsList;
        Price = price;
    }
}
