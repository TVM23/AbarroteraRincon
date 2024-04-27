using AbarroteraRincon.AccesoDatos.Data;
using AbarroteraRincon.AccesoDatos.Repositorio.IRepositorio;
using AbarroteraRincon.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.AccesoDatos.Repositorio
{
    public class PuestoRepositorio : Repositorio<Puesto>, IPuestoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PuestoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Puesto puesto)
        {
            var puestoDB = _db.Puestos.FirstOrDefault(b => b.Id == puesto.Id);
            if (puestoDB != null)
            {
                puestoDB.Nombre = puesto.Nombre;
                puestoDB.Tipo = puesto.Tipo;
                puestoDB.Salario = puesto.Salario;
                puestoDB.Horario = puesto.Horario;
                _db.SaveChanges();
            }
        }
    }
}
