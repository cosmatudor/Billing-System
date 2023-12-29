namespace MAP_Project.domain;

public class Acquisition: Entity<string>
{
    public string product { get; set; }
    
    public int quantity { get; set; }
    
    public double price { get; set; }
    
    public Bill bill { get; set; }
    
    public override string ToString()
    {
        return id + "," + product + "," + quantity + "," + price + "," + bill.id;
    }
}