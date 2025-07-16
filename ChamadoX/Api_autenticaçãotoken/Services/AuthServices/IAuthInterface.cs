using Api_autenticaçãotoken.Dtos;
using Api_autenticaçãotoken.Models;

namespace Api_autenticaçãotoken.Services.AuthServices
{
    public interface IAuthInterface
    {
        Task<Response<UsuarioCriacaoDto>> Registrar(UsuarioCriacaoDto usuarioRegistro);
    }
}
