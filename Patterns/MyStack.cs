using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class MyStack<T>
    {
        public Node<T>? first;
        public Node<T>? last;
        public int size;

        public MyStack()
        {
            first = null;
            last = null;
            size = 0;
        }

        public T? pop()
        {
            if (this.first == null) return default(T);

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

        public int push(T val)
        {
            var newNode = new Node<T>(val);

            if (this.first == null)
            {
                this.first = newNode;
                this.last = this.first;
            }
            else
            {
                var temp = this.first;
                this.first = newNode;
                this.first.next = temp;
            }

            return ++this.size;
        }
    }
}
