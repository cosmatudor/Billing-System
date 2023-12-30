using MAP_Project.domain;
using MAP_Project.repositories;

namespace MAP_Project.services;

public class BillsService
{
    private IRepository<string, Bill> _billRepository;
    
    public BillsService(IRepository<string, Bill> billRepository)
    {
        _billRepository = billRepository;
    }

    public List<Bill> getBillsDueToCurrentMonth()
    {
        return _billRepository
            .findAll()
            .Where(bill => bill.dueDate.Month == DateTime.Now.Month && bill.dueDate.Year == DateTime.Now.Year)
            .ToList();
    }
    
    public List<Bill> getBillsWithAtLeastThreeAcquisitions()
    {
        return _billRepository
            .findAll()
            .Where(bill =>
            {
                return bill.acquisitions.Sum(acquisition => acquisition.quantity) >= 3;
            })
            .ToList();
    }

    public Category getCategoryWithTheMostAcquisitions()
    {
        return _billRepository
            .findAll()
            .GroupBy(bill => bill.category)
            .Select(group => new
            {
                Category = group.Key,
                Amount = group.Sum(bill =>
                    bill.acquisitions.Sum(acquisition => acquisition.quantity * acquisition.price))
            })
            .OrderByDescending(g => g.Amount)
            .First().Category;
    }
}