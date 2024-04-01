using Renci.SshNet.Security.Cryptography.Ciphers;
using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using Renci.SshNet.Security.Cryptography.Ciphers.Paddings;
using System.Text;

namespace BoxServer.Utils
{
    public static class DES_Encryption
    {
        public static byte[] encode(byte[] inputByteArray)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ekey);
            byte[] bytes2 = Encoding.UTF8.GetBytes(eiv);
            PKCS5Padding pkcs5Padding = new PKCS5Padding();
            byte[] data = pkcs5Padding.Pad(8, inputByteArray);
            DesCipher desCipher = new DesCipher(bytes, new CbcCipherMode(bytes2), null);
            return desCipher.Encrypt(data);
        }

        public static byte[] decode(byte[] inputByteArray)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ekey);
            byte[] bytes2 = Encoding.UTF8.GetBytes(eiv);
            PKCS5Padding pkcs5Padding = new PKCS5Padding();
            byte[] data = pkcs5Padding.Pad(8, inputByteArray);
            DesCipher desCipher = new DesCipher(bytes, new CbcCipherMode(bytes2), null);
            return desCipher.Decrypt(data);
        }

        public static string ekey = "tsjhtsjh";
        public static string eiv = "51478543";
    }
}
