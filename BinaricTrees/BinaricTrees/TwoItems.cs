using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaricTrees
{
    class TwoItems
    {
        private int num1;
        private int num2;

        public TwoItems(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }
        public TwoItems(TwoItems other)
        {
            this.num1 = other.num1;
            this.num2 = other.num2;
        }
        public int GetNum1()
        {
            return this.num1;
        }
        public int GetNum2()
        {
            return this.num2;
        }
        public void SetNum1(int num1)
        {
            this.num1 = num1;
        }
        public void SetNum2(int num2)
        {
            this.num2 = num2;
        }
        public override string ToString()
        {
            return "num1 : " + this.num1 + " num2: " + this.num2+"\n";
        }
    }
}
