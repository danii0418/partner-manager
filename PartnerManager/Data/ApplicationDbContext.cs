using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PartnerManager.Models;

namespace PartnerManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Afiliado> Afiliados { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
