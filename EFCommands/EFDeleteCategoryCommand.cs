using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteCategoryCommand : BaseEFCommand, IDeleteCategoryCommand
    {
        public EFDeleteCategoryCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var category = Context.Categories.Find(request);
            if(category == null)
            {
                throw new EntityNotFoundException("Category");
            }

            Context.Categories.Remove(category);

            Context.SaveChanges();

        }
    }
}
