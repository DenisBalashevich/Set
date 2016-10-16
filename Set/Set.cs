using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Set
{
    public class Set<T> : IEnumerable<T>
    {
        private HashSet<T> set;

        public int Count
        {
            get
            {
                return set.Count;
            }
        }

        public Set()
        {
            InitSet();
        }

        public Set(T elem)
        {
            InitSet();
            Add(elem);
        }

        public Set(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
                set = new HashSet<T>();
            InitSet();
            foreach (var a in collection)
                Add(a);
        }

        public void Add(T temp)
        {
            if (ReferenceEquals(temp, null))
                throw new ArgumentNullException();
            if (Contains(temp))
            {
                return;
            }
            set.Add(temp);
        }

        public void Add(T[] temp)
        {
            if (ReferenceEquals(temp, null))
                throw new ArgumentNullException();
            foreach (var a in temp)
            {
                Add(a);
            }
        }
        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null))
                return false;
            if (set.Contains(item))
                return true;
            return false;
        }

        public bool IsEmpty()
        {
            return (set.Count == 0);
        }

        public Set<T> Union(Set<T> temp)
        {
            if (ReferenceEquals(temp, null))
                throw new ArgumentNullException();
            Set<T> result = new Set<T>(set);

            foreach (T item in temp.set)
            {
                if (!Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public Set<T> Intersection(Set<T> temp)
        {
            if (ReferenceEquals(temp, null))
                throw new ArgumentNullException();
            Set<T> result = new Set<T>();

            foreach (T item in set)
            {
                if (temp.set.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
        public Set<T> Difference(Set<T> temp)
        {
            if (ReferenceEquals(temp, null))
                throw new ArgumentNullException();
            Set<T> result = new Set<T>();

            foreach (T item in set)
            {
                if (temp.set.Contains(item) == false)
                    result.Add(item);
            }
            return result;
        }
        public Set<T> SymmetricDifference(Set<T> temp)
        {
            if (ReferenceEquals(temp, null))
                throw new ArgumentNullException();
            Set<T> union = Union(temp);
            Set<T> intersection = Intersection(temp);

            return union.Difference(intersection);

        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var a in set)
            {
                yield return a;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            Set<T> temp = obj as Set<T>;
            if (ReferenceEquals(null, temp))
                return false;
            foreach (var a in temp)
                if (this.Contains(a) == false)
                    return false;
            return true;
        }

        public override int GetHashCode()
        {
            return Count * GetType().ToString().Length + GetHashCode();
        }
        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            if (Count == 0)
                result.Append("Set is empty");
            foreach (var a in this)
                result.AppendFormat("{0} ", a);
            return string.Format("{0}", result);
        }

        private void InitSet()
        {
            set = new HashSet<T>();
        }
    }
}
