﻿using AbarroteraRincon.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarroteraRincon.AccesoDatos.Repositorio.IRepositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        void Actualizar(Producto Producto);
        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj); //Dependiendo de lo que se envie en el obj devuelve o marcas o categorias
    }
}
