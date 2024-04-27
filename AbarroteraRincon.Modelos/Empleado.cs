using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.Modelos
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo del apellido paterno es requerido")]
        [MaxLength(20, ErrorMessage = "El apellido paterno solo se compone de 20 caracteres como máximo")]
        public string Apaterno { get; set; }

        [Required(ErrorMessage = "El campo del apellido materno es requerido")]
        [MaxLength(20, ErrorMessage = "El apellido materno solo se compone de 20 caracteres como máximo")]
        public string Amaterno { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(30, ErrorMessage = "El nombre solo se compone de 30 caracteres como máximo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo dirección es requerido")]
        [MaxLength(60, ErrorMessage = "La dirección solo se compone de 60 caracteres como máximo")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo teléfono es requerido")]
        [MaxLength(10, ErrorMessage = "El teléfono solo se compone de 10 caracteres como máximo")]
        public string Telefono { get; set; }

        //Hagamos la relación con la tabla Puesto
        [Required(ErrorMessage = "El puesto es requerido")]
        public int PuestoId { get; set; }
        [ForeignKey("PuestoId")]
        public Puesto Puesto { get; set; }

        //Hagamos la relacion con la tabla Area
        [Required(ErrorMessage = "El area es requerido")]
        public int AreaPId { get; set; }
        [ForeignKey("AreaPId")]
        public AreaP AreaP { get; set; }


    }
}
