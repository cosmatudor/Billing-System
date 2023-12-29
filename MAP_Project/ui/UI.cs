using System.ComponentModel.Design;
using MAP_Project.services;

namespace MAP_Project.ui;

public class UI
{
    private DocumentsService _documentsService;
    
    public UI(DocumentsService documentsService)
    {
        _documentsService = documentsService;
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