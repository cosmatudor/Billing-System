using MAP_Project.repositories;

namespace MAP_Project.Utils;

public class DataReader
{
    public static List<T> ReadData<T>(string fileName, CreateEntity<T> createEntity)
    {
        var entities = new List<T>();
        
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            var entity = createEntity(line);
            entities.Add(entity);
        }

        return entities;
    }
}