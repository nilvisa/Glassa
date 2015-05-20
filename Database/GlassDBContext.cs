using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Database.Models;

namespace Database
{
    public class GlassDBContext : DbContext
    {
       public DbSet<Glass> Glassar { get; set; }
    }
}
