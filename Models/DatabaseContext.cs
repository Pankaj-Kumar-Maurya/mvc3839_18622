using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc3839_18622.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("xyz")
            {
            
            }
        public DbSet<tblreg> tblregs { get; set; }
    }
}