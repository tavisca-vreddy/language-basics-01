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
            int result = -1;
            string temp;
            int operandone, operandtwo, operandthree;
            string[] operands = equation.Split(new Char[] { '*', '=' });
            if (operands[2].Contains("?"))
            {
                operandone = Int32.Parse(operands[0]);
                operandtwo = Int32.Parse(operands[1]);
                operandthree = operandone * operandtwo;
                temp = operandthree.ToString();
                if (temp.Length != operands[2].Length)
                    return -1;
                else
                {
                    result = FindMissingDigit(temp, operands[2]);

                }
            }
            else if (operands[0].Contains("?"))
            {
                result = GetLeftSideOperandDigit(operands[0], operands[1], operands[2]);
            }
            else
            {
                result = GetLeftSideOperandDigit(operands[1], operands[0], operands[2]);

            }
            return result; ;
            //throw new NotImplementedException();
        }
        
        private static int GetLeftSideOperandDigit(string operandOne, string operandTwo, string operandThree)
        {
            double dividendOperand = int.Parse(operandThree);
            double divisorOperand = int.Parse(operandTwo);
            double quotientOperand = dividendOperand / divisorOperand;
            string temp = quotientOperand.ToString();
            int result = -1;
            if (dividendOperand % divisorOperand != 0 || temp.Length != operandOne.Length)
                return result;
            else

                result = FindMissingDigit(temp, operandOne);


            return result;

        }
        private static int FindMissingDigit(string calculatedString, string givenString)
        {
            int result = -1;
            for (int x = 0; x < calculatedString.Length; x++)
                if (calculatedString[x] == givenString[x])
                    continue;
                else if (givenString[x] == '?')
                    result = (int)(calculatedString[x] - 48);//converting char to int
                else
                    return -1;
            return result;
        }
    }
}
