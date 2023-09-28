using System.Collections;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class ProgramUI 
{
    protected readonly OutingsRepository repo = new OutingsRepository();

    public void Run()
    {
        RunMenu();
    }

    public void RunMenu()
    {
        bool menuLoop = true;
        Console.Clear();
        do
        {
            Console.WriteLine(
                "Komodo Outings Menu:\n" +
                "\n" +
                "1. List all outings\n" +
                "2. Add outings\n" +
                // "3. Cost by type\n" +
                "3. Exit Menu"
            );
            string selection = Console.ReadLine() ?? "";

            switch (selection)
            {
                case "1":
                    Console.Clear();
                    ListAllOutings();
                    break;
                case "2":
                    AddOuting();
                    break;
                // case "3":
                //     CostByType();
                //     break;
                case "3":
                    menuLoop = false;
                    break;
                default:
                Console.Clear();
                    Console.WriteLine("Please enter a valid selection... (1-5)\n");
                    break;
            }
        }
        while(menuLoop);
    }

    public void ListAllOutings()
    {
        List<Outings> allItems = repo.GetOutingList();
        foreach (Outings item in allItems)
        {
            DisplayOutings(item);
        }
        
        WaitForKeyPress();
        Console.Clear();
    }

    public void AddOuting()
    {
        Console.Clear();
        Console.Write("Enter event type: ");
        string eventType = Console.ReadLine() ?? "";

        Console.Clear();
        Console.Write("Enter in the number of people that attended: ");
        int numberOfPeople = Convert.ToInt16(Console.ReadLine());

        Console.Clear();
        Console.Write("Enter date (??/??/??): ");
        string date = Console.ReadLine() ?? "";

        Console.Clear();
        Console.Write("Enter in total cost per person: ");
        double costPerPerson = Convert.ToDouble(Console.ReadLine());

        double totalCost = numberOfPeople * costPerPerson;
        
        Outings newContent = new Outings(eventType, numberOfPeople, date, costPerPerson, totalCost);
        repo.AddItemToDirectory(newContent);

        Console.Clear();
        Console.WriteLine("Outing added successfully :)\n");
        WaitForKeyPress();
    }

    private void CostByType()
    {
        Console.Clear();
        bool inputLoop = true;
        do
        {
            Console.Write("Enter in event type: ");
            string input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "Golf":
                    repo.GetContentByType(input);
                    break;
                default:
                    inputLoop = false;
                    break;
            }
        }
        while(inputLoop);

        WaitForKeyPress();
    }

    // ! Helper Methods
    public void DisplayOutings(Outings item)
    {
        Console.WriteLine(
            $"Event Type: {item.EventType}\n" +
            $"Number of People: {item.People}\n" +
            $"Date: {item.Date}\n" +
            $"Cost per person: ${item.CostPerPerson}\n" +
            $"Total Cost: ${item.TotalCost}" +
            "\n"

        );
    }

    public double AddTotalOutingCost(Outings item)
    {
        
        double total = item.TotalCost;
        double grandTotal = total += total;
        Console.WriteLine(grandTotal);
        return grandTotal;
    }

    public void WaitForKeyPress()
    {
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }
}