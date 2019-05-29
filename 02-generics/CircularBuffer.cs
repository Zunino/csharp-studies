using System.Collections.Generic;
using System.Text;

namespace DotnetStudies {

    class CircularBuffer<T> {

        public CircularBuffer(int capacity) {
            this.elements = new T[capacity];
            this.capacity = capacity;
            this.index = 0;
        }

        public void Add(T value) {
            elements[index++ % capacity] = value;
        }

        override public string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            int lastIndex = elements.Length - 1;
            for (int i = 0; i < lastIndex; ++i) {
                sb.Append(elements[i]);
                sb.Append(' ');
            }
            if (lastIndex >= 0) {
                sb.Append(elements[lastIndex]);
            }
            sb.Append(']');
            return sb.ToString();
        }

        private T[] elements;
        private int capacity;
        private int index;

    }

}

