public class OutingsRepository
{
    protected readonly List<Outings> itemDirectory = new List<Outings>();

    public OutingsRepository()
    {
        Seed();
    }
    public List<Outings> GetOutingList()
    {
        return itemDirectory;
    }

    // Method that Creates new content inside the Menu Items class
    public bool AddItemToDirectory(Outings content)
    {
        int startingCount = itemDirectory.Count;
        itemDirectory.Add(content);

        bool wasAdded = itemDirectory.Count > startingCount;
        
        return wasAdded;
    }

    //Read
    public Outings GetContentByType(string type)
    {
        foreach (Outings content in itemDirectory)
        {
            if (content.EventType == type)
            {
                return content;
            }
        }

        return default;
    }
    
    //Update
    public bool UpdateExistingContent(string ogNumber, Outings newContent)
    {
        Outings oldContent = GetContentByType(ogNumber);

        if (oldContent != default)
        {
            oldContent.EventType = newContent.EventType;
            oldContent.People = newContent.People;
            oldContent.Date = newContent.Date;
            oldContent.CostPerPerson = newContent.CostPerPerson;
            oldContent.TotalCost = newContent.TotalCost;

            return true;
        }
        else
        {
            return false;
        }
    }

    // Method responsible for creating the initial content within the console. This content will refresh upon restarting the application.
    public void Seed()
    {
    Outings outingOne = new Outings(
        "Golf",
        8,
        "6/23/23",
        15,
        120
        );

    Outings outingTwo = new Outings(
        "Bowling",
        10,
        "11/3/22",
        8,
        80
    );

    Outings outingThree = new Outings(
        "Concert",
        12,
        "8/14/23",
        30,
        360
    );

        AddItemToDirectory(outingOne);
        AddItemToDirectory(outingTwo);
        AddItemToDirectory(outingThree);
    }
}