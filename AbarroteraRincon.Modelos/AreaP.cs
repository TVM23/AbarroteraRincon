using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.Modelos
{
    public class AreaP
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo descripcion es requerido")]
        [MaxLength(100, ErrorMessage = "La descripción solo se compone de 100 caracteres como máximo")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo turno es requerido")]
        public string Turno { get; set; }

    }
}
