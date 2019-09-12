using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class AnalisisDetalle
    {
        [Key]
        public int Id { get; set; }
        public int AnalisisId { get; set; }
        public int TipoId { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Resultado { get; set; }

        //[ForeignKey("AnalisisId")]
        //public virtual Analisis Analisis { get; set; }

        //[ForeignKey("TipoId")]
        //public virtual TiposAnalisis Tipo { get; set; }
        public AnalisisDetalle()
        {
            Id = 0;
            AnalisisId = 0;
            TipoId = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Resultado = string.Empty;
        }

        public AnalisisDetalle(int id, int analisisId, int tipoId, string descripcion, int precio, string resultado)
        {
            Id = id;
            AnalisisId = analisisId;
            TipoId = tipoId;
            Descripcion = descripcion;
            Precio = precio;
            Resultado = resultado;
        }
    }
}
