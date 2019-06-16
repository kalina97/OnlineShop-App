using Application.Commands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetOrdersCommand : BaseEFCommand ,IGetOrdersCommand
    {
        public EFGetOrdersCommand(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<OrderDto> Execute(OrderSearch request)
        {
            var query = Context.Orders.AsQueryable();

            return query.Select(b => new OrderDto
            {
                Id = b.Id,
                Quantity=b.Quantity,
                UserId=b.UserId,
                OrderProducts=b.OrderProducts.Select(x=>new ProductOrderDto
                {
                    ProductId=x.ProductId,
                    OrderId=x.OrderId,
                    Product=x.Product,
                    Order=x.Order

                }).ToList()
               
            }).ToList();
        }

    }
}
