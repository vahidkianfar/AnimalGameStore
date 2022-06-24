using Spectre.Console;

namespace AnimalGameStore.Models;

public class Fossils
{
  public string? FileName { get; set; }
  public string? Name{ get; set; }
  public int Price{ get; set; }
  public string? MuseumPhrase{ get; set; }
  public Uri? Photo{ get; set; }
  public string? PartOf{ get; set; }

  public void PrettyPrint()
  {
    Console.Clear();
    AnsiConsole.Write(
      new Table()
        .AddColumn(new TableColumn("Setting").Centered())
        .AddColumn(new TableColumn("Details").Centered())
        .AddRow("Fossil Name", $"[skyblue1]{Name}[/]")
        .AddRow("Photo URL", Photo!.ToString())
        .AddRow("Price", $"[skyblue1]{Price.ToString()}[/]").BorderColor(Color.Yellow2));
    AnsiConsole.MarkupLine($"[skyblue1]Description:[/] [darkolivegreen3_1]{MuseumPhrase}[/]");
    
  }
}