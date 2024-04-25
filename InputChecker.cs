namespace Task3
{
    internal class InputChecker
    {
        public InputChecker() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        internal bool IsValidComandLineParameter(string[] args)
        {
            try
            {
                int pos = ContainsDuplicate(args);
                if (args.Length < 3) throw new ArgumentException($"Comandline parameters have less then 3 params.");
                else if (pos != -1) throw new ArgumentException($"This parameters have dubplicate at position {pos}");
                else if (args.Length % 2 != 1) throw new ArgumentException($"Comandline parameters must have odd count of params.");
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        internal bool IsValidGameParameter(string param)
        {
            if (param == null) throw new ArgumentNullException("Wrong parameter, please try again");
            return true;
        }

        /// <summary>
        /// returns position of dublicate either -1
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private int ContainsDuplicate(string[] args)
        {
            int count;
            for (int i = 0; i < args.Length; i++)
            {
                count = 0;
                for (int j = 0; j < args.Length; j++)
                {
                    if (args[i] == args[j])
                        count++; if (count >= 2) return j;
                }
            }
            return -1;
        }

    }
}
