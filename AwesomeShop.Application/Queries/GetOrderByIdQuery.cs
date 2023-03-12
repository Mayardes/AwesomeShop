using AwesomeShop.Application.Dtos.ViewModels;
using MediatR;

namespace AwesomeShop.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderViewModel>
    {
        public Guid Id { get; private set; }

        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
