using Servicio_WCF.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_WCF.Controllers {
    public class Usuario {
       
        public async void Agregar() {
            using (DBDigitalBankstContext model = new DBDigitalBankstContext()) {
               var procedimientos = model.GetProcedures();
                await procedimientos.AgregarAsync();
            }
        }
    }
}
