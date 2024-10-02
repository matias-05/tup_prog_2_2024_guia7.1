using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class DepartamentoVehicular
    {
        List<RegistroVehiculo> registros = new List<RegistroVehiculo>();
        public int CantidadRegistros
        {
            get
            {
                return registros.Count;
            }
        }
        int serie=0;
        public RegistroVehiculo RegistrarVehiculo(Persona propietario, string patente)
        {
            RegistroVehiculo r = new RegistroVehiculo(patente, propietario, ++serie);
            registros.Add(r);
            return r;
        }
        public RegistroVehiculo VerRegistro(int idx)
        {
            if (idx >= 0 && idx < CantidadRegistros)
            {
                return registros[idx];
            }
            return null;
        }  
    }
}
