using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerManager.Models
{
    public class Socio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string Cedula { get; set; }
        public string Foto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad => (DateTime.Now - (DateTime.Now - FechaNacimiento)).Year;
        public string LugarTrabajo { get; set; }
        public string DireccionOficina { get; set; }
        public string TelefonoOficina { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}
