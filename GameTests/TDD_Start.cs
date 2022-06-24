using AnimalGameStore.HttpServices;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using FluentAssertions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Create_Http_Client_To_Connect_With_API()
    {
        var client = new HttpClient();
        Assert.That(client, Is.Not.Null);
    }
    [Test]
    public void Http_GET_To_Retrieve_Fossil_From_API()
    {
        var client = new HttpClient();
        var response = client.GetAsync($"https://acnhapi.com/v1/fossils/amber");
        Assert.That(response, Is.Not.Null);
    }
    [Test]
    public void Http_GET_Convert_Result_To_Json_Object()
    {
        var client = new HttpClient();
        var response = client.GetAsync($"https://acnhapi.com/v1/fossils/amber");
        var json = response.Result.Content.ReadAsStringAsync().Result;
        var fossil = JsonNode.Parse(json);
        fossil.Should().BeOfType<JsonObject>();
    }
    [Test]
    public void Retrieve_Fossil_Name_From_Converted_JSON_Object()
    {
        var client = new HttpClient();
        var fossilName="amber";
        var response = client.GetAsync($"https://acnhapi.com/v1/fossils/{fossilName}");
        var json = response.Result.Content.ReadAsStringAsync().Result;
        var fossil = JsonNode.Parse(json);

        Assert.That(fossil["file-name"]!.ToString(), Is.EqualTo(fossilName));
    }
}