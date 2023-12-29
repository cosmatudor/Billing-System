namespace MAP_Project.domain;

public class Document: Entity<string>
{
    public string name { get; set; }
    
    public DateTime emmisionDate  { get; set; }

    public override string ToString()
    {
        return id + "," + name + "," + emmisionDate ;
    }
}