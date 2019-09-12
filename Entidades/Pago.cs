using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public int Monto { get; set; }

        public Pago()
        {
            PagoId = 0;
            PersonaId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
        }

        public Pago(int pagoId, DateTime fecha, int personaId, int monto)
        {
            PagoId = 0;
            PersonaId = personaId;
            Fecha = DateTime.Now;
            Monto = 0;
        }
    }
}
