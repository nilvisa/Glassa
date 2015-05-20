using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Database.Models
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
}