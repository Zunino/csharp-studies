using System;
using System.Collections.Generic;

namespace DotnetStudies {

    class BubbleSort {

        public static void Sort<T>(IList<T> collection) where T : IComparable {
            bool swapOccurred;
            int length = collection.Count;
            do {
                swapOccurred = false;
                for (int i = 0; i < length - 1; ++i) {
                    if (collection[i].CompareTo(collection[i + 1]) > 0) {
                        T temp = collection[i];
                        collection[i] = collection[i + 1];
                        collection[i + 1] = temp;
                        swapOccurred = true;
                    }
                }
            } while (swapOccurred);
        }

    }

}

