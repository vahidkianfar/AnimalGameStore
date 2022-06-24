namespace AnimalGameStore.Models;

public class Art
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool HasFake { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string MuseumDescription{ get; set; }
    public Uri Photo { get; set; }
    
    public void PrettyPrint()
    {
        Console.WriteLine("ID: " + Id);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("hasFake: " + HasFake);
        Console.WriteLine("BuyPrice: " + BuyPrice);
        Console.WriteLine("SellPrice: " + SellPrice);
        Console.WriteLine("Photo: " + Photo);
        Console.WriteLine("Museum Description: " + MuseumDescription);
    }
}