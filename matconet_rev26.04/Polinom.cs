using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace matconet_rev26._04
{
    internal class Polinom
    {
        private int num1;
        private int num2;
        public Polinom(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }
        public int getNum1() { return num1; }
        public int getNum2() { return num2; }
        public void setnum1(int num1) { this.num1 = num1;}
        public void setnum2(int num2) {  this.num2 = num2; }

        public override string ToString()
        {
            return "("+this.num1+","+this.num2+")";
        }
    }

}
