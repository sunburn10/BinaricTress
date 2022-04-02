using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaricTreeSearch
{
    class Program
    {
        public static void PrintInOrder<T>(BinNode<T> bt)
        {
            if (bt != null)
            {
                PrintInOrder(bt.GetLeft());
                Console.Write(bt.GetValue() + ", "); // ביקור
                PrintInOrder(bt.GetRight());
            }
        }
        // חיפוש בעץ חיפוש
        public static bool IsInTree(BinNode<int> bt, int num)
        {
            if (bt == null)
                return false;
            if (bt.GetValue() == num)
                return true;
            if (bt.GetValue() < num)
                return IsInTree(bt.GetRight(), num);
            return IsInTree(bt.GetLeft(), num);
        }
        // מקבלת עץ חיפוש וערך ומוסיפה אותו לעץ
        // הנחה שהעץ אינו ריק
        public static void InsertToSortedTree(BinNode<int> bt, int num)
        {
            if (num < bt.GetValue())
            {
                if (bt.GetLeft() == null)
                    bt.SetLeft(new BinNode<int>(num));
                else
                    InsertToSortedTree(bt.GetLeft(), num);
            }
            else
            {
                if (bt.GetRight() == null)
                    bt.SetRight(new BinNode<int>(num));
                else
                    InsertToSortedTree(bt.GetRight(), num);
            }
        }
        public static BinNode<int> BuildTree()
        {
            Random rnd = new Random();
            BinNode<int> bt = new BinNode<int>(rnd.Next(10, 100));
            for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(10, 100);
                if (!IsInTree(bt, x))
                    InsertToSortedTree(bt, x);
            }
            PrintInOrder(bt);
            return bt;
        }

        public static Node<int> CreateListProgression(BinNode<int> bt)
        {
            Node<int> help = null;
            if (bt != null)
            {
                PrintInOrder(bt.GetLeft());
                Console.Write(bt.GetValue() + ", "); // ביקור
                PrintInOrder(bt.GetRight());
            }
        }
        static void Main(string[] args)
        {
            BinNode<int> bt1 = BuildTree();
            Console.ReadLine();
        }
    }
}
