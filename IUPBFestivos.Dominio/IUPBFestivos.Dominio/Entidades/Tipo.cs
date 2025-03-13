using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUPBFestivos.Dominio.Entidades
{
    [Table("Tipo")]
    public class Tipo
    {
        [Key]
        public int Id { get; set; }

        [Column("Tipo")]
        public string Nombre { get; set; }

        // Relación con Festivos (si es necesaria)  
        public ICollection<Festivo> Festivos { get; set; } // si es necesario  
    }
}