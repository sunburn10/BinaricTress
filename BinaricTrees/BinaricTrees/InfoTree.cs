using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaricTrees
{
    class InfoTree
    {
        private char ch; // תו
        private int num; // מספר החזרות של התו

        public InfoTree(char ch, int num)
        {
            this.ch = ch;
            this.num = num;
        }
        public InfoTree(InfoTree other)
        {
            this.ch = other.ch;
            this.num = other.num;
        }
        public char GetTav()
        {
            return this.ch;
        }
        public int GetNum()
        {
            return this.num;
        }
        public void SetTav(char ch)
        {
            this.ch = ch;
        }
        public void SetNum(int num)
        {
            this.num = num;
        }
        public override string ToString()
        {
            return "char : " + this.ch + "\n repeats : " + this.num + "\n";
        }
    }
}
