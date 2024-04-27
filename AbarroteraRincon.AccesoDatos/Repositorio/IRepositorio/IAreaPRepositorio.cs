using AbarroteraRincon.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.AccesoDatos.Repositorio.IRepositorio
{
    public interface IAreaPRepositorio : IRepositorio<AreaP>
    {
        void Actualizar(AreaP areap);
    }
}
