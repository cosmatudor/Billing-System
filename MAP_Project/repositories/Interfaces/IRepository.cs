using MAP_Project.domain;

namespace MAP_Project.repositories;

public interface IRepository <ID, E> where E : Entity<ID>
{
    public IEnumerable<E> findAll();
}