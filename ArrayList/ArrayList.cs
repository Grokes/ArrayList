using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList: IEnumerable
    {
        private int _length { get { return _array.Length; } }
        private int[] _array;
        public int Count { get; private set; }

        public ArrayList()
        {
            _array = new int[7];
            Count = 0;
        }

        public ArrayList(int length)
        {
            _array = new int[length];
            Count = 0;
        }

        public ArrayList(int[] arr)
        {
            int length = (int)(arr.Length * 1.5);
            _array = new int[length];

            for (int i = 0; i < arr.Length; i++)
            {
                _array[i] = arr[i];
            }

            Count = arr.Length;
        }

        public int this[int index]
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

        public void Add(int elem)
        {
            if (Count >= _length)
            {
                Increathlength();
            }
            _array[Count++] = elem;
        }
        public void Add(int[] arr)
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
        public void Add(uint ind, int elem)
        {
            if (ind > Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (Count >= _length)
            {
                Increathlength();
            }

            int cur = _array[ind];
            _array[ind] = elem;
            ++Count;

            for (uint i = ind + 1; i < Count; ++i)
            {
                int next = _array[i];
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
                int next = _array[i+1];
                _array[i] = next;
            } 
        }
        public void Remove(int elem)
        {
            int ind = Array.IndexOf(_array, elem);
            while (ind >= 0 && ind < Count)
            {
                Delete((uint)ind);
                ind = Array.IndexOf(_array, elem);
            }
        }

        public int Max()
        {
            if (Count == 0)
            {
                throw new Exception("Array empty");
            }

            int max = _array[0];
            for (int i = 0; i < Count; ++i)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }
        public int Min()
        {
            if (Count == 0)
            {
                throw new Exception("Array empty");
            }

            int min = _array[0];
            for (int i = 0; i < Count; ++i)
            {
                if (_array[i] < min)
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
            int[] newArray = new int[newLength];
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
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, newLength);
            _array = newArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ArrayListEnumerator(_array, Count);
        }
    }
}