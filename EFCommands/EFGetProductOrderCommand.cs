using Application.Commands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetProductOrderCommand : BaseEFCommand, IGetProductOrderCommand
    {
        public EFGetProductOrderCommand(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<OrderDto> Execute(ProductOrderSearch request)
        {
            var orders = Context.Orders.AsQueryable().
                Include(p => p.OrderProducts).
                ThenInclude(pa => pa.Product);

            return orders.Select(a => new OrderDto
            {
                Id=a.Id,
                UserId=a.UserId,
                Quantity=a.Quantity,
                OrderProducts=a.OrderProducts.Select(x=>new ProductOrderDto
                {
                    Product=x.Product,
                    Order=x.Order,
                    ProductId=x.ProductId,
                    OrderId=x.OrderId

                }).ToList()
                
              

            }).ToList();

        }
    }
}
