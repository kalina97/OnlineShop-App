using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFAddOrderCommand : IAddOrderCommand
    {
        private readonly IEmailSender _emailSender;
        private readonly OnlineShopContext _context;

        public EFAddOrderCommand(IEmailSender emailSender, OnlineShopContext context)
        {
            _emailSender = emailSender;
            _context = context;
        }

        public void Execute(CreateOrderDto request)
        {

            if (!_context.Users.Any(c => c.Id == request.UserId))
            {
                throw new EntityNotFoundException("User");
                
            }



            _context.Orders.Add(new Domain.Order
            {
               UserId=request.UserId,
               Quantity=request.Quantity

            });

            _context.SaveChanges();

            _emailSender.Subject = "Successful Ordering";
            _emailSender.Body = "User successfully created order!";
            _emailSender.ToEmail = "kalincevicnikola8@gmail.com";
            _emailSender.Send();


        }

    }
}
