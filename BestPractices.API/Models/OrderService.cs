using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BestPractices.API.Models
{
    public class OrderService
    {
        public ServiceResult Create()
        {
            //


            var order = new Order();
            try
            {
                order.AddItem();
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

            // context.order.any(x=>x.orderId=updateOrder.Id)

            if (false)
            {
                //throw new Exception("Güncellemeye çalıştığınız sipariş bulunamadı");

                return  new ServiceResult()
                {
                    ProblemDetails = new ProblemDetails()
                    {
                        Title = ""
                    }
                }
            }


            return true;



            throw new Exception("");
        }
    }
}