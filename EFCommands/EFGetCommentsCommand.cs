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
    public class EFGetCommentsCommand : BaseEFCommand, IGetCommentsCommand
    {
        public EFGetCommentsCommand(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<CommentDto> Execute(CommentSearch request)
        {
            var query = Context.Comments.AsQueryable();

            if (request.CommentDesc != null)
            {
                query = query.Where(c=>c.CommentDesc
                .ToLower()
                .Contains(request.CommentDesc.ToLower()));
            }

            return query.Select(b => new CommentDto
            {
                Id = b.Id,
                UserId=b.UserId,
                ProductId=b.ProductId,
                CommentDesc=b.CommentDesc
        

            });
        }
    }
}
