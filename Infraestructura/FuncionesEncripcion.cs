
using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace AsopagosPayU.Infraestructura
{
    public static class FuncionesEncripcion
    {
        private static Random random = new Random();

        /// <summary>
        /// Genera un string alfanumérico al azar. INPUT: 8 - OUTPUT: "D2FJ32PQ"
        /// </summary>
        public static string GenerarRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerarFirmaHashSHA256(string cadenaParaFirmar)
        {
            // SHA256 es "disposable" por herencia.
            using (var sha256 = SHA256.Create())
            {
                // Convertir el texto a firmar en Bytes.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(cadenaParaFirmar));

                // Obtener la firma con guíones y en mayúscula, por ejemplo: "0B-89-41-66-D3-33..."
                // var hash = BitConverter.ToString(hashedBytes);  

                // Obtener la firma sin guíones y en minúscula, por ejemplo: "0b894166d333...."
                var firma = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return firma;
            }
        }


    }

}