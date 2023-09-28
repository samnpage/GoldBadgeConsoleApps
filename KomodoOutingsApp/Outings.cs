public class Outings
{

    public string EventType { get; set; }
    public int People { get; set; }
    public string Date { get; set; }
    public double CostPerPerson { get; set; }
    public double TotalCost { get; set; }

    public Outings(string outingType, int peopleNum, string outingDate, double typeCost, double totalCost)
    {
        EventType = outingType;
        People = peopleNum;
        Date = outingDate;
        CostPerPerson = typeCost;
        TotalCost = totalCost;
    }
}