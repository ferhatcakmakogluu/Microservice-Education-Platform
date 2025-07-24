using MediatR;
using OnlineCourse.Services.Order.Application.Commands;
using OnlineCourse.Services.Order.Application.Dtos;
using OnlineCourse.Services.Order.Domain.OrderAggregate;
using OnlineCourse.Services.Order.Infrastructure;
using OnlineCourse.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineCourse.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _dbContext;

        public CreateOrderCommandHandler(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(
                        request.AddressDto.Province,
                        request.AddressDto.District,
                        request.AddressDto.Street,
                        request.AddressDto.ZipCode,
                        request.AddressDto.Line);

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });

            await _dbContext.Orders.AddAsync(newOrder);
            await _dbContext.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto{ OrderId = newOrder.Id }, 200);
        }
    }
}
