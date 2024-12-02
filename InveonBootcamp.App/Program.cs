// See https://aka.ms/new-console-template for more information


using InveonBootcamp.App;

Console.WriteLine("Hello, World!");

var serviceOne = new ServiceOne();

await serviceOne.MultiThreadMethod();


var key = Console.ReadLine();

//var result = await serviceOne.MakeRequestToGoogle();