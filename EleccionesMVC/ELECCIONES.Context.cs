﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EleccionesMVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ELECCIONESEntities : DbContext
    {
        public ELECCIONESEntities()
            : base("name=ELECCIONESEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Candidato> Candidatos { get; set; }
        public virtual DbSet<Partido_Politico> Partido_Politico { get; set; }
        public virtual DbSet<Votante> Votantes { get; set; }
        public virtual DbSet<VotosResultado> VotosResultados { get; set; }
    }
}
