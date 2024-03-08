using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace Albergo.Models
{
    public class Pensione
    {
        [Key]
        public int Pensione_ID { get; set; }

        //Tipo
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Tipo Pensione")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Il tipo deve contenere massimo 50 caratteri")]
        public string Tipo { get; set; }

        //Supplemento
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Range(1, 1000000, ErrorMessage = "Max 1000000 min 10 cifre")]
        public decimal Supplemento { get; set; }
    }
}