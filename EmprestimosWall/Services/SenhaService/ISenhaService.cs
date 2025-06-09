using System.Security.Cryptography;

namespace EmprestimosWall.Services.SenhaService
{
    public interface ISenhaService
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
    }

}
