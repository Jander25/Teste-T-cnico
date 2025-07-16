using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ChamadoX.Models
{
    public class CategoriaModel
    {
        [Key]
        public string CategoriaId { get; set; }
        public string Nome { get; set; }

    }
}
