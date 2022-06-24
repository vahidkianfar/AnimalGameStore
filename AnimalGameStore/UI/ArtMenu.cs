using AnimalGameStore.HttpServices;
using Spectre.Console;
namespace AnimalGameStore.UI;

public static class ArtMenu
{
    public static async Task Start()
    {
        var inputArt = AnsiConsole.Ask<int>("Enter Art ID (between [green]1-43[/]): ");
        AnsiConsole.MarkupLine("[green]Searching for Art...[/]");
        
        if (inputArt is > 0 and < 44)
        {
            var art = await GET.Art(inputArt);
            art?.PrettyPrint();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Art ID");
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.ResetColor();
        await Task.Run(MainMenu.Start);
    }
    
}