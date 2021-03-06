using Spectre.Console;
namespace AnimalGameStore.Models;

public class Art
{
    public int Id { get; set; }
    public string Name { get; init; }
    public bool HasFake { get; init; }
    public int BuyPrice { get; init; }
    public int SellPrice { get; init; }
    public string? MuseumDescription{ get; init; }
    public Uri? Photo { get; init; }
    
    public void PrettyPrint()
    {
        Console.Clear();
        AnsiConsole.Write(
            new Table()
                .AddColumn(new TableColumn("Variable").Centered())
                .AddColumn(new TableColumn("Details").Centered())
                .AddRow("Art Name", $"[skyblue1]{char.ToUpper(Name[0]) + Name[1..]}[/]")
                .AddRow("Photo URL", Photo!.ToString())
                .AddRow("Has Fake", HasFake ? "[red]Yes[/]" : "[green]No[/]")
                .AddRow("Buy Price", $"[skyblue1]{BuyPrice.ToString()}[/]")
                .AddRow("Sell Price", $"[skyblue1]{SellPrice.ToString()}[/]").BorderColor(Color.Yellow2));
        AnsiConsole.MarkupLine($"[skyblue1]Description:[/] [darkolivegreen3_1]{MuseumDescription}[/]");
    }
}