using AnimalGameStore.HttpServices;
using NUnit.Framework;
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
        //Console.WriteLine(response.Result.Content.ReadAsStringAsync().Result);
        Assert.IsNotNull(response);
    }
}