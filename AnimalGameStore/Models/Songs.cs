using Spectre.Console;

namespace AnimalGameStore.Models;

public class Songs
{
    public int ID { get; set; }
    public string Name { get; init; }
    public int BuyPrice { get; init; }
    public int SellPrice { get; init; }
    public bool isOrderable { get; init; }
    public Uri SongDownload { get; init; }
    public Uri SongCover { get; init; }
    
    public void PrettyPrint()
    {
        Console.Clear();
        AnsiConsole.Write(
            new Table()
                .AddColumn(new TableColumn("Variable").Centered())
                .AddColumn(new TableColumn("Details").Centered())
                .AddRow("Song Name", $"[skyblue1]{Name}[/]")
                .AddRow("Download Demo", SongDownload.ToString())
                .AddRow("Is Orderable", isOrderable ? "[green]Yes[/]" : "[red]No[/]")
                .AddRow("Buy Price", $"[skyblue1]{BuyPrice.ToString()}[/]")
                .AddRow("Sell Price", $"[skyblue1]{SellPrice.ToString()}[/]")
                .AddRow("Song Cover", SongCover.ToString()).BorderColor(Color.Yellow2));
    }
}