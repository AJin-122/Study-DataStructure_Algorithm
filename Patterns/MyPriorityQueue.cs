using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Patterns
{
    public class PNode<T> where T : IComparable
    {
        public T val;
        public int priority;

        public PNode(T val, int priority)
        {
            this.val = val;
            this.priority = priority;
        }
    }

    public class MyPriorityQueue<T> where T : IComparable
    {
        public List<PNode<T>> values;

        public MyPriorityQueue()
        {
            values = new List<PNode<T>>();
        }

        public void Enqueue(T val,int priority)
        {
            var newNode = new PNode<T>(val, priority);
            this.values.Add(newNode);
            this.bubbleUp();
        }

        public PNode<T>? Dequeue()
        {
            if (this.values.Count == 0) return null;

            var max = this.values[0];
            var end = this.values[values.Count - 1];
            this.values.RemoveAt(values.Count - 1);

            if (this.values.Count > 0)
            {
                this.values[0] = end;
                bubbleDown();
            }

            return max;
        }

        //추가한 값을 가장 높은 곳으로 올림
        public void bubbleUp()
        {
            int idx = this.values.Count - 1;
            var element = this.values[idx];
            while (idx > 0)
            {
                int parentIdx = (idx - 1) / 2;
                var parent = this.values[parentIdx];
                if (element.priority.CompareTo(parent.priority) >= 0) break;
                this.values[parentIdx] = element;
                this.values[idx] = parent;
                idx = parentIdx;

            }
        }

        public void bubbleDown()
        {
            int idx = 0;
            int length = this.values.Count;
            var element = this.values[idx];

            while (true)
            {
                int leftChildIdx = 2 * idx + 1;
                int rightChildIdx = 2 * idx + 2;
                PNode<T>? leftChild = null;
                PNode<T>? rightChild = null;
                int? swap = null;

                if (leftChildIdx < length)
                {
                    leftChild = this.values[leftChildIdx];
                    if (leftChild.priority.CompareTo(element.priority) < 0)
                    {
                        swap = leftChildIdx;
                    }
                }

                if (rightChildIdx < length)
                {
                    rightChild = this.values[rightChildIdx];
                    if ((swap == default(int) && rightChild.priority.CompareTo(element.priority) < 0) ||
                       (swap != default(int) && rightChild.priority.CompareTo(leftChild.priority) < 0))
                    {
                        swap = rightChildIdx;
                    }
                }

                if (swap == null) break;

                this.values[idx] = this.values[(int)swap];
                this.values[(int)swap] = element;
                idx = (int)swap;
            }
        }
    }
}
