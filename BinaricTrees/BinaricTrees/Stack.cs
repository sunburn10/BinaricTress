using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaricTrees
{
    public class Stack<T>
    {
        private Node<T> first;

        public Stack()
        {
            this.first = null;
        }

        public bool IsEmpty()
        {
            return this.first == null;

        }

        public void Push(T x)
        {
            this.first = new Node<T>(x, this.first);
        }

        public T Pop()
        {
            T x = this.first.GetValue();
            this.first = this.first.GetNext();

            return x;
        }

        public T Top()
        {
            return this.first.GetValue();
        }

        // פעולה המעתיקה את המחסנית
        public Stack<T> Copystack()
        {
            Node<T> pos = this.first;
            Stack<T> temp = new Stack<T>();
            while (pos != null)
            {
                temp.Push(pos.GetValue());
                pos = pos.GetNext();
            }
            Stack<T> temp2 = new Stack<T>();
            while (!temp.IsEmpty())
            {
                temp2.Push(temp.Pop());
            }
            return temp2;
        }

        public override string ToString()
        {
            string str = "[";

            Node<T> pos = this.first;
            while (pos != null)
            {
                str = str + pos.GetValue().ToString();
                if (pos.GetNext() != null)
                    str = str += ",";
                pos = pos.GetNext();
            }
            str = str + "]";
            return str;
        }

    }
}
