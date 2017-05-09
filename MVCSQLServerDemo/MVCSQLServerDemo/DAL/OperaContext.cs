using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCSQLServerDemo.Models;

namespace MVCSQLServerDemo.DAL
{
    public class OperaContext:DbContext
    {
        public DbSet<Opera> Operas { get; set; }
    }
}