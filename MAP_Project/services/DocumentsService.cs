using MAP_Project.domain;
using MAP_Project.repositories;

namespace MAP_Project.services;

public class DocumentsService
{
    private IRepository<string, Document> _documentsRepository; 
    
    public DocumentsService(IRepository<string, Document> documentsRepository)
    {
        _documentsRepository = documentsRepository;
    }

    public List<Document> getDocumentsFromYear(string year)
    {
        return _documentsRepository.findAll().ToList().FindAll(x => x.emmisionDate.Year.ToString() == year);
    }
}