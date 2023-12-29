namespace MAP_Project.domain;

public enum Category
{
    Utilities, Groceries, Fashion, Entertainment, Electronics
}

public class Bill: Document
{
    public DateTime dueDate { get; set; }
    
    public List<Acquisition> acquisitions { get; set; }
    
    public Category category { get; set; }
}