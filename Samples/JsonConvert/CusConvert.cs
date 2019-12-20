using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSamples.Rpn
{
    public static class CusConvert
    {
        public static Dictionary<string, object> Start(List<string> postfix)
        {
            Stack<CusTreeNode> sPostfix = new Stack<CusTreeNode>();
            foreach (var element in postfix)
            {
                if (element == ":")
                {
                    CusTreeNode rightOperand = sPostfix.Pop();
                    CusTreeNode leftOperand = sPostfix.Pop();
                    sPostfix.Push(new CusTreeNode(leftOperand.Key, rightOperand));
                }
                else if (element == ",")
                {
                    CusTreeNode rightOperand = sPostfix.Pop();
                    CusTreeNode leftOperand = sPostfix.Pop();

                    CusTreeNode.LinkSibling(leftOperand, rightOperand);
                    sPostfix.Push(leftOperand);
                }
                else
                {
                    sPostfix.Push(new CusTreeNode(element));
                }
            }

            CusTreeNode root = new CusTreeNode(null, sPostfix.Peek());

            Dictionary<string, object> dictRoot = (Dictionary<string, object>)Convert(root);
            return dictRoot;
        }

        private static object Convert(CusTreeNode item)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (var child in item.Children)
            {
                if (child.Children.Count == 0)
                {
                    return child.Key;
                }

                dict.Add(child.Key, Convert(child));
            }

            return dict;
        }
    }
}
