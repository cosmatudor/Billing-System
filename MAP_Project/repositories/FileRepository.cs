using System.Data;
using MAP_Project.domain;
using MAP_Project.Utils;

namespace MAP_Project.repositories;

public delegate E CreateEntity<E>(string line); // delegate for creating an entity from a line read from the file

public class FileRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
{
    protected Dictionary<ID, E> _entities = new Dictionary<ID, E>();
    protected string _fileName;
    protected CreateEntity<E> _createEntity;
    
    public FileRepository(String fileName, CreateEntity<E> createEntity)
    {
        _fileName = fileName;
        _createEntity = createEntity;
    }

    protected void loadFromFile()
    {
        var entities = DataReader.ReadData(_fileName, _createEntity);
        entities.ForEach(entity => _entities[entity.id] = entity);
    }
    
    public IEnumerable<E> findAll()
    {
        return _entities.Values.ToList();
    }
}