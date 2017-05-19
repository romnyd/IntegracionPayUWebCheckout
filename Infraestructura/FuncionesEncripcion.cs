
using System;
using System.Text;
using System.Security.Cryptography;


namespace AsopagosPayU.Infraestructura
{
    public static class FuncionesEncripcion     
    {
        public static string GenerarFirmaHashSHA256(string cadenaParaFirmar)
        {
            // SHA256 es "disposable" por herencia.
            using(var sha256 = SHA256.Create())  
            {  
                // Convertir el texto a firmar en Bytes.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(cadenaParaFirmar));  

                // Obtener la firma con guíones y en mayúscula, por ejemplo: "0B-89-41-66-D3-33..."
                // var hash = BitConverter.ToString(hashedBytes);  

                // Obtener la firma sin guíones y en minúscula, por ejemplo: "0b894166d333...."
                var firma = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();              

                return firma;
            }  
        }

    }

}