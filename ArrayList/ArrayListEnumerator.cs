using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    internal class ArrayListEnumerator : IEnumerator
    {
        int[] _array;
        public int Count { get; private set; }
        int ind = -1;
        public ArrayListEnumerator(int[] arr, int Count) 
        {
            _array = arr;
            this.Count = Count;
        }
        public object Current
        {
            get
            {
                if (ind == -1 || ind >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[ind];
            }
        }

        public bool MoveNext()
        {
            if (ind < Count - 1)
            {
                ++ind;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            ind = -1;
        }
    }
}
