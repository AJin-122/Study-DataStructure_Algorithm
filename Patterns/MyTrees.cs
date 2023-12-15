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

        //트리 너비 우선 탐색
        public List<T> BFS()
        {
            List<T> list = new List<T>();
            Queue<TNode<T>?> qu = new Queue<TNode<T>?>();
            TNode<T>? node = this.root;

            qu.Enqueue(node);

            while (qu.Count > 0)
            {
                node = qu.Dequeue();
                list.Add(node.value);
                if(node.left != null) { qu.Enqueue(node.left); }
                if (node.right != null) { qu.Enqueue(node.right); }
            }

            return list;
        }

        public List<T> DFSPreOrder()
        {
            var result = new List<T>();
            return traversePreOrder(this.root, result); ;
        }

        public List<T> traversePreOrder(TNode<T>? node, List<T> data)
        {
            data.Add(node.value);
            if(node.left != null) traversePreOrder(node.left, data);
            if(node.right != null) traversePreOrder(node.right, data);

            return data;
        }

        public List<T> DFSPostOrder()
        {
            var result = new List<T>();

            return traversePostOrder(this.root, result); ;
        }

        public List<T> traversePostOrder(TNode<T>? node, List<T> data)
        {
            if (node.left != null) traversePostOrder(node.left, data);
            if (node.right != null) traversePostOrder(node.right, data);
            data.Add(node.value);
         
            return data;
        }

        public List<T> DFSInOrder()
        {
            var result = new List<T>();

            return traverseInOrder(this.root, result); ;
        }

        public List<T> traverseInOrder(TNode<T>? node, List<T> data)
        {
            if (node.left != null) traverseInOrder(node.left, data);
            data.Add(node.value);
            if (node.right != null) traverseInOrder(node.right, data);

            return data;
        }
    }
}
