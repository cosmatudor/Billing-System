using MAP_Project.domain;
using MAP_Project.Utils;

namespace MAP_Project.repositories;

public class AcquisitionsFileRepository: FileRepository<string, Acquisition>
{
    public AcquisitionsFileRepository(string fileName, CreateEntity<Acquisition> createEntity) : base(fileName, createEntity)
    {
        loadFromFile();
    }

    private new void loadFromFile()
    {
        var acquisitions = DataReader.ReadData(_fileName, EntityFactory.GetAcquisition);
        var bills = DataReader.ReadData("../../../data/bills.txt", EntityFactory.GetBill);
        var documents = DataReader.ReadData("../../../data/documents.txt", EntityFactory.GetDocument);
        
        // here we need to complete the data for acquisitions and the data inherited from documents
        acquisitions.ForEach(acquisitions =>
        {
            acquisitions.bill = bills.Find(bill => acquisitions.bill.id == bill.id);
            acquisitions.bill.name = documents.Find(document => document.id == acquisitions.bill.id).name;
            acquisitions.bill.emmisionDate = documents.Find(document => document.id == acquisitions.bill.id).emmisionDate;
            _entities[acquisitions.id] = acquisitions;
        });
    }
}