using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class RegistroVehiculo:IComparable
    {
        public string Patente { get; private set;}
        public string Serie { get; private set; }
        public Persona Propietario { get; set; }
        public RegistroVehiculo(string patente, Persona propietario,int serie)
        {
            Match m = Regex.Match(patente.Trim(), @"^[A-Z]{3}\s*[0-9]{3}$", RegexOptions.IgnoreCase);
            if (m.Success == false)
                throw new FormatoPatenteNoValidaException();

            Patente = patente;
            Serie = serie.ToString();
            Propietario = propietario;
        }
        public int CompareTo(object obj)
        {
            if (obj is RegistroVehiculo && obj!=null)
            {
                return Patente.CompareTo(((RegistroVehiculo)obj).Patente);
            }
            return 0;
        }
        public override string ToString()
        {
            return $"{Patente} - Propietario: {Propietario.Nombre}({Propietario.DNI})";
        }
    }
}
