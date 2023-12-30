using MAP_Project.domain;
using MAP_Project.repositories;

namespace MAP_Project.services;

public class AcquisitionsService
{
    private IRepository<string, Acquisition> _acquisitionsRepository;
    
    public AcquisitionsService(IRepository<string, Acquisition> acquisitionsRepository)
    {
        _acquisitionsRepository = acquisitionsRepository;
    }
    
    public List<Acquisition> GetAcquisitionsOfCategory(Category category)
    {
        return _acquisitionsRepository
            .findAll()
            .Where(acq => acq.bill.category == category)
            .ToList();
    }
}