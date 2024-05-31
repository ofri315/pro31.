using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matconet_rev26._04
{
    internal class Node<T>
    {
        private T Value;
        private Node<T> next;
        public Node(T value)
        {
            this.Value = value;
            this.next = null;
        }
        public Node(T value, Node<T> next)
        {
            this.Value = value;
            this.next = next;
        }
        public T GetValue()
        {
            return this.Value;
        }
        public Node<T> GetNext()
        {
            return this.next;
        }
        public void SetValue(T value)
        {
            this.Value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public bool hasNext()
        {
            return this.GetNext() != null;
        }
        public override string ToString()
        {
            return "" + this.Value;
        }
    }
}
