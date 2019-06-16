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
    public class EFEditCategoryCommand : BaseEFCommand, IEditCategoryCommand
    {
        public EFEditCategoryCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            var category = Context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException("Category");
            }

            if (category.Name != request.Name)
            {
                if (Context.Categories.Any(c => c.Name == request.Name))
                {
                    throw new EntityAlreadyExistsException("Category name");
                }

                category.Name = request.Name;

                Context.SaveChanges();
            }

        }


    }
}
