using AnimalGameStore.HttpServices;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using AnimalGameStore.Models;
using FluentAssertions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameTests;

public class ArtTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Retrieve_Art_From_API()
    {
        var client = new HttpClient();
        var response = client.GetAsync($"http://acnhapi.com/v1/art/1");
        Assert.That(response, Is.Not.Null);
    }
    [Test]
    public void Convert_Result_To_Json_Object()
    {
        var client = new HttpClient();
        var response = client.GetAsync($"http://acnhapi.com/v1/art/1");
        var json = response.Result.Content.ReadAsStringAsync().Result;
        var fossil = JsonNode.Parse(json);
        fossil.Should().BeOfType<JsonObject>();
    }
    [Test]
    public void Retrieve_Art_Name_From_Converted_JSON_Object()
    {
        var client = new HttpClient();
        var artID=1;
        var response = client.GetAsync($"http://acnhapi.com/v1/art/{artID}");
        var json = response.Result.Content.ReadAsStringAsync().Result;
        var art = JsonNode.Parse(json);
        Assert.That(art!["name"]!["name-USen"]!.ToString(), Is.EqualTo("academic painting"));
    }
    [Test]
    public void GET_Art_Should_Return_Art_Object()
    {
        var result = GET.Art(1);
        Assert.That(result, Is.TypeOf(typeof(Art)));
    }
}