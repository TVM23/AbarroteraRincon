using AbarroteraRincon.AccesoDatos.Repositorio.IRepositorio;
using AbarroteraRincon.Modelos;
using AbarroteraRincon.Modelos.ViewModels;
using AbarroteraRincon.Utilidades;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AbarroteraRincon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmpleadoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public EmpleadoController(IUnidadTrabajo unidadTrabajo)
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
            EmpleadoVM empleadoVM = new EmpleadoVM()
            {
                Empleado = new Empleado(),
                PuestoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Puesto"),
                AreaPLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("AreaP")
            };
            if (id == null)
            {
                //Crear un producto nuevo
                return View(empleadoVM);
            }
            else
            {
                //Actualizar un producto existente
                empleadoVM.Empleado = await _unidadTrabajo.Empleado.Obtener(id.GetValueOrDefault());
                if (empleadoVM.Empleado == null)
                {
                    return NotFound();
                }
                return View(empleadoVM);
            }

        }

        #region API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(EmpleadoVM empleadoVM)
        {
            if (ModelState.IsValid)
            {
                if (empleadoVM.Empleado.Id == 0)
                {
                    await _unidadTrabajo.Empleado.Agregar(empleadoVM.Empleado);
                    TempData[Ds.Exitosa] = "El empleado Se Ingreso Con Exito";
                }
                else
                {
                    _unidadTrabajo.Empleado.Actualizar(empleadoVM.Empleado);
                    TempData[Ds.Exitosa] = "El empleado Se Actualizo Con Exito";
                }
                await _unidadTrabajo.Guardar();
                return View("Index");
            }
            TempData[Ds.Error] = "Error al guardar el empleado";
            empleadoVM.PuestoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Puesto");
            empleadoVM.AreaPLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("AreaP");
            return View(empleadoVM);
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Empleado.ObtenerTodos(incluirPropiedades: "Puesto,AreaP");
            return Json(new { data = todos });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string serie, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Empleado.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                        == serie.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                        == serie.ToLower().Trim() && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var empleadoDB = await _unidadTrabajo.Empleado.Obtener(id);
            if (empleadoDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la base de datos" });
            }
            _unidadTrabajo.Empleado.Remover(empleadoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Empleado eliminado con éxito" });

        }


        #endregion
    }

}
