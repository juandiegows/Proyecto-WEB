using Servicio_WCF.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicio_WCF.Controllers {
    public class UsuarioData {
       
        public async Task<bool> Agregar(string nombre, DateTime fechaNacimiento, string sexo) {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
               var procedimientos = model.GetProcedures();
              return  await procedimientos.AgregarAsync(nombre, fechaNacimiento,sexo)  > 0;
            }
        }

        public async Task<List<Models.ObtenerResult>> Obtener() {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
                var procedimientos = model.GetProcedures();
               return await procedimientos.ObtenerAsync();
            }
        }

        public async Task<bool> Eliminar(int id) {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
                var procedimientos = model.GetProcedures();
                return (await procedimientos.EliminarAsync(id)) > 0;
            }
        }
        public async Task<bool> Modificar(int id, string nombre, DateTime fechaNacimiento, string sexo) {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
                var procedimientos = model.GetProcedures();
                return (await procedimientos.ActualizarAsync(id, nombre,  DateTime.Parse(fechaNacimiento.ToShortDateString()), sexo)) > 0;
            }
        }
    }
}
