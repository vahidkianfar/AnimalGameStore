using System.Text.Json.Nodes;
using AnimalGameStore.Models;
using Newtonsoft.Json;
namespace AnimalGameStore.HttpServices;

public static class GET
{
    public static async Task<Songs?> Song(int songID)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync($"https://acnhapi.com/v1/songs/{songID}");
        var responseString = await response.Content.ReadAsStringAsync();
        var song = JsonNode.Parse(responseString);
        var mySong = new Songs
        {
            Name = song!["name"]!["name-USen"]!.ToString(),
            BuyPrice = song["buy-price"]!=null ? JsonConvert.DeserializeObject<int>(song["buy-price"]!.ToString()) : 0,
            SellPrice = JsonConvert.DeserializeObject<int>(song["sell-price"]!.ToString()),
            isOrderable = (bool)song["isOrderable"]!,
            SongDownload = new Uri(song["music_uri"]!.ToString()),
            SongCover = new Uri(song["image_uri"]!.ToString()),
        };
        
        return mySong;
    }
    public static async Task<Fossils?> Fossil(string fossilName)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync($"https://acnhapi.com/v1/fossils/{fossilName}");
        var responseString = await response.Content.ReadAsStringAsync();
        var fossil = JsonNode.Parse(responseString);
        var myFossil = new Fossils
        {
            Name = fossil!["name"]!["name-USen"]!.ToString(),
            Price = JsonConvert.DeserializeObject<int>(fossil["price"]!.ToString()),
            MuseumPhrase = fossil["museum-phrase"]!.ToString(),
            Photo = new Uri (fossil["image_uri"]!.ToString()),
        };
        return myFossil;
    }
    
    public static async Task<Art?> Art(int artID)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync($"https://acnhapi.com/v1/art/{artID}");
        var responseString = await response.Content.ReadAsStringAsync();
        var art = JsonNode.Parse(responseString);
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