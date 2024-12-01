using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.API.Models
{
    //public class RichDomainModel
    //{
    //    public string Code { get; init; }

    //    public RichDomainModel CreateCode()
    //    {
    //        return new RichDomainModel()
    //        {
    //            Code = "abc"
    //        };
    //    }
    //}


    public record OrderCreateDto(int Id, string UserId);


    public class OrderCreatedDto2
    {
        public int Id { get; init; }
        public string UserId { get; init; }

        public DateTime Created { get; set; }

        public OrderCreatedDto2(int id, string userId)
        {
            Id = id;
            UserId = userId;
            Created = DateTime.Now;
        }

        public static OrderCreatedDto2 Create(int id, string userId)
        {
            return new OrderCreatedDto2(id, userId);
        }
    }
}