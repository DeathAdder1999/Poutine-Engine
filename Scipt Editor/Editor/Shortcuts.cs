using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scipt_Editor.Editor
{
    static class Shortcuts
    {
        private static Dictionary<Keys, Shortcut> _shortcuts = new Dictionary<Keys, Shortcut>();

        public static void AddShortcut(Keys keydata, Shortcut shortcut)
        {
            _shortcuts[keydata] = shortcut;
        }

        public static void HandleShortcut(Keys keydata)
        {
            if (_shortcuts.TryGetValue(keydata, out var shortuct))
            {
                shortuct.Execute();
            }
        }
    }

    class Shortcut
    {
        private string _name;
        private Action _action;

        public Shortcut(string name, Action a)
        {
            _name = name;
            _action = a;
        }

        public void Execute()
        {
            _action?.Invoke();
        }
    }
}
