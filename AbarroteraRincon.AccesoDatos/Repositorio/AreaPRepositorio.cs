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
    public class AreaPRepositorio : Repositorio<AreaP>, IAreaPRepositorio
    {
        private readonly ApplicationDbContext _db;

        public AreaPRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(AreaP areap)
        {
            var areapDB = _db.AreasP.FirstOrDefault(b => b.Id == areap.Id);
            if (areapDB != null)
            {
                areapDB.Descripcion = areap.Descripcion;
                areapDB.Turno = areap.Turno;
                _db.SaveChanges();
            }
        }
    }
}
