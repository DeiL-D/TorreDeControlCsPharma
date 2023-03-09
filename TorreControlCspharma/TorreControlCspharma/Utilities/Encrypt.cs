using System.Security.Cryptography;
using System.Text;

namespace TorreControlCspharma.Utilities
{
    public class Encrypt
    {
 
        //Este emtodo es diferente al presentado pero generaba errores en ejecucion ya que no es del todo moderno

            private static readonly byte[] key = Encoding.UTF8.GetBytes("HerQ7[wYSoxHgkf="); // Clave de encriptación (16 bytes)
            private static readonly byte[] iv = Encoding.UTF8.GetBytes("EV2E}2JX9c+Cz;xm"); // Vector de inicialización (16 bytes)

            public string Encripter(string contra)
            {
                // Creamos un objeto de tipo AES
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    // Creamos un cifrador que encriptará la contraseña
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    // Convertimos la contraseña a un arreglo de bytes
                    byte[] bytes = Encoding.UTF8.GetBytes(contra);

                    // Creamos un stream para almacenar los datos encriptados
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Creamos un stream de cifrado para encriptar los datos
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            // Escribimos los datos en el stream de cifrado
                            cs.Write(bytes, 0, bytes.Length);
                            cs.FlushFinalBlock();
                        }

                        // Convertimos los datos encriptados a una cadena base64
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }

            public string Descriptera(string contraEncriptada)
            {
                // Creamos un objeto de tipo AES
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    // Creamos un descifrador que desencriptará la contraseña
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    // Convertimos la contraseña encriptada de base64 a un arreglo de bytes
                    byte[] bytes = Convert.FromBase64String(contraEncriptada);

                    // Creamos un stream para almacenar los datos desencriptados
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Creamos un stream de descifrado para desencriptar los datos
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                        {
                            // Escribimos los datos desencriptados en el stream de descifrado
                            cs.Write(bytes, 0, bytes.Length);
                            cs.FlushFinalBlock();
                        }

                        // Convertimos los datos desencriptados a una cadena
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }
    }


