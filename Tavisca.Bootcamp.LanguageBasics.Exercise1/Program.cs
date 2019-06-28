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
            int operandone, operandtwo, m;
            string[] a = equation.Split(new Char[] { '*', '=' });
            if (a[2].Contains("?"))
            {
                operandone = Int32.Parse(a[0]);
                operandtwo = Int32.Parse(a[1]);
                m = operandone * operandtwo;
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
                operandtwo = Int32.Parse(a[1]);
                m = Int32.Parse(a[2]);
                if (m % operandtwo != 0)
                    return -1;
                operandone = m / operandtwo;
                k = operandone.ToString();
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
                operandone = Int32.Parse(a[0]);
                m = Int32.Parse(a[2]);
                if (m % operandone != 0)
                    return -1;
                operandtwo = m / operandone;
                k = operandtwo.ToString();
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
