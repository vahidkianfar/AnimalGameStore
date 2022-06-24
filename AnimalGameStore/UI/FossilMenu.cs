using AnimalGameStore.HttpServices;
using AnimalGameStore.Models;
using Spectre.Console;

namespace AnimalGameStore.UI;

public class FossilMenu
{
    public static void Start()
    {
        var inputFossil = AnsiConsole.Ask<string>("Enter Fossil Name (e.g. amber): ").ToLower();
        AnsiConsole.MarkupLine("[green]Searching for Fossil...[/]");
        if (!string.IsNullOrEmpty(inputFossil))
        {
            var fossil = new Fossils();
            try
            {
                fossil = GET.Fossil(inputFossil);
                fossil.PrettyPrint();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fossil not found");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("More information about Fossils : ");
                Console.ResetColor();
                Console.Write(" https://acnhapi.com/v1/fossils/");
                Console.WriteLine();
            }
            
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Fossil Name");
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.ResetColor();
        MainMenu.Start();
    }
}