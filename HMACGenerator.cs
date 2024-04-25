using System.Security.Cryptography;

namespace Task3
{
    internal class HMACGenerator
    {
        private readonly HMACSHA256 _hMACSHA2;
        private readonly KeyGenerator _keyGenerator;
        private List<byte[]> _logHMAC;
        internal HMACGenerator(KeyGenerator keyGenerator) 
        {
           _keyGenerator = keyGenerator;
           _hMACSHA2 = new HMACSHA256(_keyGenerator.Key);
            _logHMAC = new List<byte[]>();
        }

        internal byte[] GenerateHMAC(string _message) 
        {
            Random random = new Random();
            var arr = this._keyGenerator.Key.Concat(System.Text.Encoding.Default.GetBytes(_message)).ToArray();
            _logHMAC.Add(_hMACSHA2.ComputeHash(arr));
            return _logHMAC.Last();
        }
    }
}
