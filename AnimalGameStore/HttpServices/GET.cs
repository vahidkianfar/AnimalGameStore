﻿using System.Text.Json.Nodes;
using AnimalGameStore.Models;
using Newtonsoft.Json;

namespace AnimalGameStore.HttpServices;

public class GET
{
    public static Fossils Fossil(string fossilName)
    {
        var client = new HttpClient();
      
        var response = client.GetAsync($"https://acnhapi.com/v1/fossils/{fossilName}");
        var json = response.Result.Content.ReadAsStringAsync().Result;
        var fossil = JsonNode.Parse(json);
        var myFossil = new Fossils
        {
            FileName = fossil!["file-name"]!.ToString(),
            Name = fossil["name"]!["name-USen"]!.ToString(),
            Price = JsonConvert.DeserializeObject<int>(fossil["price"]!.ToString()),
            MuseumPhrase = fossil["museum-phrase"]!.ToString(),
            Photo = new Uri (fossil["image_uri"]!.ToString()),
           
        };
        
        return myFossil;
    }
    public static Art Art(int artId)
    {
        var client = new HttpClient();
      
        var response = client.GetAsync($"https://acnhapi.com/v1/art/{artId}");
        var json = response.Result.Content.ReadAsStringAsync().Result;
        var art = JsonNode.Parse(json);
        var myArt = new Art
        {
            Name = art!["name"]!["name-USen"]!.ToString(),
            BuyPrice = JsonConvert.DeserializeObject<int>(art["buy-price"]!.ToString()), 
            SellPrice = JsonConvert.DeserializeObject<int>(art["sell-price"]!.ToString()),
            MuseumDescription = art["museum-desc"]!.ToString(),
            Photo = new Uri (art["image_uri"]!.ToString()),
        };
        return myArt;
    }
}