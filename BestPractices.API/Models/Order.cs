using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    //Rich Domain Model / Anemic Domain Model
    public class Order
    {
        public string Code { get; set; }

        private List<OrderItem> Items { get; set; }


        public void CreateCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new Exception("Code can't be null or empty");
            }

            if (code.Length < 7)
            {
            }

            Code = code;
        }

        public void AddItem(OrderItem item)
        {
            if (item.Price > 50)
            {
            }

            if (Items.Count >= 3)
            {
                throw new Exception("You can't add more than 3 items to the order");
            }

            if (Items.Sum(x => x.Price) > 5000)
            {
                throw new Exception("You can't add more than 5000$ to the order");
            }


            Items.Add(item);
        }
    }
}