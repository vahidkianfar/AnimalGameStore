using AnimalGameStore.HttpServices;
using Spectre.Console;

namespace AnimalGameStore.UI;

public static class SongMenu
{
    public static async Task Start()
    {
        var inputArt = AnsiConsole.Ask<int>("Enter Song ID (between [green]1-95[/]): ");
        AnsiConsole.MarkupLine("[green]Searching for Song...[/]");
        
        if (inputArt is > 0 and < 96)
        {
            var song = await GET.Song(inputArt);
            song?.PrettyPrint();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Song ID");
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.ResetColor();
        await Task.Run(MainMenu.Start);
    }

}