using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSamples.Rpn
{
    public static class Operation
    {
        public static string GetSampleString()
        {
            return "{\"a\":\"123\",\"b\":\"345\",\"c\":{\"c1\":\"11\",\"c2\":\"22\",\"c3\":\"33\"},\"d\":\"4\",\"e\":{\"e1\":{\"e11\":\"1\",\"e12\":\"2\",\"e13\":\"3\"},\"e2\":\"2\",\"e3\":\"3\"},\"f\":\"345\"}";
        }

        public static List<string> ReversePolishNotation(string str)
        {
            List<string> postfix = new List<string>();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < str.Length; i++)
            {
                string op = str[i].ToString();

                switch (op)
                {
                    case "{":
                        stack.Push(op);
                        break;
                    case ":":
                    case ",":
                        while (GetPriority(stack.Peek()) >= GetPriority(op))
                        {
                            postfix.Add(stack.Pop());
                        }
                        stack.Push(op);
                        break;
                    case "}":
                        while (stack.Peek() != "{")
                        {
                            postfix.Add(stack.Pop());
                        }
                        stack.Pop();
                        break;
                    case "\"":
                        int nextIndex = str.IndexOf(op, i + 1);
                        if (nextIndex >= 0)
                        {
                            string substr = str.Substring(i + 1, nextIndex - i - 1);
                            postfix.Add(substr);

                            i = nextIndex;
                        }
                        else
                        {
                            throw new Exception();
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }

            return postfix;
        }
        private static int GetPriority(string op)
        {
            switch (op)
            {
                case ",": return 1;
                case ":": return 2;
                default: return 0;
            }
        }
    }
}
