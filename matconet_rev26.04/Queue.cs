using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matconet_rev26._04
{
    internal class Queue<T>
    {
        private Node<T> first;

        private Node<T> last;
        //-----------------------------------
        public Queue()
        {
            this.first = null;

            this.last = null;
        }
        //-----------------------------------
        //הפעולה מחזירה אמת אם התור הנוכחי ריק אחרת מחזירה שקר
        public bool IsEmpty()
        {
            return (this.first == null);
        }
        //-----------------------------------
        //הפעולה מכניסה את הערך X לסוף התור
        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);

            if (this.first == null)

                this.first = temp;
            else

                this.last.SetNext(temp);

            this.last = temp;
        }
        //-------------------------------------
        //הפעולה מוציאה את הערך הנוכחי בראש התור ומחזירה אותו
        public T Remove()
        {
            T x = this.first.GetValue();

            first = first.GetNext();

            if (this.first == null)

                this.last = null;

            return (x);
        }
        //-------------------------------------
        //הפעולה מחזירה את ערכו של האיבר שבראש התור מבלי להוציאו
        public T Head()
        {
            return (this.first.GetValue());
        }

        //-------------------------------------
        //public void Reverse()
        //{
        //    stack<T> s = new stack<T>();

        //    Node<T> pos = this.first;

        //    while (pos != null)
        //    {
        //        s.Push(pos.GetInfo());

        //        pos = pos.GetNext();
        //    }

        //    pos = this.first;

        //    while (pos != null)
        //    {
        //        pos.SetInfo(s.Pop());

        //        pos = pos.GetNext();
        //    }


        //}
        //-------------------------------------
        //פעולה מתארת
        public override string ToString()
        {
            string st = "[";

            Node<T> pos = this.first;

            while (pos != null)
            {
                st += pos.GetValue();

                if (pos.GetNext() != null)

                    st += ",";

                pos = pos.GetNext();
            }
            st += "]";
            return (st);
        }
    }
}
