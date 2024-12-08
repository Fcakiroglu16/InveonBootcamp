using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BestPractices.API.Models
{
    public class OrderService
    {
        public ServiceResult Create()
        {
            var order = new Order();
            try
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return new ServiceResult();

            return new ServiceResult<string>()
            {
                Data = "xyz"
            };

            return new ServiceResult()
            {
                ProblemDetails = new ProblemDetails()
                {
                    Detail = "xyz"
                }
            };

            return new ServiceResult()
            {
                ProblemDetails = new ProblemDetails() { Status = 404 }
            };
        }

        public List<Order> GetAll()
        {
            return new List<Order>();
        }

        public ServiceResult Update(OrderUpdateDto updateOrder)
        {
            throw new Exception("");
        }
    }
}