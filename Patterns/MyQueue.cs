using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class MyQueue<T>
    {
        public Node<T>? first;
        public Node<T>? last;
        public int size;

        public MyQueue()
        {
            first = null;
            last = null;
            size = 0;
        }

        public int enqueue(T val)
        {
            var newNode = new Node<T>(val);

            if(this.first == null)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else
            {
                this.last.next = newNode;
                this.last = newNode;
            }

            return ++this.size;
        }

        public T? dequeue()
        {
            if(this.first == null) return default(T);

            var temp = this.first;

            if(this.first == this.last)
            {
                this.last = null;
            }

            this.first = this.first.next;
            temp.next = null;
            this.size--;

            return temp.val;
        }
    }
}
