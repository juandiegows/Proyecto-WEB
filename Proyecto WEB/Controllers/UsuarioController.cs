using Microsoft.AspNetCore.Mvc;

using Proyecto_WEB.Models.Request;

using Servicio_WCF.Controllers;
using Servicio_WCF.Models;

namespace Proyecto_WEB.Controllers {
    public class UsuarioController : Controller {
        public IActionResult Index(bool guardo = false) {
            var usuarioData = new UsuarioData();
            ViewBag.Opciones = usuarioData.ObtenerTodosSexo();
            ViewBag.Guardo = guardo;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UsuarioRequest usuario) {
            var usuarioData = new UsuarioData();
            ViewBag.Opciones = usuarioData.ObtenerTodosSexo();
            if (ModelState.IsValid) {
                await usuarioData.Agregar(usuario.Nombre, usuario.FechaNacimiento, usuario.Sexo);

                return Index(true);
            }
            else {
                ViewBag.Guardo = false;
                return View(usuario);
            }


        }
        [HttpGet]
        public async Task<IActionResult> Consulta(int accion = 0) {
            var usuarioData = new UsuarioData();
            var lista = await usuarioData.ObtenerUsuarios();
            ViewBag.Eliminar = false;
            ViewBag.actualizado = false;
            if (accion == 1) {
                ViewBag.Eliminar = true;
            }

            if (accion == 2) {
                ViewBag.actualizado = true;
            }

            return View(lista);
        }

        [HttpGet("Usuario/Eliminar/{Id}")]
        public async Task<IActionResult> Eliminar(int Id) {
            var usuarioData = new UsuarioData();
            ViewBag.Eliminar = await usuarioData.EliminarUsuario(Id);

            return RedirectToAction("consulta", new { accion = 1});
        }
        [HttpGet]
        public async Task<IActionResult> Actualizar(int Id) {
            var usuarioData = new UsuarioData();
            var usuario = (await usuarioData.ObtenerUsuarios()).Select(x => new UsuarioRequest() {
                Id = x.Id,
                Nombre = x.Nombre,
                FechaNacimiento = x.FechaNacimiento,
                Sexo = x.Sexo
            }).First(x => x.Id == Id);
            ViewBag.Opciones = usuarioData.ObtenerTodosSexo();
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(UsuarioRequest usuario) {
            var usuarioData = new UsuarioData();
            await usuarioData.ModificarUsuario(usuario.Id, usuario.Nombre, usuario.FechaNacimiento, usuario.Sexo);
            return RedirectToAction("consulta", new { accion = 2 });
        }
    }
}
