using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.ErrorHandler;

namespace Engine.Core
{
    public class Group<K, V>
    {
        public string Name { get; }

        private Dictionary<K, V> _group = new Dictionary<K, V>();

        public Group(string name)
        {
            Name = name;
        }

        public void Add(K key, V element)
        {
            if (_group.TryGetValue(key, out var e) && e.Equals(element))
            {
                throw new DuplicateException();
            }

            _group.Add(key, element);
        }

        public void Remove(K key)
        {
            if (_group.TryGetValue(key, out var element))
            {
                _group.Remove(key);
                return;
            }

            throw new ElementNotFountException();
        }
    }
}
