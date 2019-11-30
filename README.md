# Exemplo-MVC

Uma aplicação simples utilizando MVC C# Asp.net Core com Entity Framework

## Context do Entity Framework

```c#
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using DiegoEscola.Web.Models;

  namespace DiegoEscola.Web.Models
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
```
