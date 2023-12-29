using MAP_Project.domain;
using MAP_Project.repositories;
using MAP_Project.services;
using MAP_Project.ui;
using MAP_Project.Utils;

IRepository<string, Document> documentsRepository = new DocumentsFileRepo("../../../data/documents.txt", EntityFactory.GetDocument);
IRepository<string, Bill> billsRepository = new BillsFileRepository("../../../data/bills.txt", EntityFactory.GetBill);
IRepository<string, Acquisition> acquisitionsRepository = new AcquisitionsFileRepository("../../../data/acquisitions.txt", EntityFactory.GetAcquisition);

DocumentsService documentService = new DocumentsService(documentsRepository);

UI ui = new UI(documentService);
ui.run();