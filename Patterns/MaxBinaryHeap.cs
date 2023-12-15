using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class MaxBinaryHeap<T> where T : IComparable
    {
        public List<T> values;

        public MaxBinaryHeap()
        {
            values = new List<T>();
        }

        public void insert(T element)
        {
            this.values.Add(element);
            this.bubbleUp();
        }

        //추가한 값을 가장 높은 곳으로 올림
        public void bubbleUp()
        {
            int idx = this.values.Count - 1;
            var element = this.values[idx];
            while(idx > 0)
            {
                int parentIdx = (idx - 1) / 2;
                T parent = this.values[parentIdx];
                if (element.CompareTo(parent) <= 0) break;
                this.values[parentIdx] = element;
                this.values[idx] = parent;
                idx = parentIdx;
                
            }
        }

        public T? ExtractMax()
        {
            if (this.values.Count == 0) return default(T);

            T max = this.values[0];
            T end = this.values[values.Count - 1];
            this.values.RemoveAt(values.Count - 1);

            if(this.values.Count > 0)
            {
                this.values[0] = end;
                bubbleDown();
            }

            return max;
        }

        public void bubbleDown()
        {
            int idx = 0;
            int length = this.values.Count;
            T element = this.values[idx];

            while(true)
            {
                int leftChildIdx = 2 * idx + 1;
                int rightChildIdx = 2 * idx + 2;
                T? leftChild = default(T);
                T? rightChild = default(T);
                int swap = default(int);

                if(leftChildIdx < length)
                {
                    leftChild = this.values[leftChildIdx];
                    if (leftChild.CompareTo(element) > 0)
                    {
                        swap = leftChildIdx;
                    }
                }

                if(rightChildIdx < length)
                {
                    rightChild = this.values[rightChildIdx];
                    if ((swap == default(int) && rightChild.CompareTo(element) > 0) ||
                       (swap != default(int) && rightChild.CompareTo(leftChild) > 0))
                    {
                        swap = rightChildIdx;
                    }
                }

                if (swap == default(int)) break;

                this.values[idx] = this.values[swap];
                this.values[swap] = element;
                idx = swap;
            }
        }

        private void ThrowForEmptyMBH()
        {
            try
            {
                T max = this.values[0];
                throw new Exception("범위 벗어남");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
