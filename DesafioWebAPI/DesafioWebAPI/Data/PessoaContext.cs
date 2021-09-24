using DesafioWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.Data
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> opt) : base(opt)
        {                
        }

        public DbSet<Pessoa> pessoas { get; set; }

    }
}
