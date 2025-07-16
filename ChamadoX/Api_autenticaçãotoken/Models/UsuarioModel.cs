using Api_autenticaçãotoken.Enum;

namespace Api_autenticaçãotoken.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string usuario {  get; set; }

        public CargoEnum Cargo { get; set; }

        public byte[] SenhaHash {  get; set; }

        public byte[] SenhaSalt { get; set; }

        public DateTime TokenDataCriacao { get; set; } = DateTime.Now;

    }
}
