using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public abstract class BaseEFCommand
    {
        protected readonly OnlineShopContext Context;

        protected BaseEFCommand(OnlineShopContext context)
        {
            Context = context;
        }


    }
}
