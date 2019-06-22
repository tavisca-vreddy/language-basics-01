using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            string result = "0", k;
            int l1, l2, m;
            string[] a = equation.Split(new Char[] { '*', '=' });
            if (a[2].Contains("?"))
            {
                l1 = Int32.Parse(a[0]);
                l2 = Int32.Parse(a[1]);
                m = l1 * l2;
                k = m.ToString();
                if (k.Length != a[2].Length)
                    return -1;
                else
                {
                    for (int x = 0; x < k.Length; x++)
                        if (k[x] == a[2][x])
                            continue;
                        else if (a[2][x] == '?')
                            result = k[x].ToString();
                        else
                            return -1;
                }
            }
            else if (a[0].Contains("?"))
            {
                l2 = Int32.Parse(a[1]);
                m = Int32.Parse(a[2]);
                if (m % l2 != 0)
                    return -1;
                l1 = m / l2;
                k = l1.ToString();
                if (k.Length != a[0].Length)
                    return -1;
                else
                {
                    for (int x = 0; x < k.Length; x++)
                        if (k[x] == a[0][x])
                            continue;
                        else if (a[0][x] == '?')
                            result = k[x].ToString();
                        else
                            return -1;
                }


            }
            else
            {
                l1 = Int32.Parse(a[0]);
                m = Int32.Parse(a[2]);
                if (m % l1 != 0)
                    return -1;
                l2 = m / l1;
                k = l2.ToString();
                if (k.Length != a[1].Length)
                    return -1;
                else
                {
                    for (int x = 0; x < k.Length; x++)
                        if (k[x] == a[1][x])
                            continue;
                        else if (a[1][x] == '?')
                            result = k[x].ToString();
                        else
                            return -1;
                }
            }
            return Int32.Parse(result);
            //throw new NotImplementedException();
        }
    }
}
