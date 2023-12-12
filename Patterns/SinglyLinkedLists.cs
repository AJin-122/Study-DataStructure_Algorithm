using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    public class Node<T>
    {
        public T val;
        public Node<T>? next;

        public Node(T val)
        {
            this.val = val;
            this.next = null;
        }
    }

    public class SinglyLinkedLists<T>
    {
        public Node<T>? head;
        public Node<T>? tail;
        public int length;

        public SinglyLinkedLists()
        {
            this.head = null;
            this.tail = null;
            this.length = 0;
        }

        public SinglyLinkedLists<T> push(T val)
        {
            Node<T> newNode = new Node<T>(val);

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                this.tail.next = newNode;
                this.tail = newNode;
            }

            this.length++;

            return this;
        }

        public void traverse()
        {
            Node<T>? current = this.head;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
            Console.WriteLine("길이 : " + this.length);
        }

        public Node<T>? pop()
        {
            if (this.head == null) return null;

            Node<T>? current = this.head;
            Node<T>? newTail = current;

            while (current.next != null)
            {
                newTail = current;
                current = current.next;
            }

            //Console.WriteLine("current : " + current.val);
            //Console.WriteLine("new Tail : " + newTail.val);

            this.tail = newTail;
            this.tail.next = null;
            this.length--;

            if (this.length == 0)
            {
                this.head = null;
                this.tail = null;
            }

            return current;
        }

        public Node<T>? shift()
        {
            if (this.head == null) return null;

            Node<T> currentHead = this.head;
            this.head = currentHead.next;
            currentHead.next = null;
            this.length--;

            if (this.length == 0)
            {
                this.head = null;
                this.tail = null;
            }

            return currentHead;
        }

        public SinglyLinkedLists<T> unshift(T val)
        {
            Node<T> newNode = new Node<T>(val);

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                newNode.next = this.head;
                this.head = newNode;
            }

            this.length++;

            return this;
        }

        public Node<T>? get(int index)
        {
            if (index < 0 || index >= this.length) return null;

            int counter = 0;
            Node<T>? current = this.head;
            while (counter != index)
            {
                current = current.next;
                counter++;
            }

            return current;
        }

        public bool set(int index, T val)
        {
            Node<T>? foundNode = this.get(index);

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
            if (index == 0 )
                return this.unshift(val) != null ? true : false;
            
            var newNode = new Node<T>(val);
            var prev = this.get(index - 1);
            var temp = prev.next;
            prev.next = newNode;
            newNode.next = temp;
            this.length++;

            return true;
        }

        public Node<T>? remove(int index)
        {
            if (index < 0 || index >= this.length) return null;
            if (index == this.length - 1) return this.pop();
            if (index == 0) return this.shift();

            var prev = this.get(index - 1);
            var removed = prev.next;
            prev.next = removed.next;
            this.length--;

            return removed;
        }

        public SinglyLinkedLists<T> reverse()
        {
            var node = this.head;
            this.head = this.tail;
            this.tail = node;
            Node<T>? next = null;
            Node<T>? prev = null;

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
