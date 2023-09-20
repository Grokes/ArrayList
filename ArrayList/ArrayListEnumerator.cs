using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    internal class ArrayListEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _array;
        private readonly int _count;
        private int _ind = -1;
        public ArrayListEnumerator(T[] arr, int Count) 
        {
            _array = arr;
            this._count = Count;
        }
        object IEnumerator.Current
        {
            get
            {
                if (_ind == -1 || _ind >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[_ind];
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                if (_ind == -1 || _ind >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[_ind];
            }
        }
        public bool MoveNext()
        {
            if (_ind < _count - 1)
            {
                ++_ind;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            _ind = -1;
        }

        public void Dispose()
        {
            //Console.WriteLine("Всё очень плохо");
            //throw new NotImplementedException();
        }
    }
}
