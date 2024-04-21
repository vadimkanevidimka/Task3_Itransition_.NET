namespace Task3
{
    internal class Game
    {
        private Menu _menu;
        private InputChecker _inputChecker;
        /// <summary>
        /// Starts game and initalize needed fields
        /// </summary>
        /// <param name="args"></param>
        internal Game(string[] args)
        {
            try
            {
                _inputChecker = new InputChecker();
                if (_inputChecker.IsValidComandLineParameter(args))
                {
                    _menu = new Menu(args);
                    ShowGame();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        internal void ShowGame()
        {
            while (true)
            {
                Console.WriteLine($"Available moves:{_menu.PointsOfMenu}");
                _menu.ChooseMenuItem(Int32.Parse(Console.ReadLine()),"");
                Console.WriteLine("===============================================================================================\n");
            }
        }
    }
}
