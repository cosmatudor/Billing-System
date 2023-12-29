using MAP_Project.domain;

namespace MAP_Project.repositories;

public class DocumentsFileRepo: FileRepository<string, Document>
{
    public DocumentsFileRepo(string fileName, CreateEntity<Document> createEntity) : base(fileName, createEntity)
    {
        loadFromFile();
    }
    
    
}