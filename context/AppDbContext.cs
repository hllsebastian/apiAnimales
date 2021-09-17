using apiAnimales.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Aca se define un intermediario que conecta el modelo con el controlador

namespace apiAnimales.context
{
    public class AppDbContext : DbContext // Se importa el paquete Microsoft.EntityFrameworkCore para usar DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) // Se creo este constructor
        {

        }

        // Se hace la representacion de la tabla. Este nombre debe coincidir con el nombre de la tabla en el SMDB
        public DbSet<Animales> animales { get; set; } 
    }
}
