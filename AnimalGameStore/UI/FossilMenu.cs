using AnimalGameStore.HttpServices;
using Spectre.Console;
namespace AnimalGameStore.UI;

public static class FossilMenu
{
    public static async Task Start()
    {
        var inputFossil = AnsiConsole.Ask<string>("Enter Fossil Name (e.g. [orange1]amber[/]): ").ToLower();
        AnsiConsole.MarkupLine("[green]Searching for Fossil...[/]");
        if (!string.IsNullOrEmpty(inputFossil))
        {
            try
            {
                var fossil = await GET.Fossil(inputFossil);
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
        await Task.Run(MainMenu.Start);
    }
}