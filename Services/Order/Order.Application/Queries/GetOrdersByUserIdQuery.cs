using CodeAcademy.Services.Order.Application.Dtos;
using CodeAcademy.Shared.Results;
using MediatR;

namespace CodeAcademy.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}