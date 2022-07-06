using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }
        
            public DbSet <Slider> Sliders { get; set; }
            public DbSet <Models.Image> Images { get; set; }
        
    } 
}
