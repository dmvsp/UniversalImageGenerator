using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIG_Console
{
    public class DemoClass
    {
        bool useConsoleOutput = false;

        int[] a;

        public int[] b;
        int b_count = 0;

        public List<string> my_b = new List<string>();

        int num = 0;
        int n, m;

        bool NextSet(int n, int m)
        { 
            int j = m - 1;
            while (j >= 0 && a[j] == n) j--;
            if (j < 0) return false;
            if (a[j] >= n)
                j--;
            a[j]++;
            if (j == m - 1) return true;
            for (int k = j + 1; k < m; k++)
                a[k] = 0;
            return true;        
        }

        void Print(int n)
        {   
          
            num++;

            Console.Write(num + ":  ");

            string s = "";

            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i]);

                s += a[i].ToString();
            }

            my_b.Add(s);

            Console.WriteLine();
        }

        public DemoClass(int _N, int _M, bool _consoleOutput = false)
        {
            useConsoleOutput = _consoleOutput;

            n = _N;
            m = _M;
            int h = n > m ? n : m; // размер массива а выбирается как max(n,m)

            b = new int[(int)Math.Pow((n+1),m)+1];
            a = new int[h];

            for (int i = 0; i < h; i++)
                a[i] = 0;
        }
        public void Processing()
        {
            Print(m);

            while (NextSet(n, m))
                Print(m);

        }


    }

    public static class Cartesian
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            // base case: 
            IEnumerable<IEnumerable<T>> result = new[] { Enumerable.Empty<T>() };
            foreach (var sequence in sequences)
            {
                var s = sequence; // don't close over the loop variable 
                                  // recursive case: use SelectMany to build the new product out of the old one 
                result =
                    from seq in result
                    from item in s
                    select seq.Concat(new[] { item });
            }
            return result;
        }
    }

}
