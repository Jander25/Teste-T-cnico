using System.Security.Cryptography;

namespace Api_autenticaçãotoken.Services.SenhaService
{
    public class SenhaService : ISenhaService
    {
    }


    public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(System.Text.Enconding.UTF8.GetBytes(senha));
        }

        
    }
}
