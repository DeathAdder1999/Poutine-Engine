using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core
{
    /// <summary>
    /// Class is used to contain the GameObject reference, with additional info
    /// </summary>

    public class GameObjectReference
    {
        private string _reference;

        public string Reference { get; }

        public GameObjectReference()
        {

        }

        public GameObjectReference(string reference)
        {
            _reference = reference;
        }


        public static bool operator ==(GameObjectReference r1, GameObjectReference r2)
        {
            return r1.Reference == r2.Reference;
        }

        public static bool operator !=(GameObjectReference r1, GameObjectReference r2)
        {
            return !(r1 == r2);
        }

        protected bool Equals(GameObjectReference other)
        {
            return string.Equals(_reference, other._reference) && string.Equals(Reference, other.Reference);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((GameObjectReference)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_reference != null ? _reference.GetHashCode() : 0) * 397) ^ (Reference != null ? Reference.GetHashCode() : 0);
            }
        }
    }
}
