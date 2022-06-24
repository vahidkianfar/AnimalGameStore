using System.Text.Json.Nodes;
using AnimalGameStore.Models;
using Newtonsoft.Json;

namespace AnimalGameStore.HttpServices;

public static class GET
{
    public static async Task<Fossils> Fossil(string fossilName)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync($"https://acnhapi.com/v1/fossils/{fossilName}");
        var json = await response.Content.ReadAsStringAsync();
        var fossil = JsonNode.Parse(json);
        var myFossil = new Fossils
        {
            Name = fossil!["name"]!["name-USen"]!.ToString(),
            Price = JsonConvert.DeserializeObject<int>(fossil["price"]!.ToString()),
            MuseumPhrase = fossil["museum-phrase"]!.ToString(),
            Photo = new Uri (fossil["image_uri"]!.ToString()),
        };
        return myFossil;
    }
    public static async Task<Art> Art(int artID)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync($"https://acnhapi.com/v1/art/{artID}");
        var json = await response.Content.ReadAsStringAsync();
        var art = JsonNode.Parse(json);
        var myArt = new Art
        {
            Name = art!["name"]!["name-USen"]!.ToString(),
            BuyPrice = JsonConvert.DeserializeObject<int>(art["buy-price"]!.ToString()), 
            SellPrice = JsonConvert.DeserializeObject<int>(art["sell-price"]!.ToString()),
            MuseumDescription = art["museum-desc"]!.ToString(),
            HasFake = (bool)art["hasFake"]!,
            Photo = new Uri (art["image_uri"]!.ToString()),
        };
        return myArt;
    }
}