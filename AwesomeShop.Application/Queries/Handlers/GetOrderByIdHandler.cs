using AwesomeShop.Application.Dtos.ViewModels;
using AwesomeShop.Domain.Repositories;
using MediatR;

namespace AwesomeShop.Application.Queries.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderViewModel>
    {
        private readonly IOrderRepository _orderRespository;
        public GetOrderByIdHandler(IOrderRepository orderRespository)
        {
            _orderRespository = orderRespository;
        }
        public async Task<OrderViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRespository.GetByIdAsync(request.Id);

            var orderViewModel = OrderViewModel.FromEntity(order);

            return orderViewModel;
        }
    }
}
