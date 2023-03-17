using Microsoft.AspNetCore.Mvc;

using Servicio_WCF.Controllers;

namespace Proyecto_WEB.Controllers {
    public class UsuarioController : Controller {
        public IActionResult Index() {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Consulta(bool eliminado = false) {
            var usuarioData = new UsuarioData();
            var lista = await usuarioData.Obtener();
            ViewBag.Eliminar = eliminado;
            return View(lista);
        }

        [HttpGet("Eliminar/:Id")]
        public async Task<IActionResult> Eliminar(int Id) {
            var usuarioData = new UsuarioData();
            ViewBag.Eliminar = await usuarioData.Eliminar(Id);
            var lista = await usuarioData.Obtener();
            
            return View("consulta", lista);
        }
        [HttpGet("Editar/:Id")]
        public async Task<IActionResult> Editar(int Id) {
            var usuarioData = new UsuarioData();
            ViewBag.Eliminar = await usuarioData.Eliminar(Id);
            return RedirectToAction("consulta");
        }
    }
}
