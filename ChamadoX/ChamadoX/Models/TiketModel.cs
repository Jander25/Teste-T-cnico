using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChamadoX.Models
{
    public class TiketModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Preencha  a descrição Por favor!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preencha a data de validação Por favor!")]
        public DateTime? DataDeVencimento { get; set; }
        [Required(ErrorMessage = "Preencha a categoria desejada Por favor!")]
        public string CategoriaId { get; set; }
        [ValidateNever]
        public CategoriaModel CategoriaModel { get; set; }
        [Required(ErrorMessage = "Selecione um Status Por favor!")]
        public string StatusId { get; set; }
        [ValidateNever]
        public StatusModel StatusModel { get; set; }

        public bool Atrasado => StatusId == "Aberto" && DataDeVencimento <  DateTime.Today;

        
    }
}
