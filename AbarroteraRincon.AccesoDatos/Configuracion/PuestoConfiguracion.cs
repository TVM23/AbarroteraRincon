﻿using AbarroteraRincon.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.AccesoDatos.Configuracion
{
    public class PuestoConfiguracion : IEntityTypeConfiguration<Puesto>
    {
        public void Configure(EntityTypeBuilder<Puesto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Salario).IsRequired();
            builder.Property(x => x.Horario).IsRequired();
        }
    }
}
