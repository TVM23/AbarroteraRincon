using AbarroteraRincon.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.AccesoDatos.Configuracion
{
    public class AreaPConfiguracion : IEntityTypeConfiguration<AreaP>
    {
        public void Configure(EntityTypeBuilder<AreaP> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Turno).IsRequired();
        }
    }
}
