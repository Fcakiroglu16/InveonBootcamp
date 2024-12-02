using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.App
{
    internal class ServiceOne
    {
        public async Task<bool> CancelExample()
        {
            var httpClient = new HttpClient();

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(10));

            var response = await httpClient.GetAsync("xxx", cancellationTokenSource.Token);

            return response.IsSuccessStatusCode;
        }

        internal async Task MultiThreadMethod()
        {
            //TPL Task Parallel Library


            Parallel.ForEach(Enumerable.Range(1, 1000).ToList(), new ParallelOptions()
            {
            }, x => { Console.WriteLine(x); });


            foreach (var i in Enumerable.Range(1, 1000).ToList())
            {
                Task.Run(() => { Console.WriteLine(i); });
            }
        }

        internal async Task<bool> MakeRequestToGoogle()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://www.google2222.com");

            var response2 = httpClient.GetAsync("https://www.microsoft222.com");


            var responseList = await Task.WhenAll(response, response2);

            foreach (var item in responseList)
            {
                if (!item.IsSuccessStatusCode)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<object> GetUser()
        {
            var httpClient = new HttpClient();

            List<Task<HttpResponseMessage>> responseMessageList = new();

            foreach (var i in Enumerable.Range(0, 10))
            {
                responseMessageList.Add(httpClient.GetAsync("https://www.google.com"));
            }


            var result10 = await Task.WhenAll(responseMessageList);


            var user = httpClient.GetAsync("https://www.google.com");

            var stock = httpClient.GetAsync("https://www.google.com");


            var discount = httpClient.GetAsync("https://www.google.com");


            var resultList = await Task.WhenAll(user, stock, discount);


            return new
            {
                User = resultList[0],
                Stock = resultList[1],
                Discount = resultList[2]
            };
        }


        public void AddLog(string message)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.PostAsync("https://www.google.com", new StringContent(message));

            httpClient.PostAsync("https://www.google.com", new StringContent(message)).ContinueWith(
                responseMessage =>
                {
                    //var result = responseMessage.Result;


                    if (responseMessage.IsFaulted)
                    {
                        Console.WriteLine("hata var");
                    }
                    else
                    {
                        var responseResult = responseMessage.Result;


                        if (!responseResult.IsSuccessStatusCode)
                        {
                        }
                    }
                });


            Console.WriteLine("Add Log Methodu çalışması bitti.");
        }
    }
}