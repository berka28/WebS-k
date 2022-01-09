using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSäk.Models;

namespace WebSäk.Data
{
    public class WebSäkContext : DbContext
    {
        public WebSäkContext (DbContextOptions<WebSäkContext> options)
            : base(options)
        {
        }

        public DbSet<WebSäk.Models.Comment> Comment { get; set; }
        public DbSet<WebSäk.Models.AppFile> AppFile { get; set; }
    }
}
