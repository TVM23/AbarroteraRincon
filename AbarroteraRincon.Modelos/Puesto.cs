using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.Modelos
{
    public class Puesto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(60, ErrorMessage = "El nombre solo se compone de 60 caracteres como máximo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo tipo es requerido")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El salario es requerido")]
        public double Salario { get; set; }

        [Required(ErrorMessage = "El campo horario es requerido")]
        public string Horario { get; set; }

    }
}
