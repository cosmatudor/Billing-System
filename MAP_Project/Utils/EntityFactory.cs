using MAP_Project.domain;

namespace MAP_Project.Utils;

public class EntityFactory
{
    public static Document GetDocument(string line)
    {
        var fields = line.Split(",");
        Document document = new()
        {
            id = fields[0],
            name = fields[1],
            emmisionDate = DateTime.ParseExact(fields[2].Trim(), "yyyy-MM-dd", null)
        };
        return document;
    }

    public static Bill GetBill(string line)
    {
        var fields = line.Split(",");
        Bill bill = new()
        {
            id = fields[0],
            dueDate = DateTime.ParseExact(fields[1].Trim(), "yyyy-MM-dd", null),
            category = (Category)Enum.Parse(typeof(Category), fields[2])
        };
        return bill;
    }

    public static Acquisition GetAcquisition(string line)
    {
        var fields = line.Split(",");
        Acquisition acquisition = new()
        {
            id = fields[0],
            product = fields[1],
            quantity = int.Parse(fields[2]),
            price = double.Parse(fields[3]),
            bill = new Bill { id = fields[4] }
        };
        return acquisition;
    }
}