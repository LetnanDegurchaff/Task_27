using System.Security.Cryptography;
using System.Text;
using WindowsFormsApp1;

namespace WinFormsApp1.Domain.Services;

public class Sha256HashSystem : IHashSystem
{
    public string ComputeHash(string rawData)
    {
        StringBuilder stringBuilder = new StringBuilder();

        using SHA256 hash = SHA256.Create();
        
        Encoding encoding = Encoding.UTF8;
        byte[] result = hash.ComputeHash(encoding.GetBytes(rawData));

        foreach (byte @byte in result)
            stringBuilder.Append(@byte.ToString("x2"));

        return stringBuilder.ToString();
    }
}