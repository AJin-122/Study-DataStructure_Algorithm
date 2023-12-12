using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class DNode<T>
    {
        public T val;
        public DNode<T>? next;
        public DNode<T>? prev;

        public DNode(T val)
        {
            this.val = val;
            next = null;
            prev = null;
        }
    }

    public class DoublyLinkedLists<T>
    {
        public DNode<T>? head;
        public DNode<T>? tail;
        public int length;

        public DoublyLinkedLists()
        {
            this.head = null;
            this.tail = null;
            this.length = 0;
        }

        public DoublyLinkedLists<T> push(T val)
        {
            var newNode = new DNode<T>(val);

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                this.tail.next = newNode;
                newNode.prev = this.tail;
                this.tail = newNode;
            }

            this.length++;

            return this;
        }

        public void traverse()
        {
            var current = this.head;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
            Console.WriteLine("길이 : " + this.length);
        }

        public DNode<T>? pop()
        {
            if (this.head == null) return null;

            var poppedNode = this.tail;

            if(this.length == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = poppedNode.prev;
                this.tail.next = null;
                poppedNode.prev = null;
            }

            this.length--;

            return poppedNode;
        }

        public DNode<T>? shift()
        {
            if (this.head == null) return null;

            var oldHead = this.head;

            if(this.length == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = oldHead.next;
                this.head.prev = null;
                oldHead.next = null;
            }

            this.length--;

            return oldHead;
        }

        public DoublyLinkedLists<T> unshift(T val)
        {
            var newNode = new DNode<T>(val);

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                newNode.next = this.head;
                this.head.prev = newNode;
                this.head = newNode;
            }

            this.length++;

            return this;
        }

        public DNode<T>? get(int index)
        {
            if (index < 0 || index >= this.length) return null;

            DNode<T>? current = null;

            if(index <= this.length/2)
            {
                //Console.WriteLine("Start");
                int counter = 0;
                current = this.head;
                while (counter != index)
                {
                    current = current.next;
                    counter++;
                }
            }
            else
            {
                //Console.WriteLine("End");
                int counter = this.length-1;
                current = this.tail;
                while (counter != index)
                {
                    current = current.prev;
                    counter--;
                }
            }

            return current;
        }

        public bool set(int index, T val)
        {
            var foundNode = this.get(index);

            if (foundNode != null)
            {
                foundNode.val = val;
                return true;
            }

            return false;
        }

        public bool insert(int index, T val)
        {
            if (index < 0 || index > this.length) return false;
            if (index == this.length)
                return this.push(val) != null ? true : false;
            if (index == 0)
                return this.unshift(val) != null ? true : false;

            var newNode = new DNode<T>(val);
            var prev = this.get(index - 1);
            var temp = prev.next;

            prev.next = newNode; newNode.prev = prev;
            newNode.next = temp; temp.prev = newNode;
            
            this.length++;

            return true;
        }

        public DNode<T>? remove(int index)
        {
            if (index < 0 || index >= this.length) return null;
            if (index == this.length - 1) return this.pop();
            if (index == 0) return this.shift();

            var removed = this.get(index);
            removed.prev.next = removed.next;
            removed.next.prev = removed.prev;
            removed.next = null;
            removed.prev = null;
            this.length--;

            return removed;
        }

        public DoublyLinkedLists<T> reverse()
        {
            var node = this.head;
            this.head = this.tail;
            this.tail = node;
            DNode<T>? next = null;
            DNode<T>? prev = null;

            for (int i = 0; i < this.length; i++)
            {
                next = node.next;
                node.next = prev;
                prev = node;
                node = next;
            }

            return this;
        }
    }
}
