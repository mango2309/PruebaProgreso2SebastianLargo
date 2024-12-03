using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProgreso2SebastianLargo.SLModels
{
    public class RecargaSL
    {
        public string NumeroTelefono { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Teléfono: {NumeroTelefono}";
        }
    }
}
