using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ChamadoX.Models
{
    public class StatusModel
    {

        [Key]
        public string StatusId { get; set; }

        public string Nome { get; set; }
    }
}
