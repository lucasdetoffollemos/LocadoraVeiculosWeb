﻿using LocadoraVeiculos.Dominio.CupomModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.CupomModule
{
    public class CupomConfiguration : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> entity)
        {
            entity.ToTable("TBCupom");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.DataValidade)
                .HasColumnType("date")
                .IsRequired();

            entity.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            entity.Property(e => e.Valor)
                .HasDefaultValue(0)
                .HasColumnType("decimal(18, 0)");

            entity.Property(e => e.ValorMinimo)
                .HasDefaultValue(0)
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(e => e.Parceiro)
                .WithMany(p => p.Cupons)
                .HasForeignKey(p => p.ParceiroId);
        }
    }
}