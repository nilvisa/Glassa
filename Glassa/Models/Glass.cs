using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Glassa.Models
{
    public class Glass
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public int Price { get; set; }

        [Required]
        public string Maker { get; set; }
        public string Picture { get; set; }
        public bool Tasted { get; set; }
    }

    public class GlassDBContext : DbContext
    {
        public DbSet<Glass> Glassar { get; set; }
    }
}