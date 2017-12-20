using System;
using System.Linq;
using System.Security.Cryptography;

namespace ParkTrack.Models.HelperClasses
{
    public static class TokenGenerator
    {
        public static string generateRandonSerialNumber()
        {
            var random = new Random();
            var chars = "01234567890123456789";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(15).ToArray());
        }

        public static string generateToken()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[15];

            rng.GetBytes(buffer);
            return BitConverter.ToString(buffer).Replace("-", "").ToLower();
        }
    }
}
