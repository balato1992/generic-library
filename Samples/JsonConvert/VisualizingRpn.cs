using System;
using System.Collections.Generic;
using System.Drawing;

namespace TestSamples.Rpn
{
    public static class VisualizingRpn
    {
        public static void SaveBmp(string path, List<string> postfix)
        {
            var stack = new Stack<VisualizingNode>();
            foreach (string element in postfix)
            {
                if (IsOperator(element))
                {
                    VisualizingNode rightOperand = stack.Pop();
                    VisualizingNode leftOperand = stack.Pop();
                    stack.Push(new VisualizingNode(element, leftOperand, rightOperand));
                }
                else
                {
                    stack.Push(new VisualizingNode(element));
                }
            }
            stack.Pop().ToBitmap().Save(path);
        }

        private static bool IsOperator(string s)
        {
            switch (s)
            {
                case ",":
                case ":":
                    return true;

                default:
                    return false;
            }
        }

    }

}
