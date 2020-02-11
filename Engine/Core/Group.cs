using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.ErrorHandler.Exceptions;

namespace Engine.Core
{
    //TODO might want to change this into dictionary instead
    public class Group<T>
    {
        public string Name { get; }

        private List<T> _group = new List<T>();

        public Group(string name)
        {
            Name = name;
        }

        public void Add(T element)
        {
            if (_group.Contains(element))
            {
                throw new GroupDuplicateException();
            }

            _group.Add(element);
        }

        public void Remove(T element)
        {
            if (_group.Contains(element))
            {
                _group.Remove(element);
                return;
            }

            throw new GroupAbsentElementException();
        }
    }
}
