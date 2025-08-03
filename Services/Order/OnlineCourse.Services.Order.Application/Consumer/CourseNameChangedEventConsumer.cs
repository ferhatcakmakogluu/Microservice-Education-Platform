using MassTransit;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Services.Order.Infrastructure;
using OnlineCourse.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Services.Order.Application.Consumer
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly OrderDbContext _context;

        public CourseNameChangedEventConsumer(OrderDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var orderItems = await _context.OrderItems.Where(x=> x.ProductId == context.Message.CourseId).ToListAsync();

            orderItems.ForEach(x =>
            {
                x.UpdateOrderItem(context.Message.UpdatedName, x.PictureUrl, x.Price);
            });

            await _context.SaveChangesAsync();
        }
    }
}
