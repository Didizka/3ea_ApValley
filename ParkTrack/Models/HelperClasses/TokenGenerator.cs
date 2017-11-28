using System;
using System.Security.Cryptography;

namespace ParkTrack.Models.HelperClasses
{
    public static class TokenGenerator
    {
        public static string generateToken()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[32];

            rng.GetBytes(buffer);
            return BitConverter.ToString(buffer).Replace("-", "").ToLower();
        }
    }
}
