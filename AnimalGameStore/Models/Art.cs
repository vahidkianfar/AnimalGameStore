using Spectre.Console;
namespace AnimalGameStore.Models;

public class Art
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool HasFake { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string? MuseumDescription{ get; set; }
    public Uri? Photo { get; set; }
    
    public void PrettyPrint()
    {
        Console.Clear();
        AnsiConsole.Write(
            new Table()
                .AddColumn(new TableColumn("Setting").Centered())
                .AddColumn(new TableColumn("Details").Centered())
                .AddRow("Art Name", $"[skyblue1]{Name}[/]")
                .AddRow("Photo URL", Photo!.ToString())
                .AddRow("Has Fake", HasFake ? "[red]Yes[/]" : "[green]No[/]")
                .AddRow("Buy Price", $"[skyblue1]{BuyPrice.ToString()}[/]")
                .AddRow("Sell Price", $"[skyblue1]{SellPrice.ToString()}[/]").BorderColor(Color.Yellow2));
        AnsiConsole.MarkupLine($"[skyblue1]Description:[/] [darkolivegreen3_1]{MuseumDescription}[/]");
    }
}