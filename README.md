# Exemplo-MVC

Uma aplicação simples utilizando MVC C# Asp.net Core com Entity Framework

## Script do Banco de Dados (SQL Server)

```sql

  CREATE TABLE Aluno (
    idAluno int primary key identity(1,1),
    nomeAluno varchar(100),
    dataNascimento datetime,
    idEscola int
  )
  CREATE TABLE Escola (
    idEscola int primary key identity(1,1),
    nomeEscola varchar(100)
  )

  ALTER TABLE Aluno ADD CONSTRAINT FK_Aluno_Escola
  FOREIGN KEY (idEscola) REFERENCES Escola (idEscola)
  
```

## Context do Entity Framework

```c#
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
```

## Startup

```c#
 
    ...
  
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ProjetoContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProjetoContext")));
        }
        
        ...
        
```

