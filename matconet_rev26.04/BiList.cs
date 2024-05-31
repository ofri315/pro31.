using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matconet_rev26._04
{
    internal class BiList
    {
        private Node<int> lst1;
        private Node<int> lst2;
        public BiList()
        {
            lst1 = null;
            lst2 = null;
        }
        public void addNum(int num,int codeList)
        {
            if (codeList == 1)
                this.lst1 = new Node<int>(num, this.lst2);
            else
                this.lst2 = new Node<int>(num, this.lst2);
        }
    }
}
