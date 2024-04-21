using System.Security.Cryptography;

namespace Task3
{
    internal class KeyGenerator
    {
        internal byte[] Key { get { return _key; } } 
        private byte[] _key = new byte[32];

        internal KeyGenerator() => GenerateKey();
        private KeyGenerator GenerateKey()
        {
            RandomNumberGenerator.Create().GetBytes(_key);
            return this;
        }
    }
}
