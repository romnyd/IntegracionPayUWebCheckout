
using System;
using System.Text;
using System.Security.Cryptography;


namespace AsopagosPayU.Infraestructure
{
    public static class EncryptionFunctions     
    {
        public static string GenerateHash(string holaMundo)
        {
            // SHA256 is disposable by inheritance.  
            using(var sha256 = SHA256.Create())  
            {  
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(holaMundo));  
                // Get the hashed string with dashes.  
            //     var hash = BitConverter.ToString(hashedBytes);  
                // Get the hashed string without dashes.  
                 var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();  
                // Print the string.   
                return hash;
            }  
        }

    }

}