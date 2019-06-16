using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteCommentCommand : BaseEFCommand, IDeleteCommentCommand
    {
        public EFDeleteCommentCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var comment = Context.Comments.Find(request);
            if (comment == null)
            {
                throw new EntityNotFoundException("Comment");
            }

            Context.Comments.Remove(comment);

            Context.SaveChanges();

        }

    }
}
