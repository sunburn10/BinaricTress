using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaricTrees
{

    class TriBinNode<T>
    {
        private TriBinNode<T> Left;

        private TriBinNode<T> Middle;

        private TriBinNode<T> Right;

        private T Value;

        //-----------------------------
        public TriBinNode(T x)
        {
            this.Left = null;

            this.Value = x;

            this.Middle = null;

            this.Right = null;
        }
        //-----------------------------
        public TriBinNode(TriBinNode<T> Left, TriBinNode<T> Middle, TriBinNode<T> Right, T x)
        {
            this.Left = Left;

            this.Value = x;

            this.Right = Right;
        }
        //-----------------------------

        public T GetValue()
        {
            return (this.Value);
        }
        //-----------------------------

        public void SetValue(T x)
        {
            this.Value = x;
        }
        //-----------------------------
        public TriBinNode<T> GetLeft()
        {
            return (this.Left);
        }
        //-----------------------------
        public TriBinNode<T> GetRight()
        {
            return (this.Right);
        }
        //-----------------------------
        public TriBinNode<T> GetMiddle()
        {
            return (this.Middle);
        }
        //-----------------------------
        public void SetLeft(TriBinNode<T> left)
        {
            this.Left = left;
        }
        //-----------------------------
        public bool hasLeft()
        {
            return (this.Left != null);


        }
        //-----------------------------
        public bool hasRight()
        {
            return (this.Right != null);

        }
        //-----------------------------
        public void SetRight(TriBinNode<T> right)
        {
            this.Right = right;
        }
        //---------------------------------
        public bool hasMiddle()
        {
            return (this.Right != null);

        }
        //-----------------------------
        public void SetMiddle(TriBinNode<T> right)
        {
            this.Right = right;
        }
        //-----------------------------
        public override string ToString()
        {
            return (this.Value.ToString());
        }

    }
}
