using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
            Patente = patente;
            Serie = serie.ToString();
            Propietario = propietario;

            string conversion = patente.Replace(" ", "").Replace("-","").ToUpper();
              
            for (int i =0; i <conversion.Length; i++)
            {
                char c = conversion[i];
                if (!(char.IsLetter(c) && i < 3 || char.IsDigit(c) && i <= 6 && i>2))
                {
                    throw new FormatoPatenteNoValidaException();
                }
            }    
        }
        public int CompareTo(object obj)
        {
            if (obj is RegistroVehiculo && obj!=null)
            {
                return this.Patente.CompareTo(((RegistroVehiculo)obj).Patente);
            }
            return 0;
        }
        public override string ToString()
        {
            return $"{Patente} - Propietario: {Propietario.Nombre}({Propietario.DNI})";
        }
    }
}
