using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Analisis> Analisis { get; set; }
        public DbSet<AnalisisDetalle> AnalisisDetalle { get; set; }
        public DbSet<TipoAnalisis> TipoAnalisis { get; set; }
        public DbSet<Pago> Pago { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
