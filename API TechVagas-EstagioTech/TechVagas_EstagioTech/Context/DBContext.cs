﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<TipoEstagioModel> TipoEstagio { get; set; }
        public DbSet<CursoModel> Curso { get; set; }
        public DbSet<TipoDocumentoModel> TipoDocumento { get; set; }
        public DbSet<DocumentoModel> Documento { get; set; }
		
        public DbSet<VagasModel> Vagas { get; set; }
        public DbSet<CargoModel> Cargos { get; set; }
		public DbSet<ConcedenteModel> Concedentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
			//Curso
			modelBuilder.Entity<CursoModel>().HasKey(x => x.idCurso);
			modelBuilder.Entity<CursoModel>().Property(x => x.nomeCurso).IsRequired().HasMaxLength(200);

			//Documento
			modelBuilder.Entity<DocumentoModel>().HasKey(x => x.idDocumento);
			modelBuilder.Entity<DocumentoModel>().Property(x => x.descricaoDocumento).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<DocumentoModel>().Property(x => x.documento).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<DocumentoModel>().Property(x => x.situacaoDocumento).IsRequired().HasMaxLength(200);

			//TipoDocumento
			modelBuilder.Entity<TipoDocumentoModel>().HasKey(x => x.idTipoDocumento);
			modelBuilder.Entity<TipoDocumentoModel>().Property(x => x.descricaoTipoDocumento).IsRequired().HasMaxLength(200);

			//TipoEstagio
			modelBuilder.Entity<TipoEstagioModel>().HasKey(x => x.idTipoEstagio);
			modelBuilder.Entity<TipoEstagioModel>().Property(x => x.descricaoTipoEstagio).IsRequired().HasMaxLength(200);

            //Vagas
            modelBuilder.Entity<VagasModel>().HasKey(x => x.VagasId);
			modelBuilder.Entity<VagasModel>().Property(x => x.Quantidade).IsRequired();
			modelBuilder.Entity<VagasModel>().Property(x => x.DataPublicacao).IsRequired();
			modelBuilder.Entity<VagasModel>().Property(x => x.DataLimite).IsRequired();
			modelBuilder.Entity<VagasModel>().Property(x => x.Localidade).IsRequired().HasMaxLength(80);
			modelBuilder.Entity<VagasModel>().Property(x => x.Descricao).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<VagasModel>().Property(x => x.Titulo).IsRequired().HasMaxLength(80);
			modelBuilder.Entity<VagasModel>().Property(x => x.LocalidadeTrabalho).IsRequired().HasMaxLength(20);
			modelBuilder.Entity<VagasModel>().Property(x => x.HorarioEntrada).IsRequired().HasMaxLength(20);
			modelBuilder.Entity<VagasModel>().Property(x => x.HorarioSaida).IsRequired().HasMaxLength(20);
			modelBuilder.Entity<VagasModel>().Property(x => x.TotalHorasSemanis).IsRequired().HasMaxLength(20);

            //Concedente
            modelBuilder.Entity<ConcedenteModel>().HasKey(x => x.concedenteId);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.RazaoSocial);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.ResponsavelEstagio);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.Cnpj);
            modelBuilder.Entity<ConcedenteModel>().Property(x => x.Localidade);

			//Relacionamento: Concedente -> Vagas
			modelBuilder.Entity<ConcedenteModel>()
				.HasMany(c => c.Vagas)
				.WithOne(c => c.Concedente)
				.IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Cargo
            modelBuilder.Entity<CargoModel>().HasKey(x => x.CargoId);
            modelBuilder.Entity<CargoModel>().Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<CargoModel>().Property(x => x.Tipo).IsRequired().HasMaxLength(50);

            //Relacionamento: Cargo -> Vagas
            modelBuilder.Entity<VagasModel>()
				.HasMany(c => c.Cargos)
				.WithOne(v => v.Vagas)
				.IsRequired().OnDelete(DeleteBehavior.Cascade);


        }
    }
}
