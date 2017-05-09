using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCSQLServerDemo.DAL
{
    public class OperasInitializer:DropCreateDatabaseAlways<OperaContext>
    {
        protected override void Seed(OperaContext context)
        {
            base.Seed(context);
            context.Operas.Add(new Models.Opera() { Title="1",Year=1968,Composer="May"});
            context.SaveChanges();
        }
    }
}