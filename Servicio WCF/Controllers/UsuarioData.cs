using Servicio_WCF.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicio_WCF.Controllers {
    public class UsuarioData {
       
        /// <summary>
        /// Agregar un usuario usando un procedimiento almacenado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="sexo"></param>
        /// <returns></returns>
        public async Task<bool> Agregar(string nombre, DateTime fechaNacimiento, string sexo) {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
               var procedimientos = model.GetProcedures();
              return  await procedimientos.AgregarAsync(nombre, fechaNacimiento,sexo)  > 0;
            }
        }
        /// <summary>
        /// Obtiene todos los sexos de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerTodosSexo() {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
                return model.Sexo.Select(x=> x.Nombre).ToList();
            }
        }
        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<List<Models.ObtenerResult>> ObtenerUsuarios() {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
                var procedimientos = model.GetProcedures();
               return await procedimientos.ObtenerAsync();
            }
        }
        /// <summary>
        /// Elimina un usuario pasandole un ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> EliminarUsuario(int id) {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
                var procedimientos = model.GetProcedures();
                return (await procedimientos.EliminarAsync(id)) > 0;
            }
        }
        /// <summary>
        /// Actualiza o modifica un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="sexo"></param>
        /// <returns></returns>
        public async Task<bool> ModificarUsuario(int id, string nombre, DateTime fechaNacimiento, string sexo) {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
                var procedimientos = model.GetProcedures();
                return (await procedimientos.ActualizarAsync(id, nombre,  DateTime.Parse(fechaNacimiento.ToShortDateString()), sexo)) > 0;
            }
        }
    }
}
