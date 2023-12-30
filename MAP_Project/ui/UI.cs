using System.ComponentModel.Design;
using MAP_Project.domain;
using MAP_Project.services;

namespace MAP_Project.ui;

public class UI
{
    private DocumentsService _documentsService;
    private BillsService _billsService;
    private AcquisitionsService _acquisitionsService;
    
    public UI(DocumentsService documentsService, BillsService billsService, AcquisitionsService acquisitionsService)
    {
        _documentsService = documentsService;
        _billsService = billsService;
        _acquisitionsService = acquisitionsService;
    }
    
    public void run()
    {
        while (true)
        {
            Menu();   
            var option = int.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 0:
                {
                    Console.WriteLine("You have exited the application!");
                    return;
                }
                case 1:
                {
                    _documentsService.getDocumentsFromYear("2023").ForEach(Console.WriteLine);
                    break;
                }
                case 2:
                {
                    List<Bill> bills = _billsService.getBillsDueToCurrentMonth();
                    foreach (var bill in bills) 
                    {
                        Console.WriteLine(bill.name + "-" + bill.dueDate);
                    }
                    break;
                }
                case 3:
                {
                    List<Bill> bills = _billsService.getBillsWithAtLeastThreeAcquisitions();
                    foreach (var bill in bills) 
                    {
                        Console.WriteLine(bill.name + "-" + bill.acquisitions.Sum(acquisition => acquisition.quantity));
                    }
                    break;
                }
                case 4:
                {
                    List<Acquisition> acquisitions = _acquisitionsService.GetAcquisitionsOfCategory(Category.Utilities);
                    foreach (var acquisition in acquisitions) 
                    {
                        Console.WriteLine(acquisition.product + "-" + acquisition.bill.name);
                    }

                    break;
                }
                case 5:
                {
                    Console.WriteLine(_billsService.getCategoryWithTheMostAcquisitions());
                    break;
                }
            }
        }
        
    }

    private void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Task 1");
        Console.WriteLine("2. Task 2");
        Console.WriteLine("3. Task 3");
        Console.WriteLine("4. Task 4");
        Console.WriteLine("5. Task 5");
        Console.WriteLine("0. Exit");
        Console.WriteLine("Your choice: ");
    }
}