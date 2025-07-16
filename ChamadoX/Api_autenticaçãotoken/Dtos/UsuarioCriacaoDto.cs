using Api_autenticaçãotoken.Enum;
using System.ComponentModel.DataAnnotations;

namespace Api_autenticaçãotoken.Dtos
{
    public class UsuarioCriacaoDto
    {
        [Required (ErrorMessage ="O campo Usuário é obrigatorio!")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo de Email é obrigatorio!"), EmailAddress(ErrorMessage ="Favor Informar um email valido!")]
        public string Email { get; set;}

        public string Senha { get; set;}

        [Compare("Senha", ErrorMessage ="Senhas não coincidem!")]
        public string ConfirmaSenha {  get; set;}

        [Required(ErrorMessage = "O campo Cargo é obrigatorio!")]
        public CargoEnum Cargo { get; set;}

    }
}
