// See https://aka.ms/new-console-template for more information


using System.Text.Json;
using System.Text.Json.Nodes;
using AnimalGameStore.HttpServices;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

Console.WriteLine("Hello, World!");
// var myFossil = GET.Fossil("amber");
//
// myFossil.PrettyPrint();

// Console.Write("Enter Fossil name:");
// var inputFossil=Console.ReadLine();
// var myFossil = GET.Fossil(inputFossil);
// myFossil.prettyPrint();

Console.Write("Enter Art ID:");
var inputArt=Convert.ToInt32(Console.ReadLine());
var myArt = GET.Art(inputArt);
myArt.PrettyPrint();