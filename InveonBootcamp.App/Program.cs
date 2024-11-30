// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using InveonBootcamp.App;
using InveonBootcamp.App.DIP;
using InveonBootcamp.App.LSP;

Console.WriteLine("Hello, World!");

var productServiceFactory = new ProductServiceFactory();

var productController = new ProductController(productServiceFactory.CreateProductService());

var products = productController.GetAll();

foreach (var product in products)
{
    Console.WriteLine($"Id: {product.Id} Price: {product.Price}");
}


//Phone phone = new Iphone();

//phone.Call();

//if (phone is ITakePhoto phoneTakePhoto)
//{
//    phoneTakePhoto.TakePhoto();
//}


//phone = new Nokia();
//phone.Call();
//if (phone is ITakePhoto nokia)
//{
//    nokia.TakePhoto();
//}


//Action method1 = () => Console.WriteLine("Merhaba Dünya");

//Predicate<int> method2 = (x) => x > 5;

//Func<decimal, int, decimal> funDelagate = (x, y) => x * 2;

//method1();

//SalaryCalculator salaryCalculator = new SalaryCalculator();
//var managerSalary = salaryCalculator.Calculate(1000, new SeniorDeveloperSalaryCalculate());


//var xSalary = salaryCalculator.CalculateAsDelegate(1000, ManagerSalary);

//var ySalary = salaryCalculator.CalculateAsDelegate(1000, (x) => x * 2);


//Console.WriteLine(managerSalary);

//static decimal ManagerSalary(decimal salary)
//{
//    return salary * 2;
//}