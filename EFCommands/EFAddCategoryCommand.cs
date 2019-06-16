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
    public class EFAddCategoryCommand : BaseEFCommand, IAddCategoryCommand
    {
        public EFAddCategoryCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {

            if (Context.Categories.Any(c => c.Name == request.Name))
            {
                throw new EntityAlreadyExistsException("Category name");

            }

            Context.Categories.Add(new Domain.Category
            {
                
                Name=request.Name

            });

            Context.SaveChanges();

        }

    }

}

