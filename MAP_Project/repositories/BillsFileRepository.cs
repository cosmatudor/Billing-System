using MAP_Project.domain;
using MAP_Project.Utils;

namespace MAP_Project.repositories;

public class BillsFileRepository: FileRepository<string, Bill>
{
    public BillsFileRepository(string fileName, CreateEntity<Bill> createEntity) : base(fileName, createEntity)
    {
        loadFromFile();
    }

    private new void loadFromFile()
    {
        var bills = DataReader.ReadData(_fileName, EntityFactory.GetBill);
        var documents = DataReader.ReadData("../../../data/documents.txt", EntityFactory.GetDocument);
        var acquisitions = DataReader.ReadData("../../../data/acquisitions.txt", EntityFactory.GetAcquisition);
        
        // here we need to complete the data for bills and the data inherited from documents
        bills.ForEach(bill =>
        {
            bill.name = documents.Find(document => document.id == bill.id).name;
            bill.emmisionDate = documents.Find(document => document.id == bill.id).emmisionDate;
            bill.acquisitions = acquisitions.FindAll(acquisitions => acquisitions.bill.id == bill.id);
            _entities[bill.id] = bill;
        });
    }
}