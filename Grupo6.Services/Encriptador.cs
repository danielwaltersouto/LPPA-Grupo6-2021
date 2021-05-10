using System.Security.Cryptography;
using System.Text;

namespace Grupo6.Services
{
    class Encriptador
    {
        public static string Encriptar(string Pass)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] stream = null;
            StringBuilder sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(Pass));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public static bool Validar(string Pass, string PassHashData)
        {
            string Passhash;
            Passhash = Encriptador.Encriptar(Pass);


            if (Passhash == PassHashData)

            {
                return true;
            }

            else

            {
                return false;
            }

        }


    }
}
    


    

