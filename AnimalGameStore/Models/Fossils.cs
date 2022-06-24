namespace AnimalGameStore.Models;

public class Fossils
{
  public string FileName { get; set; }
  public string Name{ get; set; }
  public int Price{ get; set; }
  public string MuseumPhrase{ get; set; }
  public Uri Photo{ get; set; }
  public string PartOf{ get; set; }

  public void PrettyPrint()
  {
    Console.WriteLine("Name: " + Name);
    Console.WriteLine("Price: " + Price);
    Console.WriteLine("Photo URL: " + Photo);
    Console.WriteLine("Museum Phrase: " + MuseumPhrase);
  }
}