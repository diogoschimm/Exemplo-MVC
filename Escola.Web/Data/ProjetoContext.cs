using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EscolaDRS.Web.Models;

namespace EscolaDRS.Web.Models
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext (DbContextOptions<ProjetoContext> options)
            : base(options)
        {
        }

        public DbSet<Escola> Escola { get; set; }

        public DbSet<Aluno> Aluno { get; set; }
    }
}
