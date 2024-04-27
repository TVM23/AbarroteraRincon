using AbarroteraRincon.AccesoDatos.Data;
using AbarroteraRincon.AccesoDatos.Repositorio.IRepositorio;
using AbarroteraRincon.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.AccesoDatos.Repositorio
{
    public class EmpleadoRepositorio : Repositorio<Empleado>, IEmpleadoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public EmpleadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Empleado empleado)
        {
            var empleadoDB = _db.Empleados.FirstOrDefault(b => b.Id == empleado.Id);
            if (empleadoDB != null)
            {
                empleadoDB.Apaterno = empleado.Apaterno;
                empleadoDB.Amaterno = empleado.Amaterno;
                empleadoDB.Nombre = empleado.Nombre;
                empleadoDB.Direccion = empleado.Direccion;
                empleadoDB.Telefono = empleado.Telefono;
                empleadoDB.PuestoId = empleado.PuestoId;
                empleadoDB.AreaPId = empleado.AreaPId;
                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            if (obj == "Puesto")
            {
                return _db.Puestos.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "AreaP")
            {
                return _db.AreasP.Select(c => new SelectListItem
                {
                    Text = c.Descripcion,
                    Value = c.Id.ToString()
                });
            }
            return null;
        }

    }
}
