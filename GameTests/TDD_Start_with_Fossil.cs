using AnimalGameStore.HttpServices;
using NUnit.Framework;
using System.Text.Json.Nodes;
using AnimalGameStore.Models;
using FluentAssertions;

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
    public void Convert_Result_To_Json_Object()
    {
        var client = new HttpClient();
        var response = client.GetAsync($"https://acnhapi.com/v1/fossils/amber");
        var json = response.Result.Content.ReadAsStringAsync().Result;
        var fossil = JsonNode.Parse(json);
        fossil.Should().BeOfType<JsonObject>();
    }
    [Test]
    public void GET_Fossil_Should_Retrieve_Fossil_Name_From_Converted_JSON_Object()
    {
        var client = new HttpClient();
        var fossilName="amber";
        var response = client.GetAsync($"https://acnhapi.com/v1/fossils/{fossilName}");
        var json = response.Result.Content.ReadAsStringAsync().Result;
        var fossil = JsonNode.Parse(json);

        Assert.That(fossil!["file-name"]!.ToString(), Is.EqualTo(fossilName));
    }
    [Test]
    public async Task GET_Fossil_Should_Return_Fossil_Object()
    {
        var result = await GET.Fossil("amber");
        Assert.That(result, Is.TypeOf(typeof(Fossils)));
    }

    [Test]
    public async Task GET_Fossil_Should_Retrieve_Correct_Value_For_FossilName()
    {
        var result = await GET.Fossil("amber");
        Assert.Multiple(() =>
        {
            Assert.That(result.Name, Is.EqualTo("amber"));
            Assert.That(result.Price, Is.EqualTo(1200));
            Assert.That(result.Photo, Is.EqualTo(new Uri("https://acnhapi.com/v1/images/fossils/amber")));
        });
    }
}