using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetCategoryCommand : BaseEFCommand, IGetCategoryCommand
    {
        public EFGetCategoryCommand(OnlineShopContext context) : base(context)
        {
        }

        public CategoryDto Execute(int request)
        {
            var category = Context.Categories.Find(request);

            if (category == null)
                throw new EntityNotFoundException("Category");

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
                
                
            };

        }
    }
}
