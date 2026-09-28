namespace Massive
{
    internal class IntArrayList
    {
        private const int BaseSize = 2;

        private int[] _array;
        private int _size;

        public int Count
        {
            get { return _size; }
        }

        public int Capacity 
        {
            get => _array.Length;

            set
            {
                if (value < _size)
                {
                    throw new ArgumentException("Imposible size");
                }

                if (value > _array.Length)
                {
                    int[] ints = new int[value];
                    Array.Copy(_array, ints, _size);

                    _array = ints;
                }
            }
        }

        public IntArrayList()
        {
            _array = new int[BaseSize];
            _size = 0;
        }
        public IntArrayList(int[] ints)
        {
            _size = ints.Length;

            int[] intsInside = new int[_size * BaseSize];
            _array = new int[_size * BaseSize];
            Array.Copy(_array, intsInside, ints.Length);
        }

        public IntArrayList(int initialCapacity)
        {
            _array = new int[initialCapacity];
            _size = 0;
        }

        public void PushBack(int value)
        {
            EnsureCapacity();
            _array[_size] = value;
            _size++;
        }
        private void EnsureCapacity()
        {

            if (_array.Length == _size)
            {

                int[] newArray = new int[_size * 2];
                Array.Copy(_array, newArray, _array.Length);

                _array = newArray;
            }
        }

        public void PopBack()
        {
            _array[_size - 1] = 0;
            _size--;
        }

        public bool TryInsert(int index, int value)
        {

            if (index <= 0 || index >= _size)
            {
                return false;
            }

            _array[index] = value;

            if (index == _size)
            {
                _size++;
            }

            return true;

        }

        public bool TryErase(int index)
        {

            if (index <= 0 || index >= _size)
            {
                return false;
            }

            _array[index] = 0;

            if (index == _size)
            {
                _size--;
            }

            return true;

        }

        public bool TryGetAt(int index, out int result)
        {

            if (index < 0 || index >= _size)
            {
                result = 0;
                return false;
            }
            
            result = _array[index];
            return true;

        }

        public void Clear()
        {
            int[] ints = new int[BaseSize];
            _size = 0;

            _array = ints;
        }

        public bool TryForceCapacity(int newCapacity)
        {

            if (newCapacity < 0)
            {
                return false;
            }

            int[] ints = new int[newCapacity];
            _size = newCapacity;
            Array.Copy(_array, ints, newCapacity);

            _array = ints;

            return true;
        }
        public int Find(int value)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
