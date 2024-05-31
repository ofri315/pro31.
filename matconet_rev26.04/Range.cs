using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace matconet_rev26._04
{
    internal class Range
    {
        private int high;
        private int low;
        public Range(int high, int  low )
        {
            this.high = high;
            this.low = low;
        }
        public int gethigh() { return high; }
        public int getlow() { return low; }
        public void sethigh(int num1) { this.high = num1;}
        public void setlow(int num2) {  this.low = num2; }

        public override string ToString()
        {
            return "("+this.high +","+this.low +")";
        }
    }

}
