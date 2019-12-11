using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerManager.Models
{
    public class Afiliado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int SocioId { get; set; }
        public Socio Socio { get; set; }
        public string Relacion { get; set; }
    }
}
