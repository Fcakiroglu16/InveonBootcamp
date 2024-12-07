using Microsoft.AspNetCore.Server.HttpSys;
using System.Collections.Immutable;

namespace DesignPattern.API.Models.Repositories
{


    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }





    }
}
