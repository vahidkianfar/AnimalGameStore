using AnimalGameStore.HttpServices;
using AnimalGameStore.Models;
using Spectre.Console;
namespace AnimalGameStore.UI;

public class ArtMenu
{
    public static void Start()
    {
        var inputArt = AnsiConsole.Ask<int>("Enter Art ID (between 1-43): ");
        
        if (inputArt is > 0 and < 44)
        {
            var art = new Art();
            art = GET.Art(inputArt);
            art.PrettyPrint();
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
        MainMenu.Start();
    }
    
}