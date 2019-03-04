using System.Collections.Generic;
using System.Diagnostics;

namespace opfa_common_managed
{ 
    internal class PriorityQueue<T>
    {
        //const private members
        private const int defaultCapacity = 16;
        //private members
        private T[] heap;
        private int count;
        private IComparer<T> comparer;
        private int capacity;

        #region Constructor
        internal PriorityQueue(int capacity, IComparer<T> comparer)
        {
            heap = new T[capacity > 0 ? capacity : defaultCapacity];
            count = 0;
            this.capacity = capacity;
            this.comparer = comparer;
        }
        #endregion

        #region Priority Queue Methods
        internal int Count
        {
            get { return count; }
        }

        internal T Top
        {
            get
            {
                Debug.Assert(count > 0);
                return heap[0];
            }
        }
        internal void Push(T value)
        {
            //increase the size of the array if necessary
            if (count == heap.Length)
            {
                T[] temp = new T[count * 2];
                for (int i = 0; i < count; ++i)
                {
                    temp[i] = heap[i];
                }
                heap = temp;
            }
            int index = count;
            while (index > 0)
            {
                int parentIndex = HeapParent(index);
                if (comparer.Compare(value, heap[parentIndex]) < 0)
                {
                    //value is a better match than the parent node so exchange places to preserve the "heap" property
                    heap[index] = heap[parentIndex];
                    index = parentIndex;
                }
                else
                {
                    //we can insert here
                    break;
                }
            }

            heap[index] = value;
            count++;
        }
   
        internal void Pop()
        {
            if (count > 0)
            {
                count--;
                heap[0] = heap[count];

                Heapify(0);
            }
        }

        private void Heapify(int i)
        {
            int left = (2 * i) + 1;
            int right = left + 1;
            int smallest = i;

            if (left <= count && comparer.Compare(heap[left], heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right <= count && comparer.Compare(heap[right], heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                var pivot = heap[i];
                heap[i] = heap[smallest];
                heap[smallest] = pivot;

                Heapify(smallest);
            }
        }

        #region TEST
        /*internal void Pop()
        {
            Debug.Assert(count != 0);

            if (count > 0)
            {
                --count;
                // Logically, we're moving the last item (lowest, right-most)
                // to the root and then sifting it down.
                int ix = 0;
                while (ix < count / 2)
                {
                    // find the smallest child
                    int smallestChild = HeapLeftChild(ix);
                    int rightChild = HeapRightFromLeft(smallestChild);
                    if (rightChild < count - 1 && comparer.Compare(heap[rightChild], heap[smallestChild]) < 0)
                    {
                        smallestChild = rightChild;
                    }

                    // If the item is less than or equal to the smallest child item,
                    // then we're done.
                    if (comparer.Compare(heap[count], heap[smallestChild]) <= 0)
                    {
                        break;
                    }

                    // Otherwise, move the child up
                    heap[ix] = heap[smallestChild];

                    // and adjust the index
                    ix = smallestChild;
                }
                // Place the item where it belongs
                heap[ix] = heap[count];
                // and clear the position it used to occupy
                heap[count] = default(T);
            }
        }*/
        /*internal void Pop()
        {
            Debug.Assert(count != 0);

            if (count > 1)
            {
                int parent = 0;
                int leftChild = HeapLeftChild(parent);

                while (leftChild < count)
                {
                    int rightChild = HeapRightFromLeft(leftChild);
                    int bestChild = (rightChild < count && comparer.Compare(heap[rightChild], heap[leftChild]) < 0) ? rightChild : leftChild;
                    //promote bestChild to fill the gap left by parent.
                    heap[parent] = heap[bestChild];
                    //restore invariants, i.e., let parent point to the gap.
                    parent = bestChild;
                    leftChild = HeapLeftChild(parent);
                }
                //fill the last gap by moving the last (i.e., bottom-rightmost) node.
                heap[parent] = heap[count - 1];
            }
            count--;
        }*/
        #endregion

        internal void Clear()
        {
            heap = new T[capacity];
            count = 0;
        }
        internal T[] GetHeap()
        {
            return heap;
        }
        #endregion

        #region Private: Priority Queue Helpers
        private static int HeapParent(int i)
        {
            return (i - 1) / 2;
        }
        private static int HeapLeftChild(int i)
        {
            return (i * 2) + 1;
        }
        private static int HeapRightFromLeft(int i)
        {
            return i + 1;
        }
        #endregion
    }
}
