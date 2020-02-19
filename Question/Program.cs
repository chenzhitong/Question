using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IEnumerable<int>> ret = new[] { Enumerable.Empty<int>() };
            for (int i = 0; i < 10; i++)
                ret = from a in ret from b in Enumerable.Range(1, 4) select a.Concat(new[] { b });

            Parallel.ForEach(ret, i =>
            {
                var a = i.Prepend(0).ToList();
                var test = Q2(a) && Q3(a) && Q4(a) && Q5(a) && Q6(a) && Q7(a) && Q8(a) && Q9(a) && Q10(a);
                if (test)
                {
                    a.RemoveAt(0);
                    Console.WriteLine(string.Join(',', a)
                        .Replace("1", "A")
                        .Replace("2", "B")
                        .Replace("3", "C")
                        .Replace("4", "D"));
                }
            });

            Console.WriteLine("end");
            Console.ReadLine();
        }
        static bool Q2(List<int> a)
        {
            if (a[2] == 1) return a[5] == 3;
            if (a[2] == 2) return a[5] == 4;
            if (a[2] == 3) return a[5] == 1;
            if (a[2] == 4) return a[5] == 2;
            return false;
        }

        static bool Q3(List<int> a)
        {
            if (a[3] == 1) return a[3] != a[6] && a[6] == a[2] && a[2] == a[4];
            if (a[3] == 2) return a[6] != a[3] && a[3] == a[2] && a[2] == a[4];
            if (a[3] == 3) return a[2] != a[3] && a[3] == a[6] && a[6] == a[4];
            if (a[3] == 4) return a[4] != a[3] && a[3] == a[6] && a[6] == a[2];
            return false;
        }
        static bool Q4(List<int> a)
        {
            if (a[4] == 1) return a[1] == a[5];
            if (a[4] == 2) return a[2] == a[7];
            if (a[4] == 3) return a[1] == a[9];
            if (a[4] == 4) return a[6] == a[10];
            return false;
        }
        static bool Q5(List<int> a)
        {
            if (a[5] == 1) return a[5] == a[8];
            if (a[5] == 2) return a[5] == a[4];
            if (a[5] == 3) return a[5] == a[9];
            if (a[5] == 4) return a[5] == a[7];
            return false;
        }
        static bool Q6(List<int> a)
        {
            if (a[6] == 1) return a[8] == a[2] && a[8] == a[4];
            if (a[6] == 2) return a[8] == a[1] && a[8] == a[6];
            if (a[6] == 3) return a[8] == a[3] && a[8] == a[10];
            if (a[6] == 4) return a[8] == a[5] && a[8] == a[9];
            return false;
        }
        static bool Q7(List<int> a)
        {
            var min = a.GroupBy(p => p).OrderBy(p => p.Count()).Skip(1).First().Key;

            if (a[7] == 1) return min == 3;
            if (a[7] == 2) return min == 2;
            if (a[7] == 3) return min == 1;
            if (a[7] == 4) return min == 4;
            return false;
        }
        static bool Q8(List<int> a)
        {
            if (a[8] == 1) return Math.Abs(a[1] - a[7]) > 1;
            if (a[8] == 2) return Math.Abs(a[1] - a[5]) > 1;
            if (a[8] == 3) return Math.Abs(a[1] - a[2]) > 1;
            if (a[8] == 4) return Math.Abs(a[1] - a[10]) > 1;
            return false;
        }
        static bool Q9(List<int> a)
        {
            var result = a[1] == a[6];
            if (a[9] == 1) return (a[6] == a[5]) != result;
            if (a[9] == 2) return (a[10] == a[5]) != result;
            if (a[9] == 2) return (a[2] == a[5]) != result;
            if (a[9] == 3) return (a[9] == a[5]) != result;
            return false;
        }
        static bool Q10(List<int> a)
        {
            var min = a.GroupBy(p => p).OrderBy(p => p.Count()).Skip(1).First().Key;
            var max = a.GroupBy(p => p).OrderByDescending(p => p.Count()).First().Key;
            var minCount = a.Count(p => p == min);
            var maxCount = a.Count(p => p == max);

            if (a[10] == 1) return maxCount - minCount == 3;
            if (a[10] == 2) return maxCount - minCount == 2;
            if (a[10] == 3) return maxCount - minCount == 4;
            if (a[10] == 4) return maxCount - minCount == 1;
            return false;
        }
    }


}
