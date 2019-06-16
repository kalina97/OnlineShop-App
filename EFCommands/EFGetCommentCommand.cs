using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFGetCommentCommand : BaseEFCommand, IGetCommentCommand
    {
        public EFGetCommentCommand(OnlineShopContext context) : base(context)
        {
        }

        public CommentDto Execute(int request)
        {
            var comment = Context.Comments.Find(request);

            if (comment == null)
                throw new EntityNotFoundException("Comment");

            return new CommentDto
            {
                Id = comment.Id,
                UserId = comment.UserId,
                ProductId=comment.ProductId,
                CommentDesc=comment.CommentDesc
            };

        }
    }
}
