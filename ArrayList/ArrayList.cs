using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList<T>: IEnumerable<T> where T: IComparable<T>
    {
        private int _length { get { return _array.Length; } }
        private T[] _array;
        public int Count { get; private set; }

        public ArrayList()
        {
            _array = new T[7];
            Count = 0;
        }

        public ArrayList(int length)
        {
            _array = new T[length];
            Count = 0;
        }

        public ArrayList(T[] arr)
        {
            int length = (int)(arr.Length * 1.5);
            _array = new T[length];

            for (int i = 0; i < arr.Length; i++)
            {
                _array[i] = arr[i];
            }

            Count = arr.Length;
        }

        public T this[int index]
        {
            get
            {
                if (index > Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index > Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public void Add(T elem)
        {
            if (Count >= _length)
            {
                Increathlength();
            }
            _array[Count++] = elem;
        }
        public void Add(T[] arr)
        {
            if (_length <= arr.Length + Count)
            {
                Increathlength(arr.Length);
            }
            foreach (var el in arr)
            {
                _array[Count++] = el;
            }
        }
        public void Add(uint ind, T elem)
        {
            if (ind > Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (Count >= _length)
            {
                Increathlength();
            }

            T cur = _array[ind];
            _array[ind] = elem;
            ++Count;

            for (uint i = ind + 1; i < Count; ++i)
            {
                T next = _array[i];
                _array[i] = cur;
                cur = next;
            }
        }

        public void Delete(uint ind)
        {
            if (ind > Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (_length > Count * 2)
            {
                Decreathlength();
            }

            --Count;
            for (uint i = ind; i < Count; ++i)
            {
                T next = _array[i+1];
                _array[i] = next;
            } 
        }
        public void Remove(T elem)
        {
            int ind = Array.IndexOf(_array, elem);
            while (ind >= 0 && ind < Count)
            {
                Delete((uint)ind);
                ind = Array.IndexOf(_array, elem);
            }
        }

        public T Max()
        {
            if (Count == 0)
            {
                throw new Exception("Array empty");
            }

            T max = _array[0];
            for (int i = 0; i < Count; ++i)
            {
                if (_array[i].CompareTo(max) > 0)
                {
                    max = _array[i];
                }
            }
            return max;
        }
        public T Min()
        {
            if (Count == 0)
            {
                throw new Exception("Array empty");
            }

            T min = _array[0];
            for (int i = 0; i < Count; ++i)
            {
                if (_array[i].CompareTo(min) < 0)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        private void Increathlength(int countElements = 1)
        {
            int newLength = _length;
            while (newLength <= _length + countElements)
            {
                newLength = (int)(newLength * 1.5 + countElements);
            }
            T[] newArray = new T[newLength];
            Array.Copy(_array, newArray, _length);
            _array = newArray;
        }
        private void Decreathlength(int countElements = 1)
        {
            int newLength = _length;
            while (newLength >= Count * 1.2)
            {
                newLength = (int)(newLength * 0.9 - countElements);
            }
            if (newLength < Count) newLength = Count; 
            T[] newArray = new T[newLength];
            Array.Copy(_array, newArray, newLength);
            _array = newArray;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new ArrayListEnumerator<T>(_array, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ArrayListEnumerator<T>(_array, Count);
        }
    }
}