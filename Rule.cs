using System;
using System.Text;

namespace Task3
{
    internal class Rule
    {
        private Dictionary<string, List<string>> _RuleDictionary;
        private HMACGenerator _hMACGenerator;
        private KeyGenerator _keyGenerator;
        private readonly string[] args;
        private string ComputerChoise;
        
        internal Rule(string[] args)
        {
            this.args = args;
            this._keyGenerator = new KeyGenerator();
            _hMACGenerator = new HMACGenerator(this._keyGenerator);
            Console.WriteLine("HMAC key: " + String.Concat(_keyGenerator.Key.Select(item => item.ToString("x2"))));
            CreateRule();
        }

        private void CreateRule()
        {

            _RuleDictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < args.Length; i++)
            {
                List<string> chains = new List<string>();
                for (int j = i + 1; j <= i + args.Length / 2; j++)
                {
                    if (args.Length - j < args.Length / 2) chains.Add(args[j % args.Length]);
                    else chains.Add(args[j]);
                }
                _RuleDictionary.Add(args[i], chains);
            }
            ChangeComputerChoise();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal void IsUserWon(string userChoise)
        {
            Console.WriteLine($"Your move: {userChoise}!\r\nComputer move: {ComputerChoise}!");
            foreach (var item in _RuleDictionary)
            {
                if (userChoise == ComputerChoise) { Console.WriteLine("Draw"); break; }
                if (item.Key == userChoise)
                    if (item.Value.Contains(ComputerChoise)) {Console.WriteLine("You won!"); break; }
                if (item.Key == ComputerChoise)
                    if (item.Value.Contains(userChoise)) { Console.WriteLine("You lose!"); break; }
            }
            Console.WriteLine("HMAC: " + String.Concat(_hMACGenerator.GenerateHMAC(ComputerChoise).Select(item => item.ToString("x2"))));
            ChangeComputerChoise();
        }

        private void ChangeComputerChoise()
        {
            Random random = new Random();
            ComputerChoise = args[random.Next(args.Length)];
        }
    }
}
