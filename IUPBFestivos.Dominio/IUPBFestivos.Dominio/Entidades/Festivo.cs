using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUPBFestivos.Dominio.Entidades
{
    [Table("Festivo")]
    public class Festivo
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int DiasPascua { get; set; }

        [ForeignKey("Tipo")]
        public int IdTipo { get; set; }

        public Tipo Tipo { get; set; } // Relación con Tipo  
    }
}

