using System.Security.Cryptography;

namespace Task3
{
    internal class HMACGenerator
    {
        private readonly HMACSHA256 _hMACSHA2;
        private readonly KeyGenerator _keyGenerator;
        internal HMACGenerator(KeyGenerator keyGenerator) 
        {
           _keyGenerator = keyGenerator;
           _hMACSHA2 = new HMACSHA256(_keyGenerator.Key);
        }

        internal byte[] GenerateHMAC() 
        {
            Random random = new Random();
            var arr = this._keyGenerator.Key.OrderBy(x => random.Next()).ToArray();
            return _hMACSHA2.ComputeHash(arr);
        }
    }
}
