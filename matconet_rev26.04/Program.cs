using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace matconet_rev26._04
{
    internal class Program
    {
        //הפעולה מדפיסה את האיברי הרשימה
        public static void printlist<T>(Node<T> lst)
        {
            Node<T> pos = lst;
            while (pos != null) //אחרי האחרון
            {
                Console.Write(pos.GetValue() + " --> ");
                pos = pos.GetNext();
            }
            Console.WriteLine();
        }
        //הפעולה מקבלת רשימה ומחזירה את כמות האיברים בה
        public static int countlist(Node<int> lst)
        {
            Node<int> pos = lst;
            int count = 0;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }

        //הפעולה מקבלת רשימה ומחזירה את סכום כל האיברים
        public static int sumlist(Node<int> lst)
        {
            Node<int> pos = lst;
            int sum = 0;
            while (pos != null)
            {
                sum += pos.GetValue();
                pos = pos.GetNext();
            }
            return sum;
        }
        //הפעולה מקבלת רשימה ומספר ובדוקת האם המספר נמצא ברשימה
        public static bool IsExist(Node<int> lst, int num)
        {
            Node<int> pos = lst;
            while (pos != null)
            {
                if (num == pos.GetValue())
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }

        public static bool IsPrefix(Node<int> lst1, Node<int> lst2)
        {
            Node<int> pos1 = lst1;
            Node<int> pos2 = lst2;
            while (pos1 != null)
            {
                if (pos2.GetValue() != pos1.GetValue())
                {
                    return false;
                }
                pos1 = pos1.GetNext();
                pos2 = pos2.GetNext();
            }
            return true;
        }
        public static bool IsSubChain(Node<int> lst1, Node<int> lst2)
        {
            Node<int> pos1 = lst1;
            Node<int> pos2 = lst2;
            while (pos2 != null)
            {
                if (IsPrefix(pos1, pos2))
                    return true;
                pos2 = pos2.GetNext();
            }
            return false;
        }
        //בגרות 2021א
        public static int[] Filter(int[] arr, int num)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != num)
                    count++;
            }
            int[] arrn = new int[count];
            int x = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != num)
                    arrn[x++] = arr[i];
            }
            return arrn;
        }
        public static void printarr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public static Node<int> reverselist(Node<int> lst)
        {
            Node<int> lstnew = null;
            Node<int> pos = lst;
            while (pos != null)
            {
                lstnew = new Node<int>(pos.GetValue(), lstnew);
                pos = pos.GetNext();
            }
            return lstnew;
        }
        public static Node<int> Move(Node<int> lst, int n)
        {
            Node<int> pos = lst;
            int count = countlist(lst);
            for (int i = 0; i < count - n; i++)
            {
                pos = pos.GetNext();
            }
            Node<int> lstn = pos;
            Node<int> temp = null;
            while (pos != null)
            {
                temp = new Node<int>(pos.GetValue(), temp);
                pos = pos.GetNext();
            }

            while (temp != null)
            {
                lst = new Node<int>(temp.GetValue(), lst);
                temp = temp.GetNext();
            }
            pos = lst;
            for (int i = 0; i < count - 1; i++)
            {
                pos = pos.GetNext();
            }
            pos.SetNext(null);

            return lst;
        }
        public static int maxlist(Node<int> lst)
        {
            Node<int> pos = lst;
            int max = 0;
            while (pos != null)
            {
                if (pos.GetValue() > max)
                    max = pos.GetValue();
                pos = pos.GetNext();
            }
            return max;
        }
        //public static BiList generatebilist(Node<int> lst)
        //{
        //    int count = countlist(lst);
        //    Node<int> pos = lst;
        //    BiList bi= new BiList();
        //    while(countlist(pos)==count/2)
        //    {
        //        int max = maxlist(pos);
        //        bi.addNum(max,1);
        //        pos = Delete(max); //פעולה שנתון כי אפשר להשתמש בה

        //    }
        //    while(pos!=null)
        //    {
        //        bi.addNum(pos.GetValue(), 2);
        //        pos = pos.GetNext();
        //    }
        //    return bi;  
        //}
        //העתק של התור
        public static Queue<T> copyqueue<T>(Queue<T> q)
        {
            Queue<T> copytemp = new Queue<T>();
            while (!q.IsEmpty())
            {
                copytemp.Insert(q.Remove());
            }
            Queue<T> copyn = new Queue<T>();
            while (!copytemp.IsEmpty())
            {
                copyn.Insert(copytemp.Head());
                q.Insert(copytemp.Remove());
            }
            return copyn;
        }
        //פעולה שמקבלת תור ומספר ומחזירה כמה פעמים המספר מופיע
        public static int count(Queue<int> q)
        {
            Queue<int> qtemp = copyqueue(q);
            int count = 0;
            while (!qtemp.IsEmpty())
            {
                count++;
                qtemp.Remove();
            }
            return count;
        }
        public static bool IsIdentical(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> copy1 = copyqueue(q1);
            Queue<int> copy2 = copyqueue(q2);
            if (count(q1) != count(q2))
                return false;
            while (!copy1.IsEmpty())
            {
                if (copy1.Remove() != copy2.Remove())
                    return false;
            }
            return true;
        }
        public static bool IsSimilar(Queue<int> q1, Queue<int> q2)
        {
            int count1 = count(q1);
            int x = 0;
            while (x < count1)
            {
                if (IsIdentical(q1, q2))
                    return true;
                int num = q1.Remove();
                q1.Insert(num);
                x++;
            }
            return false;
        }
        //בגרות 2020
        public static Node<int> bulidDigit(Node<int> lst)
        {
            Node<int> pos = lst;
            Node<int> lstn = null;
            while (pos != null)
            {
                int num = 0;
                while (pos.GetValue() != -9)
                {
                    num = num * 10 + pos.GetValue();
                    pos = pos.GetNext();
                }
                pos = pos.GetNext();
                lstn = new Node<int>(num, lstn);
            }
            return lstn;

        }
        public static Node<int> breakDigit(Node<int> lst)
        {
            Node<int> pos = lst;
            Node<int> lstn = null;
            while (pos != null)
            {
                int num = pos.GetValue();
                while (num != 0)
                {
                    int dig = num % 10;
                    lstn = new Node<int>(dig, lstn);
                    num = num / 10;
                }
                lstn = new Node<int>(-9, lstn);
                pos = pos.GetNext();
            }
            return reverselist(lstn);
        }
        public static int ex38page96(Node<int> lst1, Node<int> lst2)
        {
            Node<int> pos1 = lst1;
            Node<int> pos2 = lst2;
            while (pos1 != null && pos2 != null)
            {
                if (pos1.GetValue() == pos2.GetValue())
                    return pos1.GetValue();
                else
                {
                    if (pos1.GetValue() < pos2.GetValue())
                    {
                        pos1 = pos1.GetNext();
                    }
                    else
                    {
                        pos2 = pos2.GetNext();
                    }
                }
            }
            return -999;

        }
        public static int maxqueue(Queue<int> q)
        {//הפעולה מקבלת תור ומחזירה את הערך המקסימלי
            Queue<int> qtemp = copyqueue(q);
            int max = qtemp.Head();
            while (!qtemp.IsEmpty())
            {
                int mis = qtemp.Remove();
                if (mis > max)
                {
                    max = mis;
                }
            }
            return max;
        }
        public static void maxfirst(Queue<int> q)
        {
            int max = maxqueue(q);
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                if (q.Head() != max)
                {
                    temp.Insert(q.Head());
                }
                q.Remove();
            }
            q.Insert(max);
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }
        public static Node<int> ex5page152(Queue<int> q)
        {
            Queue<int> copy = copyqueue(q);
            Node<int> lstn = null;
            while (!copy.IsEmpty())
            {
                maxfirst(copy);
                int num = copy.Remove();
                lstn = new Node<int>(num, lstn);

            }
            return lstn;
        }
        //public static void ex12bpage155(Queue<Queue<int>> q)
        //{
        //    Queue<Queue<int>> copy = copyqueue(q);
        //    while (!q.IsEmpty())
        //    {
        //        Queue<int> temp = new Queue<int>();
        //        while(!copy.IsEmpty())
        //        {

        //        }

        //    }
        //}
        //תרגול מחרוזות
        public static bool IsPolindrom(string st)
        {
            for (int i = 0; i <= st.Length / 2; i++)
            {
                if (st[i] != st[st.Length - 1 - i])
                    return false;
            }
            return true;
        }
        public static bool IsDouble(string st)
        {
            if (st.Length % 2 == 1) return false;
            return st.Substring(0, st.Length / 2).Equals(st.Substring(st.Length / 2));
        }
        public static string Noextraspace(string st)
        {
            string stn = "";
            for (int i = st.Length - 1; i > 0; i--)
            {
                if (st[i] == ' ' && st[i - 1] == ' ')
                {

                    st = st.Remove(i, 1);
                }
            }
            return st;
        }
        public static void MoveForward(Queue<int> q, int num)
        {
            Queue<int> copy = copyqueue(q);
            Queue<int> qn = new Queue<int>();
            int count = 0;
            while (!copy.IsEmpty() && copy.Remove() != num)
            {
                count++;

            }
            if (count != 0)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    qn.Insert(q.Remove());
                }
                int num1 = q.Remove();
                int num2 = q.Remove();
                qn.Insert(num2);
                qn.Insert(num1);
                while (!q.IsEmpty())
                {
                    qn.Insert(q.Remove());
                }
                while (!qn.IsEmpty())
                {
                    q.Insert(qn.Remove());
                }
            }

        }
        public static int countExist(Queue<int> q, int num)
        {
            Queue<int> qtemp = copyqueue(q);
            int count = 0;
            while (!qtemp.IsEmpty())
            {
                int mis = qtemp.Remove();
                if (mis == num)
                {
                    count++;
                }
            }

            return count;
        }
        public static bool Is1n(Queue<int> q)
        {
            int x = 1;
            Queue<int> copy = copyqueue(q);
            while (!copy.IsEmpty())
            {
                int num = copy.Remove();

                int count = countExist(q, num);
                if (count != 1)
                {
                    return false;
                }
                x++;
            }
            copy = copyqueue(q);
            for (int i = 1; i < x; i++)
            {
                if (countExist(copy, i) != 1)
                    return false;
            }
            return true;
        }
        public static void Reverse(Queue<int> q)
        {
            if (q.IsEmpty())
                return;
            int tempnum = q.Remove();
            Reverse(q);
            q.Insert(tempnum);
        }
        public static bool IsPolindrom(Queue<int> q)
        {
            Queue<int> copy = copyqueue(q);
            int count1 = count(q);
            Queue<int> stemp = new Queue<int>();
            for (int i = 0; i < count1 / 2; i++)
            {
                stemp.Insert(copy.Remove());
            }
            if (count1 % 2 == 0)
            {
                Reverse(stemp);
                while (!stemp.IsEmpty())
                {
                    if (stemp.Remove() != copy.Remove())
                        return false;
                }
                return true;
            }
            stemp.Insert(copy.Head());
            Reverse(stemp);
            while (!stemp.IsEmpty())
            {
                if (stemp.Remove() != copy.Remove())
                    return false;
            }
            return true;

        }
        public static bool IsInq(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> copy1 = copyqueue(q1);
            Queue<int> copy2 = copyqueue(q2);
            int c = 0;
            while (!copy1.IsEmpty())
            {
                while (!copy2.IsEmpty() && copy1.Remove() == copy2.Remove())
                {
                    c++;
                }
                if (c == count(q2))
                    return true;
                else
                {
                    c = 0;
                    copy2 = copyqueue(q2);
                }

            }
            return false;
        }
        public static int ToNumber(Queue<int> q)
        {
            Queue<int> copy = copyqueue(q);
            int num = 0;
            while (!copy.IsEmpty())
            {
                num = num * 10 + copy.Remove();
            }
            return num;
        }
        public static int BiggestNum(Node<Queue<int>> lst)
        {
            Node<Queue<int>> pos = lst;
            int max = 0;
            while (pos != null)
            {
                int num = ToNumber(pos.GetValue());
                if (num > max)
                {
                    max = num;
                }
                pos = pos.GetNext();
            }
            return max;
        }
        // מבחן לדוגמה
        //שאלה 4
        public static Queue<Node<int>> Wide(Queue<int>[] arr)
        {
            Queue<Node<int>> q = new Queue<Node<int>>();
            bool b = false;
            while (!b)
            {
                Node<int> lst = null;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!arr[i].IsEmpty())
                    {
                        lst = new Node<int>(arr[i].Remove(), lst);
                    }
                    if (arr[0].IsEmpty())
                        b = true;
                    if (arr[i].IsEmpty() && b)
                        b = true;
                    else
                        b = false;
                }
                q.Insert(lst);
            }
            return q;

        }
        public static int biggerNum(Node<int> lst, int num)
        {
            Node<int> pos = lst;
            int count = 0;
            while (pos != null)
            {
                if (pos.GetValue() > num)
                    count++;
                pos = pos.GetNext();
            }
            return count;
        }
        public static bool CheckList(Node<int> lst)
        {
            Node<int> pos = lst;
            int count = countlist(lst);
            for (int i = 0; i < count - 3; i++)
            {
                if (countlist(pos) - biggerNum(pos, pos.GetValue()) <= 3)
                    return false;
                pos = pos.GetNext();
            }
            while (pos != null)
            {
                if (biggerNum(pos, pos.GetValue()) != 0)
                    return false;
                pos = pos.GetNext();
            }
            return true;
        }
        public static bool IsThree(Node<int> lst)
        {
            Node<int> pos = lst;
            int count = countlist(lst);
            if (count == 0 || count % 3 != 0)
                return false;
            Node<int> lst1 = null;
            for (int i = 0; i < count / 3; i++)
            {
                lst1 = new Node<int>(pos.GetValue(), lst1);
                pos = pos.GetNext();
            }
            Node<int> lst2 = null;
            for (int i = 0; i < count / 3; i++)
            {
                lst2 = new Node<int>(pos.GetValue(), lst2);
                pos = pos.GetNext();
            }
            while (pos != null)
            {
                if (IsExist(lst1, pos.GetValue()) || IsExist(lst2, pos.GetValue()))
                    return false;
            }
            return true;

        }
        public static int lastOddValue(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] % 2 == 1)
                    return arr[i];
            }
            return -1;
        }
        public static bool IsPerfect(int[] arr)
        {
            bool b = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    b = true;
            }
            if (!b) return false;
            int x = 0;
            int count = 1;

            while (arr[x] != 0 && count <= arr.Length)
            {

                x = arr[x];
                count++;
            }
            return count == arr.Length;

        }
        public static bool IsIncluded(Node<int> lst1, Node<Range> lst2)
        {
            Node<int> pos1 = lst1;
            Node<Range> pos2 = lst2;
            bool b = false;
            while (pos2 != null || pos1 != null)
            {
                if (pos1.GetValue() >= pos2.GetValue().getlow() && pos1.GetValue() <= pos2.GetValue().gethigh())
                {
                    pos1 = pos1.GetNext();
                    b = true;

                }
                else
                {
                    pos2 = pos2.GetNext();
                    b = false;
                }

            }
            return b;
        }
        //שאלות במערכים
        //בגרות 2023
        //מערך הפרשים הוא מערך מטיפוס שלם שבו ההפרש בין המספרים בכל שני תאים סמוכים הוא קבוע 
        public static int MissingNum(int[] arr)
        {
            int d = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i + 1] - arr[i] == arr[i + 2] - arr[i + 1])
                    d = arr[i + 1] - arr[i];
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i + 1] - arr[i] != d)
                    return arr[i] + d;
            }
            return 0;
        }
        public static int[] multiply(int[] arr1, int[] arr2)
        {
            int[] k;
            int[] m;
            if (arr1.Length > arr2.Length)
            {
                k = arr2;
                m = arr1;
            }
            else
            {
                k = arr1;
                m = arr2;
            }
            int[] arrn = new int[m.Length];
            int i = 0;
            for (i = 0; i < k.Length; i++)
            {
                arrn[i] = k[i] * m[i];
            }
            for (int j = i; j < m.Length; j++)
            {
                arrn[j] = m[j];
            }
            return arrn;
        }
        //הפעולה מחזירה אמת האם המערך ממוין בחיוביים אחרת תחזיר שקר
        public static bool PosOrder(int[] arr)
        {
            int num = 0;
            int x = 0;
            while (arr[x++] < 0) ;
            num = arr[x];
            for (int i = x; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                    if (arr[i] < num)
                        return false;
            }
            return true;
        }
        //בגרות 2020ב
        //איבר במערך יקרא שוויוני אם סכום האיברים במערך מצד ימין שלו שווה לסכום האיברים במערך מצד שמאל שלו
        //הפעולה מקבלת מערך ואינדקס הפעולה תחזיר אמת אם האיבר הוא שוויוני
        public static bool IsEqual(int[] arr, int index)
        {
            int sumb = 0;
            int suma = 0;
            for (int i = 0; i < index; i++)
            {
                suma += arr[i];
            }
            for (int i = index + 1; i < arr.Length; i++)
            {
                sumb += arr[i];
            }
            return sumb == suma;
        }
        //הפעולה מחזירה אמת אם במערך איבר שויוני אחד לפחות
        public static bool arrEqual(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsEqual(arr, i))
                    return true;
                    
            }
            return false;
        }
        //בגרות 2020
        public static int Above(int[] arr, int num)
        {
            int sum = 0;
            for (int i = 0; i <arr.Length; i++)
            {
                sum += arr[i];
                if (sum > num)
                    return i;
            }
            return -1;
        }
        //הפעולה מחזירה את הערך של המספר האי זוגי האחרון במערך
        public static int lastoddval(int[] arr)
        {
            for (int i = arr.Length-1; i >= 0; i--)
            {
                if (arr[i] % 2 == 1)
                    return arr[i];
            }
            return -1;
        }
        //הפעולה מחזירה אמת אם המחרוזת היא מחרוזת כפולה
        public static bool isDouble(string st)
        {
            string st1 = st.Substring(0, st.Length / 2);
            string st2 = st.Substring(st.Length / 2);
            return st1.Equals(st2); 
        }
        static void Main(string[] args)
        {
            //Node<int> lst1 = new Node<int>(9);
            //lst1 = new Node<int>(15, lst1);
            //lst1 = new Node<int>(7, lst1);
            //lst1= new Node<int>(4, lst1);
            //lst1 = new Node<int>(-4, lst1);
            //lst1 = new Node<int>(3, lst1);
            //printlist(lst1);
            //Console.WriteLine(IsArranged(lst1));
            ////סיבוכיות זמן הריצה:
            ////אורך הקלט מיוצג ע"יn
            ////n הוא כמות האיברים בשרשרת החוליות
            ////בחלק הראשון של היא בודקת כמה איברים קיימים בה ומשתשמת בלולאות while לכן סיבוכיותה היא n 
            ////לאחר מכן הפעולה עוברת על חצי מהרשימה n/2 ומוצאת מקסימום לכן יש n\2 פעולות
            ////ולבסוף עוברת על החלק השני של הרשימה כדי לבדוק אם קיים מספר קטן מהמקס בחלק השאשון וגם כאם יש n/2 פעולות
            //// שאר ההוראות בפעולה הם בסיבוכיות קבועה o(1)
            ////לכן סיבוכיות הפעולה o(n)

            //Node<int> lst2=new Node<int>(7);
            //lst2 = new Node<int>(4, lst2);
            //lst2 = new Node<int>(2, lst2);
            //lst2 = new Node<int>(3, lst2);
            //printlist(lst2);

            //Node<int> lst3 = new Node<int>(7);
            //lst3 = new Node<int>(4, lst3);
            //lst3 = new Node<int>(2, lst3);
            //lst3 = new Node<int>(3, lst3);
            //lst3 = new Node<int>(3, lst3);
            //lst3 = new Node<int>(2, lst3);
            //printlist(lst3);
            //Console.WriteLine(IsPrefix(lst2,lst3));

            //Console.WriteLine(IsSubChain(lst2,lst3));

            //int[] arr = { 6, 9, 2, 2, 9, 4, -3 };
            //int[] arrn = Filter(arr, 9);
            //printarr(arrn);


            //Node<int> lst4 = new Node<int>(4);
            //lst4 = new Node<int>(8, lst4);
            //lst4 = new Node<int>(2, lst4);
            //lst4 = new Node<int>(1, lst4);
            //lst4 = new Node<int>(5, lst4);
            //printlist(lst4);
            //printlist(Move(lst4, 2));


            //Queue<int> q1 = new Queue<int>();
            //q1.Insert(4);
            //q1.Insert(6);
            //q1.Insert(5);
            //q1.Insert(7);

            //Queue<int> q2 = new Queue<int>();
            //q2.Insert(5);
            //q2.Insert(6);
            //q2.Insert(7);
            //q2.Insert(4);


            //Console.WriteLine(IsSimilar(q1, q2));

            //Node<int> lst = new Node<int>(5);
            //lst = new Node<int>(3, lst);
            //lst = new Node<int>(2, lst);
            //lst = new Node<int>(1, lst);
            //Node<int> lst1 = new Node<int>(7);
            //lst1 = new Node<int>(6, lst1);
            //lst1 = new Node<int>(5, lst1);
            //lst1 = new Node<int>(4, lst1);
            //Console.WriteLine(ex38page96(lst, lst1));

            //Queue<int> q = new Queue<int>();
            //q.Insert(15);
            //q.Insert(8);
            //q.Insert(30);
            //q.Insert(2);
            //q.Insert(18);
            //q.Insert(20);

            //printlist(ex5page152(q));

            //Console.WriteLine(IsDouble("@"));
            //Console.WriteLine(Noextraspace("hello      world!"));

            Queue<int> q = new Queue<int>();
            q.Insert(1);
            q.Insert(2);
            q.Insert(3);
            q.Insert(3);
            q.Insert(2);
            q.Insert(5);

            //Console.WriteLine(q);
            //MoveForward(q,5);
            //Console.WriteLine(q);
            //Console.WriteLine(Is1n(q));
            //Console.WriteLine(IsPolindrom(q));

            Queue<int> q1 = new Queue<int>();
            q1.Insert(2);
            q1.Insert(3);
            q1.Insert(3);

            Queue<int> q2 = new Queue<int>();
            q2.Insert(1);
            q2.Insert(2);
            q2.Insert(3);
            q2.Insert(4);

            //Console.WriteLine(IsInq(q,q1));
            //Console.WriteLine(ToNumber(q1));

            //Node<Queue<int>> lst = new Node<Queue<int>>(q);
            //lst = new Node<Queue<int>>(q1, lst);
            //Console.WriteLine(BiggestNum(lst));

            Node<int> lst = new Node<int>(1);
            lst = new Node<int>(2,lst);
            lst = new Node<int>(3,lst);
            lst = new Node<int>(25,lst);
            lst = new Node<int>(6,lst);
            lst = new Node<int>(30,lst);
            lst = new Node<int>(29,lst);
            lst = new Node<int>(14,lst);
            lst = new Node<int>(129,lst);

            //Console.WriteLine(biggerNum(lst,14));
            //Console.WriteLine(CheckList(lst));

            int[] arr = {1, -4, 4,9,2 };
            //Console.WriteLine(IsPerfect(arr));

            int[] arr1 = { 9,2,0,-1,3,11,23};
            //Console.WriteLine(MissingNum(arr1));

            printarr(multiply(arr1, arr));
            int[] arr2 = { 5, 9, -3, 17, 0, 29, -20, -40, 29 };
            Console.WriteLine(PosOrder(arr2));

            int[] arr3 = {6,-3,4,2,0,-6,3 };
            Console.WriteLine(arrEqual(arr3));

            int[] arr4 = { 1, 2, -2, 7, 2, 2 };
            Console.WriteLine(Above(arr4,11));

            Console.WriteLine(lastoddval(arr4));

            Console.WriteLine(isDouble("ab#ab"));
            string st = "1245";
            Console.WriteLine(st[st.Length/2]);

        }
    }
}