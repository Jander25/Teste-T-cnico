using Api_autenticaçãotoken.Data;
using Api_autenticaçãotoken.Dtos;
using Api_autenticaçãotoken.Models;
using Api_autenticaçãotoken.Services.SenhaService;

namespace Api_autenticaçãotoken.Services.AuthServices
{
    public class AuthServices : IAuthInterface

    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        public AuthServices(AppDbContext context ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
;        }


        public async Task<Response<UsuarioCriacaoDto>> Registrar(UsuarioCriacaoDto usuarioRegistro)
        {
            Response<UsuarioCriacaoDto> resportaServico = new Response<UsuarioCriacaoDto>();

            try
            {
                if (!VerificaSeEmaileUsuarioJaExiste(usuarioRegistro))
                {
                    resportaServico.Dados = null;
                    resportaServico.Status = false;
                    resportaServico.Mensagem = "Email/ Usuário Já cadastrados!"
                    return resportaServico;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegistro.Senha out byte[] senhaHash, out byte[]SenhaSalt);


                UsuarioModel usuario = new UsuarioModel()
                {
                    usuario = usuarioRegistro.Usuario,
                    Email = usuarioRegistro.Email,
                    Cargo = usuarioRegistro.Cargo,
                    SenhaHash = senhaHash,
                    SenhaSalt = SenhaSalt
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                resportaServico.Mensagem = "Usuário Criado com Sucesso";


            }
            catch (Exception ex)
            {
                resportaServico.Dados = null;
                resportaServico.Mensagem = ex.Message;
                resportaServico.Status = false;

            }
            return resportaServico;
        }




        public bool VerificaSeEmaileUsuarioJaExiste(UsuarioCriacaoDto usuarioRegistro)
        {
            var usuario = _context.usuario.FirstOrDefault(userBanco => userBanco.Email == usuarioRegistro.Email || userBanco.usuario ==
            usuarioRegistro.Usuario);
            if(usuario == null) return false;

            return true;

        }

    }
}
