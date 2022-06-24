using Spectre.Console;

namespace AnimalGameStore.Models;

public class Fossils
{
  public string? FileName { get; set; }
  public string? Name{ get; init; }
  public int Price{ get; init; }
  public string? MuseumPhrase{ get; init; }
  public Uri? Photo{ get; init; }
  public string? PartOf{ get; set; }

  public void PrettyPrint()
  {
    Console.Clear();
    AnsiConsole.Write(
      new Table()
        .AddColumn(new TableColumn("Variable").Centered())
        .AddColumn(new TableColumn("Details").Centered())
        .AddRow("Fossil Name", $"[skyblue1]{Name}[/]")
        .AddRow("Photo URL", Photo!.ToString())
        .AddRow("Price", $"[skyblue1]{Price.ToString()}[/]").BorderColor(Color.Yellow2));
    AnsiConsole.MarkupLine($"[skyblue1]Description:[/] [darkolivegreen3_1]{MuseumPhrase}[/]");
  }
}