using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaricTrees
{
    class Program
    {
        public static void PrintPreOrder<T>(BinNode<T> bt)
        {
            if (bt != null)
            {
                Console.Write(bt.GetValue() + ", "); // ביקור
                PrintPreOrder(bt.GetLeft());
                PrintPreOrder(bt.GetRight());
            }
        }
        public static void PrinInOrder<T>(BinNode<T> bt)
        {
            if (bt != null)
            {
                PrintPreOrder(bt.GetLeft());
                Console.Write(bt.GetValue() + ", "); // ביקור
                PrintPreOrder(bt.GetRight());
            }
        }
        public static void PrintPostOrder<T>(BinNode<T> bt)
        {
            if (bt != null)
            {
                PrintPreOrder(bt.GetLeft());
                PrintPreOrder(bt.GetRight());
                Console.Write(bt.GetValue() + ", "); // ביקור
            }
        }

        // פעולה המדפיסה את כל הצמתים הזוגיים בעץ
        public static void PrintEvens(BinNode<int> bt)
        {
            if (bt != null)
            {
                if (bt.GetValue() % 2 == 0)
                    Console.Write(bt.GetValue() + ", ");
                PrintEvens(bt.GetLeft());
                PrintEvens(bt.GetRight());
            }
        }

        public static bool IsLeaf<T>(BinNode<T> bt)
        {
            return bt.GetRight() == null && bt.GetLeft() == null;
        }
        public static int CountLeaves(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            int x = 0;
            if (IsLeaf(bt))
                x = 1;
            return CountLeaves(bt.GetLeft()) + CountLeaves(bt.GetRight()) + x;
        }

        // סכום הערכים בכל העץ
        public static int SumTree(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            int x = bt.GetValue();
            return SumTree(bt.GetLeft()) + SumTree(bt.GetRight()) + x;
        }


        // פעולה המדפיסה את כל הצמתים הגדולים מהילד.ים שלהם
        public static void IsParentBigger(BinNode<int> bt)
        {
            if (bt != null)
            {
                // יש שני בנים
                if (bt.GetLeft() != null && bt.GetValue() > bt.GetLeft().GetValue() && bt.GetRight() != null && bt.GetValue() > bt.GetRight().GetValue())
                    Console.WriteLine(bt.GetValue());
                // יש רק בן ימני
                if (bt.GetLeft() == null && bt.GetRight() != null && bt.GetValue() > bt.GetRight().GetValue())
                    Console.WriteLine(bt.GetValue());
                // יש רק בן שמאלי
                if (bt.GetRight() == null && bt.GetLeft() != null && bt.GetValue() > bt.GetLeft().GetValue())
                    Console.WriteLine(bt.GetValue());
                IsParentBigger(bt.GetLeft());
                IsParentBigger(bt.GetRight());
            }
        }


        // הפעולה מקבלת עץ ואיבר ומחזירה את מספר הפעמים שהאיבר מופיע בתוך העץ
        public static int XRepeat(BinNode<int> bt, int x)
        {
            if (bt == null)
                return 0;
            int count = 0;
            if (bt.GetValue() == x)
                count = 1;
            return XRepeat(bt.GetLeft(), x) + XRepeat(bt.GetRight(), x) + count;
        }

        public static bool IsExist(BinNode<int> bt, int x)
        {
            if (bt == null)
                return false;
            if (bt.GetValue() == x)
                return true;
            return IsExist(bt.GetRight(), x) || IsExist(bt.GetLeft(), x);
        }

        // פעולה הבודקת האם כל הערכים בעץ מתחלקים בשלוש
        public static bool IsDividedByThree(BinNode<int> bt)
        {
            if (bt == null)
                return true;
            if (bt.GetValue() % 3 != 0)
                return false;
            return IsDividedByThree(bt.GetRight()) || IsDividedByThree(bt.GetLeft());
        }

        // פעולה הסופרת כמה צמתים יש בעץ
        public static int CountNode(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            return CountNode(bt.GetLeft()) + CountNode(bt.GetRight()) + 1;
        }

        // עמוד 176 תרגיל 11
        // כתוב פעולה המקבלת עץ ומדפיסה את כל הצמתים שלהם ערך זוגי ואין להם בן אי זוגי
        public static void EvenSmallFamily(BinNode<int> bt)
        {
            if (bt != null)
            {
                if (bt.GetValue() % 2 == 0 && bt.GetLeft() != null && bt.GetRight() != null && bt.GetLeft().GetValue() % 2 == 0 && bt.GetRight().GetValue() % 2 == 0)
                    Console.WriteLine(bt.GetValue());
                if (bt.GetValue() % 2 == 0 && bt.GetLeft() == null && bt.GetRight() != null && bt.GetRight().GetValue() % 2 == 0)
                    Console.WriteLine(bt.GetValue());
                if (bt.GetValue() % 2 == 0 && bt.GetLeft() != null && bt.GetRight() == null && bt.GetLeft().GetValue() % 2 == 0)
                    Console.WriteLine(bt.GetValue());
                EvenSmallFamily(bt.GetRight());
                EvenSmallFamily(bt.GetLeft());
            }
        }

        // עמוד 176 תרגיל 12
        // כתוב פעולה המקבלת עץ ומחזירה את מספר הצמתים שערכם בין 10 ל100
        public static int CountInBetween(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            int count = 0;
            if (10 <= bt.GetValue() && bt.GetValue() < 100)
                count = 1;
            return CountInBetween(bt.GetLeft()) + CountInBetween(bt.GetRight()) + count;
        }

        // עמוד 176 תרגיל 13
        // כתוב פעולה המקבלת עץ ומדפיסה עבור כל אב את הערך של בנו שהערך יותר קרוב לערך האב. אם לאב יש בן יחיד יודפס הבן הזה.
        public static void PrintCloserSon(BinNode<int> bt)
        {
            if (bt != null)
            {
                if (bt.GetRight() != null && bt.GetLeft() != null && Math.Abs(bt.GetValue() - bt.GetLeft().GetValue()) >= Math.Abs(bt.GetValue() - bt.GetLeft().GetValue()))
                    Console.WriteLine(bt.GetRight().GetValue());
                if (bt.GetRight() != null && bt.GetLeft() != null && Math.Abs(bt.GetValue() - bt.GetLeft().GetValue()) < Math.Abs(bt.GetValue() - bt.GetLeft().GetValue()))
                    Console.WriteLine(bt.GetLeft().GetValue());
                if (bt.GetRight() == null && bt.GetLeft() != null)
                    Console.WriteLine(bt.GetLeft().GetValue());
                if (bt.GetLeft() == null && bt.GetRight() != null)
                    Console.WriteLine(bt.GetRight().GetValue());
                PrintCloserSon(bt.GetLeft());
                PrintCloserSon(bt.GetRight());
            }
        }

        // עמוד 176 תרגיל 14
        // כתוב פעולה המחזירה את מספר העלים בעץ
        public static int CountLeaves2(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            int x = 0;
            if (IsLeaf(bt))
                x = 1;
            return CountLeaves2(bt.GetLeft()) + CountLeaves2(bt.GetRight()) + x;
        }


        // עמוד 176 תרגיל 15
        // כתוב פעולה המקבלת עץ ושני מספרים ומחזירה את כל הצמתים בין שני המספרים
        public static int CountLowHigh(BinNode<int> bt, int low, int high)
        {
            if (bt == null)
                return 0;
            int count = 0;
            if (low <= bt.GetValue() && bt.GetValue() < high)
                count = 1;
            return CountLowHigh(bt.GetLeft(), low, high) + CountLowHigh(bt.GetRight(), low, high) + count;
        }

        // עמוד 176 תרגיל 16
        // מקבלת עץ ומחזירה את כל הצמתים שיש להם שני בנים
        public static int CountFullSmallFamily(BinNode<int> bt)
        {
            int count = 0;
            if (bt != null)
            {

                if (bt.GetLeft() != null && bt.GetRight() != null)
                    count = 1;
            }
            return CountFullSmallFamily(bt.GetRight()) + CountFullSmallFamily(bt.GetLeft()) + count;
        }

        public static int HasFourGrandkids(BinNode<int> bt)
        {
            int c = 0;
            if (bt == null)
                return 0;
            if (bt.GetRight() != null && bt.GetLeft() != null)
            {
                if (IsLeaf(bt.GetRight()) || IsLeaf(bt.GetLeft()))
                    c = 0;
                else
                    c = 1;
            }
            return HasFourGrandkids(bt.GetLeft()) + HasFourGrandkids(bt.GetRight()) + c;
        }


        // כתוב פעולה המקבלת את שורשו של עץ , הפעולה תחזיר את ערכו של המספר המקסימלי בעץ
        public static int MaxInTree(BinNode<int> bt)
        {
            if (IsLeaf(bt))
                return bt.GetValue();
            if (bt.GetRight() == null)
            {
                return Math.Max(MaxInTree(bt.GetLeft()), bt.GetValue());
            }
            if (bt.GetLeft() == null)
            {
                return Math.Max(MaxInTree(bt.GetRight()), bt.GetValue());
            }
            return max3(bt.GetValue(), MaxInTree(bt.GetRight()), MaxInTree(bt.GetLeft()));

        }
        public static int max3(int num1, int num2, int num3)
        {
            return Math.Max(Math.Max(num1, num2), num3);
        }

        // פעולה מקבלת עץ ומחזירה את גובהו של העץ
        public static int TreeHeight(BinNode<int> bt)
        {
            if (bt == null)
                return -1;
            return Math.Max(TreeHeight(bt.GetLeft()), TreeHeight(bt.GetRight())) + 1;
        }

        // פעולה המקבלת שורש של עץ ומספר רמה, הפעולה תחזיר את מספר הצמתים ברמה שהתקבלה
        public static int NodesInLevel(BinNode<int> bt, int lvl)
        {
            if (bt == null)
                return 0;
            if (lvl == 0)
                return 1;
            return NodesInLevel(bt.GetRight(), lvl - 1) + NodesInLevel(bt.GetLeft(), lvl - 1);
        }

        // הפעולה מקבלת עץ ושני ערכים ובודקת אם אחד מהערכים צאצא של השני
        public static bool IsChild(BinNode<int> bt, int x, int y)
        {
            if (bt == null)
                return false;
            if (bt.GetValue() == x)
            {
                return IsXExist(bt.GetLeft(), y) || IsXExist(bt.GetRight(), y);
            }
            if (bt.GetValue() == y)
            {
                return IsXExist(bt.GetLeft(), x) || IsXExist(bt.GetRight(), x);
            }
            return IsChild(bt.GetRight(), x, y) || IsChild(bt.GetLeft(), x, y);
        }


        // פעולה המקבלת עץ ואיבר ומחזירה את מספר הפעמים שהאיבר מופיע בתוך העץ
        public static int Countx(BinNode<int> bt, int x)
        {
            if (bt == null)
                return 0;
            int count = 0;
            if (bt.GetValue() == x)
                count = 1;
            return Countx(bt.GetLeft(), x) + Countx(bt.GetRight(), x) + count;
        }

        public static bool IsXExist(BinNode<int> bt, int x)
        {
            if (bt == null)
                return false;
            if (bt.GetValue() == x)
                return true;
            return IsXExist(bt.GetLeft(), x) || IsXExist(bt.GetRight(), x);
        }
        // פעולה המקבלת עץ ומספר ומוסיפה לכל עלה שערכו גדול מהמספר בן ימני שערכו המספר
        public static void AddToLeaf(BinNode<int> bt, int n)
        {
            if (bt != null)
            {
                if (IsLeaf(bt))
                {
                    if (bt.GetValue() > n)
                    {
                        BinNode<int> bt2 = new BinNode<int>(n);
                        bt.SetRight(bt2);
                    }
                }
                AddToLeaf(bt.GetRight(), n);
                AddToLeaf(bt.GetLeft(), n);
            }
        }

        // ex 18 
        public static bool AreSameParts(BinNode<int> t1, BinNode<int> t2)
        {
            if (t2 != null)
            {
                if (!IsXExist(t1, t2.GetValue()))
                    return false;
            }
            else
                return true;
            return AreSameParts(t1, t2.GetLeft()) || AreSameParts(t1, t2.GetRight());
        }

        // ex 19
        public static int PlusAndMinus(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            return PlusAndMinus(bt.GetLeft()) + PlusAndMinus(bt.GetRight()) + bt.GetValue();
        }
        // ex 20
        public static int CountX(BinNode<int> bt, int x)
        {
            int count = 0;
            if (bt != null)
            {
                if (bt.GetValue() == x)
                    count = 1;
            }
            if (bt == null)
                return 0;
            return CountX(bt.GetLeft(), x) + CountX(bt.GetRight(), x) + count;
        }
        public static bool IsFollowingTreeN(BinNode<int> bt, int n)
        {
            if (n != 0)
            {
                if (CountX(bt, n) > 1 || CountX(bt, n) == 0)
                    return false;
            }
            if (n == 0)
                return true;
            return IsFollowingTreeN(bt, n - 1);
        }
        // ex 21
        public static bool IsSymmetric(BinNode<int> bt)
        {
            if (bt != null)
            {
                if (Math.Abs(TreeHeight(bt.GetLeft()) - TreeHeight(bt.GetRight())) > 1)
                    return false;
            }
            if (bt == null)
                return true;
            return IsSymmetric(bt.GetLeft()) || IsSymmetric(bt.GetRight());
        }

        // פעולה הסופרת כמה בנים יש לשורש עץ
        public static int CountSons(BinNode<int> bt)
        {
            int count = 0;
            if (bt != null)
                count = 1;
            if (bt == null)
                return 0;
            return CountSons(bt.GetRight()) + CountSons(bt.GetLeft()) + count;
        }

        // ex 22
        public static bool HasOneSon(BinNode<int> bt)
        {
            if (bt.GetLeft() == null && bt.GetRight() == null)
                return false;

            if (bt.GetLeft() != null && bt.GetRight() != null)
                return false;
            return true;
        }
        public static bool NoOnlyChildren(BinNode<int> bt)
        {
            if (bt != null)
            {
                if (HasOneSon(bt))
                    return false;
            }
            if (bt == null)
                return true;
            return NoOnlyChildren(bt.GetRight()) || NoOnlyChildren(bt.GetLeft());
        }


        // ex 24
        public static int CountOnlyChildren(BinNode<int> bt)
        {
            int count = 0;
            if (bt != null)
            {
                if (HasOneSon(bt))
                    count = 1;
            }
            if (bt == null)
                return 0;
            return CountOnlyChildren(bt.GetRight()) + CountOnlyChildren(bt.GetLeft()) + count;
        }

        public static int OnlyChildWithOnlyChild(BinNode<int> bt)
        {
            int count = 0;
            if (bt != null)
            {
                if (HasOneSon(bt) && HasOneSon(bt.GetLeft()))
                    count = 1;
                if (HasOneSon(bt) && HasOneSon(bt.GetRight()))
                    count = 1;
            }
            if (bt == null)
                return 0;
            return OnlyChildWithOnlyChild(bt.GetLeft()) + OnlyChildWithOnlyChild(bt.GetRight()) + count;
        }

        // ex26
        public static bool IsFull(BinNode<int> bt)
        {
            if (CountLeaves(bt) == Math.Pow(2, TreeHeight(bt)))
                return true;
            return false;
        }

        public static bool UpPath(BinNode<int> bt)
        {
            if (bt != null)
            {
                if (bt.GetLeft().GetValue() > bt.GetValue())
                    return UpPath(bt.GetLeft());
                if (bt.GetRight().GetValue() > bt.GetValue())
                    return UpPath(bt.GetRight());
            }
            if (bt == null)
                return true;
            return false;
        }



        // page 181 ex 34
        public static int CountXRepeats(BinNode<InfoTree> bt, char x)
        {
            if (bt == null)
            {
                return 0;
            }

            if (bt.GetValue().GetTav() == x)
                return CountXRepeats(bt.GetLeft(), x) + CountXRepeats(bt.GetRight(), x) + bt.GetValue().GetNum();

            return CountXRepeats(bt.GetLeft(), x) + CountXRepeats(bt.GetRight(), x);
        }


        // ex 34 b, non recursive
        public static int MostRepeats(BinNode<InfoTree> bt)
        {
            int max = 0;
            for (char i = 'a'; i < 'z'; i++)
            {
                if (CountXRepeats(bt, i) > max)
                    max = CountXRepeats(bt, i);
            }
            return max;
        }


        // ex 34 c
        // שאלת מסלול

        public static bool IsLinear(BinNode<InfoTree> bt, char x)
        {
            if (bt == null)
                return true;
            if (IsLeaf(bt))
                return true;
            bool BoLeft = bt.GetLeft() != null && bt.GetLeft().GetValue().GetTav() != x;
            bool BoRight = bt.GetRight() != null && bt.GetRight().GetValue().GetTav() != x;
            bool BoAll = BoRight || BoLeft;
            if (BoAll)
                return BoLeft && IsLinear(bt.GetLeft(), x) || BoRight && IsLinear(bt.GetRight(), x);
            return false;
        }
        public static bool IsLinear(BinNode<InfoTree> bt)
        {
            return IsLinear(bt, bt.GetValue().GetTav());
        }


        //בגרות 2018 קיץ
        // סיבוכיות הפעולה הנה
        // O(N^2)
        // מכיוון שפעולה רקורסיבית עוברת על כל האיברים במקרה הגרוע
        // ובפעולה יש רקורסיה בתוך רקורסיה
        public static bool LessThanTree(BinNode<int> bt, int x)
        {
            if (bt == null)
                return true;
            if (bt.GetValue() < x)
                return false;
            return LessThanTree(bt.GetLeft(), x) && LessThanTree(bt.GetRight(), x);
        }
        public static bool SmallerTree(BinNode<int> bt1, BinNode<int> bt2)
        {
            if (bt2 != null)
            {
                if (!LessThanTree(bt1, bt2.GetValue()))
                    return false;
            }
            else
                return true;
            return SmallerTree(bt1, bt2.GetLeft()) && SmallerTree(bt1, bt2.GetRight());
        }
        public static int CountWays(BinNode<int> bt)
        {
            int count = 0;
            if (IsLeaf(bt))
                count = 1;
            return CountWays(bt.GetRight()) + CountWays(bt.GetLeft()) + count;
        }

        public static void PrintOneWay(BinNode<int> bt, int number)
        {
            if (bt != null)
            {
                number = number * 10 + bt.GetValue();
                if (IsLeaf(bt))
                    Console.WriteLine(number);
                PrintOneWay(bt.GetRight(), number);
                PrintOneWay(bt.GetLeft(), number);
            }
        }
        public static void PrintAll(BinNode<int> bt)
        {
            if (bt != null)
                PrintOneWay(bt, 0);
        }

        public static int CountXRepeatsNum(BinNode<int> bt, int x)
        {
            if (bt == null)
            {
                return 0;
            }
            if (bt.GetValue() == x)
                return CountXRepeatsNum(bt.GetLeft(), x) + CountXRepeatsNum(bt.GetRight(), x) + 1;

            return CountXRepeatsNum(bt.GetLeft(), x) + CountXRepeatsNum(bt.GetRight(), x);
        }

        public static bool IsInNode(Node<TwoItems> lst, TwoItems twoitems)
        {
            Node<TwoItems> copy = lst;
            while (copy != null)
            {
                if (copy.GetValue().GetNum1() == twoitems.GetNum1())
                    return true;
                copy = copy.GetNext();
            }
            return false;
        }
        public static Node<TwoItems> BuildLstFromTree(BinNode<int> bt)
        {
            TwoItems TI = new TwoItems(bt.GetValue(), CountXRepeatsNum(bt, bt.GetValue()));
            Node<TwoItems> help = new Node<TwoItems>(null);
            Node<TwoItems> lst = new Node<TwoItems>(TI, help);
            if (bt != null)
            {
                if (IsInNode(lst, TI))
                    lst = new Node<TwoItems>(null, lst);
                BuildLstFromTree(bt.GetRight());
                BuildLstFromTree(bt.GetLeft());
            }
            return lst;
        }
        public static void printlist<T>(Node<T> lst)
        {
            Node<T> pos = lst;
            while (pos != null)
            {
                Console.Write(pos.GetValue() + "-->");
                pos = pos.GetNext();
            }
            Console.WriteLine();
        }
        public static Node<TwoItems> EvenNum(BinNode<int> bt)
        {
            Node<TwoItems> list = null;
            list = EvenNum(bt, list);
            return list;
        }
        public static Node<TwoItems> EvenNum(BinNode<int> bt, Node<TwoItems> ls)
        {
            if (bt != null)
            {
                TwoItems ti = new TwoItems(bt.GetValue(), CountXRepeatsNum(bt, bt.GetValue()));
                if (!IsInNode(ls, ti))
                    ls = new Node<TwoItems>(ti, ls);
                ls = EvenNum(bt.GetLeft(), ls);
                ls = EvenNum(bt.GetRight(), ls);
            }
            return ls;
        }

        public static void AddBro(BinNode<int> bt)
        {
            if (bt != null)
            {
                if (bt.GetLeft() == null && bt.GetRight() != null)
                {
                    BinNode<int> bt1 = new BinNode<int>(bt.GetRight().GetValue());
                    bt = new BinNode<int>(bt1, bt.GetValue(), bt.GetRight());
                }
                if (bt.GetLeft() != null && bt.GetRight() == null)
                {
                    BinNode<int> bt1 = new BinNode<int>(bt.GetLeft().GetValue());
                    bt = new BinNode<int>(bt.GetLeft(), bt.GetValue(), bt1);
                }
                AddBro(bt.GetLeft());
                AddBro(bt.GetRight());
            }
        }


        // בגרות קיץ 2012
        // N - מספר הצמתים בעץ
        // ונסרוק את כולםםםם
        // * pokemon theme starts playing *
        // בפעולה בסעיף א אנו סורקים את כל הצמתים בעץ פעם אחת.
        // בכל איבר בעץ אנו עוברים על מחסנית לכל היותר על שלושה איברים
        // לכן סהכ סיבוכיות הפעולה היא
        // O(3n)
        // סיבוכיות לינארית 
        public static int SumByRules(Stack<int> st)
        {
            Stack<int> copy = st.Copystack();
            int sum = 0;
            int count = 0;
            while (count != 3)
            {
                if (copy.IsEmpty())
                    count = 3;
                sum += copy.Pop();
                count++;
            }
            return sum;
        }

        public static Stack<int> WeirdASF(BinNode<Stack<int>> bt)
        {
            Stack<int> current = new Stack<int>(); // Creating new stack
            WeirdASF(bt, current);
            return current;
        }
        public static void WeirdASF(BinNode<Stack<int>> bt, Stack<int> st)
        {
            if (bt != null)
            {
                WeirdASF(bt.GetLeft(), st);
                int sum = SumByRules(bt.GetValue());
                st.Push(sum);
            }
        }


        // בגרות 2011 קיץ ב
        public static void Leaves(BinNode<int> bt, Stack<int> st)
        {
            if (bt != null)
            {
                if (IsLeaf(bt))
                {
                    st.Push(bt.GetValue());
                }
                Leaves(bt.GetRight(), st);
                Leaves(bt.GetLeft(), st);
            }
        }
        public static int StackLen(Stack<int> st)
        {
            Stack<int> copy = st.Copystack();
            int count = 0;
            while (!copy.IsEmpty())
            {
                count++;
                copy.Pop();
            }
            return count;
        }


        public static bool CompareStacks(Stack<int> st1, Stack<int> st2)
        {
            Stack<int> copy1 = st1.Copystack();
            Stack<int> copy2 = st2.Copystack();
            if (StackLen(copy1) != StackLen(copy2))
                return false;
            while (!copy1.IsEmpty())
            {
                if (copy1.Pop() != copy2.Pop())
                    return false;
            }
            return true;
        }
        // סעיף ב
        public static bool IsSame(BinNode<int> bt1, BinNode<int> bt2)
        {
            if (CountLeaves(bt1) != CountLeaves(bt2))
                return false;
            Stack<int> st1 = new Stack<int>();
            Leaves(bt1, st1);
            Stack<int> st2 = new Stack<int>();
            Leaves(bt2, st2);
            if (!CompareStacks(st1, st2))
                return false;
            return true;
        }

        // בגרות 2013 קיץ ב
        public static int Max4(int a, int b, int c, int d)
        {
            return Math.Max(Math.Max(a, b), Math.Max(c, d));
        }

        public static int Big(TriBinNode<int> trt)
        {
            if (trt == null)
                return -1;
            int maxleft = Big(trt.GetLeft());
            int maxmiddle = Big(trt.GetMiddle());
            int maxright = Big(trt.GetRight());
            return Max4(trt.GetValue(), maxleft, maxmiddle, maxright);
        }

        // סעיף ב
        public static bool NoThree(TriBinNode<int> trt)
        {
            if (trt != null)
            {
                if (trt.GetLeft() != null && trt.GetMiddle() != null && trt.GetRight() != null)
                {
                    return false;
                }
                NoThree(trt.GetLeft());
                NoThree(trt.GetMiddle()); 
                NoThree(trt.GetRight());
            }
            return true;
        }
        static void Main(string[] args)
        {
            // בניית עץ
            BinNode<int> bt1 = new BinNode<int>(4);
            bt1 = new BinNode<int>(bt1, 13, null);
            BinNode<int> bt2 = new BinNode<int>(8);
            bt1 = new BinNode<int>(bt1, 5, bt2);
            bt2 = new BinNode<int>(9);
            bt2 = new BinNode<int>(null, 10, bt2);
            bt1 = new BinNode<int>(bt2, 7, bt1);

            BinNode<int> bt3 = new BinNode<int>(0);
            bt3 = new BinNode<int>(bt1, 0, null);
            BinNode<int> bt4 = new BinNode<int>(0);
            bt3 = new BinNode<int>(bt1, 0, bt2);
            bt4 = new BinNode<int>(0);
            bt4 = new BinNode<int>(null, 0, bt2);
            bt3 = new BinNode<int>(bt2, 0, bt1);
            Console.WriteLine("preorder");
            PrintPreOrder(bt1);
            Console.WriteLine();
            Console.WriteLine("inorder");
            PrinInOrder(bt1);
            Console.WriteLine();
            Console.WriteLine("postorder");
            PrintPostOrder(bt1);
            Console.WriteLine();
            Console.WriteLine("PrintEvens");
            PrintEvens(bt1);
            Console.WriteLine();
            Console.WriteLine("CountLeaves");
            Console.WriteLine(CountLeaves(bt1));
            Console.WriteLine("SumTree");
            Console.WriteLine(SumTree(bt1));
            Console.WriteLine("IsParentBigger");
            IsParentBigger(bt1);
            Console.WriteLine("XRepeat");
            Console.WriteLine(XRepeat(bt1, 130));
            Console.WriteLine("IsExist");
            Console.WriteLine(IsExist(bt1, 55));
            Console.WriteLine("IsDividedBy3");
            Console.WriteLine(IsDividedByThree(bt1));
            Console.WriteLine("CountNode");
            Console.WriteLine(CountNode(bt1));
            Console.WriteLine("PrintEvensFamily");
            EvenSmallFamily(bt1);
            Console.WriteLine("CountInBetween");
            Console.WriteLine(CountInBetween(bt1));
            Console.WriteLine("PrintCloserSon");
            PrintCloserSon(bt1);
            Console.WriteLine("PlusAndMinus");
            Console.WriteLine(PlusAndMinus(bt1));
            Console.WriteLine("IsSymmetric");
            Console.WriteLine(IsSymmetric(bt1));
            Console.WriteLine("SmallerTree");
            Console.WriteLine(SmallerTree(bt1, bt3));

            // בניית עץ עם אובייקט
            InfoTree t1 = new InfoTree('k', 3);
            InfoTree t2 = new InfoTree('k', 1);
            InfoTree t3 = new InfoTree('k', 0);
            InfoTree t4 = new InfoTree('k', 0);
            InfoTree t5 = new InfoTree('k', 0);
            InfoTree t6 = new InfoTree('c', 1);
            InfoTree t7 = new InfoTree('c', 0);
            InfoTree t8 = new InfoTree('e', 0);

            BinNode<InfoTree> bt1o = new BinNode<InfoTree>(t8);
            bt1o = new BinNode<InfoTree>(bt1o, t5, null);
            BinNode<InfoTree> bt2o = new BinNode<InfoTree>(t3);
            bt1o = new BinNode<InfoTree>(bt2o, t2, bt1o);
            bt2o = new BinNode<InfoTree>(t7);
            bt2o = new BinNode<InfoTree>(null, t6, bt2o);
            bt2o = new BinNode<InfoTree>(bt2o, t4, null);
            bt1o = new BinNode<InfoTree>(bt1o, t1, bt2o);


            Console.WriteLine("CountXRepeats");
            Console.WriteLine(CountXRepeats(bt1o, 'c'));
            //PrintPreOrder(bt1o);
            Console.WriteLine(MostRepeats(bt1o));
            Console.WriteLine(IsLinear(bt1o));


            // בניית עץ
            BinNode<int> bt1a = new BinNode<int>(3);
            BinNode<int> bt2a = new BinNode<int>(2);
            bt1a = new BinNode<int>(bt1a, 2, bt2a);
            bt2a = new BinNode<int>(5);
            bt2a = new BinNode<int>(null, 9, bt2a);
            bt1a = new BinNode<int>(bt1a, 1, bt2a);
            PrintPreOrder(bt1a);
            Console.WriteLine("PrintAll");
            PrintAll(bt1a);

            Console.WriteLine("BuildLstFromTree");
            Node<TwoItems> lstTI = EvenNum(bt1a);
            printlist(lstTI);

            // בניית עץ
            BinNode<int> bt1b = new BinNode<int>(6);
            bt1b = new BinNode<int>(null, 5, bt1b);
            bt1b = new BinNode<int>(bt1b, 3, null);
            BinNode<int> bt2b = new BinNode<int>(4);
            bt2b = new BinNode<int>(bt2b, 2, null);
            bt1b = new BinNode<int>(bt2b, 1, bt1b);

            AddBro(bt1b);
            PrintPreOrder(bt1b);


            Console.WriteLine("Leaves");
            Stack<int> st = new Stack<int>();
            Console.WriteLine("");
            Leaves(bt1, st);
            Console.WriteLine(st);


            // בניית עץ טרינארי
            TriBinNode<int> trt1 = new TriBinNode<int>(9);
            TriBinNode<int> trt2 = new TriBinNode<int>(5);
            trt1 = new TriBinNode<int>(null, trt2, trt1, 12);
            trt2 = new TriBinNode<int>(7);
            trt1 = new TriBinNode<int>(trt1, null, trt2, 10);
            trt2 = new TriBinNode<int>(3);
            TriBinNode<int> trt3 = new TriBinNode<int>(6);
            trt1 = new TriBinNode<int>(trt2, trt1, trt3, 8);

            Console.WriteLine("FindMaxTriTree");
            Console.WriteLine(Big(trt1));
            Console.ReadLine();
        }
    }
}
