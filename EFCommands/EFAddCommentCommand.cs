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
    public class EFAddCommentCommand :IAddCommentCommand
    {
        private readonly IEmailSender _emailSender;
        private readonly OnlineShopContext _context;

        public EFAddCommentCommand(IEmailSender emailSender, OnlineShopContext context)
        {
            _emailSender = emailSender;
            _context = context;
        }

        public void Execute(CommentDto request)
        {

            if (!_context.Users.Any(u => u.Id == request.UserId))
            {
                throw new EntityNotFoundException("User");

            }


            if (!_context.Products.Any(u => u.Id == request.ProductId))
            {
                throw new EntityNotFoundException("Product");

            }


            _context.Comments.Add(new Domain.Comment
            {
                ProductId=request.ProductId,
                UserId=request.UserId,
                CommentDesc=request.CommentDesc

            });

            _context.SaveChanges();

            _emailSender.Subject = "Successful Comment";
            _emailSender.Body = "User successfully commented on product!";
            _emailSender.ToEmail = "kalincevicnikola8@gmail.com";
            _emailSender.Send();

        }

    }
}
