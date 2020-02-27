using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Core
{
    public class SelectionManager
    {
        private static SelectionManager _instance;

        public static SelectionManager Instance => _instance ?? (_instance = new SelectionManager());
        private readonly List<GameObject> _selection = new List<GameObject>();
        public EventHandler SelectionChanged;

        public int SelectionSize => _selection.Count;

        private SelectionManager()
        {

        }

        public void Select(GameObject gameObject)
        {
            Clear();
            _selection.Add(gameObject);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void AddSelection(GameObject gameObject)
        {
            _selection.Add(gameObject);
        }

        public void AddSelections(IEnumerable<GameObject> gameObjects)
        {
            //If selection contains the objects
            //if (_selection.Any(x => gameObjects.Any(y => y == x)))
            //{
              //  _selection.AddRange(gameObjects);
            //}

            _selection.AddRange(gameObjects);
        }

        public void RemoveSelection(GameObject gameObject)
        {
            _selection.Remove(gameObject);
        }

        public void RemoveLast()
        {
            _selection.RemoveAt(_selection.Count);
        }

        public void RemoveFirst()
        {
            _selection.RemoveAt(0);
        }

        public void Clear()
        {
            _selection.Clear();
        }
    }
}
