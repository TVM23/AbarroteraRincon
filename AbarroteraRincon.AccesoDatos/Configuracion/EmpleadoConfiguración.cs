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
    public class EmpleadoConfiguracion : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Apaterno).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Amaterno).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Telefono).IsRequired().HasMaxLength(10);

            //Hagamos relaciones en fluent API

            builder.HasOne(x => x.Puesto).WithMany()
                .HasForeignKey(x => x.PuestoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AreaP).WithMany()
                .HasForeignKey(x => x.AreaPId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
