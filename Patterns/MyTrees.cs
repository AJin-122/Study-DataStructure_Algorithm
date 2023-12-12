using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class TNode<T> where T : IComparable
    {
        public T value;
        public TNode<T>? left;
        public TNode<T>? right;

        public TNode(T value)
        {
            this.value = value;
            this.right = null;
            this.left = null;
        }
    }

    public class MyTrees<T> where T : IComparable
    {
        public TNode<T>? root;

        public MyTrees()
        {
            this.root = null;
        }

        //public MyTrees<T>? insert(T val)
        //{
        //    var newNode = new TNode<T>(val);

        //    if (this.root == null)
        //    {
        //        this.root = newNode;
        //        return this;
        //    }
        //    //CompareTo 대상 > 비교 1, 대상 < 비교 -1
        //    else
        //    {
        //        var current = this.root;

        //        while(true)
        //        {
        //            if (val.CompareTo(current.value) == 0) return null;
        //            if(val.CompareTo(current.value) < 0)
        //            {
        //                if(current.left == null)
        //                {
        //                    current.left = newNode;
        //                    return this;
        //                }
        //                else
        //                {
        //                    current = current.left;
        //                }
        //            }
        //            else
        //            {
        //                if (current.right == null)
        //                {
        //                    current.right = newNode;
        //                    return this;
        //                }
        //                else
        //                {
        //                    current = current.right;
        //                }
        //            }
        //        }
        //    }
        //}
        //else 정리
        public MyTrees<T>? insert(T val)
        {
            var newNode = new TNode<T>(val);

            if (this.root == null)
            {
                this.root = newNode;
                return this;
            }
            //CompareTo 대상 > 비교 1, 대상 < 비교 -1
            var current = this.root;

            while (true)
            {
                if (val.CompareTo(current.value) == 0) return null;
                if (val.CompareTo(current.value) < 0)
                {
                    if (current.left == null)
                    {
                        current.left = newNode;
                        return this;
                    }
                    current = current.left;
                }
                else
                {
                    if (current.right == null)
                    {
                        current.right = newNode;
                        return this;
                    }
                    current = current.right;
                }
            }
        }

        public TNode<T>? find(T val)
        {
            if (this.root == null) return null;

            //CompareTo 대상 > 비교 1, 대상 < 비교 -1
            var current = this.root;
            bool found = false;
            while (current != null && !found)
            {
                if (val.CompareTo(current.value) < 0)
                {
                    current = current.left;
                }
                else if(val.CompareTo(current.value) > 0)
                {
                    current = current.right;
                }
                else
                {
                    found = true;
                }
            }

            return current;
        }
    }
}
