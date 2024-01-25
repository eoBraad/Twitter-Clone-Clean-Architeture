using System.Security.Cryptography;
using System.Text;

namespace Application.Services.Utility;

public class Encrypt
{
    public static string EncryptPassword(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        var sha512 = SHA512.Create();
        byte[] hashBytes = sha512.ComputeHash(bytes);

        var sb = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }

        return sb.ToString();
    }
}
