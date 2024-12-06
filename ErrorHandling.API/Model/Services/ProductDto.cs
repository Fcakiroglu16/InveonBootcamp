using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.API.Model.Services
{
    public record ProductDto(int Id, string Name, decimal Price);
}