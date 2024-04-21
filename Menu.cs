using System.Text;

namespace Task3
{
    internal class Menu
    {
        internal Dictionary<string, Action<int, string>> _menuItems = new Dictionary<string, Action<int, string>>();
        private Rule _rule;
        internal Menu(string[] args)
        {
            _rule = new Rule(args);
            _menuItems.Add("exit", (str, i) => Environment.Exit(0));
            foreach (var item in args)
            {
                _menuItems.Add(item, new Action<int,string>((i,str) => _rule.IsUserWon(str)));
            }
            _menuItems.Add("help", (str, i) => Help.PrintHelpDesk(args));
        }

        internal string PointsOfMenu
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                foreach (var item in _menuItems)
                {
                    sb.Append($"\r\n{i++} - {item.Key}");
                }
                return sb.ToString();
            }
        }

        internal void ChooseMenuItem(int _pointOfMenu, string command)
        {
            var a = _menuItems.ElementAt(_pointOfMenu).Value;
            a.Invoke(_pointOfMenu, _menuItems.ElementAt(_pointOfMenu).Key);
        }
    }
}
