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

