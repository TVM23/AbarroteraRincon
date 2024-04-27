using AbarroteraRincon.AccesoDatos.Repositorio.IRepositorio;
using AbarroteraRincon.Modelos;
using AbarroteraRincon.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace AbarroteraRincon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AreaPController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public AreaPController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Metodo Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            AreaP areap = new AreaP();
            if (id == null)
            {
                //creamos un nuevo registro
                return View(areap);
            }
            areap = await _unidadTrabajo.AreaP.Obtener(id.GetValueOrDefault());
            if (areap == null)
            {
                return NotFound();
            }
            return View(areap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AreaP areap)
        {
            if (ModelState.IsValid)
            {
                if (areap.Id == 0)
                {
                    await _unidadTrabajo.AreaP.Agregar(areap);
                    TempData[Ds.Exitosa] = "El area Se Creo Con Exito";
                }
                else
                {
                    _unidadTrabajo.AreaP.Actualizar(areap);
                    TempData[Ds.Exitosa] = "El area Se Actualizo Con Exito";

                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[Ds.Error] = "Error al Grabar el area";
            return View(areap);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var areapDB = await _unidadTrabajo.AreaP.Obtener(id);
            if (areapDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la base de datos" });
            }
            _unidadTrabajo.AreaP.Remover(areapDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Area eliminada con éxito" });

        }

        #region API
        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.AreaP.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Descripcion.ToLower().Trim()
                        == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Descripcion.ToLower().Trim()
                        == nombre.ToLower().Trim() && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.AreaP.ObtenerTodos();
            return Json(new { data = todos });
        }
        #endregion
    }
}
